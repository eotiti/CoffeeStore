using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class FoodDTO
    {
        public int FoodID { get; set; }

        public string FoodName { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }
}
