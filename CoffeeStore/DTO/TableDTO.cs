using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class TableDTO
    {
        public int TableID {  get; set; }
        public string TableName { get; set; }
        public int AreaID { get; set; }
        public int Status { get; set; }
    }
}
