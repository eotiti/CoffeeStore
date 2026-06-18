using CoffeeStore.DAL;
using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.BUS
{
    public class CategoryBUS
    {
        CategoryDAL categoryDAL = new CategoryDAL();

        public DataTable GetAll()
        {
            return categoryDAL.GetAll();
        }

        public bool Insert(CategoryDTO category)
        {
            return categoryDAL.Insert(category);
        }

        public bool Update(CategoryDTO category)
        {
            return categoryDAL.Update(category);
        }

        public bool Delete(int categoryID)
        {
            return categoryDAL.Delete(categoryID);
        }
        public CategoryDTO GetByID(int categoryID)
        {
            return categoryDAL.GetByID(categoryID);
        }
    }
}
