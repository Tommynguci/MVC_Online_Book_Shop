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
    public class CategoryBUS
    {
        CategoryDAO _cat = new CategoryDAO();

        public List<Category> GetCategories()
        {
            return _cat.GetCategories();
        }
    }
}
