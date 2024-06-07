using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pc_market.Forms
{

    public partial class Form_HangSanXuat : Form
    {
        public Form_HangSanXuat()
        {
            InitializeComponent();
        }
        DataTable thaumv;
        private void frm_HSX_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            txtmaHSX.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            DataGridView_Load();
            ResetValues();
        }
        private void ResetValues() {
            txtmaHSX.Text = "";
            txttenHSX.Text = "";
        }
        
        private void DataGridView_Load() {
            string query = "SELECT * FROM hangSanXuat";
            thaumv = Classes.Functions.GetDataToTable(query);
            dataGridView.DataSource = thaumv;
            dataGridView.Columns[0].HeaderText = "Mã HSX";
            dataGridView.Columns[1].HeaderText = "Tên HSX";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 300;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        
        private void btnXoa_Click(object sender, EventArgs e) {
            string sql;
            if (thaumv.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaHSX.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE hangSanXuat WHERE maHSX=N'" + txtmaHSX.Text + "'";
                Classes.Functions.RunSQL(sql);
                DataGridView_Load();
                ResetValues();
            }
        }
        
        
        private void dgridHSX_Click(object sender, EventArgs e) {
            string ma;
            if (btnThem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaHSX.Focus();
                return;
            }

            if (thaumv.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmaHSX.Text = dataGridView.CurrentRow.Cells["maHSX"].Value.ToString();
            txttenHSX.Text = dataGridView.CurrentRow.Cells["tenHSX"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        
        private void btnThem_Click(object sender, EventArgs e) {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtmaHSX.Enabled = true;
            txtmaHSX.Focus();
        }
        private void btnBoqua_Click(object sender, EventArgs e) {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmaHSX.Enabled = false;
        }
        
        private void btnLuu_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maHSX FROM hangSanXuat WHERE maHSX=N'" + txtmaHSX.Text.Trim() + "'";
            if (Classes.Functions.CheckID(sql)) {
                MessageBox.Show("Mã HSX này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaHSX.Focus();
                txtmaHSX.Text = "";
                return;
            }

            if (txtmaHSX.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã HSX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaHSX.Focus();
                return;
            }

            if (txttenHSX.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên HSX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenHSX.Focus();
                return;
            }
    
            sql = "INSERT INTO hangSanXuat(maHSX,tenHSX)VALUES(N'" + txtmaHSX.Text + "',N'" + txttenHSX.Text + "')  ";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaHSX.Enabled = false;
        }
        
        
        private void btnSua_Click(object sender, EventArgs e) {
            string sql;
            if (thaumv.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaHSX.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txttenHSX.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenHSX.Focus();
                return;
            }

            sql = "UPDATE hangSanXuat SET tenHSX=N'" + txttenHSX.Text + "' WHERE maHSX=N'" + txtmaHSX.Text + "'";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnBoqua.Enabled = false;
        }
        
        private void btnHienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT * FROM hangSanXuat";
            thaumv = Classes.Functions.GetDataToTable(sql);
            dataGridView.DataSource = thaumv;
        }
        private void btnTimkiem_Click(object sender, EventArgs e) {
            string sql;
            if (txttenHSX.Text == "") {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM hangSanXuat WHERE 1=1";
            if (txttenHSX.Text != "")
                sql = sql + " AND tenHSX Like N'%" + txttenHSX.Text + "%'";
            thaumv = Classes.Functions.GetDataToTable(sql);
            if (thaumv.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + thaumv.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridView.DataSource = thaumv;
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}