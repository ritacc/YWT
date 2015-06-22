using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Interface
{
    public class InterfaceParaOR
    {
        public Int64 PARA_ID { get; set; }
        public Int64 Inerface_ID { get; set; }
        public string PNAME { get; set; }
        public string PDescription { get; set; }

        public InterfaceParaOR(DataRow _row)
        {
            PARA_ID = Convert.ToInt64(_row["PARA_ID"].ToString());
            Inerface_ID = Convert.ToInt64(_row["Inerface_ID"].ToString());
            PNAME = _row["PNAME"].ToString();
            PDescription = _row["PDescription"].ToString();
        }
    }
}
