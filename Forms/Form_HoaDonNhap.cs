using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using pc_market.Classes;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace pc_market.Forms {
    public partial class Form_HoaDonNhap : Form {
        private DataTable table;

        public Form_HoaDonNhap() {
            InitializeComponent();
        }

        public void Form_HoaDonNhap_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;

            string employeeComboBoxQuery = "SELECT maNV, tenNV, maNV + ' - ' + tenNV as display FROM nhanVien";
            DataTable employeeTable = Classes.Functions.GetDataToTable(employeeComboBoxQuery);
            comboBox1.DataSource = employeeTable;
            comboBox1.DisplayMember = "display";
            comboBox1.ValueMember = "maNV";
            comboBox1.SelectedIndex = -1;

            string providerComboBoxQuery = "SELECT maNCC, tenNCC, maNCC + ' - ' + tenNCC as display FROM nhaCungCap";
            DataTable providerTable = Classes.Functions.GetDataToTable(providerComboBoxQuery);
            comboBox2.DataSource = providerTable;
            comboBox2.DisplayMember = "display";
            comboBox2.ValueMember = "maNCC";
            comboBox2.SelectedIndex = -1;

            string pcComboBoxQuery = "SELECT maMay, tenMay, maMay + ' - ' + tenMay as display FROM mayTinh";
            DataTable pcTable = Classes.Functions.GetDataToTable(pcComboBoxQuery);
            comboBox3.DataSource = pcTable;
            comboBox3.DisplayMember = "display";
            comboBox3.ValueMember = "maMay";
            comboBox3.SelectedIndex = -1;

            if (textBox1.Text != "") {
                InvoiceDetails_Load();
                button3.Enabled = true;
                button4.Enabled = true;
            }

            DataGridView_Load();
        }

        public void DataGridView_Load() {
            string query = $"SELECT mayTinh.maMay, mayTinh.tenMay, chiTietHDN.soLuong, mayTinh.giaNhap, chiTietHDN.thanhTien FROM mayTinh JOIN chiTietHDN ON mayTinh.maMay = chiTietHDN.maMay WHERE chiTietHDN.maHDN = '{textBox1.Text}'";
            table = Classes.Functions.GetDataToTable(query);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Mã máy tính";
            dataGridView1.Columns[1].HeaderText = "Tên máy tính";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá";
            dataGridView1.Columns[4].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void EmployeeID_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedItem == null)
                textBox2.Text = "";
            string query = $"SELECT tenNV FROM nhanVien WHERE maNV = '{comboBox1.SelectedValue}'";
            textBox2.Text = Classes.Functions.GetFieldValues(query);
        }

        private void ProviderID_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox2.SelectedItem == null) {
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                return;
            }

            string query = $"SELECT tenNCC, diaChi, dienThoai FROM nhaCungCap WHERE maNCC = '{comboBox2.SelectedValue}'";
            DataTable table = Classes.Functions.GetDataToTable(query);
            if (table.Rows.Count > 0) {
                textBox3.Text = table.Rows[0][0].ToString();
                textBox4.Text = table.Rows[0][1].ToString();
                textBox5.Text = table.Rows[0][2].ToString();
            }
            else {
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void PCID_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox3.SelectedItem == null) {
                textBox6.Text = "";
                textBox7.Text = "";
                return;
            }

            string query = $"SELECT tenMay, giaNhap FROM mayTinh WHERE maMay = '{comboBox3.SelectedValue}'";
            DataTable table = Classes.Functions.GetDataToTable(query);
            if (table.Rows.Count > 0) {
                textBox6.Text = table.Rows[0][0].ToString();
                textBox7.Text = table.Rows[0][1].ToString();
            }
            else {
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        private void InvoiceDetails_Load() {
            string invoiceDate = $"SELECT ngayNhap FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
            maskedTextBox1.Text = Classes.Functions.ConvertDateTime(Classes.Functions.GetFieldValues(invoiceDate));
            string employeeID = $"SELECT maNV FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
            comboBox1.SelectedValue = Classes.Functions.GetFieldValues(employeeID);
            string providerID = $"SELECT maNCC FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
            comboBox2.SelectedValue = Classes.Functions.GetFieldValues(providerID);
            string total = $"SELECT tongTien FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
            textBox10.Text = Classes.Functions.GetFieldValues(total);
            label17.Text = $"Bằng chữ: {Classes.Functions.ConvertNumericToText(textBox10.Text)}";
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = true;

            ResetValues();
            DataGridView_Load();

            textBox1.Text = Classes.Functions.CreateKey("HDN");
        }

        private void ResetValues() {
            textBox1.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            maskedTextBox1.Text = DateTime.Now.ToShortDateString();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            label17.Text = "Bằng chữ: ";
        }

        private void Items_ResetValues() {
            comboBox4.SelectedItem = null;
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void Quantity_TextChanged(object sender, EventArgs e) {
            double quantity = (textBox8.Text == "") ? 0 : Convert.ToDouble(textBox8.Text);
            double price = (textBox7.Text == "") ? 0 : Convert.ToDouble(textBox7.Text);
            double total = quantity * price;
            textBox9.Text = total.ToString();
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            string firstQuery = $"SELECT maHDN FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
            if (!Classes.Functions.CheckID(firstQuery)) {
                if (textBox2.Text.Length == 0) {
                    MessageBox.Show("Bạn chưa nhập ngày nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                if (comboBox1.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa lựa chọn nhân viên nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus();
                    return;
                }

                if (comboBox2.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa lựa chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    return;
                }

                string insertQuery = $"INSERT INTO hoaDonNhap(maHDN, ngayNhap, maNV, maNCC, tongTien) VALUES ('{textBox1.Text}', '{Classes.Functions.ConvertDateTime(maskedTextBox1.Text)}', '{comboBox1.SelectedValue}', '{comboBox2.SelectedValue}', '{textBox10.Text}')";
                Classes.Functions.RunSQL(insertQuery);
            }

            if (comboBox3.SelectedValue == null) {
                MessageBox.Show("Bạn chưa lựa chọn mã máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox3.Focus();
                return;
            }

            if ((textBox8.Text.Trim().Length == 0) || (textBox8.Text == "0")) {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Text = "";
                textBox8.Focus();
                return;
            }

            string secondQuery = $"SELECT maMay FROM chiTietHDN WHERE maMay = '{comboBox4.SelectedValue}' AND maHDN = '{textBox1.Text}'";
            if (Classes.Functions.CheckID(secondQuery)) {
                MessageBox.Show("Sản phẩm này đã được chọn, bạn phải lựa chọn mặt hàng máy tính khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Items_ResetValues();
                comboBox4.Focus();
                return;
            }

            double quantity, inputQuantity;
            if (!double.TryParse(Classes.Functions.GetFieldValues($"SELECT soLuong FROM mayTinh WHERE maMay = '{comboBox3.SelectedValue}'"), out quantity)) {
                MessageBox.Show("Đã xảy ra lỗi khi truy vấn từ cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox8.Text, out inputQuantity)) {
                MessageBox.Show("Số lượng sản phẩm nhập vào không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Focus();
                return;
            }

            string detailsInsertQuery = $"INSERT INTO chiTietHDN(maHDN, maMay, soLuong, thanhTien) VALUES ('{textBox1.Text}', '{comboBox3.SelectedValue}', '{textBox8.Text}', '{textBox9.Text}')";
            Classes.Functions.RunSQL(detailsInsertQuery);
            DataGridView_Load();

            double newQuantity = quantity + inputQuantity;
            string updateQuery = $"UPDATE mayTinh SET soLuong = '{newQuantity}' WHERE maMay = '{comboBox3.SelectedValue}'";
            Classes.Functions.RunSQL(updateQuery);

            double total;
            if (!double.TryParse(Classes.Functions.GetFieldValues($"SELECT tongTien FROM hoaDonNhap WHERE maHDN = '{textBox1.Text}'"), out total)) {
                MessageBox.Show("Đã xảy ra lỗi khi truy vấn từ cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double subtotal;
            if (!double.TryParse(textBox9.Text, out subtotal)) {
                MessageBox.Show("Đã xảy ra lỗi ghi nhận dữ liệu 'Thành tiền'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double newTotal = total + subtotal;
            string totalUpdateQuery = $"UPDATE hoaDonNhap SET tongTien = '{newTotal}' WHERE maHDN = '{textBox1.Text}'";
            Classes.Functions.RunSQL(totalUpdateQuery);
            textBox10.Text = newTotal.ToString();
            label17.Text = $"Bằng chữ: {Classes.Functions.ConvertNumericToText(newTotal.ToString())}";

            Items_ResetValues();
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
        }

        private void DeleteItem(string invoiceID, string pcID) {
            string query = $"SELECT soLuong FROM chiTietHDN WHERE maHDN = '{invoiceID}' AND maMay = '{pcID}'";
            double invoiceQuantity = Convert.ToDouble(Classes.Functions.GetFieldValues(query));

            string deleteQuery = $"DELETE chiTietHDN WHERE maHDN = '{invoiceID}' AND maMay = '{pcID}'";
            Classes.Functions.RunDeleteSQL(deleteQuery);

            string secondQuery = $"SELECT soLuong FROM mayTinh WHERE maMay = '{pcID}'";
            double quantity = Convert.ToDouble(Classes.Functions.GetFieldValues(secondQuery));

            double remainingQuantity = quantity - invoiceQuantity;
            string updateQuery = $"UPDATE mayTinh SET soLuong = '{remainingQuantity}' WHERE maMay = '{pcID}'";
            Classes.Functions.RunSQL(updateQuery);
        }

        private void Delete_UpdateTotal(string invoiceID, double subtotal) {
            string query = $"SELECT tongTien FROM hoaDonNhap WHERE maHDN = '{invoiceID}'";
            double total = Convert.ToDouble(Classes.Functions.GetFieldValues(query));

            double newTotal = total - subtotal;
            string updateQuery = $"UPDATE hoaDonNhap SET tongTien = '{newTotal}' WHERE maHDN = '{invoiceID}'";
            Classes.Functions.RunSQL(updateQuery);
            textBox10.Text = newTotal.ToString();
            label17.Text = "Bằng chữ: " + Classes.Functions.ConvertNumericToText(newTotal.ToString());
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                string item = dataGridView1.CurrentRow.Cells["maMay"].Value.ToString();
                DeleteItem(textBox1.Text, item);

                double subtotal = Convert.ToDouble(dataGridView1.CurrentRow.Cells["thanhTien"].Value.ToString());
                Delete_UpdateTotal(textBox1.Text, subtotal);
                DataGridView_Load();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string[] pcID = new string[20];
                int i, n = 0;
                string query = $"SELECT maMay FROM chiTietHDN WHERE maHDN = '{textBox1.Text}'";
                SqlCommand command = new SqlCommand(query, Classes.Functions.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    pcID[n] = reader.GetString(0).ToString();
                    n++;
                }

                reader.Close();

                for (i = 0; i <= n - 1; i++)
                    DeleteItem(textBox1.Text, pcID[i]);
                string deleteQuery = $"DELETE hoaDonNhap WHERE maHDN = '{textBox1.Text}'";
                Classes.Functions.RunDeleteSQL(deleteQuery);

                ResetValues();
                DataGridView_Load();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void InvoiceID_ComboBox_DropDown(object sender, EventArgs e) {
            string query = "SELECT maHDN FROM hoaDonNhap";
            DataTable table = Classes.Functions.GetDataToTable(query);
            comboBox4.DataSource = table;
            comboBox4.DisplayMember = "maHDN";
            comboBox4.ValueMember = "maHDN";
            comboBox4.SelectedIndex = -1;
        }

        private void ButtonSearch_Click(object sender, EventArgs e) {
            if (comboBox4.Text == "") {
                MessageBox.Show("Bạn chưa chọn mã hóa đơn nào để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox4.Focus();
                return;
            }

            textBox1.Text = comboBox4.SelectedValue.ToString();
            DataGridView_Load();
            InvoiceDetails_Load();

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            if (comboBox4.Items.Count > 0) {
                comboBox4.SelectedIndex = -1;
            }
        }

        private void ButtonComplete_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Bạn đã hoàn thành hóa đơn nhập hiện tại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                ResetValues();
                Items_ResetValues();
                DataGridView_Load();

                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e) {
            COMExcel.Application excelApp = new COMExcel.Application();
            COMExcel.Workbook excelBook;
            COMExcel.Worksheet excelSheet;
            COMExcel.Range excelRange;

            int excelRow = 0;
            int excelColumn = 0;
            int totalQuantity = 0;
            DataTable invoiceDetails, pcDetails;

            excelBook = excelApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            excelSheet = (COMExcel.Worksheet)excelBook.Worksheets[1];
            excelRange = (COMExcel.Range)excelSheet.Cells[1, 1];
            excelRange.Range["A1:B3"].Font.Size = 12;
            excelRange.Range["A1:B3"].Font.Name = "Times New Roman";
            excelRange.Range["A1:B3"].Font.Bold = true;
            excelRange.Range["A1:B3"].Font.ColorIndex = 5;
            excelRange.Range["A1:A1"].ColumnWidth = 7;
            excelRange.Range["B1:B1"].ColumnWidth = 15;
            excelRange.Range["A1:B1"].MergeCells = true;
            excelRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A1:B1"].Value = "Cửa hàng máy tính PC Market";
            excelRange.Range["A2:B2"].MergeCells = true;
            excelRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A2:B2"].Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";
            excelRange.Range["A3:B3"].MergeCells = true;
            excelRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A3:B3"].Value = "Điện thoại: 0123456789";

            excelRange.Range["C2:L2"].Font.Size = 16;
            excelRange.Range["C2:L2"].Font.Name = "Times New Roman";
            excelRange.Range["C2:L2"].Font.Bold = true;
            excelRange.Range["C2:L2"].Font.ColorIndex = 3;
            excelRange.Range["C2:L2"].MergeCells = true;
            excelRange.Range["C2:L2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["C2:L2"].Value = "HÓA ĐƠN NHẬP HÀNG";

            string invoiceQuery = $"SELECT hoaDonNhap.maHDN, hoaDonNhap.ngayNhap, hoaDonNhap.tongTien, nhaCungCap.tenNCC, nhaCungCap.diaChi, nhaCungCap.dienThoai, nhanVien.tenNV FROM hoaDonNhap JOIN nhanVien ON hoaDonNhap.maNV = nhanVien.maNV JOIN nhaCungCap ON hoaDonNhap.maNCC = nhaCungCap.maNCC WHERE hoaDonNhap.maHDN = '{textBox1.Text}'";
            invoiceDetails = Classes.Functions.GetDataToTable(invoiceQuery);
            excelRange.Range["B6:C9"].Font.Size = 12;
            excelRange.Range["B6:C9"].Font.Name = "Times New Roman";
            excelRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            excelRange.Range["C6:L6"].MergeCells = true;
            excelRange.Range["C6:L6"].Value = invoiceDetails.Rows[0][0].ToString();
            excelRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            excelRange.Range["C7:L7"].MergeCells = true;
            excelRange.Range["C7:L7"].Value = invoiceDetails.Rows[0][3].ToString();
            excelRange.Range["B8:B8"].Value = "Địa chỉ:";
            excelRange.Range["C8:L8"].MergeCells = true;
            excelRange.Range["C8:L8"].Value = invoiceDetails.Rows[0][4].ToString();
            excelRange.Range["B9:B9"].Value = "Điện thoại:";
            excelRange.Range["C9:L9"].MergeCells = true;
            excelRange.Range["C9:L9"].NumberFormat = "@";
            excelRange.Range["C9:L9"].Value = "'" + invoiceDetails.Rows[0][5].ToString();

            string pcQuery = $"SELECT mayTinh.tenMay, chiTietHDN.soLuong, mayTinh.giaNhap, chiTietHDN.thanhTien FROM mayTinh JOIN chiTietHDN ON mayTinh.maMay = chiTietHDN.maMay WHERE chiTietHDN.maHDN = '{textBox1.Text}'";
            pcDetails = Classes.Functions.GetDataToTable(pcQuery);
            excelRange.Range["A11:F11"].Font.Bold = true;
            excelRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["C11:F11"].ColumnWidth = 12;
            excelRange.Range["A11:A11"].Value = "Số thứ tự";
            excelRange.Range["B11:B11"].Value = "Tên máy tính";
            excelRange.Range["C11:C11"].Value = "Số lượng";
            excelRange.Range["D11:D11"].Value = "Đơn giá";
            excelRange.Range["E11:E11"].Value = "Thành tiền";
            for (excelRow = 0; excelRow <= pcDetails.Rows.Count - 1; excelRow++) {
                excelSheet.Cells[excelRow + 12, 1] = excelRow + 1;
                for (excelColumn = 0; excelColumn <= pcDetails.Columns.Count - 1; excelColumn++) {
                    excelSheet.Cells[excelRow + 12, excelColumn + 2] = pcDetails.Rows[excelRow][excelColumn].ToString();
                    if (excelColumn == 1) {
                        totalQuantity += int.Parse(pcDetails.Rows[excelRow][excelColumn].ToString());
                    }
                }
            }

            excelRange = (COMExcel.Range)excelSheet.Cells[excelRow + 14, excelColumn];
            excelRange.Font.Bold = true;
            excelRange.Value2 = "Tổng tiền:";
            excelRange = (COMExcel.Range)excelSheet.Cells[excelRow + 14, excelColumn + 1];
            excelRange.Font.Bold = true;
            excelRange.Value2 = invoiceDetails.Rows[0][2].ToString();
            excelRange = (COMExcel.Range)excelSheet.Cells[excelRow + 15, 1];
            excelRange.Range["A1:F1"].MergeCells = true;
            excelRange.Range["A1:F1"].Font.Bold = true;
            excelRange.Range["A1:F1"].Font.Italic = true;
            excelRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            excelRange.Range["A1:F1"].Value = "Bằng chữ: " + Classes.Functions.ConvertNumericToText(invoiceDetails.Rows[0][2].ToString());

            excelRange = (COMExcel.Range)excelSheet.Cells[excelRow + 14, 3];
            excelRange.Font.Bold = true;
            excelRange.Value2 = "Tổng số lượng sản phẩm: " + totalQuantity.ToString();

            excelRange = (COMExcel.Range)excelSheet.Cells[excelRow + 17, 4];
            excelRange.Range["A1:C1"].MergeCells = true;
            excelRange.Range["A1:C1"].Font.Italic = true;
            excelRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime date = Convert.ToDateTime(invoiceDetails.Rows[0][1]);
            excelRange.Range["A1:C1"].Value = $"Hà Nội, ngày {date.Day} tháng {date.Month} năm {date.Year}";
            excelRange.Range["A2:C2"].MergeCells = true;
            excelRange.Range["A2:C2"].Font.Italic = true;
            excelRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            excelRange.Range["A6:C6"].MergeCells = true;
            excelRange.Range["A6:C6"].Font.Italic = true;
            excelRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A6:C6"].Value = invoiceDetails.Rows[0][6];

            COMExcel.Range usedRange = excelSheet.UsedRange;
            usedRange.EntireColumn.AutoFit();

            excelSheet.Name = "Hóa đơn nhập";
            excelApp.Visible = true;
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}