using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
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

        public bool FncConnectToDatabase()
        {
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

        public int FncGetTotalRecords()
        {
            return this.datStoreMgr.Rows.Count;
        }

        public void ClearData()
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

    }
}
