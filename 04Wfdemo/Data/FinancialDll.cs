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
    public class FinancialDll
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetList()
        {
            string strSql = "select * from Financial";
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FinancialEntity GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from Financial ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }
        private static FinancialEntity GetModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                FinancialEntity model = new FinancialEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }

                model.ApplyTitle = dt.Rows[0]["ApplyTitle"].ToString();
                model.ApplyContent = dt.Rows[0]["ApplyContent"].ToString();
                if(dt.Rows[0]["ApplyDate"].ToString() != "")
                {
                    model.ApplyDate = Convert.ToDateTime(dt.Rows[0]["ApplyDate"].ToString());
                }
                if (dt.Rows[0]["FinancialType"].ToString() != "")
                {
                    model.FinancialType = Convert.ToInt32(dt.Rows[0]["FinancialType"].ToString());
                }
                model.CurrentActivityText = dt.Rows[0]["CurrentActivityText"].ToString();
                if (dt.Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = Convert.ToInt32(dt.Rows[0]["CreatedUserID"].ToString());
                }                
                model.CreatedUserName = dt.Rows[0]["CreatedUserName"].ToString();               
                model.AKsfzrRemark = dt.Rows[0]["AKsfzrRemark"].ToString();
                model.AKsfgldRemark = dt.Rows[0]["AKsfgldRemark"].ToString();
                model.ZzRemark = dt.Rows[0]["ZzRemark"].ToString();
                model.BKsfzrRemark = dt.Rows[0]["BKsfzrRemark"].ToString();
                model.BKsfgldRemark = dt.Rows[0]["BKsfgldRemark"].ToString();
                model.KzRemark = dt.Rows[0]["KzRemark"].ToString();
                model.FgldRemark = dt.Rows[0]["FgldRemark"].ToString();
                model.CwRemark = dt.Rows[0]["CwRemark"].ToString();
                if (dt.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(dt.Rows[0]["Status"].ToString());
                }        
                if (dt.Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"].ToString());
                }
                model.Attachment = dt.Rows[0]["Attachment"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(FinancialEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Financial(");
            strSql.Append("ApplyTitle,ApplyContent,ApplyDate,FinancialType,CurrentActivityText,CreatedUserID,CreatedUserName,Status,CreatedDate,Attachment,AKsfzrRemark,AKsfgldRemark,ZzRemark,BKsfzrRemark,BKsfgldRemark,KzRemark,FgldRemark,CwRemark");
            strSql.Append(") values (");
            strSql.Append("@ApplyTitle,@ApplyContent,@ApplyDate,@FinancialType,@CurrentActivityText,@CreatedUserID,@CreatedUserName,@Status,@CreatedDate,@Attachment,@AKsfzrRemark,@AKsfgldRemark,@ZzRemark,@BKsfzrRemark,@BKsfgldRemark,@KzRemark,@FgldRemark,@CwRemark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                            new SqlParameter("@ApplyTitle", SqlDbType.NVarChar,50),            
                            new SqlParameter("@ApplyContent", SqlDbType.NVarChar,500),
                            new SqlParameter("@ApplyDate", SqlDbType.DateTime),
                            new SqlParameter("@FinancialType", SqlDbType.SmallInt,2),
                            new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),
                            new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
                            new SqlParameter("@CreatedUserName", SqlDbType.NVarChar,500),
                            new SqlParameter("@Status", SqlDbType.Int,4),
                            new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                            new SqlParameter("@Attachment", SqlDbType.NVarChar,100),

                            new SqlParameter("@AKsfzrRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@AKsfgldRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@BKsfzrRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@BKsfgldRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@FgldRemark", SqlDbType.NVarChar,100),
                            new SqlParameter("@CwRemark", SqlDbType.NVarChar,100)
                            };
            int idx = 0;
            parameters[idx++].Value = model.ApplyTitle;
            parameters[idx++].Value = model.ApplyContent;
            parameters[idx++].Value = model.ApplyDate;
            parameters[idx++].Value = model.FinancialType;
            parameters[idx++].Value = model.CurrentActivityText;
            parameters[idx++].Value = model.CreatedUserID;
            parameters[idx++].Value = model.CreatedUserName;
            parameters[idx++].Value = model.Status;
            parameters[idx++].Value = model.CreatedDate;
            parameters[idx++].Value = model.Attachment;

            parameters[idx++].Value = model.AKsfzrRemark;
            parameters[idx++].Value = model.AKsfgldRemark;
            parameters[idx++].Value = model.ZzRemark;
            parameters[idx++].Value = model.BKsfzrRemark;
            parameters[idx++].Value = model.BKsfgldRemark;
            parameters[idx++].Value = model.KzRemark;
            parameters[idx++].Value = model.FgldRemark;
            parameters[idx++].Value = model.CwRemark;

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
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(FinancialEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Financial set ");

           
            strSql.Append(" CurrentActivityText = @CurrentActivityText ");
            strSql.Append(", AKsfzrRemark = @AKsfzrRemark ");
            strSql.Append(", AKsfgldRemark = @AKsfgldRemark ");
            strSql.Append(", ZzRemark = @ZzRemark ");
            strSql.Append(", BKsfzrRemark = @BKsfzrRemark ");
            strSql.Append(", BKsfgldRemark = @BKsfgldRemark ");            
            strSql.Append(", KzRemark = @KzRemark ");
            strSql.Append(", FgldRemark = @FgldRemark ");
            strSql.Append(", CwRemark = @CwRemark ");


            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),

                        new SqlParameter("@AKsfzrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@AKsfgldRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@BKsfzrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@BKsfgldRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgldRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@CwRemark", SqlDbType.NVarChar,100),
                        
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;          
            parameters[idx++].Value = model.CurrentActivityText;

            parameters[idx++].Value = model.AKsfzrRemark != null ? model.AKsfzrRemark : "";
            parameters[idx++].Value = model.AKsfgldRemark != null ? model.AKsfgldRemark : "";
            parameters[idx++].Value = model.ZzRemark != null ? model.ZzRemark : "";
            parameters[idx++].Value = model.BKsfzrRemark != null ? model.BKsfzrRemark : "";
            parameters[idx++].Value = model.BKsfgldRemark != null ? model.BKsfgldRemark : "";
            parameters[idx++].Value = model.KzRemark != null ? model.KzRemark : "";
            parameters[idx++].Value = model.FgldRemark != null ? model.FgldRemark : "";
            parameters[idx++].Value = model.CwRemark != null ? model.CwRemark : "";
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