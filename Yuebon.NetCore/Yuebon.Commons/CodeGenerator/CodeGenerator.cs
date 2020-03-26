using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.CodeGenerator
{
    /// <summary>
    /// 代码生成器。
    /// <remarks>
    /// 根据指定的实体域名空间生成Repositories和Services层的基础代码文件。
    /// </remarks>
    /// </summary>
    public class CodeGenerator
    {
        private static CodeGenerateOption _option;
        /// <summary>
        /// InputDto输入实体是不包含字段
        /// </summary>
        private static string inputDtoNoField= "DeleteMark,CreatorTime,CreatorUserId,CompanyId,DeptId,LastModifyTime,LastModifyUserId,DeleteTime,DeleteUserId,";
        /// <summary>
        /// 静态构造函数：从IoC容器读取配置参数，如果读取失败则会抛出ArgumentNullException异常
        /// </summary>
        static CodeGenerator()
        {
            _option = IoCContainer.Resolve<CodeGenerateOption>();
            if (_option == null)
            {
                throw new ArgumentNullException(nameof(_option));
            }
        }
        /// <summary>
        /// 代码生成器入口方法
        /// </summary>
        /// <param name="baseNamespace"></param>
        /// <param name="tableList">要生成代码的表</param>
        /// <param name="replaceTableNameStr">要删除表名称的字符</param>
        /// <param name="ifExsitedCovered">是否替换现有文件，为true时替换</param>
        public static void Generate(string baseNamespace, string tableList, string replaceTableNameStr,bool ifExsitedCovered = false)
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

            MssqlExtractor mssqlExtractor = new MssqlExtractor();
            List<DbTableInfo> listTable = mssqlExtractor.GetAllTables(_option.TableList);
            string profileContent = string.Empty;
            foreach (DbTableInfo dbTableInfo in listTable)
            {
               
                List<DbFieldInfo> listField = mssqlExtractor.GetAllColumns(dbTableInfo.TableName);
                GenerateSingle(listField, dbTableInfo, ifExsitedCovered);

                string tableName = dbTableInfo.TableName.Substring(0,1).ToUpper() + dbTableInfo.TableName.Substring(1);// System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(dbTableInfo.TableName);
                string[] rel = _option.ReplaceTableNameStr.Split(';');
                for (int i = 0; i < rel.Length; i++)
                {
                    if (!string.IsNullOrEmpty(rel[i].ToString()))
                    {
                        tableName = tableName.Replace(rel[i].ToString(), "");
                    }
                }
                profileContent += string.Format("           CreateMap<{0}, {0}OutputDto>();\n", tableName);
                profileContent += string.Format("           CreateMap<{0}InputDto, {0}>();\n", tableName);
            }            
           
            GenerateDtoProfile(_option.ModelsNamespace, profileContent, ifExsitedCovered);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listField">表字段集合</param>
        /// <param name="tableInfo"></param>
        /// <param name="ifExsitedCovered"></param>
        public static void GenerateSingle(List<DbFieldInfo> listField, DbTableInfo tableInfo,bool ifExsitedCovered = false)
        {
            var modelsNamespace =_option.ModelsNamespace;
            var modelTypeName = tableInfo.TableName;
            var modelTypeDesc = tableInfo.Description;
            if (!string.IsNullOrEmpty(_option.ReplaceTableNameStr))
            {
                string[] rel = _option.ReplaceTableNameStr.Split(';');
                for (int i = 0; i < rel.Length; i++)
                {
                    if (!string.IsNullOrEmpty(rel[i].ToString()))
                    {
                        modelTypeName = modelTypeName.Replace(rel[i].ToString(),"");
                    }
                }
            }
            modelTypeName = modelTypeName.Substring(0, 1).ToUpper() + modelTypeName.Substring(1);// System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(modelTypeName);
            string keyTypeName = "string";//主键数据类型
            string modelcontent = "";//数据库模型字段
            string InputDtocontent = "";//输入模型
            string outputDtocontent = "";//输出模型
            foreach (DbFieldInfo dbFieldInfo in listField)
            {
                string fieldName = dbFieldInfo.FieldName.Substring(0, 1).ToUpper() + dbFieldInfo.FieldName.Substring(1);// System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(dbFieldInfo.FieldName);
                if (dbFieldInfo.IsIdentity)
                {
                    keyTypeName = dbFieldInfo.DataType;
                    outputDtocontent += "        /// <summary>\n";
                    outputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.Description);
                    outputDtocontent += "        /// </summary>\n";
                    if (dbFieldInfo.DataType == "string")
                    {
                        outputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.FieldPrecision);
                    }
                    outputDtocontent += string.Format("        public {0} {1}", dbFieldInfo.DataType, fieldName);
                    outputDtocontent += " { get; set; }\n\r";
                }
                if (!dbFieldInfo.IsIdentity)
                {
                    modelcontent += "        /// <summary>\n";
                    modelcontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.Description);
                    modelcontent += "        /// </summary>\n";
                    if (dbFieldInfo.FieldType == "string")
                    {
                        modelcontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.FieldPrecision);
                    }
                    modelcontent += string.Format("        public {0} {1}", dbFieldInfo.DataType, fieldName);
                    modelcontent += " { get; set; }\n\r";


                    outputDtocontent += "        /// <summary>\n";
                    outputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.Description);
                    outputDtocontent += "        /// </summary>\n";
                    if (dbFieldInfo.DataType == "string")
                    {
                        outputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.FieldPrecision);
                    }
                    outputDtocontent += string.Format("        public {0} {1}", dbFieldInfo.DataType, fieldName);
                    outputDtocontent += " { get; set; }\n\r";
                }

                if (!inputDtoNoField.Contains(dbFieldInfo.FieldName)||dbFieldInfo.FieldName=="Id")
                {
                    InputDtocontent += "        /// <summary>\n";
                    InputDtocontent += string.Format("        /// 设置或获取{0}\n", dbFieldInfo.Description);
                    InputDtocontent += "        /// </summary>\n";
                    if (dbFieldInfo.FieldType == "string")
                    {
                        InputDtocontent += string.Format("        [MaxLength({0})]\n", dbFieldInfo.FieldPrecision);
                    }
                    InputDtocontent += string.Format("        public {0} {1}", dbFieldInfo.DataType, fieldName);
                    InputDtocontent += " { get; set; }\n\r";
                }
            }
            GenerateModels(modelsNamespace, modelTypeName, tableInfo.TableName, modelcontent, modelTypeDesc, keyTypeName, ifExsitedCovered);
            GenerateIRepository(modelTypeName, modelTypeDesc, keyTypeName, ifExsitedCovered);
            GenerateRepository(modelTypeName, modelTypeDesc, tableInfo.TableName, keyTypeName, ifExsitedCovered);
            GenerateIService(modelsNamespace, modelTypeName, modelTypeDesc, keyTypeName, ifExsitedCovered);
            GenerateService(modelsNamespace, modelTypeName, modelTypeDesc, keyTypeName, ifExsitedCovered);
            GenerateOutputDto(modelTypeName, modelTypeDesc, outputDtocontent, ifExsitedCovered);
            GenerateInputDto(modelsNamespace, modelTypeName, modelTypeDesc, InputDtocontent, keyTypeName, ifExsitedCovered);
            GenerateControllers(modelTypeName, modelTypeDesc, keyTypeName, ifExsitedCovered);
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
        /// <param name="modelTypeName">实体类型</param>
        /// <param name="modelTypeDesc"></param>
        /// <param name="keyTypeName"></param>
        /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
        private static void GenerateIRepository(string modelTypeName, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var iRepositoryPath = parentPath + "\\" + _option.BaseNamespace + "\\" + _option.IRepositoriesNamespace;
            if (!Directory.Exists(iRepositoryPath))
            {
                iRepositoryPath = parentPath + "\\" + _option.BaseNamespace + "\\IRepositories";
                Directory.CreateDirectory(iRepositoryPath);
            }
            var fullPath = iRepositoryPath + "\\I" + modelTypeName + "Repository.cs";
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
        private static void GenerateRepository(string modelTypeName, string modelTypeDesc, string tableName,string keyTypeName, bool ifExsitedCovered = false)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var repositoryPath = parentPath + "\\" + _option.BaseNamespace + "\\" + _option.RepositoriesNamespace;
            if (!Directory.Exists(repositoryPath))
            {
                repositoryPath = parentPath + "\\" + _option.BaseNamespace + "\\Repositories";
                Directory.CreateDirectory(repositoryPath);
            }
            var fullPath = repositoryPath + "\\" + modelTypeName + "Repository.cs";
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
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var iServicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + iServicsNamespace;
            if (!Directory.Exists(iServicesPath))
            {
                iServicesPath = parentPath + "\\" + _option.BaseNamespace + "\\IServices";
                Directory.CreateDirectory(iServicesPath);
            }
            var fullPath = iServicesPath + "\\I" + modelTypeName + "Service.cs";
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
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + servicesNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Services";
                Directory.CreateDirectory(servicesPath);
            }
            var fullPath = servicesPath + "\\" + modelTypeName + "Service.cs";
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
        private static void GenerateOutputDto(string modelTypeName, string modelTypeDesc, string modelContent,  bool ifExsitedCovered = false)
        {
            var servicesNamespace = _option.ServicesNamespace;
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + servicesNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Dtos";
                Directory.CreateDirectory(servicesPath);
            }
            var fullPath = servicesPath + "\\" + modelTypeName + "OutputDto.cs";
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
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + servicesNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Dtos";
                Directory.CreateDirectory(servicesPath);
            }
            var fullPath = servicesPath + "\\" + modelTypeName + "InputDto.cs";
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
        private static void GenerateDtoProfile(string modelsNamespace, string profileContent,  bool ifExsitedCovered = false)
        {
            var servicesNamespace = _option.DtosNamespace;
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + servicesNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Dtos";
                Directory.CreateDirectory(servicesPath);
            }
            var fileClassName = _option.BaseNamespace.Substring(_option.BaseNamespace.IndexOf('.')+1);
            var fullPath = servicesPath + "\\" + fileClassName + "Profile.cs";
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
        /// <param name="modelsNamespace"></param>
        /// <param name="modelTypeName"></param>
        /// <param name="tableName"></param>
        /// <param name="modelTypeDesc"></param>
        /// <param name="modelContent"></param>
        /// <param name="keyTypeName"></param>
        /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
        private static void GenerateModels(string modelsNamespace, string modelTypeName,string tableName,  string modelContent, string modelTypeDesc, string keyTypeName, bool ifExsitedCovered = false)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + modelsNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Models";
                Directory.CreateDirectory(servicesPath);
            }
            var fullPath = servicesPath + "\\" + modelTypeName + ".cs";
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
        /// <param name="modelTypeName"></param>
        /// <param name="modelTypeDesc"></param>
        /// <param name="keyTypeName"></param>
        /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
        private static void GenerateControllers(string modelTypeName, string modelTypeDesc,string keyTypeName, bool ifExsitedCovered = false)
        {
            var servicesNamespace = _option.DtosNamespace;
            var fileClassName = _option.BaseNamespace.Substring(_option.BaseNamespace.IndexOf('.') + 1);
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf("\\bin"));
            var parentPath = path.Substring(0, path.LastIndexOf("\\"));
            var servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\" + servicesNamespace;
            if (!Directory.Exists(servicesPath))
            {
                servicesPath = parentPath + "\\" + _option.BaseNamespace + "\\Areas\\"+ fileClassName;
                Directory.CreateDirectory(servicesPath);
            }
            var fullPath = servicesPath + "\\" + modelTypeName + "Controller.cs";
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
    }
}
