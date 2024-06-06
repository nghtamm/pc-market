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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace pc_market.Forms
{
    public partial class Form_BaoCaoBan : Form
    {
        public Form_BaoCaoBan()
        {
            InitializeComponent();
        }
   
        
        private void frm_MH_Load(object sender, EventArgs e)
        {
            Classes.Functions.Connect();
            Load_dataGridView();
            Load_dataGridView1();
        }
        DataTable tblCTHDB;
        DataTable tblCTHDB1;
        private void Load_dataGridView()
        {
            string sql;
            sql = "SELECT hdb.maHDB, mt.maMay, mt.tenMay, cthdb.soLuong, mt.giaBan, cthdb.thanhTien, hdb.ngayBan, kh.tenKhach, nv.tenNV FROM HoaDonBan hdb JOIN chiTietHDB cthdb ON hdb.maHDB = cthdb.maHDB JOIN MayTinh mt ON cthdb.maMay = mt.maMay JOIN KhachHang kh ON hdb.maKhach = kh.maKhach JOIN NhanVien nv ON hdb.maNV = nv.maNV";
            tblCTHDB = Functions.GetDataToTable(sql);
            dataGridView.DataSource = tblCTHDB;

            if (dataGridView.Columns.Count >= 9){
                dataGridView.Columns[0].HeaderText = "Mã hóa đơn";
                dataGridView.Columns[0].Width = 100;
                dataGridView.Columns[1].HeaderText = "Mã máy tính";
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].HeaderText = "Tên máy tính";
                dataGridView.Columns[2].Width = 200;
                dataGridView.Columns[3].HeaderText = "Số lượng bán";
                dataGridView.Columns[3].Width = 50;
                dataGridView.Columns[4].HeaderText = "Đơn giá";
                dataGridView.Columns[4].Width = 90;
                dataGridView.Columns[5].HeaderText = "Thành tiền";
                dataGridView.Columns[5].Width = 90;
                dataGridView.Columns[6].HeaderText = "Ngày bán";
                dataGridView.Columns[6].Width = 100;
                dataGridView.Columns[7].HeaderText = "Tên khách hàng";
                dataGridView.Columns[7].Width = 200;
                dataGridView.Columns[8].HeaderText = "Tên nhân viên";
                dataGridView.Columns[8].Width = 200;
            }

            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_dataGridView1()
        {
            string sql;
            sql = "SELECT mt.tenMay as 'Tên máy tính', SUM(cthdb.soLuong) as 'Tổng số lượng bán' FROM HoaDonBan hdb JOIN chiTietHDB cthdb ON hdb.maHDB = cthdb.maHDB JOIN MayTinh mt ON cthdb.maMay = mt.maMay GROUP BY mt.tenMay";
            tblCTHDB1 = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblCTHDB1;

            dataGridView1.Columns[0].HeaderText = "Tên máy tính";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].HeaderText = "Tổng số lượng bán";
            dataGridView1.Columns[1].Width = 50;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
            private void btin_Click(object sender, EventArgs e)
{
    COMExcel.Application exApp = new COMExcel.Application();
    COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
    COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];

    // Định dạng tiêu đề báo cáo
    COMExcel.Range exRange = (COMExcel.Range)exSheet.Cells[1, 1];
    exRange.Range["E10:G10"].Font.Size = 14;
    exRange.Range["E10:G10"].Font.Name = "Times New Roman";
    exRange.Range["E10:G10"].Font.Bold = true;
    exRange.Range["E10:G10"].Font.ColorIndex = 3; // Màu đỏ
    exRange.Range["E10:G10"].MergeCells = true;
    exRange.Range["E10:G10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
    exRange.Range["E10:G10"].Value = "Danh sách Bán hàng";

    // Định dạng tiêu đề cột
    exRange.Range["A12:K12"].Font.Bold = true;
    exRange.Range["A12:K12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
    exRange.Range["A12"].Value = "STT";
    exRange.Range["B12"].Value = "Mã hóa đơn";
    exRange.Range["C12"].Value = "Tên sản phẩm";
    exRange.Range["D12"].Value = "Mã sản phẩm";
    exRange.Range["E12"].Value = "Số lượng bán";
    exRange.Range["F12"].Value = "Đơn giá bán";
    exRange.Range["G12"].Value = "Khuyến mãi";
    exRange.Range["H12"].Value = "Thành tiền";
    exRange.Range["I12"].Value = "Ngày bán";
    exRange.Range["J12"].Value = "Tên khách hàng";
    exRange.Range["K12"].Value = "Tên nhân viên bán";

    // Điền dữ liệu
    for (int row = 0; row < tblCTHDB.Rows.Count; row++)
    {
        ((COMExcel.Range)exSheet.Cells[row + 13, 1]).Value2 = row + 1; // STT
        for (int col = 0; col < tblCTHDB.Columns.Count; col++)
        {
            if (tblCTHDB.Columns[col].ColumnName == "ngayban")
            {
                DateTime ngayNhap = Convert.ToDateTime(tblCTHDB.Rows[row]["ngayban"]);
                ((COMExcel.Range)exSheet.Cells[row + 13, col + 2]).Value2 = ngayNhap.ToShortDateString();
            }
            else
            {
                ((COMExcel.Range)exSheet.Cells[row + 13, col + 2]).Value2 = tblCTHDB.Rows[row][col].ToString();
            }
        }
    }

    // Điền dữ liệu vào phần tổng số lượng bán
    exRange = (COMExcel.Range)exSheet.Cells[1, 14]; // Bắt đầu từ cột N
    exRange.Range["N12"].Value = "Tên sản phẩm";
    exRange.Range["O12"].Value = "Số lượng bán";
    for (int row = 0; row < tblCTHDB1.Rows.Count; row++)
    {
        ((COMExcel.Range)exSheet.Cells[row + 13, 14]).Value2 = tblCTHDB1.Rows[row][0].ToString();
        ((COMExcel.Range)exSheet.Cells[row + 13, 15]).Value2 = tblCTHDB1.Rows[row][1].ToString();
    }

    exApp.Visible = true;
}
    }
}