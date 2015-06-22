using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Coordinate;
using YWT.Model.Coordinate;
using YWT.Model.User;

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
        #region 查询定位
        /// <summary>
        /// 查询运维商下面所有运维人员
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTUserPostionInfoOR> GetSupplierAllUserPostionInfo(string UserID, out int mResultType, out string mResultMessage)
        {
            return new YWTCoordinateDA().GetSupplierAllUserPostionInfo(UserID, out   mResultType, out   mResultMessage);
        }
        #endregion
    }
}
