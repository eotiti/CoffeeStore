using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAL
{
    public class CategoryDAL:DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM Categories ORDER BY CategoryID asc";

            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                da.Fill(dt);
            }

            return dt;
        }
        public bool Insert(CategoryDTO category)
        {
            string sql = @"INSERT INTO Categories ( CategoryName,IsActive) VALUES ( @CategoryName,@IsActive )";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                cmd.Parameters.AddWithValue("@IsActive",category.IsActive);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(CategoryDTO category)
        {
            string sql = @"UPDATE Categories SET 
                                            CategoryName = @CategoryName,
                                            IsActive = @IsActive  
                                        WHERE CategoryID  = @CategoryID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = category.CategoryID;
                cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = category.CategoryName;
                cmd.Parameters.AddWithValue("@IsActive",category.IsActive);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int CategoryID)
        {
            string sql = @"DELETE FROM Categories WHERE CategoryID = @CategoryID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public CategoryDTO GetByID(int CategoryID)
        {
            string sql = @"SELECT * FROM Categories WHERE CategoryID = @CategoryID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CategoryDTO category = new CategoryDTO();

                    category.CategoryID = Convert.ToInt32(reader["CategoryID"]);

                    category.CategoryName = reader["CategoryName"].ToString();
                    category.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    return category;
                }
            }

            return null;
        }

    }
}
