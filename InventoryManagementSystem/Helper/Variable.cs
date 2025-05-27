using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace InventoryManagementSystem.Helper
{
    public class Variable
    {
        public static string uname, password, email, role, categoryname, varianttype, 
            strid, currentuser, currentrole, productname, strsearch, itemcode, address, phone, businesstype,
            compannyname, strbatchnumber;
        public static int variantid = 0, unit, iswitch = 0, qty, supplierid, productid, userid, currentstock, criticallevel, itotalproduct;
        public static DataTable dt = new DataTable(), adminlist = new DataTable(), superadminlist = new DataTable(), 
            stafflist = new DataTable(), product = new DataTable(), stockcarddata = new DataTable(), 
            trackexpiry = new DataTable(), category = new DataTable();
        public static decimal srp, bulkprice;
        public static DateTime date, exprydate;
        public static bool bolsuccess = false, status;
        public static System.Windows.Forms.ListBox cmb = new System.Windows.Forms.ListBox();
    }
}
