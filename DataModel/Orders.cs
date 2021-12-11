using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class Orders
    {
        public string order_id { get; set; }
        public string user_id { get; set; }
        public string voucher_id { get; set; }
        public string delivery_address { get; set; }
        public string delivery_charge { get; set; }
        public string status { get; set; }
        public int total { get; set; }
        public int active_flag { get; set; }

        public Orders(string Order_id, string User_id, string Voucher_id, string Delivery_address, string Delivery_charge,
            string Status, int Total, int Active_flag)
        {
            order_id = Order_id; user_id = User_id; voucher_id = Voucher_id; delivery_address = Delivery_address;
            delivery_charge = Delivery_charge; status = Status; total = Total; active_flag = Active_flag;
        }

        public Orders()
        {

        }
    }
}
