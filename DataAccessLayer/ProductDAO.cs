using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        DataHelper dh = new DataHelper();

        public ProductDAO() 
        { 
        
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("select * from Product where active_flag = 1");
            while(rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }

        public List<Product> GetProductsCategory (string CatID)
        {
            string query;
            if(CatID != null)
            {
                query = "select * from Product where Category_id = '"+CatID+"'";

            } else {

                query = "select * from Product";

            }

            List<Product> products = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader(query);
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Author = rdr["author"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Description = rdr["description"].ToString();
                products.Add(product);
            }

            return products;
        }

        public List<Product> GetDetail(string product_id)
        {
            List<Product> lst = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("select * from Product where product_id = '"+product_id+"'");

            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Author = rdr["author"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Description = rdr["description"].ToString();
                lst.Add(product);
            }


            return lst;
        }

        public List<Product> GetProductsP(int PageIndex, int PageSize)
        {
            List<Product> lst = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("exec spPhanTrang_Product "+PageIndex+","+PageSize+"");
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                lst.Add(product);
            }

            return lst;
        }

        public string DeleteProduct(string id)
        {
            string query = "delete from product where product_id = '" + id + "'";
            return dh.ExecuteNonQuery(query);
        }

        public string AddProduct(Product p)
        {
            string query = "Insert into Product values ('"+p.Product_id+"', N'"+p.Product_title+ "', '"+p.Category_id+"'," +
                " '"+p.Publisher_id+"', N'"+p.Author+"', "+p.Quantity+", "+p.Price+", '"+p.Image_url+"', '"+p.Big_image_url+"', N'"+p.Description+"', "+1+")";
            return dh.ExecuteNonQuery(query);
        }

        public string UpdateProduct(Product p)
        {
            string query = "Update product set product_title = N'"+p.Product_title+"', category_id = '"+p.Category_id+"', publisher_id = '"+p.Publisher_id+"'," +
                "author = N'"+p.Author+"', quantity = "+p.Quantity+", price = "+p.Price+", image_url = '"+p.Image_url+"', big_image_url = '"+p.Big_image_url+"'," +
                "description = N'"+p.Description+"' ,active_flag = "+p.Active_flag+" where product_id = '"+p.Product_id+"'";
            return dh.ExecuteNonQuery(query);
        }

        public List<Product> Get_Top_Product_by_datetime()
        {
            List<Product> products = new List<Product>();

            //SqlDataReader rdr = dh.ExcuteReader("select top(5) * " +
            //    "from product " +
            //    "order by create_date_time");

            SqlDataReader rdr = dh.ExcuteReader("exec [dbo].[get_top_by_date_time]");
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }

        public List<Product> Get_10_Product_by_datetime()
        {
            List<Product> products = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("select top(10) * " +
                "from product " +
                "order by create_date_time");

            //SqlDataReader rdr = dh.ExcuteReader("exec [dbo].[get_top_by_date_time]");
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }

        public List<Product> get_product_by_datetime()
        {
            List<Product> products = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("exec [dbo].[get_product_by_datetime]");
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }

        public List<Product> get_5_product_bestseller()
        {
            List<Product> products = new List<Product>();

            //SqlDataReader rdr = dh.ExcuteReader("select top(5) * " +
            //    "from product " +
            //    "order by create_date_time");

            SqlDataReader rdr = dh.ExcuteReader("exec [dbo].[get_5_product_bestseller]");
            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }

        public List<Product> get_product_bestseller(int PageIndex, int PageSize)
        {
            List<Product> products = new List<Product>();

            SqlDataReader rdr = dh.ExcuteReader("exec [dbo].[get_product_bestsellerPT]" + PageIndex + "," + PageSize + "");

            while (rdr.Read())
            {
                Product product = new Product();
                product.Product_id = rdr["Product_id"].ToString();
                product.Product_title = rdr["product_title"].ToString();
                product.Category_id = rdr["Category_id"].ToString();
                product.Publisher_id = rdr["Publisher_id"].ToString();
                product.Author = rdr["Author"].ToString();
                product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                product.Image_url = rdr["image_url"].ToString();
                product.Big_image_url = rdr["big_image_url"].ToString();
                product.Price = Convert.ToInt32(rdr["price"]);
                product.Description = rdr["description"].ToString();
                DateTime date = Convert.ToDateTime(rdr["create_date_time"]);
                product.Create_date_time = date;
                products.Add(product);
            }

            return products;
        }
    }
}
