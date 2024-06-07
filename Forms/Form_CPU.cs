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
    public partial class Form_CPU : Form
    {
        DataTable mv;
        public Form_CPU()
        {
            InitializeComponent();
        }
        private void frm_CPU_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            txtmaCPU.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
            Classes.Functions.FillCombo("SELECT * FROM hangSanXuat", cbomaHSX, "maHSX", "tenHSX");
            cbomaHSX.SelectedIndex = -1;
        }
        private void ResetValues() {
            txtmaCPU.Text = "";
            txttenCPU.Text = "";
            txtsocket.Text = "";
            txttocDo.Text = "";
            cbomaHSX.Text = "";
            txtmoTa.Text = "";
        }
        private void Load_DataGridView() {
            string sql;
            sql = "SELECT CPU.maCPU, CPU.tenCPU, CPU.socket, CPU.tocDO, CPU.moTa, hangSanXuat.tenHSX, CPU.maHSX FROM CPU JOIN hangSanXuat ON CPU.maHSX = hangSanXuat.maHSX";
            mv = Classes.Functions.GetDataToTable(sql);
            dgridCPU.DataSource = mv;

            dgridCPU.Columns[0].HeaderText = "Mã CPU";
            dgridCPU.Columns[1].HeaderText = "Tên CPU";
            dgridCPU.Columns[2].HeaderText = "Socket";
            dgridCPU.Columns[3].HeaderText = "Tốc độ";
            dgridCPU.Columns[4].HeaderText = "Hãng sản xuất";
            dgridCPU.Columns[5].HeaderText = "Mô tả";
            dgridCPU.Columns[0].Width = 70;
            dgridCPU.Columns[1].Width = 200;
            dgridCPU.Columns[2].Width = 100;
            dgridCPU.Columns[3].Width = 100;
            dgridCPU.Columns[4].Width = 100;
            dgridCPU.Columns[5].Width = 200;
            dgridCPU.AllowUserToAddRows = false;
            dgridCPU.EditMode = DataGridViewEditMode.EditProgrammatically;
            
            string comboBoxQuery = "SELECT maHSX, tenHSX FROM hangSanXuat";
            DataTable manufacturerTable = Classes.Functions.GetDataToTable(comboBoxQuery);
            cbomaHSX.DataSource = manufacturerTable;
            cbomaHSX.DisplayMember = "tenHSX";
            cbomaHSX.ValueMember = "maHSX";
            
        }
        
        private void btnXoa_Click(object sender, EventArgs e) {
            string sql;
            if (mv.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaCPU.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE CPU WHERE maCPU=N'" + txtmaCPU.Text + "'";
                Classes.Functions.RunSQL(sql);
                Load_DataGridView();
                ResetValues();
            }
        }
        private void dgridCPU_Click(object sender, EventArgs e) {
            string ma;
            if (btnThem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaCPU.Focus();
                return;
            }

            if (mv.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmaCPU.Text = dgridCPU.CurrentRow.Cells["maCPU"].Value.ToString();
            txttenCPU.Text = dgridCPU.CurrentRow.Cells["tenCPU"].Value.ToString();
            ma = dgridCPU.CurrentRow.Cells["maHSX"].Value.ToString();
            cbomaHSX.Text = Classes.Functions.GetFieldValues("SELECT tenHSX FROM hangSanXuat WHERE maHSX = N'" + ma + "'");
            txtsocket.Text = dgridCPU.CurrentRow.Cells["socket"].Value.ToString();
            txttocDo.Text = dgridCPU.CurrentRow.Cells["tocDo"].Value.ToString();
            txtmoTa.Text = dgridCPU.CurrentRow.Cells["moTa"].Value.ToString();

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
            txtmaCPU.Enabled = true;
            txtmaCPU.Focus();
        }
        
        private void btnBoqua_Click(object sender, EventArgs e) {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmaCPU.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maCPU FROM CPU WHERE maCPU=N'" + txtmaCPU.Text.Trim() + "'";
            if (Classes.Functions.CheckID(sql)) {
                MessageBox.Show("Mã CPU này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaCPU.Focus();
                txtmaCPU.Text = "";
                return;
            }

            if (txtmaCPU.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã CPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaCPU.Focus();
                return;
            }

            if (txttenCPU.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên CPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenCPU.Focus();
                return;
            }

            if (txtsocket.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập socket", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsocket.Focus();
                return;
            }

            if (txttocDo.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttocDo.Focus();
                return;
            }

            if (cbomaHSX.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải chọn hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaHSX.Focus();
                return;
            }

            sql = "INSERT INTO CPU(maCPU,tenCPU,socket,tocDo,maHSX,moTa)VALUES(N'" + txtmaCPU.Text + "',N'" + txttenCPU.Text + "',N'" + txtsocket.Text + "',N'" + txttocDo.Text + "',N'" + cbomaHSX.SelectedValue.ToString() + "',N'" + txtmoTa.Text + "')";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaCPU.Enabled = false;
        }
        
           
        private void btnSua_Click(object sender, EventArgs e) {
            string sql;
            if (mv.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaCPU.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txttenCPU.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên CPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenCPU.Focus();
                return;
            }

            if (txtsocket.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập socket", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsocket.Focus();
                return;
            }

            if (txttocDo.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttocDo.Focus();
                return;
            }

            if (cbomaHSX.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải chọn hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomaHSX.Focus();
                return;
            }

            sql = "UPDATE CPU SET tenCPU=N'" + txttenCPU.Text + "', socket=N'" + txtsocket.Text + "',tocDo=N'" + txttocDo.Text + "',maHSX=N'" + cbomaHSX.SelectedValue.ToString() + "',moTa=N'" + txtmoTa.Text + "' WHERE maCPU=N'" + txtmaCPU.Text + "'";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }
        
        private void btnHienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT * FROM CPU";
            mv = Classes.Functions.GetDataToTable(sql);
            dgridCPU.DataSource = mv;
        }
        private void btnTimkiem_Click(object sender, EventArgs e) {
            string sql;
            if ((txttenCPU.Text == "") && (cbomaHSX.Text == "")) {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM CPU WHERE 1=1";
            if (txttenCPU.Text != "")
                sql = sql + " AND tenCPU Like N'%" + txttenCPU.Text + "%'";
            if (cbomaHSX.Text != "")
                sql = sql + " AND maHSX Like N'%" + cbomaHSX.SelectedValue + "%'";

            mv = Classes.Functions.GetDataToTable(sql);
            if (mv.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + mv.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridCPU.DataSource = mv;
            ResetValues();
        }
        private void btnDong_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}