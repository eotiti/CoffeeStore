using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class BillDTO
    {
        public int BillID { get; set; }

        public int TableID { get; set; }

        public int UserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? PaidDate { get; set; }
    }
    public static class BillStatus
    {
        public const int Open = 0;

        public const int Paid = 1;
    }
}
