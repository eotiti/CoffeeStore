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
    public class FoodRecipeBUS
    {
        private FoodRecipeDAL dal = new FoodRecipeDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        public DataTable GetByFood(int foodID)
        {
            return dal.GetByFood(foodID);
        }
        public bool Insert(FoodRecipeDTO recipe)
        {
            return dal.Insert(recipe);
        }
        public bool Exists(int foodID, int materialID)
        {
            return dal.Exists(foodID, materialID);
        }           
    }
}
