using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem.frm
{

    public partial class UserSettingsForm : Form
    {
        DBHelper con = new DBHelper();
        public UserSettingsForm()
        {
            InitializeComponent();

        }


        private void gbbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Are you sure you want to exit the application?",
              "Confirm Exit",
              MessageBoxButtons.OKCancel,
              MessageBoxIcon.Question
          );

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        void loadrecords()
        {
            BindingSource bindingSource1 = new BindingSource(), bindingSource2 = new BindingSource(), bindingSource3 = new BindingSource();

            gbtxtCurrentUser.Text = Variable.uname;
            dgvadminuser.DataSource = null;
            DBHelper.User("LoadRecordsAdmin");
            bindingSource1.DataSource = Variable.adminlist;
            dgvadminuser.DataSource = bindingSource1;
            dgvadminuser.Columns[0].Visible = false;
            dgvadminuser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvsuperadmin.DataSource = null;
            DBHelper.User("LoadRecordsSuperAdmin");
            bindingSource2.DataSource = Variable.superadminlist;
            dgvsuperadmin.DataSource = bindingSource2;
            dgvsuperadmin.Columns[0].Visible = false;
            dgvsuperadmin.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvstaff.DataSource = null;
            DBHelper.User("LoadRecordsStaff");
            bindingSource3.DataSource = Variable.stafflist;
            dgvstaff.DataSource = bindingSource3;
            dgvstaff.Columns[0].Visible = false;
            dgvstaff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            loadrecords();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            loadrecords();
        }
    }
}
