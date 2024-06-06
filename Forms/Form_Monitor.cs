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
    public partial class Form_Monitor : Form
    {
        public Form_Monitor()
        {
            InitializeComponent();
        }

        DataTable sontungmtp;

        private void frm_MH_Load(object sender, EventArgs e)
        {
            Classes.Functions.Connect();
            txtmaMH.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            DataGridView_Load();
            ResetValues();
        }

        private void ResetValues()
        {
            txtmaMH.Text = "";
            txtthongTin.Text = "";
        }

        private void DataGridView_Load()
        {
            string query = "SELECT * FROM manHinh";
            sontungmtp = Classes.Functions.GetDataToTable(query);
            dataGridView.DataSource = sontungmtp;
            dataGridView.Columns[0].HeaderText = "Mã màn hình";
            dataGridView.Columns[1].HeaderText = "Thông tin";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 300;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (sontungmtp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaMH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE manHinh WHERE maMH=N'" + txtmaMH.Text + "'";
                Classes.Functions.RunSQL(sql);
                DataGridView_Load();
                ResetValues();
            }
        }

        private void dgridMH_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtmaMH.Focus();
                return;
            }

            if (sontungmtp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmaMH.Text = dataGridView.CurrentRow.Cells["maMH"].Value.ToString();
            txtthongTin.Text = dataGridView.CurrentRow.Cells["thongTin"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màn hình", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtmaMH.Focus();
                return;
            }

            if (txtthongTin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin màn hình", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtthongTin.Focus();
                return;
            }

            sql = "INSERT INTO manHinh(maMH,thongTin)VALUES(N'" + txtmaMH.Text + "',N'" + txtthongTin.Text + "')  ";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaMH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (sontungmtp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtmaMH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (txtthongTin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtthongTin.Focus();
                return;
            }

            sql = "UPDATE manHinh SET thongTin=N'" + txtthongTin.Text + "' WHERE maMH=N'" + txtmaMH.Text + "'";
            Classes.Functions.RunSQL(sql);
            DataGridView_Load();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnHienthids_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM manHinh";
            sontungmtp = Classes.Functions.GetDataToTable(sql);
            dataGridView.DataSource = sontungmtp;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtthongTin.Text == "")
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM manHinh WHERE 1=1";
            if (txtthongTin.Text != "")
                sql = sql + " AND thongTin Like N'%" + txtthongTin.Text + "%'";
            sontungmtp = Classes.Functions.GetDataToTable(sql);
            if (sontungmtp.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + sontungmtp.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridView.DataSource = sontungmtp;
            ResetValues();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            txtmaMH.Enabled = true;
            txtthongTin.Enabled = true;
            ResetValues();
            txtmaMH.Focus();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmaMH.Enabled = false;
            txtthongTin.Enabled = true;
        }

    private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}