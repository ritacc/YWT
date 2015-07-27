using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YWT.Model.Order
{
    public class OrderStatus
    {
        static List<OrderStatusItem> _OrderStatus;
        public static List<OrderStatusItem> OrderStatusItems
        {
            get
            {
                if (_OrderStatus == null)
                {
                    Init();
                }
                return _OrderStatus;
            }

        }
         static void Init()
        {
            var _list = new List<OrderStatusItem>() {
                new  OrderStatusItem(){ OrderType=1, Status=0, StatusName="下单"},                
                new  OrderStatusItem(){ OrderType=1, Status=20, StatusName="指派运维人员"},
                new  OrderStatusItem(){ OrderType=1, Status=30, StatusName="开始运维"},
                new  OrderStatusItem(){ OrderType=1, Status=90, StatusName="完成运维"},
                new  OrderStatusItem(){ OrderType=1, Status=99, StatusName="评价"},

                new  OrderStatusItem(){ OrderType=2, Status=0, StatusName="下单"},                
                new  OrderStatusItem(){ OrderType=2, Status=1, StatusName="支付"},
                new  OrderStatusItem(){ OrderType=2, Status=21	, StatusName="选择运维人员"},
                new  OrderStatusItem(){ OrderType=2, Status=30	, StatusName="到达运维地点"},
                new  OrderStatusItem(){ OrderType=2, Status=90	, StatusName="完成运维单"  },
                new  OrderStatusItem(){ OrderType=2, Status=91	, StatusName="第三方人员"  },
                new  OrderStatusItem(){ OrderType=2, Status=92	, StatusName="运维商评价"  },
                new  OrderStatusItem(){ OrderType=2, Status=99	, StatusName="完成"        }

            };

            _OrderStatus = _list;
        }
    }
}
