using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order.View
{
    public class MonthViewAadminOR
    {
        public int OrderFinishNum { get; set; }
        public int ScoreAvg { get; set; }
        public int rowid { get; set; }



        public MonthViewAadminOR(DataRow _row)
        {
            if (_row["OrderFinishNum"] != DBNull.Value)
            {
                OrderFinishNum = Convert.ToInt32(_row["OrderFinishNum"]);
            }
            if (_row["ScoreAvg"] != DBNull.Value)
            {
                ScoreAvg = Convert.ToInt32(_row["ScoreAvg"]);
            }
            if (_row["rowid"] != DBNull.Value)
            {
                ScoreAvg = Convert.ToInt32(_row["rowid"]);
            }
        }
    }
}
