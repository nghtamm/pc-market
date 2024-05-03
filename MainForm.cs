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
    }
}