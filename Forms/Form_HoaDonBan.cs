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
using COMExcel = Microsoft.Office.Interop.Excel;


namespace pc_market.Forms
{
    public partial class Form_HoaDonBan : Form
    {
        public Form_HoaDonBan()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void frm_Hoadonban_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaHD.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMaHDBan.Enabled = false;

            txtTenmayvt.Enabled = false;
            txtDongia.Enabled = false;
            txtThanhtien.Enabled = false;
            txtTongtien.Enabled = false;

            txtTongtien.Text = "0";
            Classes.Functions.FillCombo1("SELECT maNV FROM nhanVien", cboManv,"maNV");
            cboManv.SelectedIndex = -1;

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtThanhtien_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
