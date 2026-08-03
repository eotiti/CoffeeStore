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
    public class MaterialBUS
    {
        private MaterialDAL materialDAL = new MaterialDAL();

        public DataTable GetAll()
        {
            return materialDAL.GetAll();
        }

        public MaterialDTO GetByID(int materialID)
        {
            return materialDAL.GetByID(materialID);
        }

        public bool Insert(MaterialDTO material)
        {
            return materialDAL.Insert(material);
        }

        public bool Update(MaterialDTO material)
        {
            return materialDAL.Update(material);
        }

        public bool Delete(int materialID)
        {
            return materialDAL.Delete(materialID);
        }

        /*public bool UpdateQuantity(int materialID, decimal quantity)
        {
            return materialDAL.UpdateQuantity(materialID, quantity);
        }*/
    }
}
