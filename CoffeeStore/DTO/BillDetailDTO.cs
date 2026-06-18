using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class BillDetailDTO
    {
        public int BillDetailID { get; set; }

        public int BillID { get; set; }

        public int FoodID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
    }
}
