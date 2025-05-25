using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.frm;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagementSystem.Helper;
namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        DBHelper con = new DBHelper();
        public LoginForm()
        {
            InitializeComponent();
        }
      
        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            
            if (gbtxtPass.Text != "Enter password")
            {
                gbtxtPass.UseSystemPasswordChar = !cbPass.Checked;
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            gbtxtPass.Text = "Enter Password";
            gbtxtPass.ForeColor = Color.Gray;
            gbtxtPass.UseSystemPasswordChar = false;
            cbPass.Text = "Show Password";

            gbtxtUserName.Text = "Enter Username";
            gbtxtUserName.ForeColor = Color.Gray;

           
            
        }

        private void gbtxtPass_Enter(object sender, EventArgs e)
        {
            if (gbtxtPass.Text == "Enter Password")
            {
                gbtxtPass.Text = "";
                gbtxtPass.ForeColor = Color.Black;
                gbtxtPass.UseSystemPasswordChar = true;
            }
        }

        private void gbtxtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gbtxtPass.Text))
            {
                gbtxtPass.UseSystemPasswordChar = false;
                gbtxtPass.Text = "Enter Password";
                gbtxtPass.ForeColor = Color.Gray;
            }
        }

        private void gbtxtUserName_Enter(object sender, EventArgs e)
        {
            if (gbtxtUserName.Text == "Enter Username")
            {
                gbtxtUserName.Text = "";
                gbtxtUserName.ForeColor = Color.Black;

            }
        }

        private void gbtxtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gbtxtUserName.Text))
            {

                gbtxtUserName.Text = "Enter Username";
                gbtxtUserName.ForeColor = Color.Gray;
            }
        }

        //For Log In
        private async void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string userName = gbtxtUserName.Text;
            string pass = gbtxtPass.Text;

            //  Validate input
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter your username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //  Check username pattern (letters, numbers, underscore only)
            if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Check username length
            if (userName.Length > 15)
            {
                MessageBox.Show("Username must not exceed 15 characters.", "Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Password length check
            if (pass.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Block quote characters in password
            if (pass.Contains("'") || pass.Contains("\""))
            {
                MessageBox.Show("Password must not contain quotes.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter your username.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter your password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Variable.uname = userName;
            Variable.password = pass;
            DBHelper.User("Login");

            if (Variable.bolsuccess == true)
            {
                //var okay = MessageBox.Show("Login Success!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (okay == DialogResult.OK)
                //{
                    
                   MainForm mainForm = new MainForm();
                    mainForm.Show();
                    await Task.Delay(500);
                    this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kindly click okay to proceed!");
            //        return;
            //    }
             }

        }

        //For Sign Up
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
           // var registerForm = _serviceProvider.GetRequiredService<frmRegisterUser>();
           // registerForm.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbPass_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}

