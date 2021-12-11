using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataHelper
    {
        //SqlConnection StrConnection = new SqlConnection(ConfigurationManager)
        string stcon = @"Data Source=ADMIN;Initial Catalog=DBStoreBook;Integrated Security=True";
        SqlConnection con;

        public DataHelper(string stcon)
        {
            this.stcon = stcon;
            con = new SqlConnection(stcon);
        }
        public DataHelper()
        {
            con = new SqlConnection(stcon);
        }
        public string Open()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Close()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        public SqlDataReader ExcuteReader(string query)
        {

            //string st = Open();
            //if (st != "")
            //    throw new Exception(st);
            //SqlCommand cm = new SqlCommand(sqlSelect, con);
            //SqlDataReader dr = cm.ExecuteReader();
            //return dr;
            //Close();

            string stcon = ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString;
            //List<Product> products = new List<Product>();
            SqlConnection con = new SqlConnection(stcon);

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            //con.Close();

            return rdr;
        }
        //public void ExcuteNonQuery(string sql)
        //{
        //    Open();
        //    SqlCommand cm = new SqlCommand(sql, con);
        //    cm.ExecuteNonQuery();
        //    Close();
        //}

        public string ExecuteNonQuery(string sql)
        {
            try
            {
                Open();
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                Close();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public DataTable ExcuteQuery(string query)
        {
            con.Open();

            DataTable data = new DataTable();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);

            con.Close();

            return data;
        }

        public SqlDataReader StoreReaders(string storeProc, params object[] giatri)
        {
            SqlCommand cm;
            con.Open();
            try
            {
                cm = new SqlCommand(storeProc, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;

            }
            catch
            {
                return null;
            }
        }
    }
}
