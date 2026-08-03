using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class MaterialDTO
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal MinQuantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public MaterialDTO() 
        { 

        }

        public MaterialDTO(DataRow row)
        {
            MaterialID = Convert.ToInt32(row["MaterialID"]);
            MaterialName = row["MaterialName"].ToString();
            Unit = row["Unit"].ToString();
            Quantity = Convert.ToDecimal(row["Quantity"]);
            MinQuantity = Convert.ToDecimal(row["MinQuantity"]);
            IsActive = Convert.ToBoolean(row["IsActive"]);
            CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
            UpdatedDate = Convert.ToDateTime(row["UpdatedDate"]);
        }
    }
}
