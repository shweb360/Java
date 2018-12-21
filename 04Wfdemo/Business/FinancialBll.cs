using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slickflow.WebDemo.Data;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;
namespace Slickflow.WebDemo.Business
{
    public class FinancialBll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(FinancialEntity model)
        {
            return FinancialDll.Add(model);
        }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FinancialEntity GetModel(int ID)
        {
            return FinancialDll.GetModel(ID);
        }
         /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(FinancialEntity model)
        {
            return FinancialDll.Update(model);
        }
    }
}