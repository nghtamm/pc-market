using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace pc_market.Classes {
    public class Functions {
        public static SqlConnection conn;
        public static string connString;

        // Kết nối cơ sở dữ liệu
        public static void Connect() {
            // connString for Windows Authentication (using Local SQL Server & SQL Server Management Studio)
            // connString = "Server=localhost;Database=pc-market;Trusted_Connection=True;";

            connString = "Data Source=PHUONGG\\PHUONG;Initial Catalog=pc-market;Integrated Security=True;TrustServerCertificate=true";

            // connString = "Server=127.0.0.1; Database=pc-market; User Id=sa;Password=@itscelex1623;";
            conn = new SqlConnection(connString);
            try {
                conn.Open();
                /*MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
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

        // Lấy dữ liệu từ một query SQL
        public static string GetFieldValues(string query) {
            string key = "";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                key = reader.GetValue(0).ToString();
            }

            reader.Close();
            return key;
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

        // Đổ dữ liệu vào ComboBox
        public static void FillCombo(string query, System.Windows.Forms.ComboBox comboBox, string value, string name) {
            SqlDataAdapter data = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            data.Fill(table);

            comboBox.DataSource = table;
            comboBox.ValueMember = value; // Trường giá trị
            comboBox.DisplayMember = name; // Trường hiển thị
        }
        // Đổ dữ liệu vào combo box với định dạng mã + tên
        /*public static void FillCombo1(string query, ComboBox comboBox, string value, string displayExpression)
        {
            // Create a SqlDataAdapter and DataTable
            SqlDataAdapter data = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            data.Fill(table);

            // Add a new "DisplayMember" column to the DataTable
            table.Columns.Add("DisplayMember", typeof(string)).Expression = displayExpression;

            // Bind the DataTable to the combobox
            comboBox.DataSource = table;

            // Set the ValueMember and DisplayMember properties
            comboBox.ValueMember = value;
            comboBox.DisplayMember = "DisplayMember";

            // Set the selected index to -1
            comboBox.SelectedIndex = -1;
        }*/
        // Hàm này tương tự như hàm FillCombo nhưng có thêm khả năng định dạng văn bản hiển thị trong combobox.



        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }
        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                    break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }


    }
}