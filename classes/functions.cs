using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pc_market.classes {
    public class functions {
        public static SqlConnection conn;
        public static string connString;

        public static void Connect()
        {
            connString = "Server=localhost;Database=pc-market;Trusted_Connection=True;";
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
    }
}