using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Helper
{
    public class Variable
    {
        public static string uname, password, email, role, categoryname, varianttype, strid, currentuser, currentrole;
        public static int variantid = 0;
        public static DataTable dt = new DataTable(), adminlist = new DataTable(), superadminlist = new DataTable(), stafflist = new DataTable();
        public static bool bolsuccess = false;
    }
}
