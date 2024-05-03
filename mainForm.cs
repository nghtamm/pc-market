using System;
using System.Windows.Forms;

namespace pc_market
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            classes.functions.Connect();
        }
    }
}