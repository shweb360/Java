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
    public class FinancialOpinionDll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(FinancialOpinionEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FinancialOpinion(");
            strSql.Append("AppInstanceID,ActivityID,ActivityName,Remark,ChangedTime,ChangedUserID,ChangedUserName,UploadFileID,LoginRoleID");
            strSql.Append(") values (");
            strSql.Append("@AppInstanceID,@ActivityID,@ActivityName,@Remark,@ChangedTime,@ChangedUserID,@ChangedUserName,@UploadFileID,@LoginRoleID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AppInstanceID", SqlDbType.VarChar,50),            
                        new SqlParameter("@ActivityID", SqlDbType.VarChar,500),
                        new SqlParameter("@ActivityName", SqlDbType.NVarChar,50),
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
                        new SqlParameter("@ChangedTime", SqlDbType.DateTime),
                        new SqlParameter("@ChangedUserID", SqlDbType.Int,4),
                        new SqlParameter("@ChangedUserName", SqlDbType.NVarChar,50),
                        new SqlParameter("@UploadFileID", SqlDbType.Int,4),
                        new SqlParameter("@LoginRoleID", SqlDbType.Int,4)
                        
                };
            int idx = 0;
            parameters[idx++].Value = model.AppInstanceID;
            parameters[idx++].Value = model.ActivityID;
            parameters[idx++].Value = model.ActivityName;
            parameters[idx++].Value = model.Remark;
            parameters[idx++].Value = model.ChangedTime;
            parameters[idx++].Value = model.ChangedUserID;
            parameters[idx++].Value = model.ChangedUserName;
            parameters[idx++].Value = model.UploadFileID;
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
    }
}