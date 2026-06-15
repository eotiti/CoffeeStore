using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CoffeeStore.DAL
{
    public class DBConnection
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
