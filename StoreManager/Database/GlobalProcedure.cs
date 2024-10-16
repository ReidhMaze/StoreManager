using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                password = "bajed";
                port = "3306";

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
                        //this.GridCustomers.Rows[row].Cells[0].Value = dataTable.Rows[row]["id"].ToString();
                        //this.GridCustomers.Rows[row].Cells[1].Value = dataTable.Rows[row]["fullname"].ToString();
                        //this.GridCustomers.Rows[row].Cells[2].Value = DateTime.Parse(dataTable.Rows[row]["birthdate"].ToString()).Date;
                        //this.GridCustomers.Rows[row].Cells[3].Value = dataTable.Rows[row]["gender"].ToString();
                        //this.GridCustomers.Rows[row].Cells[4].Value = dataTable.Rows[row]["address"].ToString();
                        //this.GridCustomers.Rows[row].Cells[5].Value = dataTable.Rows[row]["contactno"].ToString();
                        //this.GridCustomers.Rows[row].Cells[6].Value = dataTable.Rows[row]["emailadd"].ToString();
                        //this.GridCustomers.Rows[row].Cells[7].Value = dataTable.Rows[row]["cust_photo"].ToString();

                        int id = int.Parse(dataTable.Rows[row]["id"].ToString());
                        int itemCode = int.Parse(dataTable.Rows[row]["item_code"].ToString());
                        string itemName = dataTable.Rows[row]["item_name"].ToString();
                        double price = double.Parse(dataTable.Rows[row]["price"].ToString());
                        double costPerItem = double.Parse(dataTable.Rows[row]["cost_per_item"].ToString());
                        string size = dataTable.Rows[row]["size"].ToString();
                        string type = dataTable.Rows[row]["type"].ToString();
                        int currentStocks = int.Parse(dataTable.Rows[row]["current_stocks"].ToString());
                        string imgLocation = dataTable.Rows[row]["img_location"].ToString();

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

    }
}
