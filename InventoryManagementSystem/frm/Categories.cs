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
    public partial class Categories : Form
    {
        DBHelper cn = new DBHelper();
        public Categories()
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtcategoryname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chck1.Checked == true)
            {
                Variable.variantid = 1;
            }
            else if(chck2.Checked == true)
            {
                Variable.variantid = 2;
            }
            else
            {
                Variable.variantid = 3;
            }
     
            Variable.categoryname = txtcategoryname.Text.Trim();
            DBHelper.Categories("Insert");
            DBHelper.Categories("LoadRecords");
            loadRecords();
        }

        void loadRecords()
        {
            BindingSource bindingSource = new BindingSource();
            dataGridView2.DataSource = null;
            DBHelper.Categories("LoadRecords");
            bindingSource.DataSource = Variable.dt; 
            dataGridView2.DataSource = bindingSource;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void Categories_Load(object sender, EventArgs e)
        {
            Variable.iswitch = 0; // Reset switch for new category entry
            loadRecords();
         
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }

            int selectedCategoryId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this category?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Variable.strid = Convert.ToString(selectedCategoryId);
                DBHelper.Categories("Delete");
                Variable.iswitch = 0;
                loadRecords(); // Refresh the grid after deletion
            
            }
        }

        private void txtseach_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtseach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Variable.strsearch = txtseach.Text.Trim().ToLower();
                Variable.iswitch = 1; // Set switch for search operation
                loadRecords();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtcategoryname.Clear();
        }
    }
}
