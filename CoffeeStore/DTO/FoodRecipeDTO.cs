using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class FoodRecipeDTO
    {
        public int RecipeID { get; set; }
        public int FoodID { get; set; }
        public int MaterialID { get; set; }
        public decimal Quantity { get; set; }
    }
}
