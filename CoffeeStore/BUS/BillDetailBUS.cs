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
    public class BillDetailBUS
    {
        private BillDetailDAL dal = new BillDetailDAL();

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
        public DataTable GetBillDetails(int billID)
        {
            return dal.GetBillDetails(billID);
        }
        public decimal GetTotalAmount(int billID)
        {
            return dal.GetTotalAmount(billID);
        }
        public bool Delete(int billDetailID)
        {
            return dal.Delete(billDetailID);
        }

        public BillDetailDTO GetByID(int billDetailID)
        {
            return dal.GetByID(billDetailID);
        }
        public int CountByBill(int billID)
        {
            return dal.CountByBill(billID);
        }
    }
}
