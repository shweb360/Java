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
    public class ProcurementBll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(ProcurementEntity model)
        {
            return ProcurementDll.Add(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(ProcurementEntity model)
        {
            return ProcurementDll.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ProcurementEntity GetModel(int ID)
        {
            return ProcurementDll.GetModel(ID);
        }
    }
}