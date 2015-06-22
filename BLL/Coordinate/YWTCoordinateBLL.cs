using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Coordinate;
using YWT.Model.Coordinate;

namespace YWT.BLL.Coordinate
{
    public class YWTCoordinateBLL
    {
        //public List<YWTCoordinateOR> GetCoordinate(string m_id, out int mResultType, out string mResultMessage)
        //{
        //    return new YWTCoordinateDA().GetCoordinate(m_id, out   mResultType, out   mResultMessage);
        //}

        /// <summary>
        /// 插入
        /// </summary>
        public void Insert(YWTCoordinateOR sNRCoordinate, out int mResultType, out string mResultMessage)
        {
            new YWTCoordinateDA().Insert(sNRCoordinate, out   mResultType, out   mResultMessage);
        }

    }
}
