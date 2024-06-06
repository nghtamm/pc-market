using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace pc_market.Forms {
    public partial class Form_NCC : Form {
        DataTable tblNCC;

        public Form_NCC() {
            InitializeComponent();
        }

        private void frm_NCC_Load(object sender, EventArgs e) {
            // Classes.Functions.Connect();
            txtMancc.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }

        private void ResetValues() {
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
        }

        private void Load_DataGridView() {
            string sql;
            sql = "SELECT * FROM nhaCungCap";
            tblNCC = Classes.Functions.GetDataToTable(sql);
            dgridNCC.DataSource = tblNCC;

            dgridNCC.Columns[0].HeaderText = "Mã NCC";
            dgridNCC.Columns[1].HeaderText = "Tên NCC";
            dgridNCC.Columns[2].HeaderText = "Địa chỉ";
            dgridNCC.Columns[3].HeaderText = "Điện thoại";
            dgridNCC.Columns[0].Width = 70;
            dgridNCC.Columns[1].Width = 175;
            dgridNCC.Columns[2].Width = 300;
            dgridNCC.AllowUserToAddRows = false;
            dgridNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridNCC_Click(object sender, EventArgs e) {
            if (btnThem.Enabled == false) {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMancc.Focus();
                return;
            }

            if (tblNCC.Rows.Count == 0) {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMancc.Text = dgridNCC.CurrentRow.Cells["maNCC"].Value.ToString();
            txtTenncc.Text = dgridNCC.CurrentRow.Cells["tenNCC"].Value.ToString();
            txtDiachi.Text = dgridNCC.CurrentRow.Cells["diaChi"].Value.ToString();
            txtDienthoai.Text = dgridNCC.CurrentRow.Cells["dienThoai"].Value.ToString();
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
            txtMancc.Enabled = true;
            txtMancc.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT maNCC FROM nhaCungCap WHERE maNCC=N'" + txtMancc.Text.Trim() + "'";
            if (Classes.Functions.CheckID(sql)) {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                txtMancc.Text = "";
                return;
            }

            if (txtMancc.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }

            if (txtTenncc.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenncc.Focus();
                return;
            }

            if (txtDiachi.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }

            if (txtDienthoai.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienthoai.Focus();
                return;
            }

            sql = "INSERT INTO nhaCungCap(maNCC,tenNCC,diaChi,dienThoai)VALUES(N'" + txtMancc.Text + "',N'" + txtTenncc.Text + "',N'" + txtDiachi.Text + "'," + txtDienthoai.Text + ") ";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMancc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e) {
            string sql;
            if (tblNCC.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMancc.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (txtMancc.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }

            if (txtTenncc.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }

            if (txtDiachi.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }

            if (txtDienthoai.Text.Trim().Length == 0) {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }

            sql = "UPDATE nhaCungCap SET tenNCC=N'" + txtTenncc.Text + "', diaChi=N'" + txtDiachi.Text + "',dienThoai='" + txtDienthoai.Text + "' WHERE maNCC=N'" + txtMancc.Text + "'";
            Classes.Functions.RunSQL(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            string sql;
            if (tblNCC.Rows.Count == 0) {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMancc.Text == "") {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                sql = "DELETE nhaCungCap WHERE maNCC=N'" + txtMancc.Text + "'";
                Classes.Functions.RunSQL(sql);
                Load_DataGridView();
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
            txtMancc.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ExportExcel(string path) {
            //Khởi tạo excel
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            //Tạo cột excel
            for (int i = 0; i < dgridNCC.Columns.Count; i++) {
                application.Cells[1, i + 1] = dgridNCC.Columns[i].HeaderText;
            }

            for (int i = 0; i < dgridNCC.Rows.Count; i++) {
                for (int j = 0; j < dgridNCC.Columns.Count; j++) {
                    application.Cells[i + 2, j + 1] = dgridNCC.Rows[i].Cells[j].Value;
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
        }

        private void btnTimkiem_Click(object sender, EventArgs e) {
            string sql;
            if ((txtTenncc.Text == "") && (txtDiachi.Text == "")) {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM nhaCungCap WHERE 1=1";
            if (txtTenncc.Text != "")
                sql = sql + " AND tenNCC Like N'%" + txtTenncc.Text + "%'";
            if (txtDiachi.Text != "")
                sql = sql + " AND diaChi Like N'%" + txtDiachi.Text + "%'";

            tblNCC = Classes.Functions.GetDataToTable(sql);
            if (tblNCC.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
                MessageBox.Show("Có " + tblNCC.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgridNCC.DataSource = tblNCC;
            ResetValues();
        }

        private void btnHienthids_Click(object sender, EventArgs e) {
            string sql;
            sql = "SELECT * FROM nhaCungCap";
            tblNCC = Classes.Functions.GetDataToTable(sql);
            dgridNCC.DataSource = tblNCC;
        }
    }
}