using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_software.UI.Supplier
{
    public partial class frmsSupplierMaster : Form
    {
        String id;
        public frmsSupplierMaster()
        {
            InitializeComponent();
        }

        private void frmsSupplierMaster_Load(object sender, EventArgs e)
        {
            MODEL.Supplier sup = new MODEL.Supplier();
            DataTable dt = DAL.SupplierDal.GetAll();
            dataGridView2.DataSource = dt;
            cmbSuppliers.SelectedIndex = 0;
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                UI.Supplier.frmAddnewSupplier frm = new UI.Supplier.frmAddnewSupplier(Convert.ToInt32(this.id));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("please touch the header...");
                return;
            }
            this.id = null;

           frmsSupplierMaster_Load(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UI.Supplier.frmAddnewSupplier frm = new UI.Supplier.frmAddnewSupplier(Convert.ToInt32(this.id));
            frm.ShowDialog();
            frmsSupplierMaster_Load(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSuppliers.SelectedIndex != -1)
            {
                DataTable dt = DAL.SupplierDal.SearchSuppliers(cmbSuppliers.Text, txtSuppliersSearch.Text.Trim());
                dataGridView2.DataSource = dt;
            }
            else
            {
                MessageBox.Show("please select the combo box");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MODEL.Supplier sup = new MODEL.Supplier();
            bool is_delete = false;
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.id != null)
                {
                    sup.Id = Convert.ToInt32(this.id);
                    is_delete = DAL.SupplierDal.Delete(sup);
                }
                else
                {
                    MessageBox.Show("please double click the header....");
                }
            }
            if (is_delete)
            {
                MessageBox.Show("delete successfully.....");
                frmsSupplierMaster_Load(sender, e);

            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            frmsSupplierMaster_Load(sender, e);
            txtSuppliersSearch.Text = "";
        }
    }
}
