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

namespace InventoryManagementSystem.frm
{
    public partial class ProductForm : Form
    {
        DBHelper con = new DBHelper();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddProduct frm = new AddProduct();
            {
                frm.ShowDialog();
                LoadProducts();
            }
        }
        public void LoadProducts()
        {
            try
            {
                DBHelper.Product("LoadRecords");
                BindingSource bindingSource = new BindingSource();
                dgProducts.DataSource = null;
                bindingSource.DataSource = Variable.product;
                dgProducts.DataSource = bindingSource;
                dgProducts.Columns[0].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            Variable.iswitch = 0;
            LoadProducts();
        }

        private void gbbtnDelete_Click(object sender, EventArgs e)
        {
            if(Variable.role == "Staff")
            {
                MessageBox.Show("You do not have permission to delete products.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (dgProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete");
                    return;
                }
            }
   

            int selectedProductId = Convert.ToInt32(dgProducts.SelectedRows[0].Cells[0].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Variable.strid = Convert.ToString(selectedProductId);
                DBHelper.Product("Delete");
                Variable.iswitch = 0;
                LoadProducts();
            }
        }

        private void txtseach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Variable.strsearch = txtseach.Text.Trim().ToLower();
                Variable.iswitch = 1; // Set switch for search operation
                LoadProducts();
            }
        }
    }
}
