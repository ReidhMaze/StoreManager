using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreManager.CustomComponentsLinker;
using CustomComponents;
using System.Data.Common;
using System.Text.RegularExpressions;
using StoreManagerDb;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace StoreManager
{

    public partial class FormMainWindow : Form
    {

        private int currentPage = 1;

        private GlobalProcedure globalProcedure = new GlobalProcedure();

        private ProductsAndOrdersLinker productsAndOrdersLinker;
        private UsrCtrlCashiering buyView;
        private UsrCtrlInventory inventoryView;
        private UsrCtrlAnalytics analyticsView;
        private UsrCtrlStaff staffView;
        private int windowWidth = int.Parse(ConfigurationManager.AppSettings["width"].ToString());
        private int windowHeight = int.Parse(ConfigurationManager.AppSettings["height"].ToString());
        private bool openInFullScreen = bool.Parse(ConfigurationManager.AppSettings["open_in_fullscreen"].ToString());
        private string loggedStaffRole = "Admin";

        public FormMainWindow()
        {

            //DBConnect dbConnection = new DBConnect();
            InitializeComponent();
            //this.BtnCashier.Togg;

            //this.PnlProductsPanel.InitializeDisplay(dbConnection.GetItemList(), BtnPdpClicked);
            //this.productsAndOrdersLinker = new ProductsAndOrdersLinker(this.PnlOrdersPanel, this.PnlProductsPanel);
            //this.PnlProductsPanel.PanelSizeUpdated();
            this.globalProcedure.FncConnectToDatabase();
            this.buyView = new UsrCtrlCashiering(globalProcedure);
            this.inventoryView = new UsrCtrlInventory(globalProcedure);
            this.analyticsView = new UsrCtrlAnalytics(globalProcedure);
            this.staffView = new UsrCtrlStaff(globalProcedure);

            this.Size = new Size(windowWidth, windowHeight);
            this.WindowState = (openInFullScreen) ? FormWindowState.Maximized : FormWindowState.Normal;
            this.loggedStaffRole = globalProcedure.LoggedStaffRole;

            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            buyView.Size = this.PnlContent.Size;
            inventoryView.Size = this.PnlContent.Size;
            analyticsView.Size = this.PnlContent.Size;
            staffView.Size = this.PnlContent.Size;
            buyView.InitializeCardView();
            buyView.CenterPagination();

            this.BtnSettings.Visible = false;

            if (loggedStaffRole == "Cashier")
            {
                this.BtnInventory.Enabled = false;
                this.BtnAnalytics.Enabled = false;
                this.BtnStaff.Enabled = false;
                ShowUserCtrl(buyView);
            }
            else if (loggedStaffRole == "Inventory Manager")
            {
                this.BtnCashier.Enabled = false;
                this.BtnAnalytics.Enabled = false;
                this.BtnStaff.Enabled = false;
                ShowUserCtrl(inventoryView);
            }
            else
            {
                ShowUserCtrl(buyView);
                this.BtnSettings.Visible = true;
                this.BtnCashier.Enabled = true;
                this.BtnAnalytics.Enabled = true;
                this.BtnStaff.Enabled = true;
            }
        }


        private void TbPosSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^a-zA-Z0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void BtnPos_Click(object sender, EventArgs e)
        {
            //Panel contentPanel = this.Controls.Find("PnlContent", true)[0] as Panel;
            //this.PnlContent.Controls.Add(buyView);
            if (inventoryView.Updated)
            {
                buyView.InitializeCardView();
                inventoryView.Updated = false;
            }
            ShowUserCtrl(buyView);
        }

        private void ShowUserCtrl(UserControl userControl)
        {
            this.PnlContent.Controls.Clear();
            this.PnlContent.Controls.Add(userControl);
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            ShowUserCtrl(inventoryView);
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            ShowUserCtrl(analyticsView);
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            ShowUserCtrl(staffView);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Form settings = new FormSettings();
            settings.ShowDialog();
            this.buyView.UpdateTax();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
