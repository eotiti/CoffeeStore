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
    public class MaterialDAL:DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM Materials WHERE IsActive = 1 ORDER BY MaterialName";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public MaterialDTO GetByID(int materialID)
        {
            string sql = @"SELECT * FROM Materials WHERE MaterialID=@MaterialID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaterialID", materialID);
                SqlDataReader reader = cmd.ExecuteReader();
                MaterialDTO material = null;
                if (reader.Read())
                {
                    material = new MaterialDTO();
                    material.MaterialID = Convert.ToInt32(reader["MaterialID"]);
                    material.MaterialName = reader["MaterialName"].ToString();
                    material.Unit = reader["Unit"].ToString();
                    material.Quantity = Convert.ToDecimal(reader["Quantity"]);
                    material.MinQuantity = Convert.ToDecimal(reader["MinQuantity"]);
                    material.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    material.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    material.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                }

                reader.Close();
                conn.Close();
                return material;
            }
        }
        public bool Insert(MaterialDTO material)
        {
            string sql = @"INSERT INTO Materials
                   (
                        MaterialName,
                        Unit,
                        Quantity,
                        MinQuantity,
                        IsActive
                   )
                   VALUES
                   (
                        @MaterialName,
                        @Unit,
                        @Quantity,
                        @MinQuantity,
                        @IsActive
                   )";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaterialName", material.MaterialName);
                cmd.Parameters.AddWithValue("@Unit", material.Unit);
                cmd.Parameters.AddWithValue("@Quantity", material.Quantity);
                cmd.Parameters.AddWithValue("@MinQuantity", material.MinQuantity);
                cmd.Parameters.AddWithValue("@IsActive", material.IsActive);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }
        public bool Update(MaterialDTO material)
        {
            string sql = @"UPDATE Materials 
                                SET MaterialName = @MaterialName, Unit = @Unit, MinQuantity = @MinQuantity, UpdatedDate = GETDATE()
                                 WHERE MaterialID = @MaterialID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaterialName", material.MaterialName);
                cmd.Parameters.AddWithValue("@Unit", material.Unit);
                cmd.Parameters.AddWithValue("@MinQuantity", material.MinQuantity);
                cmd.Parameters.AddWithValue("@MaterialID", material.MaterialID);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }
        public bool Delete(int materialID)
        {
            string sql = @"UPDATE Materials SET IsActive = 0, UpdatedDate = GETDATE() WHERE MaterialID = @MaterialID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaterialID", materialID);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

    }
}
