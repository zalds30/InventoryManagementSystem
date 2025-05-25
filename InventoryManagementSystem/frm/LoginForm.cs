using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.frm;
using InventoryManagementSystem.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly IDBHelper _db;
        private readonly IServiceProvider _serviceProvider;
        public LoginForm(IDBHelper db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            // hide the password
            txtPass.UseSystemPasswordChar = true;
            // Set max length (optional)
            txtUserName.MaxLength = 15;
            txtPass.MaxLength = 8;
            _db = db;
            _serviceProvider = serviceProvider;

            GraphicsPath path = new GraphicsPath();
            int radius = 70; // change this for roundness
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);

        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string pass = txtPass.Text;

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
            if (pass.Length > 6)
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

            string query = $"select count(*) from tblUsers where username = '{userName}' and password = '{pass}'";

            var result = (int) _db.ExecuteScalar(query);
            if (result > 0)
            {
                var okay = MessageBox.Show("Login Success!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (okay == DialogResult.OK)
                {
                    this.Hide();
                    var registerForm = _serviceProvider.GetRequiredService<MainForm>();
                    registerForm.Show();
                }
                else
                {
                    MessageBox.Show("Kindly click okay to proceed!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong Credentials!");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var registerForm = _serviceProvider.GetRequiredService<frmRegisterUser>();
            registerForm.Show();
        }

        private void cbPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !cbPass.Checked;

            if (cbPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

    }
}

