using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
