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
    public class BillDAL:DBConnection
    {
        public BillDTO GetOpenBillByTable(int tableID)
        {
            string sql = @" SELECT TOP 1 * FROM Bills WHERE TableID = @TableID AND Status = 0";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TableID", tableID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            BillDTO bill = null;

            if (reader.Read())
            {
                bill = new BillDTO();
                bill.BillID = Convert.ToInt32(reader["BillID"]);
                bill.TableID = Convert.ToInt32(reader["TableID"]);
                bill.UserID = Convert.ToInt32(reader["UserID"]);
                bill.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                bill.Status = Convert.ToInt32(reader["Status"]);
            }
            conn.Close();
            return bill;
        }
        public int CreateBill(BillDTO bill)
        {
            string sql = @"INSERT INTO Bills(TableID,UserID,Status) VALUES (@TableID,@UserID,0); SELECT SCOPE_IDENTITY();";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue( "@TableID", bill.TableID);
            cmd.Parameters.AddWithValue( "@UserID", bill.UserID);
            conn.Open();
            int billID =Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return billID;
        }
        public bool Payment(int billID, decimal totalAmount)
        {
            string sql = @"UPDATE Bills SET Status = @Status, TotalAmount = @TotalAmount, PaidDate = GETDATE() WHERE BillID = @BillID";

            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BillID", billID);
                cmd.Parameters.AddWithValue("@Status", BillStatus.Paid);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool Delete(int billID)
        {
            string query = "DELETE FROM Bills WHERE BillID = @BillID";

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BillID", billID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateTable(int billID, int newTableID)
        {
            string sql = @"UPDATE Bills SET TableID = @TableID WHERE BillID = @BillID";
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd =new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TableID", newTableID);
                cmd.Parameters.AddWithValue("@BillID", billID);
                return cmd.ExecuteNonQuery() > 0;
            }
            
        }
        public DataTable GetOpenBillTotals()
        {
            DataTable dt = new DataTable();

            return dt;
        }
    }
}
