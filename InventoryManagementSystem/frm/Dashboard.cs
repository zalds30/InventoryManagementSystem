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
namespace InventoryManagementSystem.frm
{
    public partial class Dashboard : Form
    {
        DBHelper con = new DBHelper();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void CenterLabelInPanel()
        {
            // Center horizontally and vertically
            lbltotalproducts.Left = (panel1.Width - lbltotalproducts.Width) / 2;
            lbltotalproducts.Top = (panel1.Height - lbltotalproducts.Height) / 2;

            // Or for multiple controls:
            foreach (Control control in panel1.Controls)
            {
                if (control is Label)
                {
                    control.Left = (panel1.Width - control.Width) / 2;
                    control.Top = (panel1.Height - control.Height) / 2;
                }
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DBHelper.Product("CountTotalProducts");
            lbltotalproducts.Text = Variable.itotalproduct.ToString();

            CenterLabelInPanel();

            // Load logs (last 50 entries)
            var logs = DBHelper.GetLogs(50);
            foreach (var log in logs)
            {
                lbLogs.Items.Add(log.FormattedMessage);
            }

            var criticalProducts = DBHelper.GetCriticalProducts();
            lbCriticalPoint.Items.Clear();
            foreach (var product in criticalProducts)
            {
                lbCriticalPoint.Items.Add($"{product.ProductName} (Stock: {product.Quantity})");
            }

            var fastMovingProducts = DBHelper.GetFastMovingProducts();
            lbFastMoving.Items.Clear();
            foreach (var product in fastMovingProducts)
            {
                lbFastMoving.Items.Add(product.ToString());
            }
        }
    }
}
