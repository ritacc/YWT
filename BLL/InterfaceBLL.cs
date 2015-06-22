using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL;
using YWT.Model.Interface;

namespace YWT.BLL
{
    public class InterfaceBLL
    {

        public List<InterfaceParaOR> SelectPara()
        {
            return new InterfaceDA().SelectPara();
        }

        /// <summary>
        /// 参数
        /// </summary>
        /// <returns></returns>
        public List<InterfaceActionOR> SelectAction()
        {
            return new InterfaceDA().SelectAction();
        }
    }
}
