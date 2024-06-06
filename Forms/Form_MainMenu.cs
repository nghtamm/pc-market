using System;
using System.Windows.Forms;

namespace pc_market {
    public partial class Form_MainMenu : Form {
        public Form_MainMenu() {
            InitializeComponent();
        }

        public void AboutUs_Click(object sender, EventArgs e) {
            MessageBox.Show("Phần mềm quản lý cửa hàng máy tính PC Market\n\n" +
                            "• Nhóm: 1 \n" +
                            "• Thành viên: \n" +
                            "   + Nguyễn Hoàng Tâm \n" +
                            "   + Nguyễn Huy Phước \n" +
                            "   + Bùi Tú Phương \n" +
                            "   + Trần Tiến Thịnh \n" +
                            "   + Nguyễn Thị Vóc \n" +
                            "• Môn học: Lập trình .NET \n" +
                            "• Giảng viên hướng dẫn: ThS. Lê Cẩm Tú \n" +
                            "• Trường: Học viện Ngân hàng \n" +
                            "• Năm học: 2023 - 2024", "Về chúng tôi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Exit_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        public void Category_Mainboard_Click(object sender, EventArgs e) {
            Forms.Form_Mainboard formMainboard = new Forms.Form_Mainboard();
            formMainboard.Show();
        }

        public void Category_PC_Click(object sender, EventArgs e) {
            Forms.Form_PC formPC = new Forms.Form_PC();
            formPC.Show();
        }

        public void Category_GPU_Click(object sender, EventArgs e) {
            Forms.Form_GPU formGPU = new Forms.Form_GPU();
            formGPU.Show();
        }

        public void Category_Provider_Click(object sender, EventArgs e) {
            Forms.Form_NCC formNCC = new Forms.Form_NCC();
            formNCC.Show();
        }

        public void Category_Customer_Click(object sender, EventArgs e) {
            Forms.Form_KhachHang formKhachHang = new Forms.Form_KhachHang();
            formKhachHang.Show();
        }

        public void Category_RAM_Click(object sender, EventArgs e) {
            Forms.Form_RAM formRAM = new Forms.Form_RAM();
            formRAM.Show();
        }

        public void Category_DataStorage_Click(object sender, EventArgs e) {
            Forms.Form_DataStorage formDataStorage = new Forms.Form_DataStorage();
            formDataStorage.Show();
        }

        public void Receipt_HDB_Click(object sender, EventArgs e) {
            Forms.Form_HoaDonBan formHoaDonBan = new Forms.Form_HoaDonBan();
            formHoaDonBan.Show();
        }

        public void Receipt_HDN_Click(object sender, EventArgs e) {
            Forms.Form_HoaDonNhap formHoaDonNhap = new Forms.Form_HoaDonNhap();
            formHoaDonNhap.Show();
        }

        public void Search_HDN_Click(object sender, EventArgs e) {
            Forms.Form_SearchHDN formSearchHDN = new Forms.Form_SearchHDN();
            formSearchHDN.Show();
        }

        private void Search_HDB_Click(object sender, EventArgs e) {
            Forms.Form_SearchHDB formSearchHDB = new Forms.Form_SearchHDB();
            formSearchHDB.Show();
        }
    }
}