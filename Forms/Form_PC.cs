using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace pc_market.Forms {
    public partial class Form_PC : Form {
        private DataTable table;

        public Form_PC() {
            InitializeComponent();
        }

        private void FormPC_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            DataGridView_Load();
        }

        private void DataGridView_Load() {
            string query = "SELECT mayTinh.maMay, mayTinh.tenMay, loaiMay.tenLoaiMay, mainboard.tenMainboard, CPU.tenCPU, ram.tenRam, GPU.tenGPU, oCung.tenOC, manHinh.thongTin, hangSanXuat.tenHSX, mayTinh.giaNhap, mayTinh.giaBan, mayTinh.soLuong, mayTinh.thoiGianBH, mayTinh.ghiChu " +
                           "FROM mayTinh " +
                           "LEFT JOIN loaiMay ON mayTinh.maLoaiMay = loaiMay.maLoaiMay " +
                           "LEFT JOIN mainboard ON mayTinh.maMainboard = mainboard.maMainboard " +
                           "LEFT JOIN CPU ON mayTinh.maCPU = CPU.maCPU " +
                           "LEFT JOIN ram ON mayTinh.maRam = ram.maRam " +
                           "LEFT JOIN GPU ON mayTinh.maGPU = GPU.maGPU " +
                           "LEFT JOIN oCung ON mayTinh.maOC = oCung.maOC " +
                           "LEFT JOIN manHinh ON mayTinh.maMH = manHinh.maMH " +
                           "LEFT JOIN hangSanXuat ON mayTinh.maHSX = hangSanXuat.maHSX";
            table = Classes.Functions.GetDataToTable(query);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Mã máy tính";
            dataGridView1.Columns[1].HeaderText = "Tên máy tính";
            dataGridView1.Columns[2].HeaderText = "Loại máy";
            dataGridView1.Columns[3].HeaderText = "Mainboard";
            dataGridView1.Columns[4].HeaderText = "Vi xử lý";
            dataGridView1.Columns[5].HeaderText = "RAM";
            dataGridView1.Columns[6].HeaderText = "Card đồ họa";
            dataGridView1.Columns[7].HeaderText = "Ổ cứng";
            dataGridView1.Columns[8].HeaderText = "Màn hình";
            dataGridView1.Columns[9].HeaderText = "Hãng sản xuất";
            dataGridView1.Columns[10].HeaderText = "Giá nhập";
            dataGridView1.Columns[11].HeaderText = "Giá bán";
            dataGridView1.Columns[12].HeaderText = "Số lượng";
            dataGridView1.Columns[13].HeaderText = "Thời gian bảo hành";
            dataGridView1.Columns[14].HeaderText = "Ghi chú";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 160;
            dataGridView1.Columns[5].Width = 160;
            dataGridView1.Columns[6].Width = 160;
            dataGridView1.Columns[7].Width = 160;
            dataGridView1.Columns[8].Width = 200;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 100;
            dataGridView1.Columns[11].Width = 100;
            dataGridView1.Columns[12].Width = 80;
            dataGridView1.Columns[13].Width = 80;
            dataGridView1.Columns[14].Width = 400;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            string typeComboBoxQuery = "SELECT maLoaiMay, tenLoaiMay FROM loaiMay";
            DataTable typeTable = Classes.Functions.GetDataToTable(typeComboBoxQuery);
            comboBox1.DataSource = typeTable;
            comboBox1.DisplayMember = "tenLoaiMay";
            comboBox1.ValueMember = "maLoaiMay";

            string mainboardComboBoxQuery = "SELECT maMainboard, tenMainboard FROM mainboard";
            DataTable mainboardTable = Classes.Functions.GetDataToTable(mainboardComboBoxQuery);
            comboBox2.DataSource = mainboardTable;
            comboBox2.DisplayMember = "tenMainboard";
            comboBox2.ValueMember = "maMainboard";

            string cpuComboBoxQuery = "SELECT maCPU, tenCPU FROM CPU";
            DataTable cpuTable = Classes.Functions.GetDataToTable(cpuComboBoxQuery);
            comboBox3.DataSource = cpuTable;
            comboBox3.DisplayMember = "tenCPU";
            comboBox3.ValueMember = "maCPU";

            string ramComboBoxQuery = "SELECT maRam, tenRam FROM ram";
            DataTable ramTable = Classes.Functions.GetDataToTable(ramComboBoxQuery);
            comboBox4.DataSource = ramTable;
            comboBox4.DisplayMember = "tenRam";
            comboBox4.ValueMember = "maRam";

            string gpuComboBoxQuery = "SELECT maGPU, tenGPU FROM GPU";
            DataTable gpuTable = Classes.Functions.GetDataToTable(gpuComboBoxQuery);
            comboBox5.DataSource = gpuTable;
            comboBox5.DisplayMember = "tenGPU";
            comboBox5.ValueMember = "maGPU";

            string driveComboBoxQuery = "SELECT maOC, tenOC FROM oCung";
            DataTable driveTable = Classes.Functions.GetDataToTable(driveComboBoxQuery);
            comboBox6.DataSource = driveTable;
            comboBox6.DisplayMember = "tenOC";
            comboBox6.ValueMember = "maOC";

            string screenComboBoxQuery = "SELECT maMH, thongTin FROM manHinh";
            DataTable screenTable = Classes.Functions.GetDataToTable(screenComboBoxQuery);
            comboBox7.DataSource = screenTable;
            comboBox7.DisplayMember = "thongTin";
            comboBox7.ValueMember = "maMH";

            string manufacturerComboBoxQuery = "SELECT maHSX, tenHSX FROM hangSanXuat";
            DataTable manufacturerTable = Classes.Functions.GetDataToTable(manufacturerComboBoxQuery);
            comboBox8.DataSource = manufacturerTable;
            comboBox8.DisplayMember = "tenHSX";
            comboBox8.ValueMember = "maHSX";

            ResetValues();
        }

        private void DataGridView_Click(object sender, EventArgs e) {
            if (table.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBox1.Text = dataGridView1.CurrentRow.Cells["maMay"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tenMay"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["tenLoaiMay"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["tenMainboard"].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells["tenCPU"].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells["tenRam"].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells["tenGPU"].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells["tenOC"].Value.ToString();
            comboBox7.Text = dataGridView1.CurrentRow.Cells["thongTin"].Value.ToString();
            comboBox8.Text = dataGridView1.CurrentRow.Cells["tenHSX"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["giaNhap"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["giaBan"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["soLuong"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["thoiGianBH"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["ghiChu"].Value.ToString();

            string image = Classes.Functions.GetFieldValues($"SELECT mayTinh.hinhAnh FROM mayTinh WHERE maMay = N'{textBox1.Text.Trim()}'");
            textBox7.Text = image;
            pictureBox1.Image = (image != "") ? Image.FromFile(textBox7.Text) : null;

            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void ResetValues() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            richTextBox1.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            comboBox5.SelectedItem = null;
            comboBox6.SelectedItem = null;
            comboBox7.SelectedItem = null;
            comboBox8.SelectedItem = null;
            pictureBox1.Image = null;
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = false;

            ResetValues();
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void ButtonAddImage_Click(object sender, EventArgs e) {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            file.Title = "Lựa chọn hình ảnh cho sản phẩm";
            if (file.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(file.FileName);
                textBox7.Text = file.FileName;
            }
        }

        private void ImportPrice_TextChanged(object sender, EventArgs e) {
            try {
                long importPrice = long.Parse(textBox3.Text.Trim());
                double exportPrice = importPrice * 1.3;
                textBox4.Text = ((long)exportPrice).ToString();
            }
            catch (FormatException) {
                textBox4.Text = "";
            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedValue != null) {
                string type = comboBox1.SelectedValue.ToString();
                if (type == "LAP") {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.Enabled = false;

                    comboBox7.Enabled = true;
                    comboBox8.Enabled = true;
                }
                else if (type == "PC") {
                    comboBox2.Enabled = true;

                    comboBox7.SelectedIndex = -1;
                    comboBox8.SelectedIndex = -1;
                    comboBox7.Enabled = false;
                    comboBox8.Enabled = false;
                }
            }
            else {
                comboBox2.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (textBox1.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập mã máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn chưa nhập tên máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn loại máy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            string type = comboBox1.SelectedValue.ToString();
            if (type == "LAP") {
                if (comboBox3.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn CPU!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.Focus();
                    return;
                }

                if (comboBox4.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn RAM!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox4.Focus();
                    return;
                }

                if (comboBox5.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn card đồ họa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox5.Focus();
                    return;
                }

                if (comboBox6.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox6.Focus();
                    return;
                }

                if (comboBox7.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn thông tin màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox7.Focus();
                    return;
                }

                if (comboBox8.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox8.Focus();
                    return;
                }

                if (textBox3.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (textBox5.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                }
            }
            else if (type == "PC") {
                if (comboBox2.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn mainboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    return;
                }

                if (comboBox3.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn CPU!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.Focus();
                    return;
                }

                if (comboBox4.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn RAM!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox4.Focus();
                    return;
                }

                if (comboBox5.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn card đồ họa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox5.Focus();
                    return;
                }

                if (comboBox6.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox6.Focus();
                    return;
                }

                if (textBox3.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (textBox5.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                }
            }

            string query = $"SELECT maMay FROM mayTinh WHERE maMay = N'{textBox1.Text.Trim()}'";
            if (Classes.Functions.CheckID(query)) {
                MessageBox.Show("Mã máy tính này đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.Text = "";
                return;
            }

            string mainboardID = (comboBox2.SelectedValue != null) ? comboBox2.SelectedValue.ToString() : "NULL";
            string monitorID = (comboBox7.SelectedValue != null) ? comboBox7.SelectedValue.ToString() : "NULL";
            string manufacturerID = (comboBox8.SelectedValue != null) ? comboBox8.SelectedValue.ToString() : "NULL";
            string insertQuery = "INSERT INTO mayTinh(maMay, tenMay, maLoaiMay, maMainboard, maCPU, maRam, maGPU, maOC, maMH, maHSX, giaNhap, giaBan, soLuong, thoiGianBH, ghiChu, hinhAnh) " +
                                 $"VALUES (N'{textBox1.Text.Trim()}', N'{textBox2.Text.Trim()}', N'{comboBox1.SelectedValue}', {(mainboardID == "NULL" ? "NULL" : $"N'{mainboardID}'")}, N'{comboBox3.SelectedValue}', N'{comboBox4.SelectedValue}', N'{comboBox5.SelectedValue}', N'{comboBox6.SelectedValue}', {(monitorID == "NULL" ? "NULL" : $"N'{monitorID}'")}, {(manufacturerID == "NULL" ? "NULL" : $"N'{manufacturerID}'")}, {long.Parse(textBox3.Text.Trim())}, {long.Parse(textBox4.Text.Trim())}, N'{textBox5.Text.Trim()}', N'{textBox6.Text.Trim()}', N'{richTextBox1.Text.Trim()}', N'{textBox7.Text.Trim()}')";
            Classes.Functions.RunSQL(insertQuery);
            DataGridView_Load();
            ResetValues();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
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
                string query = $"DELETE FROM mayTinh WHERE maMay = N'{textBox1.Text.Trim()}'";
                Classes.Functions.RunDeleteSQL(query);
                DataGridView_Load();
                ResetValues();

                button5.Enabled = false;
                button6.Enabled = false;
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
                MessageBox.Show("Bạn chưa nhập tên máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn loại máy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            string type = comboBox1.SelectedValue.ToString();
            if (type == "LAP") {
                if (comboBox3.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn CPU!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.Focus();
                    return;
                }

                if (comboBox4.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn RAM!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox4.Focus();
                    return;
                }

                if (comboBox5.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn card đồ họa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox5.Focus();
                    return;
                }

                if (comboBox6.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox6.Focus();
                    return;
                }

                if (comboBox7.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn thông tin màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox7.Focus();
                    return;
                }

                if (comboBox8.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn hãng sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox8.Focus();
                    return;
                }

                if (textBox3.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (textBox5.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                }
            }
            else if (type == "PC") {
                if (comboBox2.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn mainboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    return;
                }

                if (comboBox3.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn CPU!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.Focus();
                    return;
                }

                if (comboBox4.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn RAM!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox4.Focus();
                    return;
                }

                if (comboBox5.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn card đồ họa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox5.Focus();
                    return;
                }

                if (comboBox6.SelectedValue == null) {
                    MessageBox.Show("Bạn chưa chọn ổ cứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox6.Focus();
                    return;
                }

                if (textBox3.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập giá nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Focus();
                    return;
                }

                if (textBox5.Text.Trim().Length == 0) {
                    MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox5.Focus();
                    return;
                }
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                string mainboardID = (comboBox2.SelectedValue != null) ? comboBox2.SelectedValue.ToString() : "NULL";
                string monitorID = (comboBox7.SelectedValue != null) ? comboBox7.SelectedValue.ToString() : "NULL";
                string manufacturerID = (comboBox8.SelectedValue != null) ? comboBox8.SelectedValue.ToString() : "NULL";
                string query = "UPDATE mayTinh " +
                               $"SET tenMay = N'{textBox2.Text.Trim()}', maLoaiMay = N'{comboBox1.SelectedValue}', maMainboard = {(mainboardID == "NULL" ? "NULL" : $"N'{mainboardID}'")}, maCPU = N'{comboBox3.SelectedValue}', maRam = N'{comboBox4.SelectedValue}', maGPU = N'{comboBox5.SelectedValue}', maOC = N'{comboBox6.SelectedValue}', maMH = {(monitorID == "NULL" ? "NULL" : $"N'{monitorID}'")}, maHSX = {(manufacturerID == "NULL" ? "NULL" : $"N'{manufacturerID}'")}, giaNhap = {long.Parse(textBox3.Text.Trim())}, giaBan = {long.Parse(textBox4.Text.Trim())}, soLuong = N'{textBox5.Text.Trim()}', thoiGianBH = N'{textBox6.Text.Trim()}', ghiChu = N'{richTextBox1.Text.Trim()}', hinhAnh = N'{textBox7.Text.Trim()}' " +
                               $"WHERE maMay = N'{textBox1.Text.Trim()}'";
                Classes.Functions.RunSQL(query);
                DataGridView_Load();
                ResetValues();

                button5.Enabled = false;
                button6.Enabled = false;
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
            button6.Enabled = false;
            button7.Enabled = true;
            textBox1.Enabled = false;
        }

        private void ButtonSearch_Click(object sender, EventArgs e) {
            string keyword = Interaction.InputBox("Nhập tên sản phẩm cần tìm", "Tìm kiếm");

            if (keyword == "") {
                return;
            }

            if (string.IsNullOrWhiteSpace(keyword)) {
                MessageBox.Show("Bạn chưa nhập tên mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT mayTinh.maMay, mayTinh.tenMay, loaiMay.tenLoaiMay, mainboard.tenMainboard, CPU.tenCPU, ram.tenRam, GPU.tenGPU, oCung.tenOC, manHinh.thongTin, hangSanXuat.tenHSX, mayTinh.giaNhap, mayTinh.giaBan, mayTinh.soLuong, mayTinh.thoiGianBH, mayTinh.ghiChu " +
                           "FROM mayTinh " +
                           "LEFT JOIN loaiMay ON mayTinh.maLoaiMay = loaiMay.maLoaiMay " +
                           "LEFT JOIN mainboard ON mayTinh.maMainboard = mainboard.maMainboard " +
                           "LEFT JOIN CPU ON mayTinh.maCPU = CPU.maCPU " +
                           "LEFT JOIN ram ON mayTinh.maRam = ram.maRam " +
                           "LEFT JOIN GPU ON mayTinh.maGPU = GPU.maGPU " +
                           "LEFT JOIN oCung ON mayTinh.maOC = oCung.maOC " +
                           "LEFT JOIN manHinh ON mayTinh.maMH = manHinh.maMH " +
                           "LEFT JOIN hangSanXuat ON mayTinh.maHSX = hangSanXuat.maHSX " +
                           $"WHERE tenMay LIKE N'%{keyword}%'";
            DataTable searchTable = Classes.Functions.GetDataToTable(query);
            if (searchTable.Rows.Count > 0) {
                dataGridView1.DataSource = searchTable;
                dataGridView1.Columns[0].HeaderText = "Mã máy tính";
                dataGridView1.Columns[1].HeaderText = "Tên máy tính";
                dataGridView1.Columns[2].HeaderText = "Loại máy";
                dataGridView1.Columns[3].HeaderText = "Mainboard";
                dataGridView1.Columns[4].HeaderText = "Vi xử lý";
                dataGridView1.Columns[5].HeaderText = "RAM";
                dataGridView1.Columns[6].HeaderText = "Card đồ họa";
                dataGridView1.Columns[7].HeaderText = "Ổ cứng";
                dataGridView1.Columns[8].HeaderText = "Màn hình";
                dataGridView1.Columns[9].HeaderText = "Hãng sản xuất";
                dataGridView1.Columns[10].HeaderText = "Giá nhập";
                dataGridView1.Columns[11].HeaderText = "Giá bán";
                dataGridView1.Columns[12].HeaderText = "Số lượng";
                dataGridView1.Columns[13].HeaderText = "Thời gian bảo hành";
                dataGridView1.Columns[14].HeaderText = "Ghi chú";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 160;
                dataGridView1.Columns[4].Width = 160;
                dataGridView1.Columns[5].Width = 160;
                dataGridView1.Columns[6].Width = 160;
                dataGridView1.Columns[7].Width = 160;
                dataGridView1.Columns[8].Width = 200;
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[10].Width = 100;
                dataGridView1.Columns[11].Width = 100;
                dataGridView1.Columns[12].Width = 80;
                dataGridView1.Columns[13].Width = 80;
                dataGridView1.Columns[14].Width = 400;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

                button1.Enabled = false;
                button7.Enabled = false;
                button5.Enabled = true;
            }
            else {
                MessageBox.Show("Sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}