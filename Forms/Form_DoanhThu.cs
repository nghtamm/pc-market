using pc_market.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;


namespace pc_market.Forms
{
    public partial class Form_DoanhThu : Form
    {
        public Form_DoanhThu()
        {
            InitializeComponent();

        }

        private void FormDoanhthu_Load(object sender, EventArgs e)
        {
            btnxem.Enabled = true;
            btnxuatfile.Enabled = true;
            btnthoat.Enabled = true;
            txtdoanhthu.Enabled = true;
            rdbNgay.Checked = false;
            rdbKhoang.Checked = false;
        }

        private void rdbNgay_CheckedChanged(object sender, EventArgs e)
        {
            mskNgay.Enabled = true;
            mskTu.Enabled = false;
            mskDen.Enabled = false;
            mskTu.Text = "";
            mskDen.Text = "";
            txtdoanhthu.Text = "";
            ClearDataGridView();
        }

        private void rdbKhoang_CheckedChanged(object sender, EventArgs e)
        {
            mskNgay.Enabled = false;
            mskNgay.Text = "";
            mskTu.Enabled = true;
            mskDen.Enabled = true;
            txtdoanhthu.Text = "";
            ClearDataGridView();
        }

        private void ClearDataGridView()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ADMIN\\VOCNGUYEN;Initial Catalog=pc-market;Integrated Security=True;Encrypt=False";
            string sql = ""; 
         
                if (rdbNgay.Checked)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(mskNgay.Text, out selectedDate))
                    {
                    sql = $"SELECT mt.maMay, mt.tenMay, SUM(ct.soLuong) AS soluongbanra, SUM(ct.thanhTien) AS doanhthu " +
                      $"FROM hoadonban hdb " +
                      $"JOIN chitiethdb ct ON hdb.maHDB = ct.maHDB " +
                      $"JOIN maytinh mt ON ct.maMay = mt.maMay " +
                      $"WHERE hdb.ngayBan = '{selectedDate.ToString("dd-MM-yyyy")}' " +
                      $"GROUP BY mt.maMay, mt.tenMay, hdb.ngayBan " +
                      $"ORDER BY hdb.ngayBan, mt.maMay";

                }
                else
                    {
                        MessageBox.Show("Ngày không hợp lệ, bạn vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (rdbKhoang.Checked)
                {
                mskNgay.Enabled = false;
                DateTime fromDate, toDate;
                    if (DateTime.TryParse(mskTu.Text, out fromDate) && DateTime.TryParse(mskDen.Text, out toDate))
                    {
                    

                        sql = $"SELECT mt.maMay,mt.tenMay,SUM(ct.soLuong) AS soluongbanra,SUM(ct.thanhTien) AS doanhthu  FROM  hoadonban hdb  " +
                        $"JOIN    chitiethdb ct ON hdb.maHDB = ct.maHDB " +
                        $"JOIN    maytinh mt ON ct.maMay = mt.maMay   " +
                        $"WHERE    hdb.ngayBan BETWEEN '{fromDate.ToString("dd-MM-yyyy")}' AND '{toDate.ToString("dd-MM-yyyy")}'   " +
                        $"GROUP BY    mt.maMay, mt.tenMay  ORDER BY  mt.maMay";
                    }
                    else
                    {
                    MessageBox.Show("Ngày không hợp lệ, bạn vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tùy chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }

                //Đổ dữ liệu vào DataGridView
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView.DataSource = table;

                decimal totalRevenue = 0;
                foreach (DataRow row in table.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row["doanhthu"]);
                }

                // Hiển thị tổng doanh thu
                txtdoanhthu.Enabled = true;
                NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
                nfi.CurrencySymbol = "₫";
                txtdoanhthu.Text = totalRevenue.ToString("C", nfi);

            }

        }

        private void ExportExcel(string path)
        {
           Excel.Application application = new Excel.Application(); 
           application.Application.Workbooks.Add(Type.Missing); 
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    application.Cells[i+2, j+1] = dataGridView.Rows[i].Cells[i].Value;
                }
                    
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;

        }


        private void btnxuatfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xlsx)|*.xls";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công!");
                }

                catch
                {
                    MessageBox.Show("Xuất file thất bại!");
                }
            }

        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }

}
    

