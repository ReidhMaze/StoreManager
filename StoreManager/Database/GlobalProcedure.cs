using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using CustomComponents;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using ReaLTaiizor.Util;
using StoreObjects;

namespace LaundrySystem
{
    public class GlobalProcedure
    {
        public string servername;
        public string databasename;
        public string username;
        public string password;
        public string port;

        public MySqlConnection conLaundry;
        public MySqlCommand sqlCommand;
        public string strConnection;

        // packages and classes
        public MySqlDataAdapter sqlAdapter;
        public DataTable datStoreMgr;

        private int v_logged_staff_id = 1;

        public int LoggedStaffId { get { return v_logged_staff_id; }  }
        public bool EnableDebugging {  get; set; }

        public bool FncConnectToDatabase()
        {

            this.EnableDebugging = true;

            try
            {
                servername = "localhost";
                databasename = "store_manager_db";
                username = "root";
                password = "android52romance";
                port = "3307";

                strConnection = "Server=" + servername + ";" +
                    "Database=" + databasename + ";" +
                    "User=" + username + ";" +
                    "Password=" + password + ";" +
                    "Port=" + port + ";" +
                    "Convert Zero Datetime=true";

                conLaundry = new MySqlConnection(strConnection);
                sqlCommand = new MySqlCommand(strConnection, conLaundry);
                //Debug.WriteLine("db connected");
                if (conLaundry.State == ConnectionState.Closed)
                {
                    sqlCommand.Connection = conLaundry;
                    conLaundry.Open();
                    return true;
                }
                else
                {
                    conLaundry.Close();
                    return false;
                }
            }catch (Exception err)
            {
                MessageBox.Show("Error Message" + err.Message);
            }
            return false;
        }

        private int FncGetTotalRecords()
        {
            return this.datStoreMgr.Rows.Count;
        }

        private void ClearData()
        {
            this.sqlAdapter.Dispose();
            this.datStoreMgr.Dispose();
        }

        public List<Item> FncGetProducts()
        {

            List<Item> list = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_all_prod_cashier";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();

                    while (!(totalRecords - 1 < row))
                    {

                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        string imgLocation = dataTable.Rows[row]["img_name"].ToString();

                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, imgLocation);
                        list.Add(item);

                        row++;
                    }

                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;

        }

        public bool FncItemExists(string p_itemName, double p_price, double p_costPerItem, string p_size, string p_type, string p_supplier_name)
        {
            bool exists = false;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_item_exists";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_itemName);
                gProcCmd.Parameters.AddWithValue("@p_price", p_price);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_costPerItem);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute and get result
                int result = Convert.ToInt32(gProcCmd.ExecuteScalar());

                // If the count is greater than 0, the item exists
                exists = (result > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return exists;
        }


        public List<Item> FncGetItems()
        {
            List<Item> list = new List<Item>();

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proce_select_all_items"; // Updated procedure name
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                if (this.datStoreMgr.Rows.Count > 0)
                {
                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = dataTable.Rows.Count;

                    while (row < totalRecords)
                    {
                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        int restockThreshold = int.Parse(dataTable.Rows[row]["restock_threshold"].ToString());
                        string supplierName = dataTable.Rows[row]["supplier_name"].ToString();
                        string imgLocation = dataTable.Rows[row]["img_name"].ToString();

                        // Use the constructor with the correct parameters
                        Item item = new Item(id, itemCode, itemName, price, costPerItem, size, type, currentStocks, restockThreshold, supplierName, imgLocation);
                        list.Add(item);

                        row++;
                    }
                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }


        public string[] FncGetDistinctSizes()
        {

            string[] sizes = null;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_select_distinct_sizes";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                

                

                if (this.datStoreMgr.Rows.Count > 0)
                {

                    DataTable dataTable = this.datStoreMgr;
                    int row = 0;
                    int totalRecords = FncGetTotalRecords();
                    sizes = new string[totalRecords];

                    while (!(totalRecords - 1 < row))
                    {

                        sizes[row] = dataTable.Rows[row]["size"].ToString();

                        row++;
                    }

                }
                else
                {
                    MessageBox.Show("No data");
                }

                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return sizes;

        }

        private int FncGetLatestOrderId()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_order_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return int.Parse(dataTable.Rows[0]["id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
        }

        private void ProcAddOrder()
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int v_tax_rate_id = FncGetLatestTaxRateId();

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_order";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                gProcCmd.Parameters.AddWithValue("@p_tax_rate_id", v_tax_rate_id);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", this.v_logged_staff_id);
                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcAddOrderProduct(int p_order_id, int p_product_id, int p_quantity, double p_cost_per_item, double p_price_per_item)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_order_product";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_order_id", p_order_id);
                gProcCmd.Parameters.AddWithValue("@p_product_id", p_product_id);
                gProcCmd.Parameters.AddWithValue("@p_quantity", p_quantity);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_price_per_item", p_price_per_item);

                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ProcAddItem(string p_item_name, string p_size, string p_type, double p_price, double p_cost_per_item, string p_img_name, string p_supplier, int p_restock_threshold)
        {
            int v_type_id;
            int v_supplier_id = -1;
            int v_item_id;

            v_type_id = FncGetTypeId(p_type);

            if(FncItemExists(p_item_name, p_price, p_cost_per_item, p_size, p_type, p_supplier))
            {
                MessageBox.Show("Item already exists\nCanceling new product");
                return;
            }

            if(!FncSupplierExists(p_supplier)) 
            {
                ProcAddSupplier(p_supplier);
            }

            v_supplier_id = FncGetSupplierId(p_supplier);

            ProcAddItemToInventory(p_item_name, p_size, v_type_id, p_cost_per_item, p_img_name, v_supplier_id, p_restock_threshold);

            v_item_id = FncGetLatestItemId();
            
            ProcAddProduct(v_item_id, p_price);

        }

        private void ProcAddItemToInventory(string p_item_name, string p_size, int p_type_id, double p_cost_per_item, string p_img_name, int p_supplier_id, int p_restock_threshold)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_item";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                gProcCmd.Parameters.AddWithValue("@p_item_name", p_item_name);
                gProcCmd.Parameters.AddWithValue("@p_size", p_size);
                gProcCmd.Parameters.AddWithValue("@p_type_id", p_type_id);
                gProcCmd.Parameters.AddWithValue("@p_cost_per_item", p_cost_per_item);
                gProcCmd.Parameters.AddWithValue("@p_img_name", p_img_name);
                gProcCmd.Parameters.AddWithValue("@p_supplier_id", p_supplier_id);
                gProcCmd.Parameters.AddWithValue("@p_restock_threshold", p_restock_threshold);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Item added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private void ProcAddProduct(int p_inventory_id, double p_price)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_product";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                gProcCmd.Parameters.AddWithValue("@p_inventory_id", p_inventory_id);
                gProcCmd.Parameters.AddWithValue("@p_price", p_price);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Product added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private void ProcAddSupplier(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_supplier";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the stored procedure
                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging)
                    MessageBox.Show("Supplier added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }
        }

        private bool FncSupplierExists(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            bool supplierExists = false;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_supplier_exists";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add input parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int exists = Convert.ToInt32(result);
                    supplierExists = (exists == 1);  // If 1, supplier exists
                }

                if (EnableDebugging)
                    MessageBox.Show("Supplier exists: " + supplierExists);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return supplierExists;
        }


        private int FncGetSupplierId(string p_supplier_name)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int supplierId = 0;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_supplier_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add parameter for supplier name
                gProcCmd.Parameters.AddWithValue("@p_supplier_name", p_supplier_name);

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    supplierId = Convert.ToInt32(result);
                }

                if (EnableDebugging)
                    MessageBox.Show("Supplier ID: " + supplierId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return supplierId;
        }

        private int FncGetTypeId(string p_type)
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int typeId = -1;  // Default value in case the type is not found

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_type_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Add input parameter for product type
                gProcCmd.Parameters.AddWithValue("@p_type", p_type);

                // Execute the stored procedure and get the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    typeId = Convert.ToInt32(result);  // Assign the returned id to typeId
                }

                if (EnableDebugging)
                    MessageBox.Show("Type ID: " + typeId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return typeId;  // Return the retrieved type ID or -1 if not found
        }


        private int FncGetLatestItemId()
        {
            MySqlCommand gProcCmd = this.sqlCommand;
            int latestItemId = 0;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_item_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                // Execute the command and retrieve the result
                object result = gProcCmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    latestItemId = Convert.ToInt32(result);
                }

                if (EnableDebugging)
                    MessageBox.Show("Latest Item ID: " + latestItemId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Display the exception message for debugging
            }

            return latestItemId;
        }

        private int FncGetLatestTaxRateId()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_tax_rate_id";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return int.Parse(dataTable.Rows[0]["id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
        }

        private void ProcInitializeOrderTotal(int p_order_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_init_order_total";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_id", p_order_id);

                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order failed to update");
            }
        }

        public void ProcCheckout(List<CartItem> cartItems)
        {
            int v_order_id;

            ProcAddOrder();

            v_order_id = FncGetLatestOrderId();

            for(int i = 0; i < cartItems.Count; i++)
            {
                CartItem cartItem = cartItems[i];
                int v_item_code = cartItems[i].ItemCode;
                int v_product_id = cartItem.Id;
                int v_quantity = cartItem.Qty;
                double v_cost_per_item = cartItem.CostPerItem;
                double v_price_per_item = cartItem.Price;

                ProcAddOrderProduct(v_order_id, v_product_id, v_quantity, v_cost_per_item, v_price_per_item);
                ProcDecreaseItemStock(v_item_code, v_order_id, v_quantity, v_logged_staff_id);
            }

            ProcInitializeOrderTotal(v_order_id);

            //TODO add init order proc
        }

        private void ProcDecreaseItemStock(int p_item_code, int p_order_id, int p_qty_removed, int staff_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_removed";
                gProcCmd.CommandType = CommandType.StoredProcedure;

                gProcCmd.Parameters.AddWithValue("@p_item_code", p_item_code);
                gProcCmd.Parameters.AddWithValue("@p_order_id", p_order_id);
                gProcCmd.Parameters.AddWithValue("@p_qty_removed", p_qty_removed);
                gProcCmd.Parameters.AddWithValue("@p_staff_id", staff_id);

                gProcCmd.ExecuteNonQuery();

                if (EnableDebugging) MessageBox.Show("Item removed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcDecreaseItemStock(int p_item_id, int p_qty_removed, int staff_id)
        {
            MySqlCommand gProcCmd = this.sqlCommand;

            try
            {
                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_add_inventory_removed";
                gProcCmd.CommandType = CommandType.StoredProcedure;


                gProcCmd.ExecuteNonQuery();
                if (EnableDebugging) MessageBox.Show("Order saved successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public double FncGetLatestTaxRate()
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_latest_tax_rate";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();

                return double.Parse(dataTable.Rows[0]["rate"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0;
            }
        }

        public double FncTotalSales()
        {
            
            
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();


                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_sales";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();





                return double.Parse(dataTable.Rows[0]["total_sales"].ToString()); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0.0;
            }
            
        }
        public int FncTotalOrder()
        {
           

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();


                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_total_order";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);


                DataTable dataTable = this.datStoreMgr;

                ClearData();
                    


                 

                return Int32.Parse(dataTable.Rows[0]["order_id"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public void productSold()
        {

        }
        public void totalCustomer()
        {

        }
       /* public void productSold()
        {

        }*/
        public void totalIncome()
        {

        }

        public void ProcAddCmbProductSoldItems(ComboBox cmb)
        {
            int rowCount = 0;
            int row = 0;

            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_item_name";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count > 0)
                {
                     rowCount = dataTable.Rows.Count;
                    while (dataTable.Rows.Count - 1 < rowCount)
                    {

                        cmb.Items.Add(dataTable.Rows[row]["item_name"].ToString());
                         

                        row++;
                    }
                }
                
            }
            catch (Exception ex)
            {
               
            }
        }

        public void ProcGetProductSoldCount(string itemName, BunifuLabel lbl)
        {
            try
            {
                MySqlCommand gProcCmd = this.sqlCommand;

                this.sqlAdapter = new MySqlDataAdapter();
                this.datStoreMgr = new DataTable();

                gProcCmd.Parameters.Clear();
                gProcCmd.CommandText = "proc_get_product_order_count";
                gProcCmd.CommandType = CommandType.StoredProcedure;
                this.sqlAdapter.SelectCommand = this.sqlCommand;
                gProcCmd.Parameters.AddWithValue("@p_name", itemName);
                this.datStoreMgr.Clear();
                this.sqlAdapter.Fill(this.datStoreMgr);

                DataTable dataTable = this.datStoreMgr;
                if (dataTable.Rows.Count <= 0)
                {
                    lbl.Text = "0";
                }
                else
                {
                    lbl.Text = dataTable.Rows[0]["orders"].ToString();
                }
               

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
