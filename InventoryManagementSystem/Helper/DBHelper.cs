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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
namespace InventoryManagementSystem
{
    class DBHelper
    {
        public static string connectionString;
        public static ComboBox cmb = new ComboBox();
        public static string qry = string.Empty;
        public DBHelper()
        {
            string connection_String = "Server=localhost\\SQLEXPRESS;Database=InventoryPOSDB;Integrated Security=True;";
            connectionString = connection_String;
        }

        public class CategoryItem
        {
            public string CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Variant { get; set; }
            public string OriginalVariant { get; set; }
        }
        public class SupplierItem
        {
            public int SupplierID { get; set; }
            public string CompanyName { get; set; }
        }
        public class ProductItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public int CriticalLevel { get; set; }
            public override string ToString()
            {
                double percentage = CriticalLevel > 0 ? (Quantity * 100.0 / CriticalLevel) : 0;
                return $"{ProductName} - {Quantity} left ({percentage:0}% of critical)";
            }
        }
        public class LogEntry
        {
            public int LogID { get; set; }
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Action { get; set; }
            public string Details { get; set; }
            public DateTime Timestamp { get; set; }
            public string FormattedMessage { get; set; }
        }
        public class FastMovingProduct
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int TotalSold { get; set; }
            public int CurrentStock { get; set; }

            public override string ToString()
            {
                return $"{ProductName} - Sold: {TotalSold} (Stock: {CurrentStock})";
            }
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
                          //  LogAction(Variable.userid, "User Registration", $"New user created: {Variable.uname}");
                        }
                    }
                }
                if (operation == "Login")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT Role, UserID FROM Users WHERE Username = @Username AND Password = @Password", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", Variable.uname);
                        cmd.Parameters.AddWithValue("@Password", Variable.password);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Variable.role = reader["Role"].ToString();
                            Variable.userid = Convert.ToInt32(reader["UserID"]);
                            MessageBox.Show("Login successful. Role: " + Variable.role);
                            Variable.bolsuccess = true;
                            Variable.currentuser = Variable.uname;
                            Variable.currentrole = Variable.role;

                            LogAction(Variable.userid, "User Login",
                                $"User {Variable.uname}");
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

                    switch (Variable.iswitch)
                    {
                        case 1:
                            qry = @"SELECT CategoryID, CategoryName AS [Name], 
                            CASE 
                                WHEN Variant = 0 THEN ''
                                WHEN Variant = 1 THEN 'White Shelled'
                                WHEN Variant = 2 THEN 'Brown Shelled'
                                WHEN Variant = 3 THEN 'N/A'
                                ELSE CAST(Variant AS VARCHAR(10))
                            END AS [Variant]
                          FROM Categories where CategoryName like '%" + Variable.strsearch + "' ";
                            break;
                        default:
                            qry = @"SELECT CategoryID, CategoryName AS [Name], 
                            CASE 
                                WHEN Variant = 0 THEN ''
                                WHEN Variant = 1 THEN 'White Shelled'
                                WHEN Variant = 2 THEN 'Brown Shelled'
                                WHEN Variant = 3 THEN 'N/A'
                                ELSE CAST(Variant AS VARCHAR(10))
                            END AS [Variant]
                          FROM Categories";
                            break;
                    }
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.dt);
                    }
                }
                if (operation == "GetRecords")
                {
                    cmb.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT CategoryName, Variant FROM Categories", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmb.Items.Add(reader["CategoryName"].ToString());
                        }
                    }
                }
                if (operation == "GetCategoryAndVariants")
                {
                    cmb.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT CategoryID, CategoryName, Variant FROM Categories", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string variantValue = reader["Variant"].ToString();
                            string displayVariant = variantValue;

                            if (variantValue == "1") displayVariant = "White Shelled";
                            else if (variantValue == "2") displayVariant = "Brown Shelled";
                            else if (variantValue == "3") displayVariant = "N/A";

                            cmb.Items.Add(new CategoryItem
                            {
                                CategoryID = reader["CategoryID"].ToString(),
                                CategoryName = reader["CategoryName"].ToString(),
                                Variant = displayVariant,
                                OriginalVariant = variantValue
                            });
                        }
                    }
                }
            }
        }
        public static string GenerateItemCode(string category, SqlConnection con)
        {
            string categoryPrefix = string.IsNullOrEmpty(category)
                ? "GEN"
                : category.ToUpper().Substring(0, Math.Min(3, category.Length));
            string query = $@"
        SELECT MAX(TRY_CAST(SUBSTRING(ItemCode, LEN('{categoryPrefix}-') + 1, LEN(ItemCode)) AS INT)) 
        FROM Product 
        WHERE ItemCode LIKE '{categoryPrefix}-%'";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                object result = cmd.ExecuteScalar();
                int lastSequence = (result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                return $"{categoryPrefix}-{(lastSequence + 1):D3}";
            }
        }

        public static void Product(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (operation == "Insert")
                {
                    // Now correctly calls the static method
                    string itemCode = GenerateItemCode(Variable.categoryname, con);

                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Product (Itemcode, Name, Category, Variant, SRP, UNIT, BulkPrice, Expiry, batchnumber, CriticalLevel, currentstock, status) " +
                        "VALUES (@Itemcode, @Name, @Category, @Variant, @SRP, @UNIT, @BulkPrice, @Expiry, @batchnumber, @CriticalLevel, @currentstock, @status)", con))
                    {
                        cmd.Parameters.AddWithValue("@Itemcode", itemCode);
                        cmd.Parameters.AddWithValue("@Name", Variable.productname);
                        cmd.Parameters.AddWithValue("@Category", Variable.categoryname);
                        cmd.Parameters.AddWithValue("@Variant", Variable.varianttype);
                        cmd.Parameters.AddWithValue("@SRP", Variable.srp);
                        cmd.Parameters.AddWithValue("@UNIT", Variable.unit);
                        cmd.Parameters.AddWithValue("@BulkPrice", Variable.bulkprice);

                        // Handle NULL expiration date
                        if (Variable.exprydate == DateTime.MinValue) // Or whatever default value you're using
                        {
                            cmd.Parameters.AddWithValue("@Expiry", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Expiry", Variable.exprydate);
                        }

                        cmd.Parameters.AddWithValue("@batchnumber", Variable.strbatchnumber = "");
                        cmd.Parameters.AddWithValue("@CriticalLevel", Variable.criticallevel);
                        cmd.Parameters.AddWithValue("@currentstock", Variable.currentstock = 0);
                        cmd.Parameters.AddWithValue("@status", Variable.status);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Variable.bolsuccess = true;
                        }
                    }
                }
                if (operation == "UpdateStock")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Product SET currentstock = @currentstock WHERE ProductID = @ProductID", con))
                    {
                        cmd.Parameters.AddWithValue("@currentstock", Variable.qty);
                        cmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock updated successfully");
                        }
                    }
                }
                if (operation == "UpdateExistingStockQTY")
                {
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            int currentStock = 0;
                            using (SqlCommand getCmd = new SqlCommand(
                                "SELECT currentstock FROM Product WHERE ProductID = @ProductID", con, transaction))
                            {
                                getCmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                                object result = getCmd.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                {
                                    currentStock = Convert.ToInt32(result);
                                }
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                "UPDATE Product SET currentstock = @currentstock WHERE ProductID = @ProductID", con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@currentstock", Variable.qty + currentStock);
                                cmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Stock updated successfully");
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("No rows affected. Update failed.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                if (operation == "LoadRecords")
                {
                    switch (Variable.iswitch)
                    {
                        case 1:
                            qry = @"SELECT ProductID, Itemcode AS [Item code], Name AS [Name], 
                            Category AS [Category], 
                            Variant AS [Variant], 
                            SRP AS [SRP], 
                            UNIT AS [UNIT], 
                            BulkPrice AS [Bulk Price], 
                            CriticalLevel AS [Critical Level] ,
                            Expiry AS [Expiry Date] ,
                            CurrentStock AS [Current Stock],
                            Status AS [Status]
                          FROM Product where Name like '%" + Variable.strsearch + "' ";
                            break;
                        default:
                            qry = @"SELECT ProductID, Itemcode AS [Item code], Name AS [Name], 
                            Category AS [Category], 
                            Variant AS [Variant], 
                            SRP AS [SRP], 
                            UNIT AS [UNIT], 
                            BulkPrice AS [Bulk Price], 
                            CriticalLevel AS [Critical Level] ,
                            Expiry AS [Expiry Date] ,
                            CurrentStock AS [Current Stock],
                            Status AS [Status]
                          FROM Product";
                            break;
                    }

                    Variable.product.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        qry, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(Variable.product);
                    }
                }
                if (operation == "Delete")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Product WHERE ProductID = @ProductID", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", Variable.strid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully");
                        }
                    }
                }
                if (operation == "GetRecords")
                {
                    cmb.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT ProductID, Name, Variant, currentstock FROM Product", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmb.Items.Add(new ProductItem
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["Name"].ToString(),
                                Quantity = Convert.ToInt32(reader["currentstock"].ToString())
                            });
                        }
                    }
                }
                if (operation == "CountTotalProducts")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Product", con))
                    {
                        int totalProducts = (int)cmd.ExecuteScalar();
                        Variable.itotalproduct = totalProducts;
                    }
                }
          
            }
        }

        public static List<LogEntry> GetLogs(int maxEntries = 100, DateTime? fromDate = null, string actionFilter = null)
        {
            var logs = new List<LogEntry>();

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    var query = @"
                SELECT TOP (@MaxEntries) 
                    l.LogID,
                    l.UserID,
                    l.Action,
                    l.Details,
                    l.LogDate,
                    u.Username
                    FROM Logs l
                    JOIN Users u ON l.UserID = u.UserID
                    WHERE 1=1";

                    if (fromDate.HasValue)
                        query += " AND l.LogDate >= @FromDate";

                    if (!string.IsNullOrEmpty(actionFilter))
                        query += " AND l.Action LIKE @ActionFilter";

                    query += " ORDER BY l.LogDate DESC";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@MaxEntries", maxEntries);

                        if (fromDate.HasValue)
                            cmd.Parameters.AddWithValue("@FromDate", fromDate.Value);

                        if (!string.IsNullOrEmpty(actionFilter))
                            cmd.Parameters.AddWithValue("@ActionFilter", $"%{actionFilter}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                logs.Add(new LogEntry
                                {
                                    LogID = Convert.ToInt32(reader["LogID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Username = reader["Username"].ToString(),
                                    Action = reader["Action"].ToString(),
                                    Details = reader["Details"].ToString(),
                                    Timestamp = Convert.ToDateTime(reader["LogDate"]),
                                    FormattedMessage = $"[{Convert.ToDateTime(reader["LogDate"]):yyyy-MM-dd HH:mm}] " +
                                                     $"{reader["Username"]} - " +
                                                     $"{reader["Action"]}: " +
                                                     $"{reader["Details"]}"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving logs: {ex.Message}");
            }

            return logs;
        }
        public static List<ProductItem> GetCriticalProducts()
        {
            var criticalProducts = new List<ProductItem>();

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                SELECT 
                    p.ProductID,
                    p.Name AS ProductName,
                    p.CurrentStock AS Quantity,
                    p.CriticalLevel,
                    CASE 
                        WHEN p.CriticalLevel = 0 THEN 0
                        ELSE (p.CurrentStock * 100.0 / p.CriticalLevel)
                    END AS CriticalPercentage
                FROM Product p
                WHERE p.CurrentStock <= p.CriticalLevel OR p.CurrentStock <= 5
                ORDER BY CriticalPercentage ASC";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                criticalProducts.Add(new ProductItem
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    CriticalLevel = Convert.ToInt32(reader["CriticalLevel"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogAction(0, "Error - GetCriticalProducts", ex.Message);
                Console.WriteLine($"Error retrieving critical products: {ex.Message}");
            }

            return criticalProducts;
        }
        public static List<FastMovingProduct> GetFastMovingProducts(int daysToAnalyze = 30, int topCount = 10)
        {
            var fastMovingProducts = new List<FastMovingProduct>();

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                SELECT TOP (@TopCount)
                    p.ProductID,
                    p.Name AS ProductName,
                    SUM(so.Quantity) AS TotalSold,
                    p.CurrentStock AS CurrentQuantity
                        FROM StockOut so
                        JOIN Product p ON so.ProductID = p.ProductID
                        WHERE so.DateOut >= DATEADD(day, -@DaysToAnalyze, GETDATE())
                        GROUP BY p.ProductID, p.Name, p.CurrentStock
                        ORDER BY TotalSold DESC";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@DaysToAnalyze", daysToAnalyze);
                        cmd.Parameters.AddWithValue("@TopCount", topCount);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fastMovingProducts.Add(new FastMovingProduct
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    TotalSold = Convert.ToInt32(reader["TotalSold"]),
                                    CurrentStock = Convert.ToInt32(reader["CurrentQuantity"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogAction(0, "Error - GetFastMovingProducts", ex.Message);
                Console.WriteLine($"Error retrieving fast-moving products: {ex.Message}");
            }

            return fastMovingProducts;
        }

 

        public  static void LogAction(int userid , string action, string details)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Logs (UserID, Action, Details, LogDate) VALUES (@UserID, @Action, @Details, @LogDate)", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Variable.userid);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@LogDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Supplier(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (operation == "Insert")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Suppliers  (CompannyName, BusinessType, Phone, Address) VALUES (@CompannyName, @BusinessType, @Phone, @Address)", con))
                    {
                        cmd.Parameters.AddWithValue("@CompannyName", Variable.compannyname);
                        cmd.Parameters.AddWithValue("@BusinessType", Variable.businesstype);
                        cmd.Parameters.AddWithValue("@Phone", Variable.phone);
                        cmd.Parameters.AddWithValue("@Address", Variable.address);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier added successfully");
                        }
                    }
                }
                if (operation == "GetRecords")
                {
                    cmb.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT SupplierID, CompannyName FROM Suppliers", con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmb.Items.Add(new SupplierItem
                            {
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                CompanyName = reader["CompannyName"].ToString()
                            });
                        }
                    }
                }
            }
        }
        public static void Stockin(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (operation == "Insert")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO StockIn (ProductID, SupplierID, Quantity, DateIn, UserID) VALUES (@ProductID, @SupplierID, @Quantity, @DateIn, @UserID)", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                        cmd.Parameters.AddWithValue("@SupplierID", Variable.supplierid);
                        cmd.Parameters.AddWithValue("@Quantity", Variable.qty);
                        cmd.Parameters.AddWithValue("@DateIn", Variable.date);
                        cmd.Parameters.AddWithValue("@UserID", Variable.userid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                           // MessageBox.Show("Stock in added successfully");
                        }
                    }
                }
        
            }
        }
        public static void Stockout(string operation)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                if (operation == "Insert")
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO StockOut (ProductID, SupplierID, Quantity, DateOut, UserID) VALUES (@ProductID, @SupplierID, @Quantity, @DateOut, @UserID)", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                        cmd.Parameters.AddWithValue("@SupplierID", Variable.supplierid);
                        cmd.Parameters.AddWithValue("@Quantity", Variable.qty);
                        cmd.Parameters.AddWithValue("@DateOut", Variable.date);
                        cmd.Parameters.AddWithValue("@UserID", Variable.userid);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                          //  MessageBox.Show("Stock out added successfully");
                        }
                    }
                }
            }
        }
        public static void StockCard()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                qry = @"
            WITH StockTransactions AS (
                -- Stock In transactions
                SELECT 
                    'IN' AS TransactionType,
                    si.StockInID AS TransactionID,
                    p.ProductID,
                    p.itemcode,
                    p.Name,
                    p.srp,
                    si.Quantity,
                    si.DateIn AS TransactionDate,
                    u.Username AS ProcessedBy
                FROM StockIn si
                INNER JOIN Product p ON si.ProductID = p.ProductID
                LEFT JOIN Users u ON si.UserID = u.UserID
                WHERE p.ProductID = @ProductID OR @ProductID = 0

                UNION ALL

                -- Stock Out transactions
                SELECT 
                    'OUT' AS TransactionType,
                    so.StockOutID AS TransactionID,
                    p.ProductID,
                    p.itemcode,
                    p.Name,
                    p.srp,
                    so.Quantity,
                    so.DateOut AS TransactionDate,
                    u.Username AS ProcessedBy
                FROM StockOut so
                INNER JOIN Product p ON so.ProductID = p.ProductID
                LEFT JOIN Users u ON so.UserID = u.UserID
                WHERE p.ProductID = @ProductID OR @ProductID = 0
            ),
            OrderedTransactions AS (
                SELECT 
                    *,
                    ROW_NUMBER() OVER (ORDER BY TransactionDate, TransactionType) AS RowNum
                FROM StockTransactions
            ),
            CalculatedBalances AS (
                SELECT 
                    t.*,
                    SUM(
                        CASE 
                            WHEN t.TransactionType = 'IN' THEN t.Quantity
                            ELSE -t.Quantity
                        END
                    ) OVER (
                        PARTITION BY t.ProductID
                        ORDER BY t.TransactionDate, t.TransactionType
                        ROWS UNBOUNDED PRECEDING
                    ) AS RunningBalance
                FROM OrderedTransactions t
            )
            SELECT 
                RowNum AS [No.],
                CONVERT(varchar, TransactionDate, 101) AS [Date],
                itemcode AS [Item Code],
                Name AS [Item Name],
                srp AS [Unit Price],
                CASE WHEN TransactionType = 'IN' THEN Quantity ELSE 0 END AS [In],
                CASE WHEN TransactionType = 'OUT' THEN Quantity ELSE 0 END AS [Out],
                RunningBalance AS [Balance],
                ProcessedBy AS [Processed By],
                CASE 
                    WHEN RunningBalance < 0 THEN 'Invalid'
                    ELSE 'Valid'
                END AS [Status]
            FROM CalculatedBalances
            ORDER BY TransactionDate, TransactionType";

                Variable.stockcarddata.Clear();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", Variable.productid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(Variable.stockcarddata);
                }
            }
        }
        public static void TrackExpiry(string category = "All", string status = "All")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                var queryBuilder = new StringBuilder(@"
            SELECT 
                p.ProductID, 
                p.Name, 
                p.Category,
                p.Variant,
                p.SRP,
                p.Expiry AS [Expiry Date],
                DATEDIFF(day, GETDATE(), p.Expiry) AS [Days Left],
                p.CurrentStock AS Quantity,
                CASE
                    WHEN p.Expiry IS NULL THEN 'Good'
                    WHEN p.Expiry < GETDATE() THEN 'Expired'
                    WHEN DATEDIFF(day, GETDATE(), p.Expiry) <= 30 THEN 'Expiry Soon'
                    ELSE 'Good'
                END AS Status
            FROM Product p
            WHERE p.Expiry IS NOT NULL"); // Only products with expiry dates

                // Add category filter if not "All"
                if (category != "All" && !string.IsNullOrEmpty(category))
                {
                    queryBuilder.Append(" AND p.Category = @Category");
                }

                // Add status filter if not "All"
                if (status != "All" && !string.IsNullOrEmpty(status))
                {
                    queryBuilder.Append(@"
                AND CASE
                    WHEN p.Expiry IS NULL THEN 'Good'
                    WHEN p.Expiry < GETDATE() THEN 'Expired'
                    WHEN DATEDIFF(day, GETDATE(), p.Expiry) <= 30 THEN 'Expiry Soon'
                    ELSE 'Good'
                END = @Status");
                }

                queryBuilder.Append(" ORDER BY p.Expiry ASC");

                using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con))
                {
                    if (category != "All" && !string.IsNullOrEmpty(category))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                    }

                    if (status != "All" && !string.IsNullOrEmpty(status))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                    }

                    Variable.trackexpiry.Clear();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Variable.trackexpiry = dt;
                    }
                }
            }
        }


    }
}
