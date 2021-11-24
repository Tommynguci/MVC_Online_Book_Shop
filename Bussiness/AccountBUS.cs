using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModel;

namespace Bussiness
{
    public class AccountBUS
    {
        AccountDAO _acc = new AccountDAO();

        public List<Account> GetAccounts()
        {
            return _acc.GetAccounts();
        }

        public Account GetAccount(string us, string pw)
        {
            return _acc.GetAccount(us, pw);
        }
        
        public string Register(string us, string pw)
        {
            return _acc.Register(us, pw);
        }
    }
}
