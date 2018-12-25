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
    public class ProcurementOpinionBll
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(ProcurementOpinionEntity model)
        {
            return ProcurementOpinionDll.Add(model);
        }
    }
}