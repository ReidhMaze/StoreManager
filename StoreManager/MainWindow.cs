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
using StoreManager.Database;
using StoreManager.CustomComponentsLinker;
using CustomComponents;
using System.Data.Common;
using System.Text.RegularExpressions;
using LaundrySystem;

namespace StoreManager
{

    public partial class MainWindow : Form
    {

        private int currentPage = 1;

        private DBConnect dbConnection = new DBConnect();
        private GlobalProcedure globalProcedure = new GlobalProcedure();

        private ProductsAndOrdersLinker productsAndOrdersLinker;
        private UsrCtrlCashiering buyView;
        private UsrCtrlInventory2Resize inventoryView;
        private UsrCtrlAnalytics analyticsView;

        public MainWindow()
        {
            //DBConnect dbConnection = new DBConnect();
            InitializeComponent();
            //this.BtnCashier.Togg;

            //this.PnlProductsPanel.InitializeDisplay(dbConnection.GetItemList(), BtnPdpClicked);
            //this.productsAndOrdersLinker = new ProductsAndOrdersLinker(this.PnlOrdersPanel, this.PnlProductsPanel);
            //this.PnlProductsPanel.PanelSizeUpdated();
            this.globalProcedure.FncConnectToDatabase();
            this.buyView = new UsrCtrlCashiering(this.dbConnection, globalProcedure);
            this.inventoryView = new UsrCtrlInventory2Resize(this.dbConnection);
            this.analyticsView = new UsrCtrlAnalytics(this.dbConnection, globalProcedure);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            buyView.Size = this.PnlContent.Size;
            inventoryView.Size = this.PnlContent.Size;
            analyticsView.Size = this.PnlContent.Size;
            buyView.InitializeCardView();
            buyView.CenterPagination();
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
    }
}
