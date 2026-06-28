using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.DTO;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeStore.DAL
{
    public class TableDAL:DBConnection
    {
        
        public List<TableDTO> GetAllByAreaID(int areaID)//lay ban theo khu vuc
        {
            List<TableDTO> list = new List<TableDTO>();
            string query = @"SELECT * FROM CafeTables WHERE AreaID = @AreaID ORDER BY TableName";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AreaID", areaID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TableDTO table = new TableDTO();
                    table.TableID = Convert.ToInt32(reader["TableID"]);
                    table.TableName = reader["TableName"].ToString();
                    table.AreaID = Convert.ToInt32(reader["AreaID"]);
                    table.Status = Convert.ToInt32(reader["Status"]);
                    list.Add(table);
                }
            }
            return list;
        }
        public bool Insert(TableDTO table)
        {
            string query = @"INSERT INTO CafeTables (TableName, AreaID, Status) 
                                         VALUES (@TableName, @AreaID, @Status)";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TableName", table.TableName);
                cmd.Parameters.AddWithValue("@AreaID", table.AreaID);
                cmd.Parameters.AddWithValue("@Status", table.Status);
               

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(TableDTO table)
        {
            string query = @"UPDATE CafeTables SET TableName = @TableName, 
                                                AreaID = @AreaID, 
                                                Status = @Status
                                            WHERE TableID = @TableID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableID", table.TableID);
                cmd.Parameters.AddWithValue("@TableName", table.TableName);
                cmd.Parameters.AddWithValue("@AreaID", table.AreaID);
                cmd.Parameters.AddWithValue("@Status", table.Status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public TableDTO GetByID(int tableID)// load thon tin ban chi dinh theo ID ban
        {
            string query = @"SELECT * FROM CafeTables WHERE TableID = @TableID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableID", tableID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new TableDTO
                    {
                        TableID = Convert.ToInt32(reader["TableID"]),
                        TableName = reader["TableName"].ToString(),
                        AreaID = Convert.ToInt32(reader["AreaID"]),
                        Status = Convert.ToInt32(reader["Status"]),
                    };
                }
            }
            return null;
        }
        public bool UpdateStatus(int tableID, int status)
        {
            string sql = @"UPDATE CafeTables SET Status = @Status WHERE TableID = @TableID";
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TableID", tableID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
