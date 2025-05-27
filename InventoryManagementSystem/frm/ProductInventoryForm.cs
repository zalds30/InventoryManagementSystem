using Guna.UI2.WinForms;
using InventoryManagementSystem.Helper;
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
using static InventoryManagementSystem.DBHelper;
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
        void CheckProduct()
        {
            gbcbSelectItem.Items.Clear();
            gbcbSelectName1.Items.Clear();
            gbcbProd.Items.Clear();
            DBHelper.Product("GetRecordsStocks");
            foreach (var item in DBHelper.cmb.Items)
            {
                gbcbSelectItem.Items.Add(item);
                gbcbSelectName1.Items.Add(item);
                gbcbProd.Items.Add(item);
            }
            gbcbSelectItem.DisplayMember = "ProductName";
            gbcbSelectItem.ValueMember = "ProductID"; // Only one ValueMember

            gbcbSelectName1.DisplayMember = "ProductName";
            gbcbSelectName1.ValueMember = "ProductID"; // Only one ValueMember

            gbcbProd.DisplayMember = "ProductName";
            gbcbProd.ValueMember = "ProductID"; // Only one ValueMember
        }

        void supplier()
        {
            gbcbSupplier.Items.Clear();
            guna2ComboBox1.Items.Clear();
            guna2ComboBox2.Items.Clear();

            DBHelper.Supplier("GetRecords");
            foreach (var item in DBHelper.cmb.Items)
            {
                gbcbSupplier.Items.Add(item);
                guna2ComboBox1.Items.Add(item);
                guna2ComboBox2.Items.Add(item);
            }

            gbcbSupplier.DisplayMember = "CompanyName";
            gbcbSupplier.ValueMember = "SupplierID";
            guna2ComboBox1.DisplayMember = "CompanyName";
            guna2ComboBox1.ValueMember = "SupplierID";
            guna2ComboBox2.DisplayMember = "CompanyName";
            guna2ComboBox2.ValueMember = "SupplierID";
        }

        void stock_card()
        {
            BindingSource bindingSource = new BindingSource();
            guna2DataGridView1.DataSource = null;
            DBHelper.StockCard();
            bindingSource.DataSource = Variable.stockcarddata;
            guna2DataGridView1.DataSource = bindingSource;
        }
        private void ProductInventoryForm_Load(object sender, EventArgs e)
        {
            tarckExpiry();
            CheckProduct();
            supplier();
            stock_card();

            if(Variable.role == "Staff")
            {
                guna2TabControl1.TabPages.Remove(tabPage1);
                 guna2TabControl1.TabPages.Remove(tabPage3);
                guna2TabControl1.TabPages.Remove(tabPage4);
                guna2TabControl1.TabPages.Remove(tabPage5);
            }
            //else if(Variable.role == "Super Admin")
            //{
            //    guna2TabControl1.TabPages.Remove(tabPage5);
            //}
            //else if(Variable.role == "Admin")
            //{
            //    guna2TabControl1.TabPages.Remove(tabPage6);
            //}
        
        }

        private void gbbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(gbcbProd.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product!");
                    return;
                }   

                if (gbcbSupplier.SelectedItem == null)
                {
                    MessageBox.Show("Please select a supplier!");
                    return;
                }

                // Cast the selected item to SupplierItem
                SupplierItem selectedSupplier = (SupplierItem)gbcbSupplier.SelectedItem;
                ProductItem selectedProduct = (ProductItem)gbcbProd.SelectedItem;

                Variable.supplierid = selectedSupplier.SupplierID;
                Variable.productid = selectedProduct.ProductID;
                Variable.qty = Convert.ToInt32(gbtxtQuantity.Text.Trim());
                Variable.date = Convert.ToDateTime(gbDate.Value.ToString("yyyy-MM-dd"));

                DBHelper.Stockin("Insert");

                string strquantity = selectedProduct.Quantity.ToString();
                int currentqty = Convert.ToInt32(strquantity);

                int totalqty = currentqty + Variable.qty;
                Variable.qty = totalqty;
                DBHelper.Product("UpdateStock");
                CheckProduct();
                stock_card();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void gbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(gbcbSelectItem.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product!");
                    return;
                }

                if (guna2ComboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select a supplier!");
                    return;
                }

                int currentQty = Convert.ToInt32(gbtxtQuanty.Text.Trim());
                int quantityToRemove = Convert.ToInt32(gbNumericNumber.Text.Trim());

                if (quantityToRemove > currentQty)
                {
                    MessageBox.Show("Quantity to remove exceeds current quantity in stock.");
                    return;
                }

                int totalQty = currentQty - quantityToRemove;

                // Cast the selected item to SupplierItem
                SupplierItem selectedSupplier = (SupplierItem)guna2ComboBox1.SelectedItem;
                ProductItem selectedProduct = (ProductItem)gbcbSelectItem.SelectedItem;

                Variable.supplierid = selectedSupplier.SupplierID;
                Variable.productid = selectedProduct.ProductID;
                Variable.qty = Convert.ToInt32(gbNumericNumber.Text.Trim());
                Variable.date = Convert.ToDateTime(gbDateTime.Value.ToString("yyyy-MM-dd"));

                DBHelper.Stockout("Insert");
                Variable.qty = totalQty; // Update the quantity to the new total
                DBHelper.Product("UpdateStock");

                CheckProduct();
                stock_card();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

   
        private void gbcbProd_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void gbcbSelectItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (gbcbSelectItem.SelectedItem != null)
            {
                // Cast the selected item to ProductItem
                ProductItem selectedProduct = (ProductItem)gbcbSelectItem.SelectedItem;

                // Display the quantity in the textbox
                gbtxtQuanty.Text = selectedProduct.Quantity.ToString();
            }
        }

        private void gbSave1_Click(object sender, EventArgs e)
        {
            if(gbcbSelectName1.SelectedItem == null)
            {
                MessageBox.Show("Please select a product!");
                return;
            }   

            if (guna2ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a supplier!");
                return;
            }

            SupplierItem selectedSupplier = (SupplierItem)guna2ComboBox2.SelectedItem;
            ProductItem selectedProduct = (ProductItem)gbcbSelectName1.SelectedItem;
            Variable.productid = selectedProduct.ProductID;
            Variable.qty = Convert.ToInt32(guna2NumericUpDown1.Value);
            Variable.date = Convert.ToDateTime(guna2DateTimePicker1.Value.ToString("yyyy-MM-dd"));
            Variable.supplierid = selectedSupplier.SupplierID;


            if (chksetnewqty.Checked == true)
            {
                DBHelper.Product("UpdateStock");
            }
            else if (chkexisting.Checked == true)
            {
                DBHelper.Product("UpdateExistingStockQTY");
            }

            CheckProduct();
            DBHelper.Stockin("Insert");


        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ApplyTrackExpiryFilter()
        {
            try
            {
                string selectedStatus = guna2ComboBox4.SelectedItem?.ToString() ?? "All";
                string selectedCategory = txtcategory.SelectedItem?.ToString() ?? "All";

                DBHelper.TrackExpiry(selectedCategory, selectedStatus);

                // Refresh the grid
                guna2DataGridView2.DataSource = null;
                guna2DataGridView2.DataSource = Variable.trackexpiry;

                // Optional: Format columns if needed
                if (guna2DataGridView2.Columns.Count > 0)
                {
                    guna2DataGridView2.Columns["Expiry Date"].DefaultCellStyle.Format = "d";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading expiry data: {ex.Message}");
            }
        }
        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTrackExpiryFilter();
        }

        private void txtcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTrackExpiryFilter();
        }

        private void guna2TabControl1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
