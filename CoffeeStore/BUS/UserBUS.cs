using CoffeeStore.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.DTO;

namespace CoffeeStore.BUS
{
    public class UserBUS
    {
        UserDAL userDAL = new UserDAL();

        public UserDTO Login(string userName, string password)
        {
            return userDAL.Login(userName, password);
        }
        public DataTable GetAll()
        {
            return userDAL.GetAll();
        }
    }
}
