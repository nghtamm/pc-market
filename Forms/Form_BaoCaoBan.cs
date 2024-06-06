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

namespace pc_market.Forms
{
    public partial class Form_BaoCaoBan : Form
    {
        public Form_BaoCaoBan()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        
        private void frm_MH_Load(object sender, EventArgs e)
        {
            Classes.Functions.Connect();

            // DataGridView_Load();
            // ResetValues();
        }
    }
}