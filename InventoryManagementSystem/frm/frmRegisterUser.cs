using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.Helper;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace InventoryManagementSystem.frm
{
    public partial class frmRegisterUser : Form
    {
       DBHelper cn = new DBHelper();
        public frmRegisterUser()
        {
            InitializeComponent();
      
        }

        //For Create
        private void gbCreate_Click(object sender, EventArgs e)
        {
            string user = gbtxtUsername.Text;
            string pass = gbtxtPass.Text;
            string email = gbtxtEmail.Text;
            string role = txtrole.Text;
            //  Check if empty
            if (string.IsNullOrEmpty(user.Trim()))
            {
                MessageBox.Show("Please fill Username.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pass.Trim()))
            {
                MessageBox.Show("Please fill Password.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(email.Trim()))
            {
                MessageBox.Show("Please fill Email.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Check username pattern
            if (!System.Text.RegularExpressions.Regex.IsMatch(user, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Minimum Username length
            if (user.Length < 6 || user.Length > 15)
            {
                MessageBox.Show("Username must be between 6 and 15 characters.", "Invalid Username Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Minimum password length
            if (pass.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gbtxtPass.Text != guna2TextBox1.Text)
            {
                MessageBox.Show("Password not match!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == string.Empty)
            {
                MessageBox.Show("Require select role.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Variable.uname = user;
            Variable.password = pass;
            Variable.role = role;
            Variable.email = email;
            DBHelper.User("Insert");
            this.Close();
            LoginForm frm = new LoginForm();
            {
                frm.Show();
            }
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            {
                frm.Show();
            }
            this.Hide();
        }
    }
}
