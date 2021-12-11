using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Order_Detail
    {
        public string order_detail_id { get; set; }
        public string order_id { get; set; }
        public string product_id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int active_flag { get; set; }
        public int? amount { get; set; }

        public Order_Detail (string Order_Detail_Id, string Order_id, string Product_id, int Quantity, int Price)
        {
            this.order_detail_id = Order_Detail_Id; 
            this.order_id = Order_id; 
            this.product_id = Product_id; 
            this.quantity = Quantity; 
            this.price = Price;
            this.amount = price * quantity;
        }
        public Order_Detail()
        {

        }
    }
}
