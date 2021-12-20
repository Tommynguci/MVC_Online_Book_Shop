using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModel;

namespace Bussiness
{
    public class ProductBUS
    {
        ProductDAO _prod = new ProductDAO();

        public List<Product> GetProducts()
        {
            return _prod.GetProducts();
        }

        public List<Product> Detail(string product_id)
        {
            return _prod.GetDetail(product_id);
        }

        public List<Product> GetProductsCategory (string CatID)
        {
            return _prod.GetProductsCategory(CatID);
        }

        public ListProduct GetProductsP (int pageIndex, int PageSize, string ProductName)
        {
            return _prod.GetProductsP(ProductName, pageIndex, PageSize);
        }

        public string DeleteProduct(string id)
        {
            return _prod.DeleteProduct(id);
        }

        public string AddProduct(Product p)
        {
            return _prod.AddProduct(p);
        }

        public string UpdateProduct(Product p)
        {
            return _prod.UpdateProduct(p);
        }

        public List<Product> Get_Top_Product_by_datetime()
        {
            return _prod.Get_Top_Product_by_datetime();
        }
    }
}
