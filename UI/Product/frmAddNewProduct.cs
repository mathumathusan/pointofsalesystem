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
    public partial class FrmAddNewProduct : Form
    {
        Int32 productId;
        public FrmAddNewProduct()
        {
            InitializeComponent();
        }
        public FrmAddNewProduct(Int32 id)
        {
            InitializeComponent();
            this.productId = id;
        }

        

        private void FrmAddNewProduct_Load_1(object sender, EventArgs e)
        {
            if (this.productId != 0)
            {
                MODEL.Product pro = new MODEL.Product();
                btnSave.Text = "Update";
                label4.Text = "Update Products";
               // MessageBox.Show(this.productId.ToString());
                DataTable dt = DAL.ProductDal.getAllById(this.productId);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    txtCatogaryId.Text = dr["catogary_id"].ToString();
                    txtProductName.Text = dr["product_name"].ToString();
                    txtProductCode.Text = dr["product_code"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool is_save = false;
          
            MODEL.Product pro = new MODEL.Product();
          
            pro.product_code = txtProductCode.Text;
            pro.product_name = txtProductName.Text;
            pro.catogary_id = txtCatogaryId.Text;


            if (this.productId != 0)
            {
                pro.Id = this.productId;
                is_save = DAL.ProductDal.Update(pro);
            }
            else
            {
                is_save = DAL.ProductDal.Insert(pro);
            }

            if (is_save)
            {
                MessageBox.Show("products save succesfully..");
            }
            else
            {
                MessageBox.Show("product save fail..");
            }
        }
    }
}
