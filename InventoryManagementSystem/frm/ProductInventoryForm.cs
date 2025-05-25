using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagementSystem.frm
{
    public partial class ProductInventoryForm : Form
    {
        DBHelper cn = new DBHelper();
        public ProductInventoryForm()
        {
            InitializeComponent();
    
        }

        void tarckExpiry()
        {
            txtcategory.Items.Clear();
            DBHelper.Categories("GetRecords");
            foreach (var item in DBHelper.cmb.Items)
            {
                txtcategory.Items.Add(item);
            }
        }
        private void ProductInventoryForm_Load(object sender, EventArgs e)
        {
            tarckExpiry();
        }
    }
}
