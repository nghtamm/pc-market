using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/*using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;*/

namespace pc_market.Forms {
    public partial class Form_GPU : Form {
        public Form_GPU() {
            InitializeComponent();
        }

        DataTable tblGPU;

        private void frm_GPU_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            txtMagpu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
            Classes.Functions.FillCombo("SELECT * FROM hangSanXuat", cboMahsx, "maHSX", "tenHSX");
            cboMahsx.SelectedIndex = -1;
        }

        private void ResetValues() {
            txtMagpu.Text = "";
            txtTengpu.Text = "";
            txtLoaigpu.Text = "";
            txtDungluong.Text = "";
            cboMahsx.Text = "";
            txtMota.Text = "";
        }

        private void Load_DataGridView() {
            string sql;
            sql = "SELECT maGPU, tenGPU, loaiGPU, dungLuong,a.maHSX,b.tenHSX,moTa FROM GPU as a INNER JOIN hangSanXuat as b ON a.maHSX = b.maHSX";
            tblGPU = Classes.Functions.GetDataToTable(sql);
            dgridGPU.DataSource = tblGPU;
            dgridGPU.Columns[4].Visible = false; // Ẩn cột maHSX

            dgridGPU.Columns[0].HeaderText = "Mã GPU";
            dgridGPU.Columns[1].HeaderText = "Tên GPU";
            dgridGPU.Columns[2].HeaderText = "Loại";
            dgridGPU.Columns[3].HeaderText = "Dung lượng";
            dgridGPU.Columns[5].HeaderText = "Tên HSX";
            dgridGPU.Columns[6].HeaderText = "Mô tả";
            dgridGPU.Columns[0].Width = 70;
            dgridGPU.Columns[1].Width = 200;
            dgridGPU.Columns[2].Width = 70;
            dgridGPU.Columns[4].Width = 70;
            dgridGPU.Columns[6].Width = 200;
            dgridGPU.AllowUserToAddRows = false;
            dgridGPU.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            string sql;
            if (tblGPU.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMagpu.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE GPU WHERE maGPU=N'" + txtMagpu.Text + "'";
                Classes.Functions.RunSQL(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void dgridGPU_Click(object sender, EventArgs e) {
            string ma;
            if (btnThem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMagpu.Focus();
                return;
            }

            if (tblGPU.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMagpu.Text = dgridGPU.CurrentRow.Cells["maGPU"].Value.ToString();
            txtTengpu.Text = dgridGPU.CurrentRow.Cells["tenGPU"].Value.ToString();
            ma = dgridGPU.CurrentRow.Cells["maHSX"].Value.ToString();
            cboMahsx.Text = Classes.Functions.GetFieldValues("SELECT tenHSX FROM hangSanXuat WHERE maHSX = N'" + ma + "'");
            txtLoaigpu.Text = dgridGPU.CurrentRow.Cells["loaiGPU"].Value.ToString();
            txtDungluong.Text = dgridGPU.CurrentRow.Cells["dungLuong"].Value.ToString();
            txtMota.Text = dgridGPU.CurrentRow.Cells["moTa"].Value.ToString();

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
            txtMagpu.Enabled = true;
            txtMagpu.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maGPU FROM GPU WHERE maGPU=N'" + txtMagpu.Text.Trim() + "'";
            if (Classes.Functions.CheckID(sql)) {
                MessageBox.Show("Mã GPU này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMagpu.Focus();
                txtMagpu.Text = "";
                return;
            }

            if (txtMagpu.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã GPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMagpu.Focus();
                return;
            }

            if (txtTengpu.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên GPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTengpu.Focus();
                return;
            }

            if (txtLoaigpu.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải loại GPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaigpu.Focus();
                return;
            }

            if (txtDungluong.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập dung lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDungluong.Focus();
                return;
            }

            if (cboMahsx.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải chọn hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahsx.Focus();
                return;
            }

            sql = "INSERT INTO GPU(maGPU,tenGPU,loaiGPU,dungLuong,maHSX,moTa)VALUES(N'" + txtMagpu.Text + "',N'" + txtTengpu.Text + "',N'" + txtLoaigpu.Text + "',N'" + txtDungluong.Text + "',N'" + cboMahsx.SelectedValue.ToString() + "',N'" + txtMota.Text + "')";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMagpu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e) {
            string sql;
            if (tblGPU.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMagpu.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTengpu.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên GPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTengpu.Focus();
                return;
            }

            if (txtLoaigpu.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải loại GPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaigpu.Focus();
                return;
            }

            if (txtDungluong.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập dung lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDungluong.Focus();
                return;
            }

            if (cboMahsx.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải chọn hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahsx.Focus();
                return;
            }

            sql = "UPDATE GPU SET tenGPU=N'" + txtTengpu.Text + "', loaiGPU=N'" + txtLoaigpu.Text + "',dungLuong=N'" + txtDungluong.Text + "',maHSX=N'" + cboMahsx.SelectedValue.ToString() + "',moTa=N'" + txtMota.Text + "' WHERE maGPU=N'" + txtMagpu.Text + "'";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e) {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMagpu.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e) {
            string sql;
            if ((txtTengpu.Text == "") && (cboMahsx.Text == "")) {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT maGPU, tenGPU, loaiGPU, dungLuong,a.maHSX,b.tenHSX,moTa FROM GPU as a INNER JOIN hangSanXuat as b ON a.maHSX = b.maHSX WHERE 1=1";
            if (txtTengpu.Text != "")
                sql = sql + " AND a.tenGPU Like N'%" + txtTengpu.Text + "%'";
            if (cboMahsx.Text != "")
                sql = sql + " AND a.maHSX Like N'%" + cboMahsx.SelectedValue + "%'";

            tblGPU = Classes.Functions.GetDataToTable(sql);
            if (tblGPU.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblGPU.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgridGPU.DataSource = tblGPU;
            ResetValues();
        }

        private void btnHienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maGPU, tenGPU, loaiGPU, dungLuong,a.maHSX,b.tenHSX,moTa FROM GPU as a INNER JOIN hangSanXuat as b ON a.maHSX = b.maHSX";
            tblGPU = Classes.Functions.GetDataToTable(sql);
            dgridGPU.DataSource = tblGPU;
            dgridGPU.Columns[4].Visible = false; // Ẩn cột maHSX

            dgridGPU.Columns[0].HeaderText = "Mã GPU";
            dgridGPU.Columns[1].HeaderText = "Tên GPU";
            dgridGPU.Columns[2].HeaderText = "Loại";
            dgridGPU.Columns[3].HeaderText = "Dung lượng";
            dgridGPU.Columns[5].HeaderText = "Tên HSX";
            dgridGPU.Columns[6].HeaderText = "Mô tả";
            dgridGPU.Columns[0].Width = 70;
            dgridGPU.Columns[1].Width = 200;
            dgridGPU.Columns[2].Width = 70;
            dgridGPU.Columns[4].Width = 70;
            dgridGPU.Columns[6].Width = 200;
            dgridGPU.AllowUserToAddRows = false;
            dgridGPU.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        /*private void ExportExcel(string path) {
            //Khởi tạo excel
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            //Tạo cột excel
            for (int i = 0; i < dgridGPU.Columns.Count; i++) {
                application.Cells[1, i + 1] = dgridGPU.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgridGPU.Rows.Count; i++) {
                for (int j = 0; j < dgridGPU.Columns.Count; j++) {
                    application.Cells[i + 2, j + 1] = dgridGPU.Rows[i].Cells[j].Value;
                }
            }

            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void btnXuatexcel_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuat file thanh cong");
                }
                catch (Exception ex) {
                    MessageBox.Show("Xuat file khong thanh cong\n" + ex.Message);
                }
            }
        }*/

        private void btnDong_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}