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
    public class CategoryDAO
    {
        DataHelper dh = new DataHelper();

        public CategoryDAO()
        {

        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            SqlDataReader rdr = dh.ExcuteReader("select * from Category");
            while (rdr.Read())
            {
                Category category = new Category();
                category.Category_id = rdr["Category_id"].ToString();
                category.Category_name = rdr["Category_name"].ToString(); 
                category.Description = rdr["Description"].ToString();
                categories.Add(category);
            }

            return categories;
        }
    }
}
