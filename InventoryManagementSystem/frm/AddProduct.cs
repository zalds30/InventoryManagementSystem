using InventoryManagementSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static InventoryManagementSystem.DBHelper;

namespace InventoryManagementSystem.frm
{
    public partial class AddProduct : Form
    {
        DBHelper con = new DBHelper();

        public AddProduct()
        {
            InitializeComponent();

            dgAddProducts.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgAddProducts.IsCurrentCellDirty)
                {
                    dgAddProducts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            dgAddProducts.AllowUserToAddRows = true;
            dgAddProducts.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            dgAddProducts.Columns.Add("Column2", "Name");

            DataGridViewComboBoxColumn categoryCol = new DataGridViewComboBoxColumn
            {
                HeaderText = "Category",
                Name = "Column3",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat,
                DisplayMember = "CategoryName",  // Property to display
                ValueMember = "CategoryName",    // Property to use as value
                DataPropertyName = "Column3"     // Links to the underlying data
            };
            dgAddProducts.Columns.Add(categoryCol);

            dgAddProducts.Columns.Add("Column4", "Variant");
            dgAddProducts.Columns.Add("Column5", "SRP");
            dgAddProducts.Columns.Add("Column6", "UNIT");
            dgAddProducts.Columns.Add("Column7", "Bulk Price");
            dgAddProducts.Columns.Add("Column8", "Critical Level");
            dgAddProducts.Columns.Add("Column9", "Expiry Date [mm/dd/yyyy]");
            dgAddProducts.Columns.Add("Column10", "Batch Number");
            dgAddProducts.Columns.Add("Column11", "Current Stock");

            DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn
            {
                HeaderText = "Status",
                Name = "Column12",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat
            };

            statusCol.Items.Add("Active");
            statusCol.Items.Add("Inactive");

            dgAddProducts.Columns.Add(statusCol);

            LoadCategoriesToComboBox();

            dgAddProducts.CellValueChanged += dgAddProducts_CellValueChanged;

            dgAddProducts.Columns["Column10"].Visible = false;
            dgAddProducts.Columns["Column11"].Visible = false;

            
        }

        private void LoadCategoriesToComboBox()
        {
            try
            {
                DBHelper.Categories("GetCategoryAndVariants");

                DataGridViewComboBoxColumn categoryCol = (DataGridViewComboBoxColumn)dgAddProducts.Columns["Column3"];
                categoryCol.DataSource = null;

                // Convert DBHelper.cmb.Items to a List<CategoryItem>
                var categoryList = new List<CategoryItem>();
                foreach (var item in DBHelper.cmb.Items)
                {
                    // Ensure we're adding CategoryItem objects, not strings
                    if (item is CategoryItem categoryItem)
                    {
                        categoryList.Add(categoryItem);
                    }
                }

                categoryCol.DataSource = categoryList;
                categoryCol.DisplayMember = "CategoryName";
                categoryCol.ValueMember = "CategoryName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgAddProducts.EndEdit();
        }

        private void dgAddProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgAddProducts.Columns["Column3"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dgAddProducts.Rows[e.RowIndex];
                var categoryCell = selectedRow.Cells["Column3"];
                var variantCell = selectedRow.Cells["Column4"];

                if (categoryCell.Value != null)
                {
                    try
                    {
                        string categoryName;
                        string variantValue;

                        // Handle both cases where Value might be the object or just the string
                        if (categoryCell.Value is CategoryItem categoryItem)
                        {
                            categoryName = categoryItem.CategoryName;
                            variantValue = categoryItem.Variant;
                        }
                        else
                        {
                            categoryName = categoryCell.Value.ToString();
                            // Find the corresponding variant in the data source
                            var comboBoxColumn = (DataGridViewComboBoxColumn)dgAddProducts.Columns["Column3"];
                            var matchingItem = comboBoxColumn.Items.OfType<CategoryItem>()
                                .FirstOrDefault(item => item.CategoryName == categoryName);
                            variantValue = matchingItem?.Variant ?? string.Empty;
                        }

                        categoryCell.Value = categoryName;
                        variantCell.Value = variantValue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error setting variant: " + ex.Message);
                    }
                }
            }
        }

        private void gnbtnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAddProducts.Rows)
            {
                if (!row.IsNewRow && row.Cells["Column2"].Value != null)
                {
                    try
                    {
                        // Get values from grid with validation
                        Variable.productname = row.Cells["Column2"].Value?.ToString();                  
                        Variable.categoryname = row.Cells["Column3"].FormattedValue?.ToString();
                        Variable.varianttype = row.Cells["Column4"].FormattedValue?.ToString();
                        // Validate and convert SRP (Column5)
                        if (row.Cells["Column5"].Value != null)
                        {
                            if (!decimal.TryParse(row.Cells["Column5"].Value.ToString(), out decimal srpValue))
                            {
                                MessageBox.Show($"Invalid SRP format in row {row.Index + 1}. Please enter a valid decimal number.");
                                return;
                            }
                            Variable.srp = srpValue;
                        }

                        // Validate and convert UNIT (Column6)
                        if (row.Cells["Column6"].Value != null)
                        {
                            if (!int.TryParse(row.Cells["Column6"].Value.ToString(), out int unitValue))
                            {
                                MessageBox.Show($"Invalid UNIT format in row {row.Index + 1}. Please enter a valid whole number.");
                                return;
                            }
                            Variable.unit = unitValue;
                        }

                        // Validate and convert Bulk Price (Column7)
                        if (row.Cells["Column7"].Value != null)
                        {
                            if (!decimal.TryParse(row.Cells["Column7"].Value.ToString(), out decimal bulkPriceValue))
                            {
                                MessageBox.Show($"Invalid Bulk Price format in row {row.Index + 1}. Please enter a valid decimal number.");
                                return;
                            }
                            Variable.bulkprice = bulkPriceValue;
                        }

                        Variable.criticallevel = Convert.ToInt32(row.Cells["Column8"].Value?.ToString());

                        // Validate and convert Expiry Date (Column9)
                        if (row.Cells["Column9"].Value != null)
                        {
                            if (!DateTime.TryParse(row.Cells["Column9"].Value.ToString(), out DateTime expiryDateValue))
                            {
                                MessageBox.Show($"Invalid Expiry Date format in row {row.Index + 1}. Please enter a valid date (MM/dd/yyyy).");
                                return;
                            }
                            Variable.exprydate = expiryDateValue;
                        }

                        string statusValue = row.Cells["Column12"].Value?.ToString();
                        if(statusValue == "Active")
                        {
                            Variable.status = true;
                        }
                        else
                        {
                            Variable.status = false;
                        }

                        DBHelper.Product("Insert");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error in row {row.Index + 1}: {ex.Message}");
                        return;
                    }
                }
            }
            if (Variable.bolsuccess == true)
            {
                MessageBox.Show("Products saved successfully!");
                Variable.bolsuccess = false;
            }
        }

        private void gnbtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}