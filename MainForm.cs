using System;
using System.Windows.Forms;

namespace pc_market
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Classes.Functions.Connect();
        }

        private void categoryProvider_Click(object sender, EventArgs e)
        {
            Forms.frm_NCC a = new Forms.frm_NCC();
            a.Show();
        }

        private void categoryPCParts_Click(object sender, EventArgs e)
        {

        }

        private void PCParts_GPU_Click(object sender, EventArgs e)
        {
            Forms.frm_GPU a = new Forms.frm_GPU();
            a.Show();
        }
    }
}