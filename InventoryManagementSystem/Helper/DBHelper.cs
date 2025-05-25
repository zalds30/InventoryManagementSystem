using InventoryManagementSystem.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace InventoryManagementSystem
{
     class DBHelper
    {
        public static string connectionString;
        public static ComboBox cmb = new ComboBox();
        public DBHelper()
        {
            string connection_String = "Server=localhost\\SQLEXPRESS;Database=InventoryDB;Integrated Security=True;";
            connectionString = connection_String;
        }

        public static void User(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                if (operation == "Insert")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Users (Username, Password, Email, Role) VALUES (@Username, @Password, @Email, @Role)", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", Variable.uname);
                        cmd.Parameters.AddWithValue("@Password", Variable.password);
                        cmd.Parameters.AddWithValue("@Role", Variable.role);
                        cmd.Parameters.AddWithValue("@Email", Variable.email);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User registered successfully");
                        }
                    }
                }
                if (operation == "Login")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", Variable.uname);
                        cmd.Parameters.AddWithValue("@Password", Variable.password);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Variable.role = reader["Role"].ToString();
                            MessageBox.Show("Login successful. Role: " + Variable.role);
                            Variable.bolsuccess = true;
                            Variable.currentuser = Variable.uname;
                            Variable.currentrole = Variable.role;
                        }
                        else
                        {
                            MessageBox.Show("Wrong Credentials!");
                        }
                    }
                }
                if (operation == "LoadRecordsAdmin")
                {
                    Variable.adminlist.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, Username AS [Name], Email, Role FROM Users where role = 'Admin'", con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.adminlist);
                    }
                }
                if (operation == "LoadRecordsSuperAdmin")
                {
                    Variable.superadminlist.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, Username AS [Name], Email, Role FROM Users where role = 'Super Admin'", con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.superadminlist);
                    }
                }
                if (operation == "LoadRecordsStaff")
                {
                    Variable.stafflist.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, Username AS [Name], Email, Role FROM Users where role = 'Staff'", con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.stafflist);
                    }
                }
            }
        }
        public static void Categories(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (operation == "Insert")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Categories (CategoryName, Variant) VALUES (@CategoryName, @Variant)", con))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", Variable.categoryname);
                        cmd.Parameters.AddWithValue("@Variant", Variable.variantid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully");
                        }
                    }
                }
                if (operation == "Delete")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Categories WHERE CategoryID = @CategoryID", con))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", Variable.strid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category deleted successfully");
                        }
                    }
                }
                if (operation == "LoadRecords")
                {
                    Variable.dt.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT CategoryID, CategoryName AS [Name], 
                            CASE 
                                WHEN Variant = 0 THEN ''
                                WHEN Variant = 1 THEN 'White Shelled'
                                WHEN Variant = 2 THEN 'Brown Shelled'
                                ELSE CAST(Variant AS VARCHAR(10))
                            END AS [Variant]
                          FROM Categories", con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.dt);
                    }
                }
                if (operation == "GetRecords")
                {
                    cmb.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT CategoryName FROM Categories", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmb.Items.Add(reader["CategoryName"].ToString());
                        }
                    }
                }




            }
        }




    }
}
