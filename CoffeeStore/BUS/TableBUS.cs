using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.DAL;
using CoffeeStore.DTO;

namespace CoffeeStore.BUS
{
    public class TableBUS
    {
        private TableDAL tableDAL=new TableDAL();
        public List<TableDTO> GetAll()
        {  
            return tableDAL.GetAll();
        }
        public List<TableDTO> GetAllByAreaID(int areaID)// load Danh sach ban theo khu vuc
        {
            return tableDAL.GetAllByAreaID(areaID);
        }
        public bool Insert(TableDTO table)//them ban moi
        {
            if (string.IsNullOrWhiteSpace(table.TableName))
            {
                return false;
            }    
                
            return tableDAL.Insert(table);
        }
        public bool Update(TableDTO table)//sua ban
        {
            if (string.IsNullOrWhiteSpace(table.TableName))
                return false;

            return tableDAL.Update(table);
        }
        public TableDTO GetByID(int tableID)//lay ban theo khu vuc
        {
            return tableDAL.GetByID(tableID);
        }
        public bool UpdateStatus(int tableID, int status)
        {
            return tableDAL.UpdateStatus(tableID, status);
        }
    }

}
