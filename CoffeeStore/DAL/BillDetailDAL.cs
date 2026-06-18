using CoffeeStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.DAL
{
    public class BillDetailDAL:DBConnection
    {
        public BillDetailDTO GetFoodInBill(int billID,int foodID)
        {
            string sql = @"SELECT * FROM BillDetails WHERE BillID = @BillID AND FoodID = @FoodID";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BillID", billID);
            cmd.Parameters.AddWithValue("@FoodID", foodID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            BillDetailDTO detail = null;
            if (reader.Read())
            {
                detail = new BillDetailDTO();
                detail.BillDetailID = Convert.ToInt32(reader["BillDetailID"]);
                detail.BillID = Convert.ToInt32(reader["BillID"]);
                detail.FoodID = Convert.ToInt32(reader["FoodID"]);
                detail.Quantity = Convert.ToInt32(reader["Quantity"]);
                detail.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                detail.Amount = Convert.ToDecimal(reader["Amount"]);
            }
            conn.Close();
            return detail;
        }
        public bool Insert(BillDetailDTO detail)
        {
            string sql = @"INSERT INTO BillDetails (BillID,FoodID,Quantity,UnitPrice,Amount) 
                                            VALUES (@BillID,@FoodID,@Quantity,@UnitPrice,@Amount)";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BillID", detail.BillID);
            cmd.Parameters.AddWithValue("@FoodID", detail.FoodID);
            cmd.Parameters.AddWithValue("@Quantity", detail.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", detail.UnitPrice);
            cmd.Parameters.AddWithValue("@Amount", detail.Amount);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
        public bool UpdateQuantity( int billDetailID, int quantity, decimal amount)
        {
            string sql = @"UPDATE BillDetails 
                                SET Quantity = @Quantity, Amount = @Amount 
                                WHERE BillDetailID = @BillDetailID";
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue( "@BillDetailID", billDetailID);
            cmd.Parameters.AddWithValue( "@Quantity", quantity);
            cmd.Parameters.AddWithValue( "@Amount", amount);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }
    }
}
