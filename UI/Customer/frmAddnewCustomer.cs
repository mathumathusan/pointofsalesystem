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
    public partial class frmAddNewCustomer : Form
    {
        Int32 customerId;
        public frmAddNewCustomer()
        {
            InitializeComponent();
        }

        public frmAddNewCustomer(Int32 id)
        {
            InitializeComponent();
            this.customerId = id;
        }

        private void frmAddNewCustomer_Load(object sender, EventArgs e)
        {
            if (this.customerId != 0)
            {
                MODEL.Customer cus = new MODEL.Customer();
                btnSave.Text = "Update";
                label4.Text = "Update Customer";
               // MessageBox.Show(this.customerId.ToString());
                DataTable dt = DAL.CustomerDal.getAllById(this.customerId);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    txtTelephoneNo.Text = dr["telephone_no"].ToString();
                    txtCustomerName.Text = dr["customer_name"].ToString();
                    txtCustomerAddress.Text = dr["address"].ToString();
                }    
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool is_save = false;
            // DAL.CustomerDal cus = new DAL.CustomerDal();
            MODEL.Customer cus = new MODEL.Customer();
           // cus.Id = 8;
            cus.customer_name = txtCustomerName.Text;
            cus.telephone_no = txtTelephoneNo.Text;
            cus.address =txtCustomerAddress.Text;
            

            if (this.customerId != 0)
            {
                cus.Id = this.customerId;
                is_save = DAL.CustomerDal.Update(cus);
            }
            else
            {
                is_save = DAL.CustomerDal.Insert(cus);
            }

            if (is_save)
            {
                MessageBox.Show("customer save succesfully..");
            }
            else
            {
                MessageBox.Show("customer save fail..");
            }
        }
    }
}
