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
    public class ProcurementDll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(ProcurementEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Procurement(");
            strSql.Append("ApplyTitle,ApplyNumber,ApplyContent,ApplyDate,Attachment,CurrentActivityText,CreatedUserID,CreatedUserName,Status,CreatedDate,KsfzRemark,FgldRemark,CgjbrRemark,ZzRemark");
            strSql.Append(") values (");
            strSql.Append("@ApplyTitle,@ApplyNumber,@ApplyContent,@ApplyDate,@Attachment,@CurrentActivityText,@CreatedUserID,@CreatedUserName,@Status,@CreatedDate,@KsfzRemark,@FgldRemark,@CgjbrRemark,@ZzRemark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ApplyTitle", SqlDbType.NVarChar,50),  
                        new SqlParameter("@ApplyNumber", SqlDbType.Decimal,4),
                        new SqlParameter("@ApplyContent", SqlDbType.NVarChar,500),
                        new SqlParameter("@ApplyDate", SqlDbType.DateTime),
                        new SqlParameter("@Attachment", SqlDbType.NVarChar,100),
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),
                        new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
                        new SqlParameter("@CreatedUserName", SqlDbType.NVarChar,500),
                        new SqlParameter("@Status", SqlDbType.Int,4),
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                        new SqlParameter("@KsfzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgldRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@CgjbrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100)
                };
            int idx = 0;
            parameters[idx++].Value = model.ApplyTitle;
            parameters[idx++].Value = model.ApplyNumber;
            parameters[idx++].Value = model.ApplyContent;
            parameters[idx++].Value = model.ApplyDate;
            parameters[idx++].Value = model.Attachment;
            parameters[idx++].Value = model.CurrentActivityText;
            parameters[idx++].Value = model.CreatedUserID;
            parameters[idx++].Value = model.CreatedUserName;
            parameters[idx++].Value = model.Status;
            parameters[idx++].Value = model.CreatedDate;

            parameters[idx++].Value = model.KsfzRemark;
            parameters[idx++].Value = model.FgldRemark;
            parameters[idx++].Value = model.CgjbrRemark;
            parameters[idx++].Value = model.ZzRemark;

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
        public static ProcurementEntity GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from Procurement ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }
        private static ProcurementEntity GetModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                ProcurementEntity model = new ProcurementEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }

                model.ApplyTitle = dt.Rows[0]["ApplyTitle"].ToString();
                model.ApplyContent = dt.Rows[0]["ApplyContent"].ToString();
                if (dt.Rows[0]["ApplyDate"].ToString() != "")
                {
                    model.ApplyDate = Convert.ToDateTime(dt.Rows[0]["ApplyDate"].ToString());
                }
                if (dt.Rows[0]["ApplyNumber"].ToString() != "")
                {
                    model.ApplyNumber = Convert.ToDecimal(dt.Rows[0]["ApplyNumber"].ToString());
                }
                model.Attachment = dt.Rows[0]["Attachment"].ToString();
                model.CurrentActivityText = dt.Rows[0]["CurrentActivityText"].ToString();
                if (dt.Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = Convert.ToInt32(dt.Rows[0]["CreatedUserID"].ToString());
                }
                model.CreatedUserName = dt.Rows[0]["CreatedUserName"].ToString();
                if (dt.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(dt.Rows[0]["Status"].ToString());
                }
                if (dt.Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString());
                }
                model.KsfzRemark = dt.Rows[0]["KsfzRemark"].ToString();
                model.FgldRemark = dt.Rows[0]["FgldRemark"].ToString();
                model.CgjbrRemark = dt.Rows[0]["CgjbrRemark"].ToString();
                model.ZzRemark = dt.Rows[0]["ZzRemark"].ToString();
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
        public static bool Update(ProcurementEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Procurement set ");


            strSql.Append(" CurrentActivityText = @CurrentActivityText ");
            strSql.Append(", KsfzRemark = @KsfzRemark ");
            strSql.Append(", FgldRemark = @FgldRemark ");
            strSql.Append(", CgjbrRemark = @CgjbrRemark ");
            strSql.Append(", ZzRemark = @ZzRemark ");

            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,                              
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),

                        new SqlParameter("@KsfzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgldRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@CgjbrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100)
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;

            parameters[idx++].Value = model.CurrentActivityText;

            parameters[idx++].Value = model.KsfzRemark;
            parameters[idx++].Value = model.FgldRemark;
            parameters[idx++].Value = model.CgjbrRemark;
            parameters[idx++].Value = model.ZzRemark;

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