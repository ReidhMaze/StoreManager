using StoreManager.CustomComponentsLinker;
using StoreManagerDb;
using StoreManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreObjects;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System.Windows.Media.Animation;

namespace StoreManager
{
    public partial class UsrCtrlInventory : UserControl
    {
        private GlobalProcedure gProc;

        string imgLocation;
        Boolean addProduct, editProduct, removeProduct, restock, disposeStock;
        //private int selectedItemId = -1;
        private Item selectedItem = null;
        Dictionary<int, Item> rowId = new Dictionary<int, Item>();
        private string itemNameSearch;
        private string[] inventoryCols = { "Name", "Item Code", "Price", "Cost Per Item", "Size", "Type", "Current  Stocks", "Supplier Name", "Restock Threshold"};
        private string[] orderCols = { "Invoice Number", "Total Price", "Subtotal", "Vat", "Tax Rate", "Date", "Staff Name" };
        private string[] inventoryLogCols = { "Item Name", "Quantity", "Date", "Supplier/Invoice", "Staff Name" };
        private bool onInventory = true;

        public bool Updated = false;

        public UsrCtrlInventory(GlobalProcedure gProc)
        {
            InitializeComponent();
            this.gProc = gProc;
            this.gProc.FncConnectToDatabase();
            StandardView(true);
            InitializeItemsGrid();
            //this.CmbSize.Items.AddRange(gProc.FncGetDistinctSizes());
            //this.CmbType.Items.AddRange(gProc.FncGetProductTypes());
            this.CmbTypeInfo.Items.AddRange(gProc.FncGetProductTypes());
            //this.CmbSizeInfo.Items.AddRange(gProc.FncGetDistinctSizes());
            this.CmbViewType.SelectedIndex = 0;
        }

        private void BtnUploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "Images Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofdPic.FileName;
                ImgItem.Image = new Bitmap(ofdPic.FileName);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            string currentDir = Environment.CurrentDirectory;
            string imageFolderDir = Path.Combine(currentDir, "..\\..\\ProductImages");

            string itemName = TxtName.Text;
            string size = CmbSizeInfo.Text;
            string type = CmbTypeInfo.Text;
            string imgLocation = this.imgLocation;
            string imgName = Path.GetFileName(imgLocation);
            string supplier = TxtSupplier.Text;
            int restockThreshold, remainingStocks, quantity;
            double price, costPerItem;

            if(selectedItem == null && !addProduct)
            {
                MessageBox.Show("Please select an item");
                return;
            }

            try
            {
                if (addProduct)
                {
                    //if (this.selectedItem != null || this.selectedItem.ImgName != imgName)
                    //if (this.selectedItem != null)
                    try
                    {
                        File.Copy(this.imgLocation, Path.Combine(imageFolderDir, imgName), true);
                    }
                    catch (Exception)
                    {

                    }
                    

                    restockThreshold = int.Parse(TxtRestockThreshold.Text);
                    price = double.Parse(TxtPrice.Text);
                    costPerItem = double.Parse(TxtCostPerItem.Text);

                    if (string.IsNullOrEmpty(size) || string.IsNullOrEmpty(type)) 
                    {
                        MessageBox.Show("Missing Inputs", "Error");
                    }
                    else
                    {
                        var confirmAdd = MessageBox.Show("Are you sure you want to add this product?", "Confirm Add", MessageBoxButtons.YesNo);

                        if (confirmAdd == DialogResult.Yes)
                        {
                            gProc.ProcAddItem(itemName, size, type, price, costPerItem, imgName, supplier, restockThreshold);
                            MessageBox.Show("Product Successfuly Added");
                            ClearAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                
                if (editProduct) 
                {
                    if(this.selectedItem.ImgName != imgName) File.Copy(this.imgLocation, Path.Combine(imageFolderDir, imgName), true);
                    restockThreshold = int.Parse(TxtRestockThreshold.Text);
                    price = double.Parse(TxtPrice.Text);

                    if (string.IsNullOrEmpty(size) || string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Missing Inputs", "Error");
                    }
                    else
                    {
                        var confirmEdit = MessageBox.Show("Are you sure you want to edit this product?", "Confirm Edit", MessageBoxButtons.YesNo);

                        if (confirmEdit == DialogResult.Yes)
                        {
                            gProc.ProcEditItemById(this.selectedItem.Id, itemName, size, type, imgName, restockThreshold, price);
                            MessageBox.Show("Product Successfuly Edited");
                            ClearAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (restock)
                {

                    if(TxtQuantity.Text == "")
                    {
                        MessageBox.Show("Enter Quantity");
                        return;
                    }

                    price = double.Parse(TxtPrice.Text);
                    costPerItem = double.Parse(TxtCostPerItem.Text);
                    quantity = int.Parse(TxtQuantity.Text);

                    if (string.IsNullOrEmpty(size) || string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Missing Inputs", "Error");
                    }
                    else
                    {
                        var confirmRestock = MessageBox.Show("Are you sure you want to restock this product?", "Confirm Restock", MessageBoxButtons.YesNo);

                        if (confirmRestock == DialogResult.Yes)
                        {
                            gProc.ProcRestock(itemName, price, costPerItem, size, type, supplier, quantity);
                            MessageBox.Show("Product Successfuly Restocked");
                            ClearAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (disposeStock)
                {
                    
                    if(this.TxtQuantity.Text.Length < 1)
                    {
                        MessageBox.Show("Please input quantity");
                        return;
                    }

                    int qtyRemoved = int.Parse(this.TxtQuantity.Text);

                    if (qtyRemoved > this.selectedItem.CurrentStocks)
                    {
                        qtyRemoved = this.selectedItem.CurrentStocks;
                    }

                    if (qtyRemoved == 0)
                    {
                        MessageBox.Show("No stock to remove");
                    }

                    var confirmDispose = MessageBox.Show("Are you sure you want to dispose " + qtyRemoved + " stock/s of this product?", "Confirm Restock", MessageBoxButtons.YesNo);


                    if (confirmDispose == DialogResult.Yes)
                    {
                        this.gProc.ProcDecreaseItemStock(this.selectedItem.ItemCode, qtyRemoved);
                        MessageBox.Show("Product Successfuly Disposed");
                        ClearAll();
                    }
                    else
                    {
                        return;
                    }

                    
                }

                if (removeProduct)
                {
                    if(selectedItem == null)
                    {
                        MessageBox.Show("No item selected");
                        return;
                    }

                    var confirmDelete = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Restock", MessageBoxButtons.YesNo);


                    if (confirmDelete == DialogResult.Yes)
                    {
                        this.gProc.ProcDeleteItemById(this.selectedItem.Id);
                        MessageBox.Show("Product Successfuly Deleted");
                        ClearAll();
                    }
                    else
                    {
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Missing Inputs", "Error");
                MessageBox.Show(ex.Message);
            }

            Updated = true;
            InitializeItemsGrid();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductMode();
        }

        private void AddProductMode()
        {
            EnabledAll(true);
            TxtRemainingStocks.Enabled = false;

            addProduct = true;
            editProduct = false;
            removeProduct = false;
            restock = false;
            disposeStock = false;
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void EditMode()
        {
            EnabledAll(false);
            TxtSupplier.Enabled = false;
            TxtCostPerItem.Enabled = false;
            TxtRemainingStocks.Enabled = false;

            addProduct = false;
            editProduct = true;
            removeProduct = false;
            restock = false;
            disposeStock = false;
        }

        private void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            RemoveProductMode();
        }

        private void RemoveProductMode()
        {
            StandardView(false);
            BtnSubmit.Enabled = true;

            addProduct = false;
            editProduct = false;
            removeProduct = true;
            restock = false;
            disposeStock = false;
        }

        private void BtnRestock_Click(object sender, EventArgs e)
        {
            RestockMode();
        }

        private void RestockMode()
        {
            EnabledAll(false);
            TxtName.Enabled = false;
            TxtRemainingStocks.Enabled = false;
            BtnUploadImg.Enabled = false;
            TxtQuantity.Visible = true;
            LblQuantity.Visible = true;

            addProduct = false;
            editProduct = false;
            removeProduct = false;
            restock = true;
            disposeStock = false;
        }

        private void BtnDisposeStock_Click(object sender, EventArgs e)
        {
            DisposeStockMode();
        }

        private void DisposeStockMode()
        {
            StandardView(false);
            TxtQuantity.Visible = true;
            LblQuantity.Visible = true;
            BtnSubmit.Enabled = true;

            addProduct = false;
            editProduct = false;
            removeProduct = false;
            restock = false;
            disposeStock = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelModes();
        }

        public void CancelModes()
        {
            StandardView(true);

            addProduct = false;
            editProduct = false;
            removeProduct = false;
            restock = false;
            disposeStock = false;
        }

        private void TbNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void InitializeItemsGrid()
        {

            this.DataGridItems.Columns.Clear();
            for (int i = 0; i < inventoryCols.Length; i++)
            {
                this.DataGridItems.Columns.Add("" + i, inventoryCols[i]);
            }

            List<Item> items = gProc.FncGetItems();
            this.rowId.Clear();
            this.DataGridItems.RowCount = items.Count;
            this.selectedItem = null;

            for (int i = 0; i < items.Count; i++)
            {

                if (items[i].CurrentStocks <= items[i].RestockThreshold) this.DataGridItems.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                if (items[i].CurrentStocks == 0) this.DataGridItems.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                this.rowId.Add(i, items[i]);
                this.DataGridItems.Rows[i].Cells[0].Value = items[i].Name;              // Name
                this.DataGridItems.Rows[i].Cells[1].Value = items[i].ItemCode;          // Item Code
                this.DataGridItems.Rows[i].Cells[2].Value = items[i].Price;             // Price
                this.DataGridItems.Rows[i].Cells[3].Value = items[i].CostPerItem;       // Cost per Item
                this.DataGridItems.Rows[i].Cells[4].Value = items[i].Size;              // Size
                this.DataGridItems.Rows[i].Cells[5].Value = items[i].Type;              // Type
                this.DataGridItems.Rows[i].Cells[6].Value = items[i].CurrentStocks;     // Current Stocks
                this.DataGridItems.Rows[i].Cells[7].Value = items[i].SupplierName;      // Supplier Name
                this.DataGridItems.Rows[i].Cells[8].Value = items[i].RestockThreshold;  // Restock Threshold
            }
        }

        private void InitializeItemsGrid(string itemName)
        {

            this.DataGridItems.Columns.Clear();
            for(int i = 0; i < inventoryCols.Length; i++)
            {
                this.DataGridItems.Columns.Add("" + i, inventoryCols[i]);
            }

            List<Item> items = gProc.FncGetFilteredItems(itemName);
            this.rowId.Clear();
            this.DataGridItems.RowCount = items.Count;
            this.selectedItem = null;

            for (int i = 0; i < items.Count; i++)
            {

                if (items[i].CurrentStocks <= items[i].RestockThreshold) this.DataGridItems.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                if (items[i].CurrentStocks == 0) this.DataGridItems.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                this.rowId.Add(i, items[i]);
                this.DataGridItems.Rows[i].Cells[0].Value = items[i].Name;              // Name
                this.DataGridItems.Rows[i].Cells[1].Value = items[i].ItemCode;          // Item Code
                this.DataGridItems.Rows[i].Cells[2].Value = items[i].Price;             // Price
                this.DataGridItems.Rows[i].Cells[3].Value = items[i].CostPerItem;       // Cost per Item
                this.DataGridItems.Rows[i].Cells[4].Value = items[i].Size;              // Size
                this.DataGridItems.Rows[i].Cells[5].Value = items[i].Type;              // Type
                this.DataGridItems.Rows[i].Cells[6].Value = items[i].CurrentStocks;     // Current Stocks
                this.DataGridItems.Rows[i].Cells[7].Value = items[i].SupplierName;      // Supplier Name
                this.DataGridItems.Rows[i].Cells[8].Value = items[i].RestockThreshold;  // Restock Threshold
            }
        }

        private void InitializeOrderGrid()
        {
            this.DataGridItems.Columns.Clear();
            for (int i = 0; i < orderCols.Length; i++)
            {
                this.DataGridItems.Columns.Add("" + i, orderCols[i]);
            }

            List<StoreOrder> orders = gProc.FncGetOrders();
            this.DataGridItems.RowCount = orders.Count();

            for(int i = 0; i < orders.Count; i++)
            {
                this.DataGridItems.Rows[i].Cells[0].Value = orders[i].InvoiceNum;
                this.DataGridItems.Rows[i].Cells[1].Value = "₱" + orders[i].TotalPrice.ToString("#,###.00");
                this.DataGridItems.Rows[i].Cells[2].Value = "₱" + orders[i].Subtotal.ToString("#,###.00");
                this.DataGridItems.Rows[i].Cells[3].Value = "₱" + orders[i].Vat.ToString("#,###.00");
                this.DataGridItems.Rows[i].Cells[4].Value = (int)(double.Parse(orders[i].TaxRate.ToString()) * 100) + "%";
                this.DataGridItems.Rows[i].Cells[5].Value = orders[i].Date.ToShortDateString();
                this.DataGridItems.Rows[i].Cells[6].Value = orders[i].StaffName;
            }

        }

        private void InitializeInventoryLogGrid()
        {
            this.DataGridItems.Columns.Clear();
            for (int i = 0; i < inventoryLogCols.Length; i++)
            {
                this.DataGridItems.Columns.Add("" + i, inventoryLogCols[i]);
            }

            List<InventoryLogEntry> log = gProc.FncGetInventoryLog();
            this.DataGridItems.RowCount = log.Count();

            for(int i = 0; i < log.Count; i++)
            {
                this.DataGridItems.Rows[i].Cells[0].Value = log[i].ItemName;
                this.DataGridItems.Rows[i].Cells[1].Value = log[i].Quantity;
                this.DataGridItems.Rows[i].Cells[2].Value = log[i].Date.ToShortDateString();
                this.DataGridItems.Rows[i].Cells[3].Value = log[i].SupplierOrInvoice;
                this.DataGridItems.Rows[i].Cells[4].Value = log[i].StaffName;
            }
        }


        private void DataGridItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (!onInventory) return;

            int selectedIdx = e.RowIndex;

            //if (addProduct) return;
            if(selectedIdx < 0) return;

            string size = this.DataGridItems.Rows[selectedIdx].Cells[4].Value.ToString();
            string type = this.DataGridItems.Rows[selectedIdx].Cells[5].Value.ToString();

            this.rowId.TryGetValue(selectedIdx, out this.selectedItem);

            this.TxtName.Text = this.DataGridItems.Rows[selectedIdx].Cells[0].Value.ToString();
            this.CmbSizeInfo.SelectedIndex = CmbSizeInfo.Items.IndexOf(size);
            this.CmbTypeInfo.SelectedIndex = CmbTypeInfo.Items.IndexOf(type);
            this.TxtSupplier.Text = this.DataGridItems.Rows[selectedIdx].Cells[7].Value.ToString();
            this.TxtPrice.Text = this.DataGridItems.Rows[selectedIdx].Cells[2].Value.ToString();
            this.TxtCostPerItem.Text = this.DataGridItems.Rows[selectedIdx].Cells[3].Value.ToString();
            this.TxtRestockThreshold.Text = this.DataGridItems.Rows[selectedIdx].Cells[8].Value.ToString();
            this.TxtRemainingStocks.Text = this.DataGridItems.Rows[selectedIdx].Cells[6].Value.ToString();
            SetPicBoxImage(this.selectedItem.ImgName);
        }

        public void SetPicBoxImage(string imageName)
        {
            string currentDir = Environment.CurrentDirectory;
            string imageFolderDir = Path.Combine(currentDir, "..\\..\\ProductImages");
            string imageLocation = Path.Combine(imageFolderDir, imageName);

            this.imgLocation = imageLocation;

            try
            {
                //Debug.WriteLine(imageLocation);
                this.ImgItem.ImageLocation = imageLocation;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TbSearch_Enter(object sender, EventArgs e)
        {
            if (this.TbSearch.Text == "Search")
                this.TbSearch.Text = "";
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (TbSearch.Text != "Search") this.itemNameSearch = TbSearch.Text;
            InitializeItemsGrid(this.itemNameSearch);
        }

        private void TbSearch_Leave(object sender, EventArgs e)
        {
            this.TbSearch.Text = (TbSearch.Text == "") ? "Search" : TbSearch.Text;
        }

        private void CmbViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = CmbViewType.SelectedItem.ToString();

            if(mode == "Inventory Log")
            {
                DisableInventoryOperations();
                InitializeInventoryLogGrid();
                this.onInventory = false;
            }

            if (mode == "Orders")
            {
                DisableInventoryOperations();
                InitializeOrderGrid();
                this.onInventory = false;
            }

            if (mode == "Inventory")
            {

                EnableInventoryOperations();
                InitializeItemsGrid();
                this.onInventory = true;

                

                if (addProduct)
                    AddProductMode();
                else if (removeProduct)
                    RemoveProductMode();
                else if (restock)
                    RestockMode();
                else if (editProduct)
                    EditMode();
                else if (disposeStock)
                    DisposeStockMode();
                else
                    CancelModes();

            }
        }

        private void DisableInventoryOperations()
        {
            StandardView(true);
            this.BtnAddProduct.Enabled = false;
            this.BtnEditProduct.Enabled = false;
            this.BtnCancel.Enabled = false;
            this.BtnRestock.Enabled = false;
            this.BtnDisposeStock.Enabled = false;
            this.BtnRemoveProduct.Enabled = false;
            this.TbSearch.Enabled = false;
        }

        private void EnableInventoryOperations()
        {
            StandardView(true);
            this.BtnAddProduct.Enabled = true;
            this.BtnEditProduct.Enabled = true;
            this.BtnCancel.Enabled = true;
            this.BtnRestock.Enabled = true;
            this.BtnDisposeStock.Enabled = true;
            this.BtnRemoveProduct.Enabled = true;
            this.TbSearch.Enabled = true;
        }

        private void TbInvSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        public void StandardView(bool clear)
        {
            TxtName.Enabled = false;
            CmbSizeInfo.Enabled = false;
            CmbTypeInfo.Enabled = false;
            TxtPrice.Enabled = false;
            TxtCostPerItem.Enabled = false;
            TxtRestockThreshold.Enabled = false;
            TxtRemainingStocks.Enabled = false;
            TxtSupplier.Enabled = false;
            BtnUploadImg.Enabled = false;
            BtnSubmit.Enabled = false;
            TxtQuantity.Visible = false;
            TxtQuantity.Text = "";
            LblQuantity.Visible = false;
            if (clear) ClearAll();
        }

        public void EnabledAll(bool clear)
        {
            TxtName.Enabled = true;
            CmbSizeInfo.Enabled = true;
            CmbTypeInfo.Enabled = true;
            TxtPrice.Enabled = true;
            TxtCostPerItem.Enabled = true;
            TxtRestockThreshold.Enabled = true;
            TxtRemainingStocks.Enabled = true;
            TxtSupplier.Enabled = true;
            BtnUploadImg.Enabled = true;
            BtnSubmit.Enabled = true;
            TxtQuantity.Visible = false;
            TxtQuantity.Text = "";
            LblQuantity.Visible = false;
            if (clear) ClearAll();
        }

        public void ClearAll()
        {
            TxtName.Clear();
            CmbSizeInfo.SelectedIndex = -1;
            CmbTypeInfo.SelectedIndex = -1;
            TxtPrice.Clear();
            TxtCostPerItem.Clear();
            TxtRestockThreshold.Clear();
            TxtRemainingStocks.Clear();
            TxtSupplier.Clear();
            TxtQuantity.Clear();
            ImgItem.Image = null;
            imgLocation = null;
            //addProduct = false;
            //editProduct = false;
            //removeProduct = false;
            //restock = false;
            //disposeStock = false;
            this.selectedItem = null;
        }

    }
}

