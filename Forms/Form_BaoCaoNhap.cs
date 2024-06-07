using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.IO;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace pc_market.Forms {
    public partial class Form_BaoCaoNhap : Form {
        private DataTable invoiceTable;
        private DataTable itemTable;

        public Form_BaoCaoNhap() {
            InitializeComponent();
        }

        public void Form_BCN_Load(object sender, EventArgs e) {
            Classes.Functions.Connect();
            Invoice_DataGridView_Load();
            Item_DataGridView_Load();
        }

        public void Invoice_DataGridView_Load() {
            string query = "SELECT hoaDonNhap.maHDN, mayTinh.maMay, mayTinh.tenMay, chiTietHDN.soLuong, mayTinh.giaNhap, chiTietHDN.thanhTien, hoaDonNhap.ngayNhap, nhaCungCap.tenNCC, nhanVien.tenNV " +
                           "FROM hoaDonNhap " +
                           "JOIN chiTietHDN ON hoaDonNhap.maHDN = chiTietHDN.maHDN " +
                           "JOIN mayTinh ON chiTietHDN.maMay = mayTinh.maMay " +
                           "JOIN nhaCungCap ON hoaDonNhap.maNCC = nhaCungCap.maNCC " +
                           "JOIN nhanVien ON hoaDonNhap.maNV = nhanVien.maNV";
            invoiceTable = Classes.Functions.GetDataToTable(query);
            dataGridView1.DataSource = invoiceTable;
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã máy tính";
            dataGridView1.Columns[2].HeaderText = "Tên máy tính";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn giá";
            dataGridView1.Columns[5].HeaderText = "Thành tiền";
            dataGridView1.Columns[6].HeaderText = "Ngày nhập";
            dataGridView1.Columns[7].HeaderText = "Nhà cung cấp";
            dataGridView1.Columns[8].HeaderText = "Nhân viên";
            dataGridView1.Columns[0].Width = 180;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 180;
            dataGridView1.Columns[8].Width = 140;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Item_DataGridView_Load() {
            string query = "SELECT mayTinh.tenMay, SUM(chiTietHDN.soLuong) FROM mayTinh JOIN chiTietHDN ON mayTinh.maMay = chiTietHDN.maMay GROUP BY mayTinh.tenMay";
            itemTable = Classes.Functions.GetDataToTable(query);
            dataGridView2.DataSource = itemTable;
            dataGridView2.Columns[0].HeaderText = "Tên máy tính";
            dataGridView2.Columns[1].HeaderText = "Tổng số lượng nhập";
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ButtonExport_Click(object sender, EventArgs e) {
            COMExcel.Application excelApp = new COMExcel.Application();
            COMExcel.Workbook excelBook = excelApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet excelSheet = (COMExcel.Worksheet)excelBook.Worksheets[1];

            COMExcel.Range excelRange = (COMExcel.Range)excelSheet.Cells[1, 1];
            excelRange.Range["E10:G10"].Font.Size = 14;
            excelRange.Range["E10:G10"].Font.Name = "Times New Roman";
            excelRange.Range["E10:G10"].Font.Bold = true;
            excelRange.Range["E10:G10"].Font.ColorIndex = 3; // Màu đỏ
            excelRange.Range["E10:G10"].MergeCells = true;
            excelRange.Range["E10:G10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["E10:G10"].Value = "Danh sách nhập hàng";

            excelRange.Range["A12:J12"].Font.Bold = true;
            excelRange.Range["A12:J12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange.Range["A12"].Value = "STT";
            excelRange.Range["B12"].Value = "Mã hóa đơn";
            excelRange.Range["C12"].Value = "Tên sản phẩm";
            excelRange.Range["D12"].Value = "Mã sản phẩm";
            excelRange.Range["E12"].Value = "Số lượng nhập";
            excelRange.Range["F12"].Value = "Đơn giá nhập";
            excelRange.Range["G12"].Value = "Thành tiền";
            excelRange.Range["H12"].Value = "Ngày bán";
            excelRange.Range["I12"].Value = "Tên nhà cung cấp";
            excelRange.Range["J12"].Value = "Tên nhân viên";

            for (int row = 0; row < invoiceTable.Rows.Count; row++) {
                ((COMExcel.Range)excelSheet.Cells[row + 13, 1]).Value2 = row + 1;
                for (int col = 0; col < invoiceTable.Columns.Count; col++) {
                    if (invoiceTable.Columns[col].ColumnName == "ngayNhap") {
                        DateTime date = Convert.ToDateTime(invoiceTable.Rows[row]["ngayNhap"]);
                        ((COMExcel.Range)excelSheet.Cells[row + 13, col + 2]).Value2 = date.ToShortDateString();
                    }
                    else {
                        ((COMExcel.Range)excelSheet.Cells[row + 13, col + 2]).Value2 = invoiceTable.Rows[row][col].ToString();
                    }
                }
            }

            excelRange = (COMExcel.Range)excelSheet.Cells[1, 1];
            excelRange.Range["N12:O12"].Font.Bold = true;
            excelRange.Range["N12:O12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            excelRange = (COMExcel.Range)excelSheet.Cells[12, 14];
            excelRange.Value2 = "Tên sản phẩm";
            excelRange = (COMExcel.Range)excelSheet.Cells[12, 15];
            excelRange.Value2 = "Số lượng nhập";
            for (int row = 0; row < itemTable.Rows.Count; row++) {
                ((COMExcel.Range)excelSheet.Cells[row + 13, 14]).Value2 = itemTable.Rows[row][0].ToString();
                ((COMExcel.Range)excelSheet.Cells[row + 13, 15]).Value2 = itemTable.Rows[row][1].ToString();
            }

            excelSheet.Columns.AutoFit();
            excelApp.Visible = true;
        }
    }
}