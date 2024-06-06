using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace pc_market.Forms
{
    public partial class Form_NhanVien : Form
    {
        public Form_NhanVien()
        {
            InitializeComponent();
        }
        DataTable thau;
        private void ResetValues() {
            txtmaNV.Text = "";
            txttenNV.Text = "";
            txtdiaChi.Text = "";
            txtdienThoai.Text = "";
            txtgioiTinh.SelectedItem = null;
            txtngaySinh.Text = "";
        } 
        
        private void btnLuu_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maNV FROM nhanVien WHERE maNV=N'" + txtmaNV.Text.Trim() + "'";
            if (Classes.Functions.CheckID(sql)) {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                txtmaNV.Text = "";
                return;
            }

            if (txtmaNV.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txttenNV.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txtdiaChi.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txtdienThoai.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if ((txtgioiTinh.SelectedItem == null) ) {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return; 
            }
            if (txtngaySinh.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }
            
            sql = "INSERT INTO nhanVien(maNV,tenNV,ngaySinh,gioiTinh,diaChi,dienThoai)VALUES(N'" + txtmaNV.Text + "',N'" + txttenNV.Text + "',N'" + txtngaySinh.Text + "',N'" + txtgioiTinh.SelectedItem.ToString() + "',N'" + txtdiaChi.Text + "'," + txtdienThoai.Text + ") ";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaNV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e) {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmaNV.Enabled = true;
            txtmaNV.Focus();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Classes.Functions.Connect();
            txtmaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;

            DataGridView_Load();
        }
        
        private void DataGridView_Load() {
            string query = "SELECT * FROM nhanVien";
            thau = Classes.Functions.GetDataToTable(query);
            dataGridView.DataSource = thau;
            dataGridView.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView.Columns[2].HeaderText = "Ngày sinh";
            dataGridView.Columns[3].HeaderText = "Giới tính";
            dataGridView.Columns[4].HeaderText = "Địa chỉ";
            dataGridView.Columns[5].HeaderText = "Điện thoại";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 150;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 400;
            dataGridView.Columns[5].Width = 100;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        
        private void btnXoa_Click(object sender, EventArgs e) {
            string sql;
            if (thau.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaNV.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE nhanVien WHERE maNV=N'" + txtmaNV.Text + "'";
                Classes.Functions.RunSQL(sql);
                DataGridView_Load();
                ResetValues();
            }
        }
        private void btnBoqua_Click(object sender, EventArgs e) {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmaNV.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e) {
            this.Close();
        }
        
        private void btnSua_Click(object sender, EventArgs e) {
            string sql;
            if (thau.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaNV.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (txtmaNV.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txttenNV.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txtdiaChi.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }

            if (txtdienThoai.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }
            
            if (txtgioiTinh.SelectedItem == null)  {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }
            if (txtngaySinh.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaNV.Focus();
                return;
            }
            sql = "UPDATE nhanVien SET tenNV=N'" + txttenNV.Text + "', diaChi=N'" + txtdiaChi.Text + "',gioiTinh=N'" + txtgioiTinh.SelectedItem.ToString() +  "',ngaySinh='" + txtngaySinh.Text +  "',dienThoai='" + txtdienThoai.Text + "' WHERE maNV=N'" + txtmaNV.Text + "'";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnBoqua.Enabled = false;
        }
        private void dataGridView_CellContentClick(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaNV.Focus();
                return;
            }
            if (thau.Rows.Count == 0 )
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }    
            txtmaNV.Text = dataGridView.CurrentRow.Cells["maNV"].Value.ToString();
            txttenNV.Text = dataGridView.CurrentRow.Cells["tenNV"].Value.ToString();
            txtngaySinh.Text = dataGridView.CurrentRow.Cells["ngaySinh"].Value.ToString();
            txtgioiTinh.SelectedItem = dataGridView.CurrentRow.Cells["gioiTinh"].Value.ToString();
            txtdiaChi.Text = dataGridView.CurrentRow.Cells["diaChi"].Value.ToString();
            txtdienThoai.Text = dataGridView.CurrentRow.Cells["dienThoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        private void btnTimkiem_Click(object sender, EventArgs e) {
            string sql;
            if ((txttenNV.Text == "") && (txtdiaChi.Text == "")) {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM nhanVien WHERE 1=1";
            if (txttenNV.Text != "")
                sql = sql + " AND tenNV Like N'%" + txttenNV.Text + "%'";
            if (txtdiaChi.Text != "")
                sql = sql + " AND diaChi Like N'%" + txtdiaChi.Text + "%'";


            thau = Classes.Functions.GetDataToTable(sql);
            if (thau.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + thau.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridView.DataSource = thau;
            ResetValues();
        }
        
        private void btnHienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT * FROM nhanVien";
            thau = Classes.Functions.GetDataToTable(sql);
            dataGridView.DataSource = thau;
        }
    }
}