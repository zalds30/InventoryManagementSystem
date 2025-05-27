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
    public partial class Supplier : Form
    {
        DBHelper con = new DBHelper();
        public Supplier()
        {
            InitializeComponent();
        }

        private void gnbtnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void gnbtnSave_Click(object sender, EventArgs e)
        {
            Variable.compannyname = gbtxtCompany.Text.Trim();
            Variable.businesstype = gnbtnBusiness.Text.Trim();
            Variable.address = gnbtnAddress.Text.Trim();
            Variable.phone = gnbtnPhoneNo.Text.Trim();
            DBHelper.Supplier("Insert");
        }
    }
}
