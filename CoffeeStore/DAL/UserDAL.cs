using CoffeeStore.DAL;
using CoffeeStore.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.DTO;

namespace CoffeeStore.DAL
{
    public class UserDAL : DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM Users";
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }
        public UserDTO Login(string userName, string password)
        {
            string sql = @"
                SELECT
                    U.UserID,
                    U.UserName,
                    U.FullName,
                    U.RoleID,
                    R.RoleName,
                    U.IsActive    
                FROM Users U
                INNER JOIN Roles R
                    ON U.RoleID = R.RoleID
                WHERE U.UserName = @UserName
                AND U.Password = @Password
                AND U.IsActive = 1";

            UserDTO user = null;//khởi tạo đối tượng User = rỗng (chưa có infor)

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new UserDTO();

                        user.UserID =
                            Convert.ToInt32(reader["UserID"]);

                        user.UserName =
                            reader["UserName"].ToString();

                        user.FullName =
                            reader["FullName"].ToString();

                        user.RoleID =
                            Convert.ToInt32(reader["RoleID"]);

                        user.RoleName =
                            reader["RoleName"].ToString();

                        user.IsActive =
                            Convert.ToBoolean(reader["IsActive"]);
                    }
                }
            }

            return user;
        }
    }
}
