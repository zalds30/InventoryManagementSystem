using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementSystem.frm;
using InventoryManagementSystem.Helper;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private readonly IDBHelper _db;
        private readonly IServiceProvider _serviceProvider;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblName.Text = Variable.uname;
            lblrole.Text = Variable.role;
        }

        private async void btnDashboard_Click_1(object sender, EventArgs e)
        {
            panelform.Controls.Clear();
            Dashboard frm = new Dashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;


            panelform.Controls.Add(frm);


            frm.Location = new Point(
                (panelform.Width - frm.Width) / 2,
                (panelform.Height - frm.Height) / 2
            );


            panelform.Resize += (s, args) => {
                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );
            };

            frm.Show();
        }

        private async void btnProducts_Click_1(object sender, EventArgs e)
        {
            Variable.iswitch = 0;
            panelform.Controls.Clear();
            ProductForm frm = new ProductForm();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;

            panelform.Controls.Add(frm);


            frm.Location = new Point(
                (panelform.Width - frm.Width) / 2,
                (panelform.Height - frm.Height) / 2
            );

            panelform.Resize += (s, args) => {
                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );
            };

            frm.Show();
        }

   

        private async void btnProdInventory_Click_1(object sender, EventArgs e)
        {
            panelform.Controls.Clear();
            ProductInventoryForm frm = new ProductInventoryForm();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;


            panelform.Controls.Add(frm);


            frm.Location = new Point(
                (panelform.Width - frm.Width) / 2,
                (panelform.Height - frm.Height) / 2
            );


            panelform.Resize += (s, args) => {
                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );
            };

            frm.Show();
        }


        private async void button7_Click_1(object sender, EventArgs e)
        {
            if(Variable.role == "Super Admin" || Variable.role == "Admin")
            {
                panelform.Controls.Clear();
                UserSettingsForm frm = new UserSettingsForm();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;


                panelform.Controls.Add(frm);


                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );


                panelform.Resize += (s, args) => {
                    frm.Location = new Point(
                        (panelform.Width - frm.Width) / 2,
                        (panelform.Height - frm.Height) / 2
                    );
                };

                frm.Show();
            }
            else
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            DBHelper.LogAction(Variable.userid, "User Logout",
                          $"User {Variable.uname}");
            this.Hide();
            LoginForm frm = new LoginForm();
            frm.Show();
      
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

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            if(Variable.role == "Super Admin" || Variable.role == "Admin")
            {
                panelform.Controls.Clear();
                Supplier frm = new Supplier();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;


                panelform.Controls.Add(frm);


                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );


                panelform.Resize += (s, args) => {
                    frm.Location = new Point(
                        (panelform.Width - frm.Width) / 2,
                        (panelform.Height - frm.Height) / 2
                    );
                };

                frm.Show();
            }
            else
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncategpries_Click(object sender, EventArgs e)
        {
            if (Variable.role == "Super Admin" || Variable.role == "Admin")
            {
                panelform.Controls.Clear();
                Categories frm = new Categories();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;


                panelform.Controls.Add(frm);


                frm.Location = new Point(
                    (panelform.Width - frm.Width) / 2,
                    (panelform.Height - frm.Height) / 2
                );


                panelform.Resize += (s, args) => {
                    frm.Location = new Point(
                        (panelform.Width - frm.Width) / 2,
                        (panelform.Height - frm.Height) / 2
                    );
                };

                frm.Show();
            }
            else
            {
                MessageBox.Show("You do not have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    } 
}
