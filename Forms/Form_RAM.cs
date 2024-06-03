using pc_market.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pc_market.Forms {
    public partial class Form_RAM : Form {
        public Form_RAM() {
            InitializeComponent();
        }


        private void FormRAM_Load(object sender, EventArgs e) {
            txtMaRam.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            Load_dataGridView();
            Functions.FillCombo("SELECT maHSX, tenHSX FROM hangSanXuat", cboMaHsx, "MaHSX", "TenHSX");
            cboMaHsx.SelectedIndex = -1;
            ResetValues();
        }

        private void ResetValues() {
            txtMaRam.Text = "";
            txtTenRam.Text = "";
            txtloaiRam.Text = "";

            txtDungluong.Text = "0";
            txtbus.Text = "0";
            txtDungluong.Enabled = false;
            txtbus.Enabled = false;

            cboMaHsx.Text = "";
            txtMota.Text = "";
        }

        DataTable tblram;

        private void Load_dataGridView() {
            string sql;
            sql = "SELECT maRam, tenRam, loaiRam, bus, dungLuong, maHSX, moTa  FROM ram";
            tblram = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblram;
            dataGridView.Columns[0].HeaderText = "Mã RAM";
            dataGridView.Columns[1].HeaderText = "Tên RAM";
            dataGridView.Columns[2].HeaderText = "Loại RAM";
            dataGridView.Columns[3].HeaderText = "bus";
            dataGridView.Columns[4].HeaderText = "Dung lượng";
            dataGridView.Columns[5].HeaderText = "HSX";
            dataGridView.Columns[6].HeaderText = "Mô tả";

            dataGridView.Columns[0].Width = 80;
            dataGridView.Columns[1].Width = 170;
            dataGridView.Columns[2].Width = 80;
            dataGridView.Columns[3].Width = 80;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void dataGridView_Click(object sender, EventArgs e) {
            string ma;
            if (btnthem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaRam.Focus();
                return;
            }


            if (tblram.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaRam.Text = dataGridView.CurrentRow.Cells["maRam"].Value.ToString();
            txtTenRam.Text = dataGridView.CurrentRow.Cells["tenRam"].Value.ToString();

            ma = dataGridView.CurrentRow.Cells["maHSX"].Value.ToString();
            cboMaHsx.Text = Functions.GetFieldValues("SELECT tenHSX FROM hangSanXuat WHERE maHSX = N'" + ma + "'");

            txtloaiRam.Text = dataGridView.CurrentRow.Cells["loaiRam"].Value.ToString();
            txtDungluong.Text = dataGridView.CurrentRow.Cells["dungLuong"].Value.ToString();
            txtbus.Text = dataGridView.CurrentRow.Cells["bus"].Value.ToString();
            txtMota.Text = dataGridView.CurrentRow.Cells["moTa"].Value.ToString();

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
            txtMaRam.Enabled = true;
            txtMaRam.Focus();
        }

        private void btnluu_Click(object sender, EventArgs e) {
            string sql;
            if (txtMaRam.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaRam.Focus();
                return;
            }

            if (txtTenRam.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenRam.Focus();
                return;
            }

            if (txtloaiRam.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập loại Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloaiRam.Focus();
                return;
            }


            if (cboMaHsx.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải chọn hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHsx.Focus();
                return;
            }

            sql = "select maRam from ram where maRam=N'" + txtMaRam.Text.Trim() + "'";

            if (Functions.CheckID(sql)) {
                MessageBox.Show("Mã Ram này đã có, bạn vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaRam.Focus();
                txtMaRam.Text = "";
                return;
            }

            sql = "INSERT INTO ram(maRam,tenRam,loaiRam,bus,dungLuong,maHSX,moTa) VALUES(N'" + txtMaRam.Text.Trim() + "',N'" + txtTenRam.Text.Trim() + "',N'" + txtloaiRam.Text.Trim() + "'," + txtbus.Text.Trim() + "," + txtDungluong.Text.Trim() + ",N'" + cboMaHsx.SelectedValue.ToString() + "',N'" + txtMota.Text.Trim() + "')";

            Classes.Functions.RunSQL(sql);
            Load_dataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnboqua.Enabled = false;
            btnluu.Enabled = false;
            txtMaRam.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e) {
            string sql;
            if (tblram.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaRam.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTenRam.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenRam.Focus();
                return;
            }

            if (txtloaiRam.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập loại Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloaiRam.Focus();
                return;
            }

            if (cboMaHsx.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã HSX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHsx.Focus();
                return;
            }


            sql = "UPDATE ram SET tenRam=N'" +
                  txtTenRam.Text.Trim().ToString() + "',loaiRam=N'" + txtloaiRam.Text.Trim().ToString() + "',maHSX=N'" +
                  cboMaHsx.SelectedValue.ToString() + "',moTa=N'" + txtMota.Text.Trim().ToString() + "' WHERE maRam=N'" + txtMaRam.Text + "'";

            Functions.RunSQL(sql);
            Load_dataGridView();
            btnboqua.Enabled = false;
            ResetValues();
        }

        private void btnxoa_Click(object sender, EventArgs e) {
            string sql;
            if (tblram.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaRam.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE ram WHERE maRam=N'" + txtMaRam.Text + "'";
                Functions.RunDeleteSQL(sql);
                Load_dataGridView();
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
            txtMaRam.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e) {
            string sql;
            if ((txtMaRam.Text == "") && (txtTenRam.Text == "") && (cboMaHsx.Text == "")) {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sql = "SELECT * FROM ram WHERE 1=1";
            ;
            if (txtTenRam.Text != "")
                sql = sql + " AND tenRam Like N'%" + txtTenRam.Text + "%'";
            if (cboMaHsx.Text != "")
                sql = sql + " AND maHSX Like N'%" + cboMaHsx.SelectedValue + "%'";

            tblram = Classes.Functions.GetDataToTable(sql);
            if (tblram.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + tblram.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView.DataSource = tblram;
            ResetValues();
        }

        private void btnhienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maRam, tenRam, Mahsx, bus, dungLuong, moTa from ram";
            tblram = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblram;
        }

        private void btnthoat_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}