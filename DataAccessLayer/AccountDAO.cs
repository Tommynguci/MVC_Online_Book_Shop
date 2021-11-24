using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        DataHelper dh = new DataHelper();

        public AccountDAO() 
        { 
        
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            SqlDataReader rdr = dh.ExcuteReader("select * from Account");
            while(rdr.Read())
            {
                Account account = new Account();
                account.username = rdr["username"].ToString();
                account.password = rdr["password"].ToString();
                account.role = rdr["role"].ToString();
                account.active = Convert.ToInt32(rdr["active"]);
                accounts.Add(account);
            }

            return accounts;
        }

        public Account GetAccount(string us, string pw)
        {
            string query = "select * from Account where username = '"+us+"'and password = '"+pw+"'";

            SqlDataReader rdr = dh.ExcuteReader(query);
            if (rdr.Read())
            {
                Account acc = new Account();
                acc.username = rdr["username"].ToString();
                acc.password = rdr["password"].ToString();
                acc.role = rdr["role"].ToString();
                acc.active = Convert.ToInt32(rdr["active"]);
                
                return acc;
            }
            else
            {
                return null;
            }
            
        }

        public string Register(string us, string pw)
        {
            string query = "insert into account values ('"+us+"', '"+pw+"', 'kh', "+0+", "+1+")";
            return dh.ExecuteNonQuery(query);
        }
    }
}
