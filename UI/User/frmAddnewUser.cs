using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_software.UI.User
{
    public partial class frmAddnewUser : Form
    {
        Int32 userId;
        public frmAddnewUser()
        {
            InitializeComponent();
        }
        public frmAddnewUser(Int32 id)
        {
            InitializeComponent();
            this.userId = id;
        }


        private void frmAddnewUser_Load(object sender, EventArgs e)
        {
            if (this.userId != 0)
            {
                MODEL.User user = new MODEL.User();
                btnSave.Text = "Update";
                label4.Text = "Update user";
                DataTable dt = DAL.UserDal.getAllById(this.userId);
                if (dt != null)
                {
                    DataRow dr = dt.Rows[0];
                    txtPassword.Text = dr["password"].ToString();
                    txtUserName.Text = dr["username"].ToString();
                    txtUsertype.Text = dr["user_type"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool is_save = false;
            
            MODEL.User user = new MODEL.User();
            // cus.Id = 8;
            user.username = txtUserName.Text;
            user.password = txtPassword.Text;
            user.user_type = txtUsertype.Text;


            if (this.userId != 0)
            {
                user.Id = this.userId;
                is_save = DAL.UserDal.Update(user);
            }
            else
            {
                is_save = DAL.UserDal.Insert(user);
            }

            if (is_save)
            {
                MessageBox.Show("user save succesfully..");
            }
            else
            {
                MessageBox.Show("user save fail..");
            }
        }
    }
}
