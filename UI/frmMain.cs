using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_software.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void saleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Sale.frmSaleMaster f= new Sale.frmSaleMaster();
            f.MdiParent = this; 
            f.Show();
        }
    }
}
