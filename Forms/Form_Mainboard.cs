using System;
using System.Data;
using System.Windows.Forms;

namespace pc_market.Forms {
    public partial class Form_Mainboard : Form {
        private DataTable table;

        public Form_Mainboard() {
            InitializeComponent();
        }

        private void FormMainboard_Load(object sender, EventArgs e) {
            Classes.Functions.Connect();
            textBox1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            DataGridView_Load();
        }

        private void DataGridView_Load() {
            string query = "SELECT mainboard.maMainboard, mainboard.tenMainboard, mainboard.socket, mainboard.moTa, hangSanXuat.tenHSX FROM mainboard JOIN hangSanXuat ON mainboard.maHSX = hangSanXuat.maHSX";
            table = Classes.Functions.GetDataToTable(query);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Mã mainboard";
            dataGridView1.Columns[1].HeaderText = "Tên mainboard";
            dataGridView1.Columns[2].HeaderText = "Socket";
            dataGridView1.Columns[3].HeaderText = "Mô tả";
            dataGridView1.Columns[4].HeaderText = "Hãng sản xuất";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 670;
            dataGridView1.Columns[4].Width = 100;
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

            textBox1.Text = dataGridView1.CurrentRow.Cells["maMainboard"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tenMainboard"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["socket"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["moTa"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["tenHSX"].Value.ToString();

            button5.Enabled = true;
        }

        private void ResetValues() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
                MessageBox.Show("Bạn chưa nhập mã mainboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập tên mainboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập socket!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (richTextBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            string query = $"SELECT mainboard.maMainboard, mainboard.tenMainboard, mainboard.socket, mainboard.moTa, hangSanXuat.tenHSX FROM mainboard JOIN hangSanXuat ON mainboard.maHSX = hangSanXuat.maHSX WHERE mainboard.maMainboard = N'{textBox1.Text.Trim()}'";
            if (Classes.Functions.CheckID(query)) {
                MessageBox.Show("Mã mainboard này đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.Text = "";
                return;
            }

            string insertQuery = $"INSERT INTO mainboard(maMainboard, tenMainboard, socket, moTa, maHSX) VALUES (N'{textBox1.Text.Trim()}', N'{textBox2.Text.Trim()}', N'{textBox3.Text.Trim()}', N'{richTextBox1.Text.Trim()}', N'{comboBox1.SelectedValue}')";
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
                string query = $"DELETE FROM mainboard WHERE maMainboard = N'{textBox1.Text.Trim()}'";
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
                MessageBox.Show("Bạn chưa nhập tên mainboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập socket!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (richTextBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                richTextBox1.Focus();
                return;
            }

            if (comboBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string query = $"UPDATE mainboard SET tenMainboard = N'{textBox2.Text.Trim()}', socket = N'{textBox3.Text.Trim()}', moTa = N'{richTextBox1.Text.Trim()}', maHSX = N'{comboBox1.SelectedValue}' WHERE maMainboard = N'{textBox1.Text.Trim()}'";
                Classes.Functions.RunSQL(query);
                DataGridView_Load();
                ResetValues();

                button5.Enabled = false;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e) {
            ResetValues();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
        }
    }
}