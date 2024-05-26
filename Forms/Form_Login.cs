using System;
using System.Windows.Forms;

namespace pc_market.Forms {
    public partial class Form_Login : Form {
        public Form_Login() {
            InitializeComponent();
        }

        public void FormLogin_Load(object sender, EventArgs e) {
            Classes.Functions.Connect();
        }

        public void ButtonLogin_Click(object sender, EventArgs e) {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (Classes.Functions.AccountValidate(username, password)) {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form_MainMenu mainMenu = new Form_MainMenu();
                this.Hide();
                mainMenu.Show();
            }
            else {
                MessageBox.Show("Thông tin đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        public void ShowPassword_Checked(object sender, EventArgs e) {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}