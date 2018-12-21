using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Slickflow.WebDemo.Data;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;


namespace Slickflow.WebDemo.Business
{
    public class WorkFlows
    {
        #region SysRole
        /// <summary>
        /// 获取系统角色
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysRole()
        {
            return WorkFlowManager.GetSysRole();
        }
        /// <summary>
        /// 增加一条角色数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysRole(SysRoleEntity model)
        {
            return WorkFlowManager.AddSysRole(model);
        }
        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysRole(SysRoleEntity model)
        {
            return WorkFlowManager.UpdateSysRole(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysRoleEntity GetSysRoleModel(int ID)
        {
            return WorkFlowManager.GetSysRoleModel(ID);
        }
        /// <summary>
        /// 根据用户ID得到一个对象实体
        /// </summary>
        public static SysRoleEntity GetSysRoleModelByUserID(int UserID)
        {
            return WorkFlowManager.GetSysRoleModelByUserID(UserID);
        }

        /// <summary>
        /// 删除一条角色数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysRole(string ID)
        {
            return WorkFlowManager.DeleteSysRole(ID);
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
            return WorkFlowManager.GetSysRoleUser(roleId);
        }
        #endregion


        #region SysUser
        /// <summary>
        /// 得到用户对象实体
        /// </summary>
        /// <param name="ID">用户ID</param>
        /// <returns></returns>
        public static SysUserEntity GetSysUserModel(int ID)
        {
            return WorkFlowManager.GetSysUserModel(ID);
        }
        public static DataTable GetSysUserInfo(string userName, string pwd)
        {
            return WorkFlowManager.GetSysUserInfo(userName, pwd);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="roleID">角色ID集合</param>
        /// <returns></returns>
        public static DataTable GetSysUserByRoleIdList(string roleIdList)
        {
            return WorkFlowManager.GetSysUserByRoleIdList(roleIdList);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public static DataTable GetSysUser(int roleID)
        {
            return WorkFlowManager.GetSysUser(roleID);
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetSysUser(string sqlWhere)
        {
            return WorkFlowManager.GetSysUser(sqlWhere);
        }

        /// <summary>
        /// 增加一条用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysUser(SysUserEntity model)
        {
            return WorkFlowManager.AddSysUser(model);
        }
        /// <summary>
        /// 删除一条用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysUser(string ID)
        {
            return WorkFlowManager.DeleteSysUser(ID);
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
            return WorkFlowManager.AddHrsLeave(model);
        }
        /// <summary>
        /// 更新请假活动步骤数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateHrsLeave(HrsLeaveEntity model)
        {
            return WorkFlowManager.UpdateHrsLeave(model);
        }

        /// <summary>
        /// 得到一个请假对象实体
        /// </summary>
        /// <param name="ID">请假ID</param>
        /// <returns></returns>
        public static HrsLeaveEntity GetHrsLeaveModel(int ID)
        {
            return WorkFlowManager.GetHrsLeaveModel(ID);
        }

        /// <summary>
        /// 查询请假列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHrsLeave()
        {
            return GetHrsLeave(string.Empty);
        }

        /// <summary>
        /// 查询请假列表
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeave(string sqlWhere)
        {
            return WorkFlowManager.GetHrsLeave(sqlWhere);
        }

        /// <summary>
        /// 查询请假流程实例
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveProcessInstance()
        {
            return GetHrsLeaveProcessInstance(string.Empty);
        }

        /// <summary>
        /// 查询请假流程实例
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveProcessInstance(string sqlWhere)
        {
            return WorkFlowManager.GetHrsLeaveProcessInstance(sqlWhere);
        }
        /// <summary>
        /// 经办流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetTaskList(string sqlWhere)
        {
            return WorkFlowManager.GetTaskList(sqlWhere);
        }
         /// <summary>
        /// 我发起的流程
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public static DataTable GetMyProcessInstance(string sqlWhere)
        {
            return WorkFlowManager.GetMyProcessInstance(sqlWhere);
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
            model.ChangedTime = DateTime.Now;
            return WorkFlowManager.AddHrsLeaveOpinion(model);
        }


        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static HrsLeaveOpinionEntity GetHrsLeaveOpinionModel(int ID)
        {
            return WorkFlowManager.GetHrsLeaveOpinionModel(ID);
        }

        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="AppInstanceID"></param>
        /// <returns></returns>
        public static HrsLeaveOpinionEntity GetHrsLeaveOpinionByAppInstanceID(string AppInstanceID)
        {
            return WorkFlowManager.GetHrsLeaveOpinionByAppInstanceID(AppInstanceID);
        }



        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveOpinion(string sqlWhere)
        {
            return WorkFlowManager.GetHrsLeaveOpinion(sqlWhere);
        }

        /// <summary>
        /// 查询请假处理过程
        /// </summary>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetHrsLeaveOpinionListByAppInstanceID(string AppInstanceID)
        {
            return WorkFlowManager.GetHrsLeaveOpinionListByAppInstanceID(AppInstanceID);
        }

        /// <summary>
        /// 查询处理过程
        /// </summary>
        /// <param name="StrTable">应用表名称</param>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetOpinionListByAppInstanceID(int KStype,string StrTable, string AppInstanceID)
        {
            return WorkFlowManager.GetOpinionListByAppInstanceID(KStype, StrTable, AppInstanceID);
        }
        /// <summary>
        /// 查询处理过程
        /// </summary>      
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetOpinionListByAppInstanceID(string StrTableName,string AppInstanceID)
        {
            return WorkFlowManager.GetOpinionListByAppInstanceID(StrTableName,AppInstanceID);
        }
        public static DataTable GetOpinionSummary(string StrTableName, string AppInstanceID)
        {
            return WorkFlowManager.GetOpinionSummary(StrTableName, AppInstanceID);
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
            return WorkFlowManager.AddBizAppFlow(model);
        }
        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static BizAppFlowEntity GetBizAppFlowModel(int ID)
        {
            return WorkFlowManager.GetBizAppFlowModel(ID);
        }

        /// <summary>
        /// 得到业务公共实体
        /// </summary>
        /// <param name="AppInstanceID"></param>
        /// <returns></returns>
        public static BizAppFlowEntity GetBizAppFlowModelByAppInstanceID(string AppInstanceID)
        {
            return WorkFlowManager.GetBizAppFlowModelByAppInstanceID(AppInstanceID);
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBizAppFlow()
        {
            return GetBizAppFlow(string.Empty);
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public static DataTable GetBizAppFlow(string sqlWhere)
        {
            return WorkFlowManager.GetBizAppFlow(sqlWhere);
        }

        /// <summary>
        /// 查询业务流程
        /// </summary>
        /// <param name="AppInstanceID">应用实例ID</param>
        /// <returns></returns>
        public static DataTable GetBizAppFlowByAppInstanceID(string AppInstanceID)
        {
            return WorkFlowManager.GetBizAppFlowByAppInstanceID(AppInstanceID);
        }
        #endregion


        #region SysMenu
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysMenu()
        {
            return WorkFlowManager.GetSysMenu();
        }
        /// <summary>
        /// 更新资源信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysMenu(SysMenuEntity model)
        {
            return WorkFlowManager.UpdateSysMenu(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysMenuEntity GetSysMenuModel(int ID)
        {
            return WorkFlowManager.GetSysMenuModel(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysMenu(SysMenuEntity model)
        {
            return WorkFlowManager.AddSysMenu(model);
        }
        /// <summary>
        /// 删除一条资源数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysMenu(string ID)
        {
            return WorkFlowManager.DeleteSysMenu(ID);
        }
        #endregion

        #region SysMenuUser
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSysMenuUser()
        {
            return WorkFlowManager.GetSysMenuUser();
        }
        /// <summary>
        /// 根据用户获取相应菜单
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="ParentID">菜单的父级ID</param>
        /// <returns></returns>
        public static DataTable GetMenuList(int UserID, int ParentID)
        {
            return WorkFlowManager.GetMenuList(UserID, ParentID);
        }
        /// <summary>
        /// 更新资源信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateSysMenuUser(SysMenuUserEntity model)
        {
            return WorkFlowManager.UpdateSysMenuUser(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static SysMenuUserEntity GetSysMenuUserModel(int ID)
        {
            return WorkFlowManager.GetSysMenuUserModel(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int AddSysMenuUser(SysMenuUserEntity model)
        {
            return WorkFlowManager.AddSysMenuUser(model);
        }
        /// <summary>
        /// 删除一条资源数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int DeleteSysMenuUser(string ID)
        {
            return WorkFlowManager.DeleteSysMenuUser(ID);
        }

        public static bool IsResend(string ProcessInstanceID, string UserID)
        {
            return WorkFlowManager.IsResend(ProcessInstanceID, UserID);
        }
        #endregion

        /// <summary>
        /// 判断是否为办公室（党委办公室）用户发起
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="tableType">1是采购</param>
        /// <returns></returns>
        public static bool IsStartedByBgsUser(int instanceId, int tableType)
        {
            return WorkFlowManager.IsStartedByBgsUser(instanceId, tableType);
        }


        public static List<string> GetCurrUserRoleIDlist(int UserID)
        {
            return WorkFlowManager.GetCurrUserRoleIDlist(UserID);
        }
    }
}