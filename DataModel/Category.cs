using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Category
    {
        public string Category_id { get; set; }
        public string Category_name { get; set; }
        public string Parent_id { get; set; }
        public string Description { get; set; }
        public int Active_flag { get; set; }
    }
}
