using System;
using System.Data;
using System.Windows.Forms;

namespace pc_market.Forms {
    public partial class Form_DataStorage : Form {
        private DataTable table;

        public Form_DataStorage() {
            InitializeComponent();
        }

        private void FormDataStorage_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            textBox1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            DataGridView_Load();
        }

        private void DataGridView_Load() {
            string query = "SELECT oCung.maOC, oCung.tenOC, oCung.dungLuong, oCung.loaiOC, hangSanXuat.tenHSX, oCung.moTa FROM oCung JOIN hangSanXuat ON oCung.maHSX = hangSanXuat.maHSX";
            table = Classes.Functions.GetDataToTable(query);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Mã ổ cứng";
            dataGridView1.Columns[1].HeaderText = "Tên ổ cứng";
            dataGridView1.Columns[2].HeaderText = "Dung lượng";
            dataGridView1.Columns[3].HeaderText = "Loại ổ cứng";
            dataGridView1.Columns[4].HeaderText = "Hãng sản xuất";
            dataGridView1.Columns[5].HeaderText = "Mô tả";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 300;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            string comboBoxQuery = "SELECT maHSX, tenHSX FROM hangSanXuat";
            DataTable manufacturerTable = Classes.Functions.GetDataToTable(comboBoxQuery);
            comboBox1.DataSource = manufacturerTable;
            comboBox1.DisplayMember = "tenHSX";
            comboBox1.ValueMember = "maHSX";

            ResetValues();
        }

        private void DataGridView_Click(object sender, EventArgs e) {
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBox1.Text = dataGridView1.CurrentRow.Cells["maOC"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tenOC"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["dungLuong"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["loaiOC"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["moTa"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["tenHSX"].Value.ToString();

            button5.Enabled = true;
        }

        private void ResetValues() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
            comboBox1.SelectedItem = null;
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;

            ResetValues();
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (textBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập mã ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập tên ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập dung lượng ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập loại ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            string query = $"SELECT oCung.maOC, oCung.tenOC, oCung.dungLuong, oCung.loaiOC, hangSanXuat.tenHSX, oCung.moTa FROM oCung JOIN hangSanXuat ON oCung.maHSX = hangSanXuat.maHSX WHERE oCung.maOC = N'{textBox1.Text.Trim()}'";
            if (Classes.Functions.CheckID(query)) {
                MessageBox.Show("Mã ổ cứng này đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.Text = "";
                return;
            }

            string insertQuery = $"INSERT INTO oCung(maOC, tenOC, dungLuong, loaiOC, moTa, maHSX) VALUES (N'{textBox1.Text.Trim()}', N'{textBox2.Text.Trim()}', N'{textBox3.Text.Trim()}', N'{textBox4.Text.Trim()}', N'{richTextBox1.Text.Trim()}', N'{comboBox1.SelectedValue}')";
            Classes.Functions.RunSQL(insertQuery);
            DataGridView_Load();
            ResetValues();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
        }

        private void ButtonDelete_Click(object sender, EventArgs e) {
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text == "") {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string query = $"DELETE FROM oCung WHERE maOC = N'{textBox1.Text.Trim()}'";
                Classes.Functions.RunDeleteSQL(query);
                DataGridView_Load();
                ResetValues();

                button5.Enabled = false;
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e) {
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox2.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập tên ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập dung lượng ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập loại ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (comboBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string query = $"UPDATE oCung SET tenOC = N'{textBox2.Text.Trim()}', dungLuong = N'{textBox3.Text.Trim()}', loaiOC = N'{textBox4.Text.Trim()}', moTa = N'{richTextBox1.Text.Trim()}', maHSX = N'{comboBox1.SelectedValue}' WHERE maOC = N'{textBox1.Text.Trim()}'";
                Classes.Functions.RunSQL(query);
                DataGridView_Load();
                ResetValues();

                button5.Enabled = false;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e) {
            ResetValues();
            DataGridView_Load();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
        }

        private void Validate_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}