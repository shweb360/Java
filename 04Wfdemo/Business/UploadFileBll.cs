using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slickflow.WebDemo.Data;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;
using System.Data;

namespace Slickflow.WebDemo.Business
{
    public class UploadFileBll
    { /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(UploadFileEntity model)
        {
            return UploadFileDll.Add(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(UploadFileEntity model)
        {
            return UploadFileDll.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModel(int WFBizID, int WFBizType, int LoginRoleID)
        {
            return UploadFileDll.GetModel(WFBizID, WFBizType, LoginRoleID);
        }
 /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModelByUserID(int WFBizID, int WFBizType, int CreatedUserID)
        {
            return UploadFileDll.GetModelByUserID(WFBizID, WFBizType, CreatedUserID);
        }
                /// <summary>
        /// 获取所有上传附件
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListUploadFile(int WFBizID, int WFBizType, int LoginRoleID)
        {
            return UploadFileDll.GetListUploadFile(WFBizID, WFBizType, LoginRoleID);
        }

         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static UploadFileEntity GetModel(int ID)
        {
            return UploadFileDll.GetModel(ID);
        }

        
    }
}