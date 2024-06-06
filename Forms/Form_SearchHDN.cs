using System;
using System.Data;
using System.Windows.Forms;

namespace pc_market.Forms {
    public partial class Form_SearchHDN : Form {
        private DataTable table;

        public Form_SearchHDN() {
            InitializeComponent();
        }

        public void Form_SearchHDN_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            string employeeComboBoxQuery = "SELECT maNV, tenNV FROM nhanVien";
            DataTable employeeTable = Classes.Functions.GetDataToTable(employeeComboBoxQuery);
            comboBox1.DataSource = employeeTable;
            comboBox1.DisplayMember = "maNV";
            comboBox1.ValueMember = "maNV";
            comboBox1.SelectedIndex = -1;

            string providerComboBoxQuery = "SELECT maNCC, tenNCC FROM nhaCungCap";
            DataTable providerTable = Classes.Functions.GetDataToTable(providerComboBoxQuery);
            comboBox2.DataSource = providerTable;
            comboBox2.DisplayMember = "maNCC";
            comboBox2.ValueMember = "maNCC";
            comboBox2.SelectedIndex = -1;
        }

        private void ResetValues() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        private void ButtonSearch_Click(object sender, EventArgs e) {
            if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == "") && (comboBox1.SelectedItem == null) && (comboBox2.SelectedItem == null)) {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT * FROM hoaDonNhap WHERE 1=1";
            if (textBox1.Text != "")
                query = query + $" AND maHDN LIKE N'%{textBox1.Text}%'";
            if (textBox2.Text != "")
                query = query + $" AND MONTH(ngayNhap) = {textBox2.Text}";
            if (textBox3.Text != "")
                query = query + $" AND YEAR(ngayNhap) = {textBox3.Text}";
            if (comboBox1.SelectedItem != null)
                query = query + $" AND maNV = '{comboBox1.SelectedValue}'";
            if (comboBox2.SelectedItem != null)
                query = query + $" AND maNCC = '{comboBox2.SelectedValue}'";
            if (textBox4.Text != "")
                query = query + $" AND tongTien <= {textBox4.Text}";
            table = Classes.Functions.GetDataToTable(query);
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có hóa đơn nào thỏa mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + table.Rows.Count + " hóa đơn thỏa mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.DataSource = table;
            DataGridView_Load();
        }

        private void DataGridView_Load() {
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dataGridView1.Columns[1].HeaderText = "Ngày nhập";
            dataGridView1.Columns[2].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[3].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[4].HeaderText = "Tổng tiền";
            dataGridView1.Columns[0].Width = 180;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ButtonRetry_Click(object sender, EventArgs e) {
            ResetValues();
            dataGridView1.DataSource = null;
        }

        private void Total_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void ButtonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e) {
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string invoiceID = dataGridView1.CurrentRow.Cells["maHDN"].Value.ToString();
                Forms.Form_HoaDonNhap formHoaDonNhap = new Forms.Form_HoaDonNhap();
                formHoaDonNhap.textBox1.Text = invoiceID;
                formHoaDonNhap.maskedTextBox1.ReadOnly = true;
                formHoaDonNhap.textBox8.ReadOnly = true;
                formHoaDonNhap.comboBox1.Enabled = false;
                formHoaDonNhap.comboBox2.Enabled = false;
                formHoaDonNhap.comboBox3.Enabled = false;
                formHoaDonNhap.comboBox4.Enabled = false;
                formHoaDonNhap.button1.Enabled = false;
                formHoaDonNhap.button2.Enabled = false;
                formHoaDonNhap.button3.Enabled = false;
                formHoaDonNhap.button4.Enabled = false;
                formHoaDonNhap.button5.Enabled = false;
                formHoaDonNhap.button6.Enabled = false;
                formHoaDonNhap.Show();
            }
        }
    }
}