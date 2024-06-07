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
using pc_market.Classes;


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
            // Classes.Functions.Connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenmayvt.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            txtManhanvien.ReadOnly = true;
            txtMakhach.ReadOnly = true;

            txtTongtien.Text = "0";


            Functions.FillCombo("SELECT maKhach, tenKhach FROM khachHang", cboMakhach, "maKhach", "tenKhach");
            cboMakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT maNV, tenNV FROM nhanVien",cboManhanvien, "maNV", "tenNV");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT maMay, tenMay FROM mayTinh", cboMamayvt, "maMay", "tenMay");
            cboMamayvt.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                Load_ThongtinHD();
                btnXoa.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_DataGridViewChitiet();

        }
        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.maMay, b.tenMay, a.soLuong, b.giaBan, a.thanhTien FROM chiTietHDB AS a, mayTinh AS b WHERE a.maHDB = N'" + txtMaHDBan.Text + "' AND a.maMay=b.maMay";
            /*sql = "SELECT * FROM chiTietHDB";*/
            tblCTHDB = Functions.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblCTHDB;

            DataGridViewChitiet.Columns[0].HeaderText = "Mã máy tính";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên máy tính";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Đơn giá";

            DataGridViewChitiet.Columns[4].HeaderText = "Thành tiền";
            DataGridViewChitiet.Columns[0].Width = 100;
            DataGridViewChitiet.Columns[1].Width = 200;
            DataGridViewChitiet.Columns[2].Width = 80;
            DataGridViewChitiet.Columns[3].Width = 90;
            DataGridViewChitiet.Columns[4].Width = 90;
            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngayBan FROM hoaDonBan WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            mskNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT tenNV FROM hoaDonBan as a INNER JOIN nhanVien as b ON a.maNV=b.maNV WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT tenNV FROM hoaDonBan as a INNER JOIN nhanVien as b ON a.maNV=b.maNV WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT maNV FROM hoaDonBan WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtManhanvien.Text = Functions.GetFieldValues(str);

            str = "SELECT tenKhach FROM hoaDonBan as a INNER JOIN khachHang as b ON a.maKhach=b.maKhach WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            cboMakhach.Text = Functions.GetFieldValues(str);
            str = "SELECT tenKhach FROM hoaDonBan as a INNER JOIN khachHang as b ON a.maKhach=b.maKhach WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtTenkhach.Text = Functions.GetFieldValues(str);

            str = "SELECT diaChi FROM hoaDonBan as a INNER JOIN khachHang as b ON a.maKhach=b.maKhach WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "SELECT dienThoai FROM hoaDonBan as a INNER JOIN khachHang as b ON a.maKhach=b.maKhach WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);

            str = "SELECT tongTien FROM hoaDonBan WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);

            lblBangchu.Text = "Bằng chữ: " + Functions.ConvertNumericToText(txtTongtien.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThem.Enabled = false;
            
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            Load_DataGridViewChitiet();

        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            mskNgayban.Text = DateTime.Now.ToShortDateString();

            cboManhanvien.Text = "";
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            cboMakhach.Text = "";
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";

            lblBangchu.Text = "Bằng chữ: ";
            cboMamayvt.Text = "";
            txtTenmayvt.Text = "";
            txtSoluong.Text = "";
            txtDongia.Text = "";
            /*       txtGiamgia.Text = "0";*/
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT maHDB FROM hoaDonBan WHERE maHDB=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckID(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (mskNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mskNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakhach.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban    
                sql = "INSERT INTO hoaDonBan(maHDB, ngayBan, maNV, maKhach, tongTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "', '" +
                        Functions.ConvertDateTime(mskNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" +
                        cboMakhach.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSQL(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cboMamayvt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamayvt.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            /*if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }*/
            sql = "SELECT maHDB FROM hoaDonBan WHERE maHDB=N'" + cboMamayvt.SelectedValue + "' AND maHDB = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckID(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMamayvt.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soLuong FROM mayTinh WHERE maMay = N'" + cboMamayvt.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO chiTietHDB(maHDB,maMay,soLuong,thanhTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "', N'" + cboMamayvt.SelectedValue + "'," + txtSoluong.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSQL(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE mayTinh SET Soluong =" + SLcon + " WHERE maMay= N'" + cboMamayvt.SelectedValue + "'";
            Functions.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT tongTien FROM hoaDonBan WHERE maHDB = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE hoaDonBan SET tongTien =" + Tongmoi + " WHERE maHDB = N'" + txtMaHDBan.Text + "'";
            Functions.RunSQL(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ConvertNumericToText(Tongmoi.ToString());
            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnInhoadon.Enabled = true;

        }
        private void ResetValuesHang()
        {


            cboMamayvt.Text = "";
            txtSoluong.Text = "";
            /*txtGiamgia.Text = "0";*/
            txtThanhtien.Text = "0";
        }

        private void txtTennhanvien_TextChanged(object sender, EventArgs e)
        {
        }

        public void cboMakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select tenKhach from khachHang where maKhach = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = Functions.GetFieldValues(str);
            str = "Select maKhach from khachHang where maKhach = N'" + cboMakhach.SelectedValue + "'";
            txtMakhach.Text = Functions.GetFieldValues(str);
            str = "Select diaChi from khachHang where maKhach = N'" + cboMakhach.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select dienThoai from khachHang where maKhach= N'" + cboMakhach.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);

        }

        public void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tenNV from nhanVien where maNV =N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
            str = "Select maNV from nhanVien where maNV =N'" + cboManhanvien.SelectedValue + "'";
            txtManhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cboMamayvt_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMamayvt.Text == "")
            {
                txtTenmayvt.Text = "";
                txtDongia.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tenMay FROM mayTinh WHERE maMay =N'" + cboMamayvt.SelectedValue + "'";
            txtTenmayvt.Text = Functions.GetFieldValues(str);
            str = "SELECT giaBan FROM mayTinh WHERE maMay =N'" + cboMamayvt.SelectedValue + "'";
            txtDongia.Text = Functions.GetFieldValues(str);

        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);

            if (txtDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg - sl * dg / 100;
            txtThanhtien.Text = tt.ToString();

        }


        private void DataGridViewChitiet_DoubleClick(object sender, EventArgs e)
        {
            {
                string Mahang;
                Double Thanhtien;
                if (tblCTHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    //Xóa hàng và cập nhật lại số lượng hàng 
                    Mahang = DataGridViewChitiet.CurrentRow.Cells["maMay"].Value.ToString();
                    DelHang(txtMaHDBan.Text, Mahang);
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    Thanhtien = Convert.ToDouble(DataGridViewChitiet.CurrentRow.Cells["thanhTien"].Value.ToString());
                    DelUpdateTongtien(txtMaHDBan.Text, Thanhtien);
                    Load_DataGridViewChitiet();
                }

            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soLuong FROM chiTietHDB WHERE maHDB = N'" + Mahoadon + "' AND maMay = N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE chiTietHDB WHERE maHDB=N'" + Mahoadon + "' AND maMay = N'"+ Mahang + "'";
            Functions.RunDeleteSQL(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soLuong FROM mayTinh WHERE maMay = N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE mayTinh SET soLuong =" + SLcon + " WHERE maMay= N'" + Mahang + "'";
            Functions.RunSQL(sql);
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongTien FROM hoaDonBan WHERE maHDB = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE hoaDonBan SET tongTien =" + Tongmoi + " WHERE maHDB = N'" +Mahoadon + "'";
            Functions.RunSQL(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ConvertNumericToText(Tongmoi.ToString());
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT maMay FROM chiTietHDB WHERE maHDB = N'" + txtMaHDBan.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMaHDBan.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE hoaDonBan WHERE maHDB=N'" + txtMaHDBan.Text + "'";
                Functions.RunDeleteSQL(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnInhoadon.Enabled = false;
            }

        }
        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            // Định dạng chung
            exRange = (COMExcel.Range)exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng máy tính PC Market";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Số 12 Chùa Bộc, Đống Đa, Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0123456789";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.maHDB, a.ngayBan, a.tongTien, b.tenKhach, b.diaChi, b.dienThoai, c.tenNV FROM hoaDonBan AS a, khachHang AS b, nhanVien AS c WHERE a.maHDB = N'" + txtMaHDBan.Text + "' AND a.maKhach = b.maKhach AND a.maNV =c.maNV";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tenMay, a.soLuong, b.giaBan, a.thanhTien " +
                  "FROM chiTietHDB AS a , mayTinh AS b WHERE a.maHDB = N'" +
                  txtMaHDBan.Text + "' AND a.maMay = b.maMay";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên máy tính";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
  
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[hang + 12, 1] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[hang + 12, cot + 2] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = (COMExcel.Range)exSheet.Cells[hang + 14, cot];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = (COMExcel.Range)exSheet.Cells[hang + 14, cot + 1];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = (COMExcel.Range)exSheet.Cells[hang + 15, 1]; //Ô A1
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ConvertNumericToText(tblThongtinHD.Rows[0][2].ToString());
            exRange = (COMExcel.Range)exSheet.Cells[hang + 17, 4]; //Ô A1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnThem.Enabled = true; 
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;

        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT maHDB FROM hoaDonBan", cboMaHDBan, "maHDB","maHDB");
            cboMaHDBan.SelectedIndex = -1;

        }

        private void Form_HoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboManhanvien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboMakhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboMamayvt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}