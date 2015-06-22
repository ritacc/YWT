using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    public class YWTUserPostionInfoOR
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime? CoordLastTime { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string OrderNo { get; set; }

        public YWTUserPostionInfoOR(DataRow _row)
        {
            latitude = _row["latitude"].ToString();
            longitude = _row["longitude"].ToString();
            if (DBNull.Value != _row["CoordLastTime"])
            {
                CoordLastTime = Convert.ToDateTime(_row["CoordLastTime"]);
            }
            RealName = _row["RealName"].ToString();
            Mobile = _row["Mobile"].ToString();
            OrderNo = _row["OrderNo"].ToString();
        }
    }
}
