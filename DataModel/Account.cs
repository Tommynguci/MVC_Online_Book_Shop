using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public int active { get; set; }
        public int Active_flag { get; set; }
    }
}
