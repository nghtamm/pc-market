using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pc_market.Classes {
    public class Functions {
        public static SqlConnection conn;
        public static string connString;

        public static void Connect()
        {
            connString = "Data Source=PHUONGG\\PHUONG;Initial Catalog=pc-market;Integrated Security=True";
            // connString = "Server=127.0.0.1; Database=pc-market; User Id=sa;Password=@itscelex1623;";
            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Kết nối không thành công!\nMã lỗi: " + e.Message, "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void Disconnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd;		               
            cmd = new SqlCommand();	        
            cmd.Connection = Functions.conn;	  
            cmd.CommandText = sql;			  
            try
            {
                cmd.ExecuteNonQuery();		  
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;

            cbo.ValueMember = ma;    // Truong gia tri
            cbo.DisplayMember = ten;    // Truong hien thi
        }





    }
}