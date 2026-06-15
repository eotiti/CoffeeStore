using CoffeeStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class AreaDTO
    {
        public int AreaID { get; set; }

        public string AreaName { get; set; }

        public string Description { get; set; }
    }
    
}
