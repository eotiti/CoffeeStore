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
    public class FoodDAL:DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT   f.FoodID, 
                                    f.FoodName, 
                                    f.CategoryID, 
                                    c.CategoryName, 
                                    f.Price, 
                                    f.IsActive
                            FROM Foods f
                            INNER JOIN Categories c
                                ON f.CategoryID = c.CategoryID
                            ORDER BY c.CategoryName, f.FoodName";

            SqlConnection conn = GetConnection();

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public FoodDTO GetByID(int foodID)
        {
            string sql = @" SELECT * FROM Foods WHERE FoodID = @FoodID";

            SqlConnection conn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@FoodID", foodID);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            FoodDTO food = null;

            if (reader.Read())
            {
                food = new FoodDTO();

                food.FoodID = Convert.ToInt32(reader["FoodID"]);

                food.FoodName = reader["FoodName"].ToString();

                food.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                food.CategoryName = "";

                food.Price = Convert.ToDecimal(reader["Price"]);

                food.IsActive = Convert.ToBoolean(reader["IsActive"]);
                
            }

            conn.Close();

            return food;
        }
        public bool Insert(FoodDTO food)
        {
            string sql = @" INSERT INTO Foods ( FoodName,CategoryID, Price, IsActive ) VALUES ( @FoodName, @CategoryID, @Price, @IsActive )";

            SqlConnection conn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@FoodName", food.FoodName);

            cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);

            cmd.Parameters.AddWithValue("@Price", food.Price);

            cmd.Parameters.AddWithValue("@IsActive", food.IsActive);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            return rows > 0;
        }
        public bool Update(FoodDTO food)
        {
            string sql = @"
                UPDATE Foods
                SET
                    FoodName = @FoodName,
                    CategoryID = @CategoryID,
                    Price = @Price,
                    IsActive = @IsActive
                WHERE FoodID = @FoodID";

            SqlConnection conn = GetConnection();

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@FoodID", food.FoodID);

            cmd.Parameters.AddWithValue("@FoodName", food.FoodName);

            cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);

            cmd.Parameters.AddWithValue("@Price", food.Price);


            cmd.Parameters.AddWithValue("@IsActive", food.IsActive);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            return rows > 0;
        }
        public DataTable GetByCategory(int categoryID)
        {
            string sql = @"SELECT * FROM Foods
                                    WHERE CategoryID = @CategoryID
                                    AND IsActive = 1
                                    ORDER BY FoodName";
            SqlConnection conn = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@CategoryID",categoryID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
