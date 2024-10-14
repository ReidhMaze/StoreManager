using CustomComponents;
using LaundrySystem;
using StoreManager.CustomComponentsLinker;
using StoreManager.Database;
using StoreObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManager
{
    public partial class UsrCtrlCashiering : UserControl
    {

        private int currentPage = 1;
        private DBConnect dbConnection;
        private GlobalProcedure gProc;

        ProductsAndOrdersLinker productsAndOrdersLinker;

        public UsrCtrlCashiering(DBConnect dbConnection, GlobalProcedure gProc)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.gProc = gProc;
        }

        public void InitializeCardView()
        {
            Debug.WriteLine(this.PanelPOS.Size);
            this.PnlProductsPanel.InitializeItems(gProc.FncGetProducts(), this.BtnPdpClicked);
            this.PnlProductsPanel.InitializeCards();
            this.PnlProductsPanel.ArrangeProductPanels(currentPage);

            this.productsAndOrdersLinker = new ProductsAndOrdersLinker(this.PnlOrdersPanel, this.PnlProductsPanel);

            this.PnlOrdersPanel.InitializeCheckoutLabels(this.LblTotalOutput, this.LblTaxOutput, this.LblSubtotalOutput);
            this.CmbSizes.Items.AddRange(gProc.FncGetDistinctSizes());
            UpdatePaginationText();
        }

        public void BtnPdpClicked(object sender, EventArgs e)
        {
            ProductDisplayPanel PdpPressed = productsAndOrdersLinker.GetProdDisplayPanel(sender.GetHashCode());
            this.PnlOrdersPanel.AddOrder(PdpPressed.Item.ToCartItem());
            this.PnlOrdersPanel.UpdateCheckoutLabels();
            //this.PnlOrdersPanel.DisplayOrders();
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (PnlProductsPanel.IsOnLastPage()) return;
            this.currentPage += 1;
            this.PnlProductsPanel.ArrangeProductPanels(currentPage);
            UpdatePaginationText();
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage - 1 <= 0) return;
            this.currentPage -= 1;
            this.PnlProductsPanel.ArrangeProductPanels(currentPage);
            UpdatePaginationText();
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

        private void TbPosSearch_Enter(object sender, EventArgs e)
        {
            this.TbPosSearch.SelectAll();
        }

        public void CenterPagination()
        {
            int paginationWidth = this.PanelPagination.Width;
            int paginationContainerWidth = this.PanelPaginationContainer.Width;

            this.PanelPagination.Location = new Point(paginationContainerWidth/2 - paginationWidth/2, this.PanelPagination.Location.Y);
        }

        public void UpdatePaginationText()
        {
            int currentPage = this.PnlProductsPanel.Currentpage;
            int numOfPages = this.PnlProductsPanel.Lastpage;
            this.LblPaginationText.Text = currentPage + " of " + numOfPages;
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            //PnlOrdersPanel.displayOrders();
            PrintItemList(gProc.FncGetProducts());
        }

        public void PrintItemList(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Item Code: {item.ItemCode}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Cost Per Item: {item.CostPerItem}");
                Console.WriteLine($"Size: {item.Size}");
                Console.WriteLine($"Type: {item.Type}");
                Console.WriteLine($"Current Stocks: {item.CurrentStocks}");
                Console.WriteLine($"Image Location: {item.ImgLocation}");
                Console.WriteLine("----------------------------");
            }
        }

    }
}
