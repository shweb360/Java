using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;
namespace Slickflow.WebDemo.Data
{
    public class UploadFileDll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(UploadFileEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UploadFile(");
            strSql.Append("FileName,FilePath,WFBizID,WFBizType,CreatedUserID,CreatedUserName,CreatedDate,LoginRoleID");
            strSql.Append(") values (");
            strSql.Append("@FileName,@FilePath,@WFBizID,@WFBizType,@CreatedUserID,@CreatedUserName,@CreatedDate,@LoginRoleID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@FileName", SqlDbType.NVarChar,100),  
                        new SqlParameter("@FilePath", SqlDbType.NVarChar,100),
                        new SqlParameter("@WFBizID", SqlDbType.Int,4),
                        new SqlParameter("@WFBizType", SqlDbType.Int,4),
                        new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
                        new SqlParameter("@CreatedUserName", SqlDbType.NVarChar,50),
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                        new SqlParameter("@LoginRoleID",SqlDbType.Int,4)
                     
                };
            int idx = 0;
            parameters[idx++].Value = model.FileName;
            parameters[idx++].Value = model.FilePath;
            parameters[idx++].Value = model.WFBizID;
            parameters[idx++].Value = model.WFBizType;
            parameters[idx++].Value = model.CreatedUserID;
            parameters[idx++].Value = model.CreatedUserName;
            parameters[idx++].Value = model.CreatedDate;
            parameters[idx++].Value = model.LoginRoleID;
            
            object obj = SQLHelper.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from UploadFile ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }

        /// <summary>
        /// 获取所有上传附件
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListUploadFile(int WFBizID, int WFBizType, int LoginRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F.*,D.DeptName ");
            strSql.Append("  from UploadFile as F");
            strSql.Append("  inner join SysUser as U on F.CreatedUserID=U.ID ");
            strSql.Append("  inner join SysDepartment as D on D.ID=U.DeptID ");
            strSql.Append(" where F.WFBizID=@WFBizID");
            strSql.Append(" and F.WFBizType=@WFBizType");
            strSql.Append(" and F.LoginRoleID<>@LoginRoleID");
            strSql.Append(" and F.ID=(select max(ID) from UploadFile Y where Y.CreatedUserID=U.ID)");
            
            SqlParameter[] parameters = {
				   new SqlParameter("@WFBizID", SqlDbType.Int,4),
                   new SqlParameter("@WFBizType", SqlDbType.Int,4),
                   new SqlParameter("@LoginRoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = WFBizID;
            parameters[1].Value = WFBizType;
            parameters[2].Value = LoginRoleID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);

            return ds.Tables[0];
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModel(int WFBizID, int WFBizType, int LoginRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from UploadFile ");
            strSql.Append(" where WFBizID=@WFBizID");
            strSql.Append(" and WFBizType=@WFBizType");
            strSql.Append(" and LoginRoleID=@LoginRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@WFBizID", SqlDbType.Int,4),
                   new SqlParameter("@WFBizType", SqlDbType.Int,4),
                   new SqlParameter("@LoginRoleID", SqlDbType.Int,4)
			};
            parameters[0].Value = WFBizID;
            parameters[1].Value = WFBizType;
            parameters[2].Value = LoginRoleID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModelByUserID(int WFBizID, int WFBizType, int CreatedUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from UploadFile ");
            strSql.Append(" where WFBizID=@WFBizID");
            if (WFBizType > 0)
            {
                strSql.Append(" and WFBizType=@WFBizType");
            }          
            strSql.Append(" and CreatedUserID=@CreatedUserID");
            SqlParameter[] parameters = {
					new SqlParameter("@WFBizID", SqlDbType.Int,4),
                   new SqlParameter("@WFBizType", SqlDbType.Int,4),
                   new SqlParameter("@CreatedUserID", SqlDbType.Int,4)
			};
            parameters[0].Value = WFBizID;
            parameters[1].Value = WFBizType;
            parameters[2].Value = CreatedUserID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }
        private static UploadFileEntity GetModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                UploadFileEntity model = new UploadFileEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.FileName = dt.Rows[0]["FileName"].ToString();
                model.FilePath = dt.Rows[0]["FilePath"].ToString();
                if (dt.Rows[0]["WFBizID"].ToString() != "")
                {
                    model.WFBizID = int.Parse(dt.Rows[0]["WFBizID"].ToString());
                }
                if (dt.Rows[0]["WFBizType"].ToString() != "")
                {
                    model.WFBizType = int.Parse(dt.Rows[0]["WFBizType"].ToString());
                }
                if (dt.Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(dt.Rows[0]["CreatedUserID"].ToString());
                }
                model.CreatedUserName = dt.Rows[0]["CreatedUserName"].ToString();

                if (dt.Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString());
                }
                if (dt.Rows[0]["LoginRoleID"].ToString() != "")
                {
                    model.LoginRoleID = int.Parse(dt.Rows[0]["LoginRoleID"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(UploadFileEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UploadFile set ");
            strSql.Append(" FileName = @FileName ");
            strSql.Append(", FilePath = @FilePath ");
            strSql.Append(", CreatedDate = @CreatedDate ");          
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4),            
                        new SqlParameter("@FileName", SqlDbType.NVarChar,100), 
                        new SqlParameter("@FilePath", SqlDbType.NVarChar,100),                    
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime)
                                        };
            int idx = 0;
            parameters[idx++].Value = model.ID;
            parameters[idx++].Value = model.FileName;
            parameters[idx++].Value = model.FilePath;
            parameters[idx++].Value = model.CreatedDate;

            int rows = SQLHelper.ExecuteNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}