using CoffeeStore.DAL;
using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.BUS
{
    public class BillBUS
    {
        private BillDAL dal = new BillDAL();

        public BillDTO GetOpenBillByTable(int tableID)
        {
            return dal.GetOpenBillByTable(tableID);
        }

        public int CreateBill(BillDTO bill)
        {
            return dal.CreateBill(bill);
        }
        public bool Payment(int billID, decimal totalAmount)
        {
            return dal.Payment(billID, totalAmount);
        }
        public bool Delete(int billID)
        {
            return dal.Delete(billID);
        }
        public bool MoveTable(int billID, int newTableID)
        {
            return dal.UpdateTable(billID, newTableID);
        }
    }
}
