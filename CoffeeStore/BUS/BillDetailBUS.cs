using CoffeeStore.DAL;
using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.BUS
{
    public class BillDetailBUS
    {
        private BillDetailDAL dal =
            new BillDetailDAL();

        public BillDetailDTO GetFoodInBill(int billID,int foodID)
        {
            return dal.GetFoodInBill(billID,foodID);
        }

        public bool Insert(BillDetailDTO detail)
        {
            return dal.Insert(detail);
        }

        public bool UpdateQuantity(int billDetailID,int quantity,decimal amount)
        {
            return dal.UpdateQuantity(billDetailID,quantity,amount);
        }
    }
}
