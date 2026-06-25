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
    public class AreaDAL:DBConnection
    {
        public DataTable GetAll()
        {
            string sql = @"SELECT * FROM Areas ORDER BY AreaName asc";
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter da =new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }

            return dt;
        }
        public bool Insert(AreaDTO area)
        {
            string sql = @"INSERT INTO Areas ( AreaName, Description) VALUES ( @AreaName, @Description )";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add( "@AreaName", SqlDbType.NVarChar).Value = area.AreaName;
                cmd.Parameters.Add( "@Description", SqlDbType.NVarChar).Value = area.Description;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(AreaDTO area)
        {
            string sql = @"UPDATE Areas SET AreaName = @AreaName, Description = @Description WHERE AreaID = @AreaID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add( "@AreaID", SqlDbType.Int).Value = area.AreaID;
                cmd.Parameters.Add( "@AreaName", SqlDbType.NVarChar).Value = area.AreaName;
                cmd.Parameters.Add( "@Description", SqlDbType.NVarChar).Value = area.Description;

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int areaID)
        {
            string sql = @"DELETE FROM Areas WHERE AreaID = @AreaID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add( "@AreaID", SqlDbType.Int).Value = areaID;
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public AreaDTO GetByID(int areaID)
        {
            string sql = @"SELECT * FROM Areas WHERE AreaID = @AreaID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add( "@AreaID", SqlDbType.Int).Value = areaID;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    AreaDTO area = new AreaDTO();

                    area.AreaID = Convert.ToInt32( reader["AreaID"]);

                    area.AreaName = reader["AreaName"].ToString();

                    area.Description = reader["Description"].ToString();

                    return area;
                }
            }

            return null;
        }
    }
}
