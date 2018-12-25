using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Slickflow.WebDemo.Data;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;

namespace Slickflow.WebDemo.Business
{
    public class FinancialOpinionBll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(FinancialOpinionEntity model)
        {
            return FinancialOpinionDll.Add(model);
        }
    }
}