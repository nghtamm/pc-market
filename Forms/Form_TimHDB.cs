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
using pc_market.Classes;

namespace pc_market.Forms
{
    public partial class Form_TimHDB : Form
    {
        DataTable tblHDB;
        public Form_TimHDB()
        {
            InitializeComponent();
        }

        private void Form_TimHDB_Load(object sender, EventArgs e)
        {
            Classes.Functions.Connect();
            ResetValues();
            DataGridView.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan1.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDBan1.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtManhanvien.Text == "") && (txtMakhach.Text == "") &&
               (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM hoaDonBan WHERE 1=1";
            if (txtMaHDBan1.Text != "")
                sql = sql + " AND maHDB Like N'%" + txtMaHDBan1.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(ngayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(ngayBan) =" + txtNam.Text;
            if (txtManhanvien.Text != "")
                sql = sql + " AND maNV Like N'%" + txtManhanvien.Text + "%'";
            if (txtMakhach.Text != "")
                sql = sql + " AND maKhach Like N'%" + txtMakhach.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND tongTien <=" + txtTongtien.Text;
            tblHDB = Functions.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblHDB;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            DataGridView.Columns[0].HeaderText = "Mã HĐB";
            DataGridView.Columns[1].HeaderText = "Ngày bán";
            DataGridView.Columns[2].HeaderText = "Mã nhân viên";
            DataGridView.Columns[3].HeaderText = "Mã khách";
            DataGridView.Columns[4].HeaderText = "Tổng tiền";
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;

        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        public void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = DataGridView.CurrentRow.Cells["maHDB"].Value.ToString();
                Form_HoaDonBan frm = new Form_HoaDonBan();
                frm.txtMaHDBan.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
