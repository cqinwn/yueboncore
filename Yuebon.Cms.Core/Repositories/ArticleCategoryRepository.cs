using System;

using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;
using System.Data;
using Dapper;
using Yuebon.Commons.Json;
using System.Linq;

namespace Yuebon.CMS.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<ArticleCategory, string>, IArticleCategoryRepository
    {
		public ArticleCategoryRepository()
        {
            this.tableName = "CMS_ArticleCategory";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 得到分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleSimpleCategoryOutputDto> GetArticleCategoryListInfo(string id)
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(id))
            {
                strWhere = " and Id='" + id + "' ";
            }

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select Id,Title,Id as Value,Title as Name,0 as CK from CMS_ArticleCategory";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }
                sql += " Order by SortCode desc";

                IEnumerable<ArticleSimpleCategoryOutputDto> categoryOutputDto = conn.Query<ArticleSimpleCategoryOutputDto>(sql);

                return categoryOutputDto;
            }
        }

        /// <summary>
        /// 得到分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetArticleIndexCategoryListInfo(string id)
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(id))
            {
                strWhere = " where Id='" + id + "' ";
            }

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select Id,Id as cateId,Title as txt,1 as page,0 as loadMore,
0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory ";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }
                sql += " Order by SortCode desc";
                IEnumerable<ArticleIndexCategoryOutputDto> categoryOutputDto = conn.Query<ArticleIndexCategoryOutputDto>(sql);

                return categoryOutputDto;
            }
        }

        /// <summary>
        /// 得到分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfo(string userid)
        {
            string strWhere = "";
            strWhere = " where CreatorUserId='" + userid + "' ";

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select * from CMS_UserArticleCategory ";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }

                //先搜索是否存在
                IEnumerable<ArticleUserCategoryOutputDto> categoryOutputDto = conn.Query<ArticleUserCategoryOutputDto>(sql);

                //如果存在
                if (categoryOutputDto.AsList().Count!=0)
                {
                    List<ArticleIndexCategoryOutputDto> indexCategory =
                        new List<ArticleIndexCategoryOutputDto>();
                    foreach(ArticleUserCategoryOutputDto item in categoryOutputDto)
                    {                        

                        string selStr = item.SelectItems.ToString();
                        selStr=selStr.Replace("\r\n", "");
                        List<ArticleIndexCategoryOutputDto> selObj = JsonHelper.ToList<ArticleIndexCategoryOutputDto>(selStr);

                        for(int i=0;i<selObj.Count;i++)
                        {
                            ArticleIndexCategoryOutputDto model = new ArticleIndexCategoryOutputDto();
                            model = selObj[i];
                            indexCategory.Add(model);
                        }
                    }
                    return indexCategory as IEnumerable<ArticleIndexCategoryOutputDto>;
                }
                else
                {
                    sql = @"select Id,Id as cateId,Title as txt,1 as page,0 as loadMore,
0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory ";
                    IEnumerable<ArticleIndexCategoryOutputDto> categoryOutputDto1 = conn.Query<ArticleIndexCategoryOutputDto>(sql);
                    return categoryOutputDto1;
                }

               
            }
        }

        /// <summary>
        /// 得到用户分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfoNew(string userid)
        {
            string strWhere = "";
            strWhere = " where CreatorUserId='" + userid + "' ";

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select * from CMS_UserArticleCategory ";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }

                //先搜索是否存在
                IEnumerable<ArticleUserCategoryOutputDto> categoryOutputDto = conn.Query<ArticleUserCategoryOutputDto>(sql);

                //如果存在
                if (categoryOutputDto.AsList().Count != 0)
                {
                    List<ArticleIndexCategoryOutputDto> indexCategory =
                        new List<ArticleIndexCategoryOutputDto>();
                    foreach (ArticleUserCategoryOutputDto item in categoryOutputDto)
                    {

                        string selStr = item.SelectItems.ToString();
                        string[] selArray = selStr.Split(',');
                        //构造筛选条件
                        string selWhere = "(";
                        for (int k = 0; k < selArray.Length; k++)
                        {
                            selWhere = selWhere + "'" + selArray[k] + "',";
                        }
                        selWhere = selWhere.Substring(0, selWhere.Length - 1);
                        selWhere = selWhere + ") ";

                        string sqlFindAll = @"select Id, Id as cateId,Title as txt,1 as page,0 as loadMore,
0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory  where Id in " +
                               selWhere + " and EnabledMark=1 and DeleteMark=0 ";

                        List<ArticleIndexCategoryOutputDto> tmpindexCategory =
                        new List<ArticleIndexCategoryOutputDto>();

                        tmpindexCategory = conn.Query<ArticleIndexCategoryOutputDto>(sqlFindAll).AsList();
                        
                        //需要重新按用户选择排序
                        for (int ii = 0; ii < selArray.Length; ii++)
                        {
                            foreach(ArticleIndexCategoryOutputDto subItem in tmpindexCategory)
                            {
                                if(selArray[ii]==subItem.Id)
                                {
                                    indexCategory.Add(subItem);
                                    tmpindexCategory.Remove(subItem);
                                    break;
                                }
                            }
                        }
                    }
                    return indexCategory as IEnumerable<ArticleIndexCategoryOutputDto>;
                }
                else
                {
                    sql = @"select Id,Id as cateId,Title as txt,1 as page,0 as loadMore,
                    0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory ";
                    IEnumerable<ArticleIndexCategoryOutputDto> categoryOutputDto1 = conn.Query<ArticleIndexCategoryOutputDto>(sql);
                    return categoryOutputDto1;

                }


            }
        }

        /// <summary>
        /// 得到未选择分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfoNew(string userid)
        {
            string strWhere = "";           
           
            strWhere = " where CreatorUserId='" + userid + "' ";            

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select * from CMS_UserArticleCategory ";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }

                //先搜索用户定义是否存在
                IEnumerable<ArticleUserCategoryOutputDto> categoryOutputDto = conn.Query<ArticleUserCategoryOutputDto>(sql);

                //如果存在
                if (categoryOutputDto.AsList().Count != 0)
                {
                    IEnumerable<ArticleIndexCategoryOutputDto> indexCategory =
                        new List<ArticleIndexCategoryOutputDto>();

                    foreach (ArticleUserCategoryOutputDto item in categoryOutputDto)
                    {
                        string selStr = item.SelectItems.ToString();
                        string[] selArray = selStr.Split(',');

                        //构造筛选条件
                        string unselWhere = "(";
                        for(int k=0;k<selArray.Length;k++)
                        {
                            unselWhere = unselWhere + "'" + selArray[k] + "',";
                        }
                        unselWhere = unselWhere.Substring(0, unselWhere.Length - 1);
                        unselWhere = unselWhere + ") ";

                        string sqlFindAll = @"select Id, Id as cateId,Title as txt,1 as page,0 as loadMore,
0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory  where Id not in " +
                               unselWhere + " and EnabledMark=1 and DeleteMark=0 ";

                        indexCategory = conn.Query<ArticleIndexCategoryOutputDto>(sqlFindAll);
                    }

                    return indexCategory as IEnumerable<ArticleIndexCategoryOutputDto>;

                }
                else
                {
                    //                    sql = @"select Id,Id as cateId,Title as txt,1 as page,0 as loadMore,
                    //0 as refresh,0 as loadingType,0 as maxpage from CMS_ArticleCategory ";
                    //                    IEnumerable<ArticleIndexCategoryOutputDto> categoryOutputDto1 = conn.Query<ArticleIndexCategoryOutputDto>(sql);
                    //                    return categoryOutputDto1;

                    return null;
                }
                
            }
        }



        /// <summary>
        /// 得到未选择分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfo(string userid)
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(userid))
            {
                strWhere = " where CreatorUserId='" + userid + "' and UnSelectItems is not null and UnSelectItems !=''";
            }

            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"select * from CMS_UserArticleCategory ";

                if (strWhere != "")
                {
                    sql = sql + strWhere;
                }

                //先搜索是否存在
                IEnumerable<ArticleUserCategoryOutputDto> categoryOutputDto = conn.Query<ArticleUserCategoryOutputDto>(sql);

                //如果存在
                if (categoryOutputDto.AsList().Count != 0)
                {
                    List<ArticleIndexCategoryOutputDto> indexCategory =
                        new List<ArticleIndexCategoryOutputDto>();

                    foreach (ArticleUserCategoryOutputDto item in categoryOutputDto)
                    {                        
                        string selStr = item.UnSelectItems.ToString();
                        selStr = selStr.Replace("\r\n", "");
                        List<ArticleIndexCategoryOutputDto> selObj = JsonHelper.ToList<ArticleIndexCategoryOutputDto>(selStr);

                        for (int i = 0; i < selObj.Count; i++)
                        {
                            ArticleIndexCategoryOutputDto model = new ArticleIndexCategoryOutputDto();
                            model = selObj[i];
                            indexCategory.Add(model);
                        }
                    }

                    return indexCategory as IEnumerable<ArticleIndexCategoryOutputDto>;

                }


                return null;
            }
        }


        /// <summary>
        /// 保存用户自定义分类
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="selstr"></param>
        /// <param name="unselstr"></param>
        /// <returns></returns>
        public bool SaveUserArticleCategoryList(string userid, string selstr, string unselstr)
        {
            string strWhere = "";
            if (!String.IsNullOrEmpty(userid))
            {
                strWhere = " where CreatorUserId='" + userid + "'";
                using (IDbConnection conn = OpenSharedConnection())
                {
                    string sql = "select * from CMS_UserArticleCategory ";
                    if (strWhere != "")
                    {
                        sql = sql + strWhere;
                    }

                    //先搜索是否存在
                    IEnumerable<ArticleUserCategoryOutputDto> categoryOutputDto = conn.Query<ArticleUserCategoryOutputDto>(sql);
                    if (categoryOutputDto.AsList().Count != 0)
                    {
                        sql = @"update CMS_UserArticleCategory set SelectItems='" +
                            selstr + "',UnSelectItems='" + unselstr + "',LastModifyTime='" + 
                            DateTime.Now.ToString()+"',LastModifyUserId='"+
                            userid+"' "+ strWhere;

                        return conn.Execute(sql) > 0 ? true : false;
                    }
                    else
                    {
                        sql = @"insert into CMS_UserArticleCategory values ('" +
                            Guid.NewGuid().ToString() + "','" +
                            selstr + "','" +
                            unselstr + "','" +
                            userid + "','" +
                            DateTime.Now.ToString() +"','"+
                            DateTime.Now.ToString() +"','"+
                             userid + "' )";

                        return conn.Execute(sql) > 0 ? true : false;
                    }

                }
            }
            else
            {
                return false;
            }
        }
    }
}