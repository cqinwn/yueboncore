using NPOI.XWPF.UserModel;
using System.Reflection;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Options;
using Yuebon.Core.DataManager;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Yuebon.Commons.CodeGenerator;

/// <summary>
/// 代码生成器。
/// <remarks>
/// 根据指定的实体域名空间生成Repositories和Services层的基础代码文件。
/// </remarks>
/// </summary>
public class CodeGenerator
{

    /// <summary>
    /// 代码生成器配置
    /// </summary>
    private static readonly CodeGenerateOption _option = new CodeGenerateOption();
    /// <summary>
    /// InputDto输入实体是不包含字段
    /// </summary>
    private static string inputDtoNoField = "DeleteMark,CreatorTime,CreatorUserId,CompanyId,DeptId,LastModifyTime,LastModifyUserId,DeleteTime,DeleteUserId,";
    /// <summary>
    /// 静态构造函数：从IoC容器读取配置参数，如果读取失败则会抛出ArgumentNullException异常
    /// </summary>
    static CodeGenerator()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static SqlSugarClient GetDB()
    {
        YuebonCacheHelper yuebonCacheHelper = new();

        object connCode = yuebonCacheHelper.Get("CodeGeneratorDbConn");
        ConnectionConfig config = new ConnectionConfig();
        if (connCode != null)
        {
            string dbTypeCache = yuebonCacheHelper.Get("CodeGeneratorDbType").ToString();
            config = new()
            {
                ConfigId = "codedb",
                ConnectionString = connCode.ToString(),
                DbType = (DbType)dbTypeCache.ToInt(),
                IsAutoCloseConnection = true
            };
            return new SqlSugarClient(config);
        }
        else
        {
            List<DbConnections> allDbs = DBServerProvider.GetAllDbConnections();
            bool conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt").ToBool();
            allDbs.ForEach(m =>
            {
                config = new ConnectionConfig()
                {
                    ConfigId = m.ConnId.ToLower(),
                    ConnectionString = conStringEncrypt ? DEncrypt.Decrypt(m.MasterDB.ConnectionString) : m.MasterDB.ConnectionString,
                    DbType = (DbType)m.MasterDB.DatabaseType,
                    IsAutoCloseConnection = true,
                };
            });

            return new SqlSugarClient(config);
        }
    }

    /// <summary>
    /// 代码生成器入口方法
    /// </summary>
    /// <param name="baseNamespace">项目命名空间</param>
    /// <param name="tableList">要生成代码的表</param>
    /// <param name="replaceTableNameStr">要删除表名称的字符</param>
    /// <param name="ifExsitedCovered">是否替换现有文件，为true时替换</param>
    public static void Generate(string baseNamespace, string tableList, string replaceTableNameStr, bool ifExsitedCovered = false)
    {
        _option.DtosNamespace = baseNamespace + ".Dtos";
        _option.ModelsNamespace = baseNamespace + ".Models";
        _option.IRepositoriesNamespace = baseNamespace + ".IRepositories";
        _option.RepositoriesNamespace = baseNamespace + ".Repositories";
        _option.IServicsNamespace = baseNamespace + ".IServices";
        _option.ServicesNamespace = baseNamespace + ".Services";
        _option.ApiControllerNamespace = baseNamespace + "Api";
        _option.ReplaceTableNameStr = replaceTableNameStr;
        _option.TableList = tableList;
        _option.BaseNamespace = baseNamespace;


        List<DbTableInfo> listTable = GetDB().DbMaintenance.GetTableInfoList().FindAll(o => SqlFunc.ContainsArrayUseSqlParameters(_option.TableList.Split(","), o.Name));
        string profileContent = string.Empty;
        foreach (DbTableInfo dbTableInfo in listTable)
        {
            List<DbColumnInfo> listField = GetDB().DbMaintenance.GetColumnInfosByTableName(dbTableInfo.Name);
            GenerateSingle(listField, dbTableInfo, ifExsitedCovered);
            string tableName = dbTableInfo.Name;
            if (!string.IsNullOrEmpty(_option.ReplaceTableNameStr))
            {
                string[] rel = _option.ReplaceTableNameStr.Split(';');
                for (int i = 0; i < rel.Length; i++)
                {
                    if (!string.IsNullOrEmpty(rel[i].ToString()))
                    {
                        tableName = tableName.Replace(rel[i].ToString(), "");
                    }
                }
            }
            string[] tableNameTempArry = tableName.Split("_");
            string tableNameClass = string.Empty;
            foreach (string tableNameTemp in tableNameTempArry)
            {
                tableNameClass += tableNameTemp.Substring(0, 1).ToUpper() + tableNameTemp.Substring(1);
            }
            profileContent += string.Format("           CreateMap<{0}, {0}OutputDto>();\n", tableNameClass);
            profileContent += string.Format("           CreateMap<{0}InputDto, {0}>();\n", tableNameClass);
        }

        GenerateDtoProfile(_option.ModelsNamespace, profileContent, ifExsitedCovered);
    }

    /// <summary>
    /// 单表生成代码
    /// </summary>
    /// <param name="listField">表字段集合</param>
    /// <param name="tableInfo">表信息</param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    public static void GenerateSingle(List<DbColumnInfo> listField, DbTableInfo tableInfo, bool ifExsitedCovered = false)
    {
        var modelsNamespace = _option.ModelsNamespace;
        var tableName = tableInfo.Name;//表名
        var modelTypeDesc = tableInfo.Description;//表描述
        if (!string.IsNullOrEmpty(_option.ReplaceTableNameStr))
        {
            string[] rel = _option.ReplaceTableNameStr.Split(';');
            for (int i = 0; i < rel.Length; i++)
            {
                if (!string.IsNullOrEmpty(rel[i].ToString()))
                {
                    tableName = tableName.Replace(rel[i].ToString(), "");
                }
            }
        }
        string[] tableNameTempArry = tableName.Split("_");
        string modleNameClass = string.Empty;
        foreach (string tableNameTemp in tableNameTempArry)
        {
            modleNameClass += tableNameTemp.Substring(0, 1).ToUpper() + tableNameTemp.Substring(1);
        }
        string keyTypeName = "string";//主键数据类型
        string modelcontent = "";//数据库模型字段
        string InputDtocontent = "";//输入模型
        string outputDtocontent = "";//输出模型
        string vueViewListContent = string.Empty;//Vue列表输出内容
        string vueViewFromContent = string.Empty;//Vue表单输出内容 
        string vueViewEditFromContent = string.Empty;//Vue变量输出内容
        string vueViewEditFromBindContent = string.Empty;//Vue显示初始化输出内容
        string vueViewSaveBindContent = string.Empty;//Vue保存时输出内容
        string vueViewEditFromRuleContent = string.Empty;//Vue数据校验

        foreach (DbColumnInfo dbFieldInfo in listField)
        {
            string fieldName = dbFieldInfo.DbColumnName.Substring(0, 1).ToUpper() + dbFieldInfo.DbColumnName.Substring(1);
            string strDataType = SqlType2CsharpTypeStr(dbFieldInfo.DataType, dbFieldInfo.IsNullable);
            //主键
            if (dbFieldInfo.IsPrimarykey)
            {
                keyTypeName = strDataType;
                outputDtocontent += "        /// <summary>\n";
                outputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.ColumnDescription);
                outputDtocontent += "        /// </summary>\n";
                if (strDataType.ToLower() == "string")
                {
                    outputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.Length);
                }
                outputDtocontent += string.Format("        public {0} {1}", strDataType, fieldName);
                outputDtocontent += " { get; set; }\n\r";
            }
            else //非主键
            {
                modelcontent += "        /// <summary>\n";
                modelcontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.ColumnDescription);
                modelcontent += "        /// </summary>\n";
                if (strDataType.ToLower().Contains("string"))
                {
                    modelcontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.Length);
                }
                modelcontent += string.Format("        [SugarColumn(ColumnDescription=\"{0}\")]\n", dbFieldInfo.ColumnDescription);
                modelcontent += string.Format("        public {0}{1} {2}", strDataType, dbFieldInfo.IsNullable ? "" : "?", fieldName);
                modelcontent += " { get; set; }\n\r";


                outputDtocontent += "        /// <summary>\n";
                outputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.ColumnDescription);
                outputDtocontent += "        /// </summary>\n";
                if (strDataType.ToLower().Contains("string"))
                {
                    outputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.Length);
                }
                outputDtocontent += string.Format("        public {0}{1} {2}", strDataType, dbFieldInfo.IsNullable ? "" : "?", fieldName);
                outputDtocontent += " { get; set; }\n\r";
                if (strDataType.ToLower().Contains("bool") || strDataType.ToLower().Contains("tinyint"))
                {

                    vueViewListContent += string.Format("        <el-table-column prop=\"{0}\" label=\"{1}\" sortable=\"custom\" width=\"120\" >\n", fieldName, dbFieldInfo.ColumnDescription);
                    vueViewListContent += "          <template  #default=\"scope\">\n";
                    if (fieldName == "DeleteMark")
                    {
                        vueViewListContent += string.Format("            <el-tag :type=\"scope.row.{0} === true ? 'danger' : 'info'\"  disable-transitions >", fieldName);
                    }
                    else
                    {
                        vueViewListContent += string.Format("            <el-tag :type=\"scope.row.{0} === true ? 'success' : 'info'\"  disable-transitions >", fieldName);
                    }
                    vueViewListContent += "{{ ";
                    vueViewListContent += string.Format("scope.row.{0}===true?'是':'否' ", fieldName);
                    vueViewListContent += "}}</el-tag>\n";
                    vueViewListContent += "          </template>\n";
                    vueViewListContent += "        </el-table-column>\n";

                    vueViewFromContent += "        <el-col :span=\"12\">\n";
                    vueViewFromContent += string.Format("        <el-form-item label=\"{0}\" :label-width=\"formLabelWidth\" prop=\"{1}\">", dbFieldInfo.ColumnDescription, fieldName);
                    vueViewFromContent += string.Format("          <el-radio-group v-model=\"editFrom.{0}\">\n", fieldName);
                    vueViewFromContent += "           <el-radio :value=\"true\">是</el-radio>\n";
                    vueViewFromContent += "           <el-radio :value=\"false\">否</el-radio>\n";
                    vueViewFromContent += "          </el-radio-group>\n";
                    vueViewFromContent += "        </el-form-item>\n";
                    vueViewFromContent += "        </el-col>\n";

                    vueViewEditFromContent += string.Format("        {0}: true,\n", fieldName);
                    vueViewEditFromBindContent += string.Format("        this.editFrom.{0} = res.ResData.{0}+''\n", fieldName);
                }
                else if (strDataType.ToLower().Contains("datetime"))
                {
                    vueViewListContent += string.Format("        <el-table-column prop=\"{0}\" label=\"{1}\" sortable=\"custom\" width=\"120\" />\n", fieldName, dbFieldInfo.ColumnDescription);
                    vueViewFromContent += "        <el-col :span=\"12\">\n";
                    vueViewFromContent += string.Format("        <el-form-item label=\"{0}\" :label-width=\"formLabelWidth\" prop=\"{1}\">\n", dbFieldInfo.ColumnDescription, fieldName);
                    vueViewFromContent += string.Format("          <el-date-picker v-model=\"editFrom.{0}\" placeholder=\"请选择{1}\" type=\"datetime\" clearable />\n", fieldName, dbFieldInfo.ColumnDescription);
                    vueViewFromContent += "        </el-form-item>\n";
                    vueViewFromContent += "        </el-col>\n";
                    vueViewEditFromContent += string.Format("        {0}: '',\n", fieldName);
                    vueViewEditFromBindContent += string.Format("        this.editFrom.{0} = res.ResData.{0}\n", fieldName);
                }
                else if (strDataType.ToLower().Contains("decimal"))
                {
                    vueViewListContent += string.Format("        <el-table-column prop=\"{0}\" label=\"{1}\" sortable=\"custom\" width=\"120\" />\n", fieldName, dbFieldInfo.ColumnDescription);
                    vueViewFromContent += "        <el-col :span=\"12\">\n";
                    vueViewFromContent += string.Format("        <el-form-item label=\"{0}\" :label-width=\"formLabelWidth\" prop=\"{1}\">\n", dbFieldInfo.ColumnDescription, fieldName);
                    vueViewFromContent += string.Format("          <el-input-number v-model=\"editFrom.{0}\" autocomplete=\"off\" clearable />\n", fieldName);
                    vueViewFromContent += "        </el-form-item>\n";
                    vueViewFromContent += "        </el-col>\n";
                    vueViewEditFromContent += string.Format("        {0}: '',\n", fieldName);
                    vueViewEditFromBindContent += string.Format("        this.editFrom.{0} = res.ResData.{0}\n", fieldName);
                }
                else
                {
                    vueViewListContent += string.Format("        <el-table-column prop=\"{0}\" label=\"{1}\" sortable=\"custom\" width=\"120\" />\n", fieldName, dbFieldInfo.ColumnDescription);

                    vueViewFromContent += "        <el-col :span=\"12\">\n";
                    vueViewFromContent += string.Format("        <el-form-item label=\"{0}\" :label-width=\"formLabelWidth\" prop=\"{1}\">\n", dbFieldInfo.ColumnDescription, fieldName);
                    vueViewFromContent += string.Format("          <el-input v-model=\"editFrom.{0}\" placeholder=\"请输入{1}\" autocomplete=\"off\" clearable />\n", fieldName, dbFieldInfo.ColumnDescription);
                    vueViewFromContent += "        </el-form-item>\n";
                    vueViewFromContent += "        </el-col>\n";
                    vueViewEditFromContent += string.Format("        {0}: '',\n", fieldName);
                    vueViewEditFromBindContent += string.Format("        this.editFrom.{0} = res.ResData.{0}\n", fieldName);
                }
                vueViewSaveBindContent += string.Format("        '{0}':this.editFrom.{0},\n", fieldName);
                if (!dbFieldInfo.IsNullable)
                {
                    vueViewEditFromRuleContent += string.Format("        {0}: [\n", fieldName);
                    vueViewEditFromRuleContent += "        {";
                    vueViewEditFromRuleContent += string.Format("required: true, message:\"请输入{0}\", trigger: \"blur\"", dbFieldInfo.ColumnDescription);
                    vueViewEditFromRuleContent += "},\n          { min: 2, max: 50, message: \"长度在 2 到 50 个字符\", trigger:\"blur\" }\n";
                    vueViewEditFromRuleContent += "        ],\n";
                }
            }

            if (!inputDtoNoField.Contains(dbFieldInfo.DbColumnName) || dbFieldInfo.DbColumnName == "Id")
            {
                InputDtocontent += "        /// <summary>\n";
                InputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.ColumnDescription);
                InputDtocontent += "        /// </summary>\n";
                if (strDataType == "string")
                {
                    InputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.Length);
                }
                InputDtocontent += string.Format("        public {0}{1} {2}", strDataType, dbFieldInfo.IsNullable ? "" : "?", fieldName);
                InputDtocontent += " { get; set; }\n\r";
            }
            //
        }
        GenerateModels(modelsNamespace, modleNameClass, tableInfo.Name, modelcontent, modelTypeDesc, keyTypeName, ifExsitedCovered);
        GenerateIRepository(modleNameClass, modelTypeDesc, keyTypeName, ifExsitedCovered);
        GenerateRepository(modleNameClass, modelTypeDesc, tableInfo.Name, keyTypeName, ifExsitedCovered);
        GenerateIService(modelsNamespace, modleNameClass, modelTypeDesc, keyTypeName, ifExsitedCovered);
        GenerateService(modelsNamespace, modleNameClass, modelTypeDesc, keyTypeName, ifExsitedCovered);
        GenerateOutputDto(modleNameClass, modelTypeDesc, outputDtocontent, ifExsitedCovered);
        GenerateInputDto(modelsNamespace, modleNameClass, modelTypeDesc, InputDtocontent, keyTypeName, ifExsitedCovered);
        GenerateControllers(modleNameClass, modelTypeDesc, keyTypeName, ifExsitedCovered);
        GenerateVueViews(modleNameClass, modelTypeDesc, vueViewListContent, vueViewFromContent, vueViewEditFromContent, vueViewEditFromBindContent, vueViewSaveBindContent, vueViewEditFromRuleContent, ifExsitedCovered);
    }


    /// <summary>
    /// 从代码模板中读取内容
    /// </summary>
    /// <param name="templateName">模板名称，应包括文件扩展名称。比如：template.txt</param>
    /// <returns></returns>
    private static string ReadTemplate(string templateName)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var content = string.Empty;
        using (var stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.CodeTemplate.{templateName}"))
        {
            if (stream != null)
            {
                using var reader = new StreamReader(stream);
                content = reader.ReadToEnd();
            }
        }
        return content;
    }

    /// <summary>
    /// 生成IRepository层代码文件
    /// </summary>
    /// <param name="modelTypeName">实体类名</param>
    /// <param name="modelTypeDesc">实体描述</param>
    /// <param name="keyTypeName">主键</param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateIRepository(string modelTypeName, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        //path = path.Substring(0, path.IndexOf("\\bin"));
        var iRepositoryPath = Path.Combine(path, _option.BaseNamespace, _option.IRepositoriesNamespace);
        if (!Directory.Exists(iRepositoryPath))
        {
            iRepositoryPath = Path.Combine(path, _option.BaseNamespace, "IRepositories");
            Directory.CreateDirectory(iRepositoryPath);
        }
        var fullPath = Path.Combine(iRepositoryPath, "I" + modelTypeName) + "Repository.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("IRepositoryTemplate.txt");
        content = content.Replace("{ModelsNamespace}", _option.ModelsNamespace)
            .Replace("{IRepositoriesNamespace}", _option.IRepositoriesNamespace)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{KeyTypeName}", keyTypeName);
        WriteAndSave(fullPath, content);
    }
    /// <summary>
    /// 生成Repository层代码文件
    /// </summary>
    /// <param name="modelTypeName"></param>
    /// <param name="modelTypeDesc"></param>
    /// <param name="tableName">表名</param>
    /// <param name="keyTypeName"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateRepository(string modelTypeName, string modelTypeDesc, string tableName, string keyTypeName, bool ifExsitedCovered = false)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var repositoryPath = Path.Combine(path, _option.BaseNamespace, _option.RepositoriesNamespace);
        if (!Directory.Exists(repositoryPath))
        {
            repositoryPath = Path.Combine(path, _option.BaseNamespace, "Repositories");
            Directory.CreateDirectory(repositoryPath);
        }
        var fullPath = Path.Combine(repositoryPath, modelTypeName) + "Repository.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("RepositoryTemplate.txt");
        content = content.Replace("{ModelsNamespace}", _option.ModelsNamespace)
            .Replace("{IRepositoriesNamespace}", _option.IRepositoriesNamespace)
            .Replace("{RepositoriesNamespace}", _option.RepositoriesNamespace)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{TableName}", tableName)
            .Replace("{KeyTypeName}", keyTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成IService文件
    /// </summary>
    /// <param name="modelsNamespace"></param>
    /// <param name="modelTypeName"></param>
    /// <param name="modelTypeDesc"></param>
    /// <param name="keyTypeName"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateIService(string modelsNamespace, string modelTypeName, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
    {
        var iServicsNamespace = _option.IServicsNamespace;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var iServicesPath = Path.Combine(path, _option.BaseNamespace, _option.IServicsNamespace);
        if (!Directory.Exists(iServicesPath))
        {
            iServicesPath = Path.Combine(path, _option.BaseNamespace, "IServices");
            Directory.CreateDirectory(iServicesPath);
        }
        var fullPath = Path.Combine(iServicesPath, "I" + modelTypeName) + "Service.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("IServiceTemplate.txt");
        content = content.Replace("{ModelsNamespace}", modelsNamespace)
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{IServicsNamespace}", iServicsNamespace)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{KeyTypeName}", keyTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成Service文件
    /// </summary>
    /// <param name="modelsNamespace"></param>
    /// <param name="modelTypeName"></param>
    /// <param name="modelTypeDesc"></param>
    /// <param name="keyTypeName"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateService(string modelsNamespace, string modelTypeName, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.ServicesNamespace;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Services");
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, modelTypeName) + "Service.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("ServiceTemplate.txt");
        content = content
            .Replace("{IRepositoriesNamespace}", _option.IRepositoriesNamespace)
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{IServicsNamespace}", _option.IServicsNamespace)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{ModelsNamespace}", modelsNamespace)
            .Replace("{ServicesNamespace}", servicesNamespace)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{KeyTypeName}", keyTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成OutputDto文件
    /// </summary>
    /// <param name="modelTypeName"></param>
    /// <param name="modelTypeDesc"></param>
    /// <param name="modelContent"></param>
    /// <param name="ifExsitedCovered"></param>
    private static void GenerateOutputDto(string modelTypeName, string modelTypeDesc, string modelContent, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.ServicesNamespace;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Dtos");
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, modelTypeName) + "OutputDto.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("OuputDtoTemplate.txt");
        content = content
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{ModelContent}", modelContent)
            .Replace("{ModelTypeName}", modelTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成InputDto文件
    /// </summary>
    /// <param name="modelsNamespace"></param>
    /// <param name="modelTypeName"></param>
    /// <param name="modelTypeDesc"></param>
    /// <param name="modelContent"></param>
    /// <param name="keyTypeName"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateInputDto(string modelsNamespace, string modelTypeName, string modelTypeDesc, string modelContent, string keyTypeName, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.DtosNamespace;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Dtos");
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, modelTypeName) + "InputDto.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("InputDtoTemplate.txt");
        content = content
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{ModelsNamespace}", modelsNamespace)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{KeyTypeName}", keyTypeName)
            .Replace("{ModelContent}", modelContent)
            .Replace("{ModelTypeName}", modelTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成Profile文件
    /// </summary>
    /// <param name="modelsNamespace"></param>
    /// <param name="profileContent"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateDtoProfile(string modelsNamespace, string profileContent, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.DtosNamespace;
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Dtos");
            Directory.CreateDirectory(servicesPath);
        }
        var fileClassName = _option.BaseNamespace.Substring(_option.BaseNamespace.LastIndexOf('.') + 1);
        var fullPath = Path.Combine(servicesPath, fileClassName) + "Profile.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("ProfileTemplate.txt");
        content = content
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{ModelsNamespace}", modelsNamespace)
            .Replace("{ProfileContent}", profileContent)
            .Replace("{ClassName}", fileClassName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成Models文件
    /// </summary>
    /// <param name="modelsNamespace">命名空间</param>
    /// <param name="modelTypeName">类名</param>
    /// <param name="tableName">表名称</param>
    /// <param name="modelTypeDesc">表描述</param>
    /// <param name="modelContent">数据库表实体内容</param>
    /// <param name="keyTypeName">主键数据类型</param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateModels(string modelsNamespace, string modelTypeName, string tableName, string modelContent, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, modelsNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Models");
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, modelTypeName) + ".cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("ModelsTemplate.txt");
        content = content
            .Replace("{ModelsNamespace}", modelsNamespace)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{KeyTypeName}", keyTypeName)
            .Replace("{ModelContent}", modelContent)
            .Replace("{TableName}", tableName);
        WriteAndSave(fullPath, content);
    }


    /// <summary>
    /// 生成控制器ApiControllers文件
    /// </summary>
    /// <param name="modelTypeName">实体类型名称</param>
    /// <param name="modelTypeDesc">实体描述</param>
    /// <param name="keyTypeName"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateControllers(string modelTypeName, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.DtosNamespace;
        var fileClassName = _option.BaseNamespace.Substring(_option.BaseNamespace.IndexOf('.') + 1);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace, "Controllers");
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "Areas", fileClassName);
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, modelTypeName) + "Controller.cs";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("ControllersTemplate.txt");
        content = content
            .Replace("{DtosNamespace}", _option.DtosNamespace)
            .Replace("{ApiControllerNamespace}", _option.ApiControllerNamespace)
            .Replace("{ModelsNamespace}", _option.ModelsNamespace)
            .Replace("{TableNameDesc}", modelTypeDesc)
            .Replace("{IServicsNamespace}", _option.IServicsNamespace)
            .Replace("{BaseNameSpaceEx}", fileClassName)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{KeyTypeName}", keyTypeName);
        WriteAndSave(fullPath, content);
    }

    /// <summary>
    /// 生成Vue页面
    /// </summary>
    /// <param name="modelTypeName">类名</param>
    /// <param name="modelTypeDesc">表/类描述</param>
    /// <param name="vueViewListContent"></param>
    /// <param name="vueViewFromContent"></param>
    /// <param name="vueViewEditFromContent"></param>
    /// <param name="vueViewEditFromBindContent"></param>
    /// <param name="vueViewSaveBindContent"></param>
    /// <param name="vueViewEditFromRuleContent"></param>
    /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
    private static void GenerateVueViews(string modelTypeName, string modelTypeDesc, string vueViewListContent, string vueViewFromContent, string vueViewEditFromContent, string vueViewEditFromBindContent, string vueViewSaveBindContent, string vueViewEditFromRuleContent, bool ifExsitedCovered = false)
    {
        var servicesNamespace = _option.DtosNamespace;
        var fileClassName = _option.BaseNamespace.Substring(_option.BaseNamespace.IndexOf('.') + 1);
        var path = AppDomain.CurrentDomain.BaseDirectory;
        var servicesPath = Path.Combine(path, _option.BaseNamespace, servicesNamespace);
        if (!Directory.Exists(servicesPath))
        {
            servicesPath = Path.Combine(path, _option.BaseNamespace, "vue", modelTypeName.ToLower());
            Directory.CreateDirectory(servicesPath);
        }
        var fullPath = Path.Combine(servicesPath, "index") + ".vue";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        var content = ReadTemplate("VueTemplate.txt");
        content = content
            .Replace("{BaseNamespace}", fileClassName.ToLower())
            .Replace("{fileClassName}", modelTypeName.ToLower())
            .Replace("{ModelTypeNameToLower}", modelTypeName.ToLower())
            .Replace("{VueViewListContent}", vueViewListContent)
            .Replace("{VueViewFromContent}", vueViewFromContent)
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{ModelTypeDesc}", modelTypeDesc)
            .Replace("{VueViewEditFromContent}", vueViewEditFromContent)
            .Replace("{VueViewEditFromBindContent}", vueViewEditFromBindContent)
            .Replace("{VueViewSaveBindContent}", vueViewSaveBindContent)
            .Replace("{VueViewEditFromRuleContent}", vueViewEditFromRuleContent);
        WriteAndSave(fullPath, content);

        fullPath = servicesPath + "\\" + modelTypeName.ToLower() + "service.js";
        if (File.Exists(fullPath) && !ifExsitedCovered)
            return;
        content = ReadTemplate("VueJsTemplate.txt");
        content = content
            .Replace("{ModelTypeName}", modelTypeName)
            .Replace("{ModelTypeDesc}", modelTypeDesc)
            .Replace("{fileClassName}", fileClassName);
        WriteAndSave(fullPath, content);
    }
    /// <summary>
    /// 写文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="content"></param>
    private static void WriteAndSave(string fileName, string content)
    {
        //实例化一个文件流--->与写入文件相关联
        using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        //实例化一个StreamWriter-->与fs相关联
        using var sw = new StreamWriter(fs);
        //开始写入
        sw.Write(content);
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }
    /// <summary>
    /// 将数据库类型转为系统类型。
    /// </summary>
    /// <param name="sqlType">数据库字段类型</param>
    /// <param name="isNullable">字段是否可空</param>
    /// <returns></returns>
    public static string SqlType2CsharpTypeStr(string sqlType, bool isNullable = false)
    {
        if (string.IsNullOrEmpty(sqlType))
            throw new ArgumentNullException(nameof(sqlType));
        var val = string.Empty;
        var allowNull = false;
        switch (sqlType.ToLower())
        {
            case "bit":
                val = "bool";
                break;
            case "int":
                val = "int";
                break;
            case "smallint":
                val = "short";
                break;
            case "bigint":
                val = "long";
                break;
            case "tinyint":
                val = "bool";
                break;

            case "binary":
            case "image":
            case "varbinary":
                val = "byte[]";
                allowNull = true;
                break;

            case "decimal":
                val = "decimal";
                break;
            case "numeric":
            case "money":
            case "smallmoney":
                val = "decimal";
                break;

            case "float":
                val = "float";
                break;
            case "real":
                val = "Single";
                break;

            case "datetime":
                val = "DateTime";
                break;
            case "smalldatetime":
            case "timestamp":
                val = "DateTime";
                break;

            case "uniqueidentifier":
                val = "Guid";
                break;
            case "Variant":
                val = "object";
                allowNull = true;
                break;

            case "text":
                val = "string";
                allowNull = true;
                break;
            case "ntext":
                val = "string";
                allowNull = true;
                break;
            case "char":
                val = "string";
                allowNull = true;
                break;
            case "nchar":
                val = "string";
                allowNull = true;
                break;
            case "varchar":
                val = "string";
                allowNull = true;
                break;
            case "nvarchar":
                val = "string";
                allowNull = true;
                break;
            default:
                val = "string";
                allowNull = true;
                break;
        }
        if (isNullable && !allowNull)
            return val + "?";
        return val;
    }
}
