using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace pc_market.Classes {
    public class Functions {
        public static SqlConnection conn;
        public static string connString;

        // Kết nối cơ sở dữ liệu
        public static void Connect() {
            // connString for Windows Authentication (using Local SQL Server & SQL Server Management Studio)
            // connString = "Server=localhost;Database=pc-market;Trusted_Connection=True;";

            connString = "Server=127.0.0.1; Database=pc-market; User Id=sa;Password=@itscelex1623;";
            conn = new SqlConnection(connString);
            try {
                conn.Open();
                // MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) {
                MessageBox.Show($"Kết nối không thành công! \nMã lỗi: {e.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xác thực tài khoản
        public static bool AccountValidate(string username, string password) {
            using (SqlCommand query = new SqlCommand("SELECT * FROM taiKhoan WHERE tenTaiKhoan = @username AND matKhau = @password", conn)) {
                query.Parameters.AddWithValue("@username", username);
                query.Parameters.AddWithValue("@password", password);
                using (SqlDataReader reader = query.ExecuteReader()) {
                    return reader.Read();
                }
            }
        }

        // Đổ dữ liệu vào DataTable
        public static DataTable GetDataToTable(string query) {
            SqlDataAdapter data = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            data.Fill(table);
            return table;
        }

        // Kiểm tra ID của bản ghi
        public static bool CheckID(string query) {
            SqlDataAdapter data = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            data.Fill(table);
            if (table.Rows.Count > 0) {
                return true;
            }

            return false;
        }

        // Thực thi query SQL
        public static void RunSQL(string query) {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            try {
                command.ExecuteNonQuery();
            }
            catch (System.Exception e) {
                MessageBox.Show($"Đã xảy ra lỗi: {e}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();
        }

        // Thực thi query SQL (xóa)
        public static void RunDeleteSQL(string query) {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            try {
                command.ExecuteNonQuery();
            }
            catch (System.Exception) {
                MessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();
        }
    }
}