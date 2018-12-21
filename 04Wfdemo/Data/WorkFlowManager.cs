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
    public class WorkFlowManager
    {
        #region SysRole
        /// <summary>
        /// 获取系统角色
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysRole()
        {
            string strSql = "select * from SysRole";
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysRoleEntity GetSysRoleModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysRole ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetSysRoleModel(ds.Tables[0]);
        }
        /// <summary>
        /// 根据用户ID得到一个对象实体
        /// </summary>
        public static SysRoleEntity GetSysRoleModelByUserID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysRole ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetSysRoleModel(ds.Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static SysRoleEntity GetSysRoleModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                SysRoleEntity model = new SysRoleEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.RoleCode = dt.Rows[0]["RoleCode"].ToString();
                model.RoleName = dt.Rows[0]["RoleName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增加一条角色数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysRole(SysRoleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysRole(");
            strSql.Append("RoleCode,RoleName");
            strSql.Append(") values (");
            strSql.Append("@RoleCode,@RoleName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,50)        
    
                };
            int idx = 0;
            parameters[idx++].Value = model.RoleCode;
            parameters[idx++].Value = model.RoleName;
        
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
        /// 更新角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysRole(SysRoleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysRole set ");
            strSql.Append(" RoleCode = @RoleCode , ");
            strSql.Append(" RoleName = @RoleName ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoleCode", SqlDbType.NVarChar,50),
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,50)
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;
            parameters[idx++].Value = model.RoleCode;
            parameters[idx++].Value = model.RoleName;
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

        /// <summary>
        /// 删除一条角色数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysRole(string ID)
        {
            string strSql = string.Format("delete from SysRole where ID={0}", ID);
            return SQLHelper.ExecuteNonQuery(strSql);
        }
        #endregion

        #region SysRoleUser

        /// <summary>
        /// 根据角色获取系统用户
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public static DataTable GetSysRoleUser(int roleId)
        {
            string strSql = string.Format("select * from SysRoleUser where 1=1 and RoleID={0}", roleId);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
       

        #endregion

        #region SysUser

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysUserEntity GetSysUserModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetSysUserModel(ds.Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static DataTable GetSysUserInfo(string userName, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysRoleUser as ru ");
            strSql.Append(" inner join SysRole as r on ru.RoleID=r.ID ");
            strSql.Append(" inner join SysUser as u on u.ID=ru.UserID");
            strSql.Append(" where u.UserName=@UserName and u.Password=@Password");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50,userName),
                    new SqlParameter("@Password", SqlDbType.VarChar,100,pwd)
			};
            parameters[0].Value = userName;
            parameters[1].Value = pwd;
            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return ds.Tables[0];
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static SysUserEntity GetSysUserModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                SysUserEntity model = new SysUserEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.UserName = dt.Rows[0]["UserName"].ToString();
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.Password = dt.Rows[0]["Password"].ToString();               
                model.Mobile = dt.Rows[0]["Mobile"].ToString();
                model.EMail = dt.Rows[0]["EMail"].ToString();
                model.CardID = dt.Rows[0]["CardID"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="roleID">角色ID集合</param>
        /// <returns></returns>
        public static DataTable GetSysUserByRoleIdList(string roleIdList)
        {
            string strSql = string.Format("select u.* from SysUser u where 1=1 and u.ID in(select r.UserID from SysRoleUser r where r.RoleID in ({0}))", roleIdList);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];

        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public static DataTable GetSysUser(int roleID)
        {
            string strSql = string.Format("select u.* from SysUser u where 1=1 and u.ID in(select r.UserID from SysRoleUser r where r.RoleID={0})", roleID);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }


        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetSysUser(string sqlWhere)
        {
            string strSql = string.Format("select * from SysUser where 1=1 {0} order by CardID", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 增加一条用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysUser(SysUserEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysUser(");
            strSql.Append("LoginName,UserName,AccountType,Status,Password,EMail,Mobile,CardID,CreatedDate");
            strSql.Append(") values (");
            strSql.Append("@LoginName,@UserName,@AccountType,@Status,@Password,@EMail,@Mobile,@CardID,@CreatedDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@LoginName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AccountType", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Password", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@EMail", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Mobile", SqlDbType.NVarChar,20) ,    
                        new SqlParameter("@CardID", SqlDbType.NVarChar,50) ,      
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime,3)             
                };
            int idx = 0;
            parameters[idx++].Value = model.LoginName;
            parameters[idx++].Value = model.UserName;
            parameters[idx++].Value = model.AccountType;
            parameters[idx++].Value = model.Status;
            parameters[idx++].Value = model.Password;
            parameters[idx++].Value = model.EMail;
            parameters[idx++].Value = model.Mobile;
            parameters[idx++].Value = model.CardID; 
            parameters[idx++].Value = model.CreatedDate;
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
        /// 删除一条用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysUser(string ID)
        {
            string strSql = string.Format("delete from SysUser where ID={0}", ID);
            return SQLHelper.ExecuteNonQuery(strSql);
        }


        
        #endregion

        #region HrsLeave
        /// <summary>
        /// 增加一条请假数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddHrsLeave(HrsLeaveEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HrsLeave(");
            strSql.Append("LeaveType,Days,FromDate,ToDate,CurrentActivityText,Status,CreatedUserID,CreatedUserName,CreatedDate,Attachment,KzRemark,FgzzRemark,ZzRemark,LzRemark");
            strSql.Append(") values (");
            strSql.Append("@LeaveType,@Days,@FromDate,@ToDate,@CurrentActivityText,@Status,@CreatedUserID,@CreatedUserName,@CreatedDate,@Attachment,@KzRemark,@FgzzRemark,@ZzRemark,@LzRemark");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@LeaveType", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Days", SqlDbType.Decimal,18) ,            
                        new SqlParameter("@FromDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@ToDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreatedUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreatedUserName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                        new SqlParameter("@Attachment", SqlDbType.NVarChar,100),
                        new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgzzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@LzRemark", SqlDbType.NVarChar,100),
                };
            int idx = 0;
            parameters[idx++].Value = model.LeaveType;
            parameters[idx++].Value = model.Days;
            parameters[idx++].Value = model.FromDate;
            parameters[idx++].Value = model.ToDate;
            parameters[idx++].Value = model.CurrentActivityText;
            parameters[idx++].Value = model.Status;
            parameters[idx++].Value = model.CreatedUserID;
            parameters[idx++].Value = model.CreatedUserName;
            parameters[idx++].Value = model.CreatedDate;
            parameters[idx++].Value = model.Attachment;

            parameters[idx++].Value = model.KzRemark;
            parameters[idx++].Value = model.FgzzRemark;
            parameters[idx++].Value = model.ZzRemark;
            parameters[idx++].Value = model.LzRemark;

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
        /// 更新请假活动步骤数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateHrsLeave(HrsLeaveEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HrsLeave set ");

            strSql.Append(" DepManagerRemark = @DepManagerRemark , ");
            strSql.Append(" DirectorRemark = @DirectorRemark , ");
            strSql.Append(" DeputyGeneralRemark = @DeputyGeneralRemark , ");
            strSql.Append(" GeneralManagerRemark = @GeneralManagerRemark , ");
            strSql.Append(" CurrentActivityText = @CurrentActivityText , ");
            strSql.Append(" KzRemark = @KzRemark , ");
            strSql.Append(" FgzzRemark = @FgzzRemark , ");
            strSql.Append(" ZzRemark = @ZzRemark , ");
            strSql.Append(" LzRemark = @LzRemark ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@DepManagerRemark", SqlDbType.NVarChar,50),
                        new SqlParameter("@DirectorRemark", SqlDbType.NVarChar,50),
                        new SqlParameter("@DeputyGeneralRemark", SqlDbType.NVarChar,50),
                        new SqlParameter("@GeneralManagerRemark", SqlDbType.NVarChar,50),
                        new SqlParameter("@CurrentActivityText", SqlDbType.NVarChar,50),
                        new SqlParameter("@KzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@FgzzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@ZzRemark", SqlDbType.NVarChar,100),
                        new SqlParameter("@LzRemark", SqlDbType.NVarChar,100)
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;
            parameters[idx++].Value = model.DepManagerRemark;
            parameters[idx++].Value = model.DirectorRemark;
            parameters[idx++].Value = model.DeputyGeneralRemark;
            parameters[idx++].Value = model.GeneralManagerRemark;
            parameters[idx++].Value = model.CurrentActivityText;

            parameters[idx++].Value = model.KzRemark;
            parameters[idx++].Value = model.FgzzRemark;
            parameters[idx++].Value = model.ZzRemark;
            parameters[idx++].Value = model.LzRemark;

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



        /// <summary>
        /// 得到一个请假对象实体
        /// </summary>
        /// <param name="ID">请假ID</param>
        /// <returns></returns>
        public static HrsLeaveEntity GetHrsLeaveModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from HrsLeave ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetHrsLeaveModel(ds.Tables[0]);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static HrsLeaveEntity GetHrsLeaveModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                HrsLeaveEntity model = new HrsLeaveEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["LeaveType"].ToString() != "")
                {
                    model.LeaveType = int.Parse(dt.Rows[0]["LeaveType"].ToString());
                }
                if (dt.Rows[0]["Days"].ToString() != "")
                {
                    model.Days = decimal.Parse(dt.Rows[0]["Days"].ToString());
                }
                if (dt.Rows[0]["FromDate"].ToString() != "")
                {
                    model.FromDate = DateTime.Parse(dt.Rows[0]["FromDate"].ToString());
                }
                if (dt.Rows[0]["ToDate"].ToString() != "")
                {
                    model.ToDate = DateTime.Parse(dt.Rows[0]["ToDate"].ToString());
                }
                model.CurrentActivityText = dt.Rows[0]["CurrentActivityText"].ToString();
                if (dt.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(dt.Rows[0]["Status"].ToString());
                }
                if (dt.Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(dt.Rows[0]["CreatedUserID"].ToString());
                }
                model.CreatedUserName = dt.Rows[0]["CreatedUserName"].ToString();
                if (dt.Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(dt.Rows[0]["CreatedDate"].ToString());
                }

                model.DepManagerRemark = dt.Rows[0]["DepManagerRemark"].ToString();
                model.DirectorRemark = dt.Rows[0]["DirectorRemark"].ToString();
                model.DeputyGeneralRemark = dt.Rows[0]["DeputyGeneralRemark"].ToString();
                model.GeneralManagerRemark = dt.Rows[0]["GeneralManagerRemark"].ToString();

                model.KzRemark = dt.Rows[0]["KzRemark"].ToString();
                model.FgzzRemark = dt.Rows[0]["FgzzRemark"].ToString();
                model.ZzRemark = dt.Rows[0]["ZzRemark"].ToString();
                model.LzRemark = dt.Rows[0]["LzRemark"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }




        /// <summary>
        /// 查询请假列表
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeave(string sqlWhere)
        {
            string strSql = string.Format("select * from HrsLeave where 1=1 {0}", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }


        /// <summary>
        /// 查询请假流程实例
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveProcessInstance(string sqlWhere)
        {
            string strSql = string.Format(" SELECT i.*,h.* FROM WfProcessInstance i LEFT JOIN HrsLeave h ON i.AppInstanceID = CONVERT(VARCHAR(50), h.ID) where 1=1 {0} order by i.ID DESC ", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 经办流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetTaskList(string sqlWhere)
        {
            string strSql = string.Format(" SELECT * FROM WfTasks where 1=1 {0} order by ID DESC ", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 我发起的流程
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public static DataTable GetMyProcessInstance(string sqlWhere)
        {
            string strSql = string.Format(" SELECT * FROM WfProcessInstance where 1=1 {0} order by ID DESC ", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
            //StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT T.ID, A.ID as ActivityInstanceID,A.AppName,P.ProcessState,P.Version,P.CreatedByUserName,P.CreatedDateTime,P.ProcessGUID,P.AppInstanceID");
            //sb.Append(" FROM WfProcessInstance as P");
            //sb.Append(" inner join  WfActivityInstance A  on A.AssignedToUserIDs=CAST(P.CreatedByUserID as nvarchar(1000))");
            //sb.Append(" inner join  WfTasks T  on T.ActivityInstanceID=A.ID");
            //sb.AppendFormat(" where 1=1 and P.CreatedByUserID={0}",CreatedByUserID);
           // return SQLHelper.ExecuteDataset(sb.ToString()).Tables[0];
        }
        #endregion

        #region HrsLeaveOpinion
        /// <summary>
        /// 新增一条业务流程数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddHrsLeaveOpinion(HrsLeaveOpinionEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HrsLeaveOpinion(");
            strSql.Append("AppInstanceID,ActivityName,ActivityID,Remark,ChangedTime,ChangedUserID,ChangedUserName,UploadFileID,LoginRoleID");
            strSql.Append(") values (");
            strSql.Append("@AppInstanceID,@ActivityName,@ActivityID,@Remark,@ChangedTime,@ChangedUserID,@ChangedUserName,@UploadFileID,@LoginRoleID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@AppInstanceID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ActivityID", SqlDbType.VarChar,50) ,     
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@ChangedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChangedUserID", SqlDbType.VarChar,50) ,  
                        new SqlParameter("@ChangedUserName", SqlDbType.NVarChar,50) , 
                        new SqlParameter("@UploadFileID", SqlDbType.Int,4) ,  
                        new SqlParameter("@LoginRoleID", SqlDbType.Int,4) 
            };
            int idx = 0;
            parameters[idx++].Value = model.AppInstanceID;
            parameters[idx++].Value = model.ActivityName;
            parameters[idx++].Value = model.ActivityID;
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


        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static HrsLeaveOpinionEntity GetHrsLeaveOpinionModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AppName, AppInstanceID, ActivityName, Remark, ChangedTime, ChangedUserID, ChangedUserName  ");
            strSql.Append("  from HrsLeaveOpinion ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetHrsLeaveOpinionModel(ds.Tables[0]);
        }

        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="AppInstanceID"></param>
        /// <returns></returns>
        public static HrsLeaveOpinionEntity GetHrsLeaveOpinionByAppInstanceID(string AppInstanceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AppName, AppInstanceID, ActivityName, Remark, ChangedTime, ChangedUserID, ChangedUserName  ");
            strSql.Append("  from HrsLeaveOpinion ");
            strSql.Append(" where AppInstanceID=@AppInstanceID");
            SqlParameter[] parameters = {
					new SqlParameter("@AppInstanceID", SqlDbType.VarChar, 50)
			};
            parameters[0].Value = AppInstanceID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetHrsLeaveOpinionModel(ds.Tables[0]);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static HrsLeaveOpinionEntity GetHrsLeaveOpinionModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                HrsLeaveOpinionEntity model = new HrsLeaveOpinionEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }

                model.AppInstanceID = dt.Rows[0]["AppInstanceID"].ToString();
                model.ActivityName = dt.Rows[0]["ActivityName"].ToString();
                model.ActivityID = dt.Rows[0]["ActivityID"].ToString();
                model.Remark = dt.Rows[0]["Remark"].ToString();
                if (dt.Rows[0]["ChangedTime"].ToString() != "")
                {
                    model.ChangedTime = DateTime.Parse(dt.Rows[0]["ChangedTime"].ToString());
                }
                if (dt.Rows[0]["ChangedUserID"].ToString() != "")
                {
                    model.ChangedUserID = dt.Rows[0]["ChangedUserID"].ToString();
                }
                model.ChangedUserName = dt.Rows[0]["ChangedUserName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveOpinion(string sqlWhere)
        {
            string strSql = string.Format("select * from HrsLeaveOpinion where 1=1 {0}", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }

        /// <summary>
        /// 查询请假处理过程
        /// </summary>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveOpinionListByAppInstanceID(string AppInstanceID)
        {
            string strSql = string.Format("select * from HrsLeaveOpinion where 1=1  and AppInstanceID='{0}'", AppInstanceID);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }

        /// <summary>
        /// 查询处理过程
        /// </summary>
        /// <param name="StrTable">应用表名称</param>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetOpinionListByAppInstanceID(int KStype,string StrTable,string AppInstanceID)
        {
          
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from {0} where 1=1 ", StrTable);
            strSql.Append("and AppInstanceID=@AppInstanceID ");           

            #region 科室
            if (KStype == 1)
            {
                //质管科
                strSql.Append("and LoginRoleID in (6,23,26,27,28,29,30,16,25) ");
            }
            else if (KStype == 2)
            {
                //技信科
                strSql.Append("and LoginRoleID in (6,23,31,32,33,34,35,16,25) ");
            }
            else if (KStype == 3)
            {
                //安管科
                strSql.Append("and LoginRoleID in (6,23,36,37,38,39,40,16,25) ");
            }
            else if (KStype == 4)
            {
                //市监科
                strSql.Append("and LoginRoleID in (6,23,41,42,43,44,45,16,25) ");
            }
            else if (KStype == 5)
            {
                //工监科
                strSql.Append("and LoginRoleID in (6,23,46,47,48,49,50,16,25) ");
            }
            else if (KStype == 6)
            {
                //工巡科
                strSql.Append("and LoginRoleID in (6,23,51,52,53,54,55,16,25) ");
            }
            else if (KStype == 7)
            {
                //信访办
                strSql.Append("and LoginRoleID in (6,23,56,57,58,59,60,16,25) ");
            }
            else if (KStype == 8)
            {
                //执查科
                strSql.Append("and LoginRoleID in (6,23,61,62,63,64,65,16,25) ");
            }
            else if (KStype == 9)
            {
                //总师室
                strSql.Append("and LoginRoleID in (6,23,66,67,68,69,70,16,25) ");
            }
            else if (KStype == 10)
            {
                //办公室
                strSql.Append("and LoginRoleID in (6,23,71,72,73,74,16,25) ");
            }
            #endregion

            SqlParameter[] parameters = {                    
					new SqlParameter("@AppInstanceID", SqlDbType.Int,4)
			};
            parameters[0].Value = AppInstanceID;            
            return SQLHelper.ExecuteDataset(strSql.ToString(),parameters).Tables[0];
        }
        /// <summary>
        /// 查询处理过程
        /// </summary>
        /// <param name="StrTable">应用表名称</param>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetOpinionListByAppInstanceID(string StrTableName,string AppInstanceID)
        {            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT U.FilePath,F.ChangedUserName,F.ActivityName,F.Remark,F.ChangedTime ");
            strSql.Append("  FROM UploadFile as U ");
            strSql.AppendFormat("  inner join {0} as F ", StrTableName);
            strSql.Append("  on U.ID=F.UploadFileID ");
            strSql.Append(" where AppInstanceID=@AppInstanceID");
            //取最新上传的附件
            strSql.Append(" and U.ID=(select max(ID) from UploadFile Y where Y.CreatedUserID=F.ChangedUserID)");              
   
            SqlParameter[] parameters = {
					new SqlParameter("@AppInstanceID", SqlDbType.Int,4)
			};
            parameters[0].Value = AppInstanceID;
            return SQLHelper.ExecuteDataset(strSql.ToString(), parameters).Tables[0];
        }
        public static DataTable GetOpinionSummary(string StrTableName, string AppInstanceID)
        {
            StringBuilder strSql = new StringBuilder();           
            strSql.Append("SELECT U.FilePath,F.ChangedUserName,F.ActivityName,F.Remark,F.ChangedTime ");
            strSql.Append("  FROM UploadFile as U ");
            strSql.AppendFormat("  inner join {0} as F ", StrTableName);
            strSql.Append("  on U.ID=F.UploadFileID ");
            strSql.AppendFormat(" where U.ID in(SELECT MAX(U.ID) FROM UploadFile as U   inner join {0} as F  on U.ID=F.UploadFileID  where AppInstanceID=@AppInstanceID and F.LoginRoleID in(6,16))", StrTableName);
            SqlParameter[] parameters = {
					new SqlParameter("@AppInstanceID", SqlDbType.Int,4)
			};
            parameters[0].Value = AppInstanceID;
            return SQLHelper.ExecuteDataset(strSql.ToString(), parameters).Tables[0];
        }
        #endregion

        #region BizAppFlow
        /// <summary>
        /// 新增一条业务流程数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddBizAppFlow(BizAppFlowEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BizAppFlow(");
            strSql.Append("AppName,AppInstanceID,ActivityName,Remark,ChangedTime,ChangedUserID,ChangedUserName");
            strSql.Append(") values (");
            strSql.Append("@AppName,@AppInstanceID,@ActivityName,@Remark,@ChangedTime,@ChangedUserID,@ChangedUserName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AppName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AppInstanceID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@ChangedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChangedUserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ChangedUserName", SqlDbType.NVarChar,50)             
            };
            int idx = 0;
            parameters[idx++].Value = model.AppName;
            parameters[idx++].Value = model.AppInstanceID;
            parameters[idx++].Value = model.ActivityName;
            parameters[idx++].Value = model.Remark;
            parameters[idx++].Value = model.ChangedTime;
            parameters[idx++].Value = model.ChangedUserID;
            parameters[idx++].Value = model.ChangedUserName;

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
        /// 得到业务公共实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static BizAppFlowEntity GetBizAppFlowModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AppName, AppInstanceID, ActivityName, Remark, ChangedTime, ChangedUserID, ChangedUserName  ");
            strSql.Append("  from BizAppFlow ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetBizAppFlowModel(ds.Tables[0]);
        }

        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="AppInstanceID"></param>
        /// <returns></returns>
        public static BizAppFlowEntity GetBizAppFlowModelByAppInstanceID(string AppInstanceID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AppName, AppInstanceID, ActivityName, Remark, ChangedTime, ChangedUserID, ChangedUserName  ");
            strSql.Append("  from BizAppFlow ");
            strSql.Append(" where AppInstanceID=@AppInstanceID");
            SqlParameter[] parameters = {
					new SqlParameter("@AppInstanceID", SqlDbType.VarChar, 50)
			};
            parameters[0].Value = AppInstanceID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetBizAppFlowModel(ds.Tables[0]);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static BizAppFlowEntity GetBizAppFlowModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                BizAppFlowEntity model = new BizAppFlowEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.AppName = dt.Rows[0]["AppName"].ToString();
                model.AppInstanceID = dt.Rows[0]["AppInstanceID"].ToString();
                model.ActivityName = dt.Rows[0]["ActivityName"].ToString();
                model.Remark = dt.Rows[0]["Remark"].ToString();
                if (dt.Rows[0]["ChangedTime"].ToString() != "")
                {
                    model.ChangedTime = DateTime.Parse(dt.Rows[0]["ChangedTime"].ToString());
                }
                if (dt.Rows[0]["ChangedUserID"].ToString() != "")
                {
                    model.ChangedUserID = dt.Rows[0]["ChangedUserID"].ToString();
                }
                model.ChangedUserName = dt.Rows[0]["ChangedUserName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetBizAppFlow(string sqlWhere)
        {
            string strSql = string.Format("select * from BizAppFlow where 1=1 {0}", sqlWhere);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetBizAppFlowByAppInstanceID(string AppInstanceID)
        {
            string strSql = string.Format("select * from BizAppFlow where 1=1  and AppInstanceID='{0}'", AppInstanceID);
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }

        #endregion

        #region SysMenu
         /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysMenu()
        {
            string strSql = "select * from SysMenu";
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }


        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysMenu(SysMenuEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysMenu set ");
            strSql.Append(" MenuName = @MenuName , ");
            strSql.Append(" MenuUrl = @MenuUrl ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
                        new SqlParameter("@MenuUrl", SqlDbType.NVarChar,150)
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;
            parameters[idx++].Value = model.MenuName;
            parameters[idx++].Value = model.MenuUrl;
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysMenuEntity GetSysMenuModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysMenu ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetSysMenuModel(ds.Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static SysMenuEntity GetSysMenuModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                SysMenuEntity model = new SysMenuEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.MenuName = dt.Rows[0]["MenuName"].ToString();
                model.MenuUrl = dt.Rows[0]["MenuUrl"].ToString();
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
        public static int AddSysMenu(SysMenuEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysMenu (");
            strSql.Append("MenuName,MenuUrl");
            strSql.Append(") values (");
            strSql.Append("@MenuName,@MenuUrl");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RoleCode", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@RoleName", SqlDbType.NVarChar,150)        
    
                };
            int idx = 0;
            parameters[idx++].Value = model.MenuName;
            parameters[idx++].Value = model.MenuUrl;

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
        /// 删除一条角色数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysMenu(string ID)
        {
            string strSql = string.Format("delete from SysMenu where ID={0}", ID);
            return SQLHelper.ExecuteNonQuery(strSql);
        }
        #endregion


        #region SysMenuUser

        /// <summary>
        /// 获取系统角色
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysMenuUser()
        {
            string strSql = "select * from SysMenuUser";
            return SQLHelper.ExecuteDataset(strSql).Tables[0];
        }
        /// <summary>
        /// 根据用户获取相应菜单
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="ParentID">菜单的父级ID</param>
        /// <returns></returns>
        public static DataTable GetMenuList(int UserID, int ParentID)
        {         
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *  FROM [WfDB].[dbo].[SysMenuUser] as MU");
            strSql.Append("  inner join [WfDB].[dbo].[SysMenu] as M on MU.MenuID=M.ID ");
            strSql.Append(" where MU.UserID=@UserID and M.ParentID=@ParentID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ParentID", SqlDbType.Int,4)
			};
            parameters[0].Value = UserID;
            parameters[1].Value = ParentID;
            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return ds.Tables[0];
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysMenuUser(SysMenuUserEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysMenuUser (");
            strSql.Append("MenuID,UserID");
            strSql.Append(") values (");
            strSql.Append("@MenuID,@UserID");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@MenuID", SqlDbType.Int,4),            
                        new SqlParameter("@UserID", SqlDbType.Int,4)        
    
                };
            int idx = 0;
            parameters[idx++].Value = model.MenuID;
            parameters[idx++].Value = model.UserID;

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
        public static SysMenuUserEntity GetSysMenuUserModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysMenuUser ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            return GetSysMenuUserModel(ds.Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private static SysMenuUserEntity GetSysMenuUserModel(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                SysMenuUserEntity model = new SysMenuUserEntity();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["MenuID"].ToString() != "")
                {
                    model.MenuID = int.Parse(dt.Rows[0]["MenuID"].ToString());
                }
                if (dt.Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                }               
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysMenuUser(SysMenuUserEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysMenuUser set ");
            strSql.Append(" MenuID = @MenuID , ");
            strSql.Append(" UserID = @UserID ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,     
                        new SqlParameter("@MenuID", SqlDbType.Int,4) ,
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,
            };
            int idx = 0;
            parameters[idx++].Value = model.ID;
            parameters[idx++].Value = model.MenuID;
            parameters[idx++].Value = model.UserID;
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysMenuUser(string ID)
        {
            string strSql = string.Format("delete from SysMenuUser where ID={0}", ID);
            return SQLHelper.ExecuteNonQuery(strSql);
        }
        #endregion

        public static bool IsResend(string AppInstanceID, string UserID)
        {
            bool flag = false;


            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM [vwWfActivityInstanceTasks] ");
            strSql.Append("where AppInstanceID=@AppInstanceID ");
            strSql.Append("and PreviousUserID=@UserID ");
            strSql.Append("and ActivityState=7 ");
            SqlParameter[] parameters = {
					new SqlParameter("@AppInstanceID", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = AppInstanceID;
            parameters[1].Value = UserID;
            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0] != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 判断是否为办公室（党委办公室）用户发起
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public static bool IsStartedByBgsUser(int instanceId,int tableType)
        {
            bool flag = false;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM {0} as P ", tableType == 1 ? "Procurement" : "Contract");
            strSql.Append("inner join SysUser as U ");
            strSql.Append("on P.CreatedUserID=U.ID ");
            strSql.Append("where P.ID=@instanceId and U.DeptID=19 ");
            SqlParameter[] parameters = {
					new SqlParameter("@instanceId", SqlDbType.Int,4)                 
			};
            parameters[0].Value = instanceId;            
            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0] != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }

            return flag;
        }
       
        public static List<string> GetCurrUserRoleIDlist(int UserID)
        {
            var list = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from SysRoleUser ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID",SqlDbType.Int,4)                 
			};
            parameters[0].Value = UserID;          
            DataSet ds = SQLHelper.ExecuteDataset(strSql.ToString(), parameters);
            if (ds.Tables[0] != null && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(ds.Tables[0].Rows[i]["RoleID"].ToString());
                }
            }

            return list;
        }
    }
}