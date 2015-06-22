using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Interface
{
    public class InterfaceActionOR
    {
        public Int64 Inerface_ID { get; set; }
        public string IFile { get; set; }
        public string IACTION { get; set; }
        public string IDescription { get; set; }

        public InterfaceActionOR(DataRow _row)
        {
            Inerface_ID = Convert.ToInt64(_row["Inerface_ID"].ToString());
            IFile = _row["IFile"].ToString();
            IACTION = _row["IACTION"].ToString();
            IDescription = _row["IDescription"].ToString();
        }
    }
}
