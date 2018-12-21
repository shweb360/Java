using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slickflow.WebDemo.Data;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;
namespace Slickflow.WebDemo.Business
{
    public class ContractBll
    {
         /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(ContractEntity model)
        {
            return ContractDll.Add(model);
        }
        /// 得到一个对象实体
        /// </summary>
        public static ContractEntity GetModel(int ID)
        {
            return ContractDll.GetModel(ID);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(ContractEntity model)
        {
            return ContractDll.Update(model);
        }
    }
}