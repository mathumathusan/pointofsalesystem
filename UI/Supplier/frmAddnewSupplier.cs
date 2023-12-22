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
    public partial class frmAddnewSupplier : Form
    {
        int supplierId;
        public frmAddnewSupplier()
        {
            InitializeComponent();
        }
        public frmAddnewSupplier(int id)
        {
            InitializeComponent();
            this.supplierId = id;
        }

        private void frmAddnewSupplier_Load(object sender, EventArgs e)
        {
            if (this.supplierId != 0)
            {
                MODEL.Supplier sup= new MODEL.Supplier();
                btnSave.Text = "Update";
                label4.Text = "Update Customer";
                // MessageBox.Show(this.customerId.ToString());
                DataTable dt = DAL.SupplierDal.getAllById(this.supplierId);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    txtTelephoneNo.Text = dr["telephone_no"].ToString();
                    txtSupplierName.Text = dr["supplier_name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool is_save = false;
           
            MODEL.Supplier sup = new MODEL.Supplier();
           
            sup.supplier_name = txtSupplierName.Text;
            sup.telephone_no = txtTelephoneNo.Text;
           sup.address= txtAddress.Text;


            if (this.supplierId != 0)
            {
                sup.Id = this.supplierId;
                is_save = DAL.SupplierDal.Update(sup);
            }
            else
            {
                is_save = DAL.SupplierDal.Insert(sup);
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
