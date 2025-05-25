using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    public interface IDBHelper
    {
        DataTable ExecuteQuery(string query, params SqlParameter[] parameters);
        int ExecuteNonQuery(string query, params SqlParameter[] parameters);
        object ExecuteScalar(string query, params SqlParameter[] parameters);
        SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters);
    }
}
