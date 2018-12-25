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
    public class ContractDll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(ContractEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Contract(");
            strSql.Append("ApplyTitle,ApplyType,PartyA,PartyB,SigningDate,Amount,TimeLimit,Remark,Attachment,CurrentActivityText,CreatedUserID,CreatedUserName,Status,CreatedDate,KzRemark,CwzgRemark,BgsfzrRemark,FgzzRemark,ZzRemark");
            strSql.Append(") values (");
            strSql.Append("@ApplyTitle,@ApplyType,@PartyA,@PartyB,@SigningDate,@Amount,@TimeLimit,@Remark,@Attachment,@CurrentActivityText,@CreatedUserID,@CreatedUserName,@Status,@CreatedDate,@KzRemark,@CwzgRemark,@BgsfzrRemark,@FgzzRemark,@ZzRemark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ApplyTitle", SqlDbType.NVarChar,50),  
                        new SqlParameter("@ApplyType", SqlDbType.Int,4),
                        new SqlParameter("@PartyA", SqlDbType.NVarChar,100),
                        new SqlParameter("@PartyB", SqlDbType.NVarChar,100),
                        new SqlParameter("@SigningDate", SqlDbType.DateTime),
                        new SqlParameter("@Amount", SqlDbType.Decimal,4),
                        new SqlParameter("@TimeLimit", SqlDbType.NVarChar,50),
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
                        new SqlParameter("@Attachment", SqlDbType.NVarChar,100),
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),
                        new SqlParameter("@CreatedUserID", SqlDbType.Int,4),
                        new SqlParameter("@CreatedUserName", SqlDbType.NVarChar,50),
                        new SqlParameter("@Status", SqlDbType.Int,4),
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                        new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@CwzgRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@BgsfzrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgzzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100)
                };
            int idx = 0;
            parameters[idx++].Value = model.ApplyTitle;
            parameters[idx++].Value = model.ApplyType;
            parameters[idx++].Value = model.PartyA;
            parameters[idx++].Value = model.PartyB;
            parameters[idx++].Value = model.SigningDate;
            parameters[idx++].Value = model.Amount;
            parameters[idx++].Value = model.TimeLimit;
            parameters[idx++].Value = model.Remark;
            parameters[idx++].Value = model.Attachment;
            parameters[idx++].Value = model.CurrentActivityText;
            parameters[idx++].Value = model.CreatedUserID;
            parameters[idx++].Value = model.CreatedUserName;
            parameters[idx++].Value = model.Status;
            parameters[idx++].Value = model.CreatedDate;

            parameters[idx++].Value = model.KzRemark;
            parameters[idx++].Value = model.CwzgRemark ;
            parameters[idx++].Value = model.BgsfzrRemark;
            parameters[idx++].Value = model.FgzzRemark;
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
        public static ContractEntity GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from Contract ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetModel(ds.Tables[0]);
        }
        private static ContractEntity GetModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                ContractEntity model = new ContractEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["ApplyType"].ToString() != "")
                {
                    model.ApplyType = int.Parse(dt.Rows[0]["ApplyType"].ToString());
                }
                model.ApplyTitle = dt.Rows[0]["ApplyTitle"].ToString();
                model.PartyA = dt.Rows[0]["PartyA"].ToString();
                model.PartyB = dt.Rows[0]["PartyB"].ToString();

                if (dt.Rows[0]["SigningDate"].ToString() != "")
                {
                    model.SigningDate = Convert.ToDateTime(dt.Rows[0]["SigningDate"].ToString());
                }
                if (dt.Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
                }
                
                model.TimeLimit = dt.Rows[0]["TimeLimit"].ToString();
                model.Remark = dt.Rows[0]["Remark"].ToString();
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

                model.KzRemark = dt.Rows[0]["KzRemark"].ToString();
                model.CwzgRemark = dt.Rows[0]["CwzgRemark"].ToString();
                model.BgsfzrRemark = dt.Rows[0]["BgsfzrRemark"].ToString();
                model.FgzzRemark = dt.Rows[0]["FgzzRemark"].ToString();
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
        public static bool Update(ContractEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Contract set ");


            strSql.Append(" CurrentActivityText = @CurrentActivityText ");
            strSql.Append(", KzRemark = @KzRemark ");
            strSql.Append(", CwzgRemark = @CwzgRemark ");
            strSql.Append(", BgsfzrRemark = @BgsfzrRemark ");
            strSql.Append(", FgzzRemark = @FgzzRemark ");
            strSql.Append(", ZzRemark = @ZzRemark ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                  
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),
                        new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@CwzgRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@BgsfzrRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgzzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100)
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;

            parameters[idx++].Value = model.CurrentActivityText;

            parameters[idx++].Value = model.KzRemark;
            parameters[idx++].Value = model.CwzgRemark;
            parameters[idx++].Value = model.BgsfzrRemark;
            parameters[idx++].Value = model.FgzzRemark;
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