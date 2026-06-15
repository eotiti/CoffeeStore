using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.DAL;
using CoffeeStore.DTO;
using System.Data;

namespace CoffeeStore.BUS
{
    public class AreaBUS
    {
        AreaDAL areaDAL = new AreaDAL();

        public DataTable GetAll()
        {
            return areaDAL.GetAll();
        }

        public bool Insert(AreaDTO area)
        {
            return areaDAL.Insert(area);
        }

        public bool Update(AreaDTO area)
        {
            return areaDAL.Update(area);
        }

        public bool Delete(int areaID)
        {
            return areaDAL.Delete(areaID);
        }
        public AreaDTO GetByID(int areaID)
        {
            return areaDAL.GetByID(areaID);
        }
    }
}
