using CustomComponents;
using StoreManagerDb;
using Org.BouncyCastle.Asn1.Mozilla;
using StoreManager.CustomComponentsLinker;
using StoreObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StoreManager
{
    public partial class UsrCtrlCashiering : UserControl
    {

        private int currentPage = 1;
        private GlobalProcedure gProc;

        private string itemName = string.Empty;
        private string itemSize = string.Empty;
        private string itemType = string.Empty;
        private string order = "Alphabetical";

        ProductsAndOrdersLinker productsAndOrdersLinker;

        public UsrCtrlCashiering(GlobalProcedure gProc)
        {
            InitializeComponent();
            this.PnlOrdersPanel.OrderDeleted += new System.EventHandler(OnOrderDeleted);
            this.gProc = gProc;
            this.PnlOrdersPanel.TaxRate = gProc.FncGetLatestTaxRate();
            this.LblTax.Text = "VAT (" + (int)(this.PnlOrdersPanel.TaxRate * 100) + "%)";
            this.CmbType.Items.AddRange(gProc.FncGetProductTypes());
        }

        public void InitializeCardView()
        {
            //Debug.WriteLine(this.PanelPOS.Size);
            this.PnlProductsPanel.InitializeItems(gProc.FncGetProducts(), this.BtnPdpClicked);
            this.PnlProductsPanel.InitializeCards();
            this.PnlProductsPanel.ArrangeProductPanels(currentPage);

            this.productsAndOrdersLinker = new ProductsAndOrdersLinker(this.PnlOrdersPanel, this.PnlProductsPanel);

            this.PnlOrdersPanel.InitializeCheckoutLabels(this.LblTotalOutput, this.LblTaxOutput, this.LblSubtotalOutput);
            this.CmbSizes.Items.AddRange(gProc.FncGetDistinctSizes());
            this.CmbOrder.SelectedIndex = 0;
            UpdatePaginationText();
        }

        public void BtnPdpClicked(object sender, EventArgs e)
        {
            ProductDisplayPanel pdpPressed = productsAndOrdersLinker.GetProdDisplayPanel(sender.GetHashCode());
            this.PnlProductsPanel.AddCartContentId(pdpPressed.Item.Id);
            this.PnlOrdersPanel.AddOrder(pdpPressed.Item.ToCartItem());
            this.PnlOrdersPanel.UpdateCheckoutLabels();
            pdpPressed.DisableButton();
            //pdpPressed.EnableButton();
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

        public void SearchAndFilter(string name, string size, string type, string order)
        {
            this.PnlProductsPanel.InitializeItems(gProc.FncGetFilteredProducts(name, size, type, order), this.BtnPdpClicked);
            this.PnlProductsPanel.InitializeCards();
            this.PnlProductsPanel.ArrangeProductPanels(currentPage);
        }

        private void TbPosSearch_Enter(object sender, EventArgs e)
        {
            if(this.TbPosSearch.Text == "Search")
                this.TbPosSearch.Text = "";
        }

        public void CenterPagination()
        {
            int paginationWidth = this.PanelPagination.Width;
            int paginationContainerWidth = this.PanelPaginationContainer.Width;

            this.PanelPagination.Location = new System.Drawing.Point(paginationContainerWidth/2 - paginationWidth/2, this.PanelPagination.Location.Y);
        }

        public void UpdatePaginationText()
        {
            int currentPage = this.PnlProductsPanel.Currentpage;
            int numOfPages = this.PnlProductsPanel.Lastpage;
            this.LblPaginationText.Text = currentPage + " of " + numOfPages;
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {

            FormCheckoutDialog checkoutDialog;

            List<CartItem> cartItems = PnlOrdersPanel.Cart;

            if(cartItems.Count == 0) 
            {
                System.Windows.Forms.MessageBox.Show("Order is Empty");
                return;
            }

            checkoutDialog = new FormCheckoutDialog(cartItems);

            checkoutDialog.ShowDialog();

            if(checkoutDialog.OrderConfirmed)
            {
                gProc.ProcCheckout(cartItems);
                PnlOrdersPanel.ClearOrders();
                this.PnlProductsPanel.InitializeItems(gProc.FncGetProducts(), this.BtnPdpClicked);
                this.PnlProductsPanel.ArrangeProductPanels(currentPage);
            }

            checkoutDialog.Close();

        }

        private void OnOrderDeleted(object sender, EventArgs e)
        {

            int deletedItemId = this.PnlOrdersPanel.DeletedOrder.CartItem.Id;
            ClearFilters();
            ProductDisplayPanel pdpPanel = this.productsAndOrdersLinker.ProductsPanelId[deletedItemId];
            this.PnlProductsPanel.RemoveCartContentId(deletedItemId);


            this.PnlOrdersPanel.DeletedOrder = null;

            pdpPanel.EnableButton();
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
                Console.WriteLine($"Image Location: {item.ImgName}");
                Console.WriteLine("----------------------------");
            }
        }

        private void TbPosSearch_Leave(object sender, EventArgs e)
        {
            this.TbPosSearch.Text = (TbPosSearch.Text == "") ? "Search" : TbPosSearch.Text;
        }

        private void TbPosSearch_TextChanged(object sender, EventArgs e)
        {
            if (TbPosSearch.Text != "Search") this.itemName = TbPosSearch.Text;
            SearchAndFilter(itemName, itemSize, itemType, order);
        }

        private void CmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.order = CmbOrder.Text;
            SearchAndFilter(itemName, itemSize, itemType, order);
        }

        private void CmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.itemSize = CmbSizes.Text;
            SearchAndFilter(itemName, itemSize, itemType, order);
        }

        private void ClearFilters()
        {
            this.TbPosSearch.Text = "";
            this.CmbSizes.SelectedIndex = 0;
            this.CmbOrder.SelectedIndex = 0;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.itemType = CmbType.Text;
            SearchAndFilter(itemName, itemSize, itemType, order);
        }

        public OrdersPanel PanelOrdersPanel
        {
            get { return this.PnlOrdersPanel; }
        }

        public void UpdateTax()
        {
            double latestTaxRate = gProc.FncGetLatestTaxRate();
            this.PnlOrdersPanel.TaxRate = latestTaxRate;
            this.LblTax.Text = "VAT (" + (int)(latestTaxRate * 100) + "%)";
            PnlOrdersPanel.ClearOrders();
        }
    }
}
