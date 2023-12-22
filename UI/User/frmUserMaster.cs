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
    public partial class frmUserMaster : Form
    {
        String id = null;
        public frmUserMaster()
        {
            InitializeComponent();
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            MODEL.User user = new MODEL.User();
            DataTable dt = DAL.UserDal.GetAll();
            dataGridView2.DataSource = dt;
            cmbUsers.SelectedIndex = 0;
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmAddNewCustomer(Int32 id)

            if (id != null)
            {
                UI.User.frmAddnewUser frm = new UI.User.frmAddnewUser(Convert.ToInt32(this.id));
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("please touch the header...");
                return;
            }
            this.id = null;

            frmUserMaster_Load(sender, e);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UI.User.frmAddnewUser frm = new UI.User.frmAddnewUser(Convert.ToInt32(this.id));

            frm.ShowDialog();
            frmUserMaster_Load(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedIndex != -1)
            {
                DataTable dt = DAL.UserDal.SearchUsers(cmbUsers.Text, txtUsersSearch.Text.Trim());
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
            MODEL.User user = new MODEL.User();
            bool is_delete = false;
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.id != null)
                {
                    user.Id = Convert.ToInt32(this.id);
                    is_delete = DAL.UserDal.Delete(user);
                }
                else
                {
                    MessageBox.Show("please double click the header....");
                }
            }
            if (is_delete)
            {
                MessageBox.Show("delete successfully.....");
                frmUserMaster_Load(sender, e);

            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            frmUserMaster_Load(sender, e);
            txtUsersSearch.Text = "";
        }
    }
}
