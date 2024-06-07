using pc_market.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace pc_market.Forms {
    public partial class Form_KhachHang : Form {
        public Form_KhachHang() {
            InitializeComponent();
        }

        private void FormKhachhang_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            txtMakhach.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Load_DataGridView();
        }

        DataTable tblKH;

        private void Load_DataGridView() {
            string sql;
            sql = "SELECT maKhach, tenKhach, diaChi, dienThoai FROM khachHang";
            tblKH = Classes.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKH;
            DataGridView.Columns[0].HeaderText = "Mã khách";
            DataGridView.Columns[1].HeaderText = "Tên khách";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "Điện thoại";

            DataGridView.Columns[0].Width = 110;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 400;
            DataGridView.Columns[3].Width = 150;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues() {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }

        private void DataGridView_CellContentClick(object sender, EventArgs e) {
            if (btnthem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }

            if (tblKH.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMakhach.Text = DataGridView.CurrentRow.Cells["maKhach"].Value.ToString();
            txtTenkhach.Text = DataGridView.CurrentRow.Cells["tenKhach"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["diaChi"].Value.ToString();
            mskDienthoai.Text = DataGridView.CurrentRow.Cells["dienThoai"].Value.ToString();

            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
        }

        private void btnthem_Click_1(object sender, EventArgs e) {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtMakhach.Enabled = true;
            txtMakhach.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e) {
            string sql;
            if (txtMakhach.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }

            if (txtTenkhach.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }

            if (mskDienthoai.Text == "(   )    -") {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienthoai.Focus();
                return;
            }

            sql = "SELECT maKhach FROM khachHang WHERE maKhach=N'" + txtMakhach.Text.Trim() + "'";

            if (Functions.CheckID(sql)) {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                txtMakhach.Text = "";
                return;
            }

            sql = "INSERT INTO khachHang(maKhach,tenKhach,diaChi,dienThoai)VALUES(N'" + txtMakhach.Text.Trim() + "',N'" + txtTenkhach.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskDienthoai.Text + "')";

            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e) {
            string sql;
            if (tblKH.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMakhach.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTenkhach.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }

            if (mskDienthoai.Text == "(   )    -") {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienthoai.Focus();
                return;
            }

            sql = "UPDATE khachHang SET tenKhach=N'" +
                  txtTenkhach.Text.Trim().ToString() + "',diaChi=N'" + txtDiachi.Text.Trim().ToString() + "',dienThoai='" + mskDienthoai.Text.ToString() + "' WHERE maKhach=N'" + txtMakhach.Text + "'";

            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnboqua.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e) {
            string sql;
            if (tblKH.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMakhach.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE khachHang WHERE maKhach=N'" + txtMakhach.Text + "'";
                Classes.Functions.RunDeleteSQL(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnboqua_Click(object sender, EventArgs e) {
            ResetValues();
            btnboqua.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btndong_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void mskDienthoai_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void Validate_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}