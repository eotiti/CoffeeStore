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
    public class FoodBUS
    {
        private FoodDAL dal = new FoodDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public FoodDTO GetByID(int id)
        {
            return dal.GetByID(id);
        }

        public bool Insert(FoodDTO food)
        {
            return dal.Insert(food);
        }

        public bool Update(FoodDTO food)
        {
            return dal.Update(food);
        }
        public DataTable GetByCategory(int categoryID)
        {
            return dal.GetByCategory(categoryID);
        }
    }
}
