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
    public class FoodRecipeDAL : DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT FoodID, FoodName
                   FROM Foods
                   WHERE IsActive = 1
                   ORDER BY FoodName";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public DataTable GetByFood(int foodID)
        {
            string sql = @"SELECT
                        r.RecipeID,
                        r.FoodID,
                        r.MaterialID,
                        m.MaterialName,
                        r.Quantity,
                        m.Unit
                   FROM FoodRecipes r
                   INNER JOIN Materials m
                        ON r.MaterialID = m.MaterialID
                   WHERE r.FoodID = @FoodID
                         AND m.IsActive = 1
                   ORDER BY m.MaterialName";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FoodID", foodID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public bool Insert(FoodRecipeDTO recipe)
        {
            string sql = @"INSERT INTO FoodRecipes
                   (
                       FoodID,
                       MaterialID,
                       Quantity
                   )
                   VALUES
                   (
                       @FoodID,
                       @MaterialID,
                       @Quantity
                   )";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FoodID", recipe.FoodID);
                cmd.Parameters.AddWithValue("@MaterialID", recipe.MaterialID);
                cmd.Parameters.AddWithValue("@Quantity", recipe.Quantity);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }

        }
        public bool Exists(int foodID, int materialID)
        {
            string sql = @"SELECT COUNT(*)
                   FROM FoodRecipes
                   WHERE FoodID = @FoodID
                     AND MaterialID = @MaterialID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FoodID", foodID);
                cmd.Parameters.AddWithValue("@MaterialID", materialID);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                return count > 0;
            }
        }
        /*public FoodRecipeDTO GetByID(int recipeID);

        

        public bool Update(FoodRecipeDTO recipe);

        public bool Delete(int recipeID);*/
    }
}
