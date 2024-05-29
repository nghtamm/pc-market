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
    }
}