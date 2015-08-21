using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order.View
{
    public class MonthViewOR
    {
        public int OrderFinishNum { get; set; }
        public int ScoreAvg { get; set; }
        public int IYear { get; set; }
        public int IMonth { get; set; }

        public MonthViewOR(DataRow _row)
        {
            if (_row["OrderFinishNum"] != DBNull.Value)
            {
                OrderFinishNum = Convert.ToInt32(_row["OrderFinishNum"]);
            }
            if (_row["ScoreAvg"] != DBNull.Value)
            {
                ScoreAvg = Convert.ToInt32(_row["ScoreAvg"]);
            }
            if (_row["IYear"] != DBNull.Value)
            {
                IYear = Convert.ToInt32(_row["IYear"]);
            }
            if (_row["IMonth"] != DBNull.Value)
            {
                IMonth = Convert.ToInt32(_row["IMonth"]);
            }
        }
    }
}
