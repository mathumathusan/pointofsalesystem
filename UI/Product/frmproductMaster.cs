using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_software.UI.Product
{
    public partial class FrmproductMaster : Form
    {
        String id = null;
        public FrmproductMaster()
        {
            InitializeComponent();
        }

        private void FrmproductMaster_Load(object sender, EventArgs e)
        {
            MODEL.Product pro = new MODEL.Product();
            DataTable dt = DAL.ProductDal.GetAll();
            dataGridView2.DataSource = dt;
            cmbProducts.SelectedIndex = 0;
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (id != null)
            {
                UI.Product.FrmAddNewProduct frm = new UI.Product.FrmAddNewProduct(Convert.ToInt32(this.id));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("please touch the header...");
                return;
            }
            this.id = null;

            FrmproductMaster_Load(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UI.Product.FrmAddNewProduct frm = new UI.Product.FrmAddNewProduct(Convert.ToInt32(this.id));

            frm.ShowDialog();
            FrmproductMaster_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MODEL.Product pro = new MODEL.Product();
            bool is_delete = false;
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.id != null)
                {
                    pro.Id = Convert.ToInt32(this.id);
                    is_delete = DAL.ProductDal.Delete(pro);
                }
                else
                {
                    MessageBox.Show("please double click the header....");
                }
            }
            if (is_delete)
            {
                MessageBox.Show("delete successfully.....");
                FrmproductMaster_Load(sender, e);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedIndex != -1)
            {
                DataTable dt = DAL.ProductDal.SearchProducts(cmbProducts.Text, txtProductsSearch.Text.Trim());
                dataGridView2.DataSource = dt;
            }
            else
            {
                MessageBox.Show("please select the combo box");
                return;
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            FrmproductMaster_Load(sender, e);
            txtProductsSearch.Text = "";
        }
    }
}
