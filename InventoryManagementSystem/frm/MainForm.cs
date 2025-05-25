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

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private readonly IDBHelper _db;
        private readonly IServiceProvider _serviceProvider;
        public MainForm(IDBHelper db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db;
            _serviceProvider = serviceProvider;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
        }
    }
}
