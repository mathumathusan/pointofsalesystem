using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_software.UI.Customer
{
    public partial class frmCustomerMaster : Form
    {
        String id=null;
        public frmCustomerMaster()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            MODEL.Customer cus = new MODEL.Customer();
            DataTable dt = DAL.CustomerDal.GetAll();
            dataGridView1.DataSource = dt;
            cmbCustomers.SelectedIndex = 0;
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmAddNewCustomer(Int32 id)
           
            if (id != null)
            {
                UI.Customer.frmAddNewCustomer frm = new UI.Customer.frmAddNewCustomer(Convert.ToInt32(this.id));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("please touch the header...");
                return;
            }
            this.id = null;
           
            frmCustomerMaster_Load(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UI.Customer.frmAddNewCustomer frm = new UI.Customer.frmAddNewCustomer(Convert.ToInt32(this.id));

            frm.ShowDialog();
            frmCustomerMaster_Load(sender, e);
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedIndex != -1)
            {
                DataTable dt = DAL.CustomerDal.SearchCustomers(cmbCustomers.Text, txtCustomerSearch.Text.Trim());
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("please select the combo box");
                return;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MODEL.Customer cus = new MODEL.Customer();
            bool is_delete = false;
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete" , "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.id != null)
                {
                    cus.Id = Convert.ToInt32(this.id);
                    is_delete = DAL.CustomerDal.Delete(cus);
                }
                else
                {
                    MessageBox.Show("please double click the header....");
                }
            }
            if (is_delete)
            {
                MessageBox.Show("delete successfully.....");
                frmCustomerMaster_Load(sender, e);

            }
            
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            frmCustomerMaster_Load(sender, e);
            txtCustomerSearch.Text = "";
        }
    }
}
