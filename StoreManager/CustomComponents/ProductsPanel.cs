using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;
using System.Diagnostics;
using StoreObjects;
using StoreManager;
using StoreManager.Icons;
using System.IO;
using Org.BouncyCastle.Pqc.Crypto.Lms;
//using ReaLTaiizor.Controls;

namespace CustomComponents
{

    public class ProductDisplayPanel : ReaLTaiizor.Controls.MaterialCard
    {
        private static Size PANEL_SIZE = new Size(100, 200);
        private static Size PICBOX_PROD_PIC_SIZE = new Size(90, 90);
        private static Size LBL_PROD_NAME_SIZE = new Size(PICBOX_PROD_PIC_SIZE.Width, 50);
        private static Size LBL_PRODSIZE_SIZE = new Size(PICBOX_PROD_PIC_SIZE.Width, 14);
        private static Size BTN_ADDTOCART_SIZE = new Size(PICBOX_PROD_PIC_SIZE.Width, 20);

        public PictureBox PicBoxProductPicture;
        public Label LblProductName;
        public Label LblProductSize;
        public ReaLTaiizor.Controls.Button BtnAddToCart;
        public EventHandler Clicked;
        private Item item;
        private string currentDir = Environment.CurrentDirectory;
        private string imageFolderDir;
        private string imageLocation;

        public string ProdName { get; }

        int gap = 5;
        int xLoc = 5;
        int yLoc = 5;

        public ProductDisplayPanel(EventHandler eventHandler)
        {

            //this.imageFolderDir = Path.Combine(currentDir, "..\\..\\ProductImages");
            //this.imageLocation = currentDir + "\\" + Item.ImgName;

            //this.Item = item;
            //this.ProdName = item.Name;

            this.PicBoxProductPicture = new PictureBox();
            this.LblProductName = new Label();
            this.LblProductSize = new Label();
            this.BtnAddToCart = new ReaLTaiizor.Controls.Button();

            this.Size = PANEL_SIZE;
            this.Location = new Point(10, 10);

            //this.PicBoxProductPicture.ImageLocation = @"Image\airforce.png";
            this.PicBoxProductPicture.Size = PICBOX_PROD_PIC_SIZE;
            this.PicBoxProductPicture.Location = new Point(xLoc, yLoc);
            this.PicBoxProductPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            this.yLoc = yLoc + this.PicBoxProductPicture.Size.Height + gap;
            
            //this.LblProductName.Text = "dasddasdd";
            this.LblProductName.Location = new Point(xLoc, yLoc);
            this.LblProductName.Size = LBL_PROD_NAME_SIZE;
            this.LblProductName.AutoEllipsis = true;
            this.LblProductName.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.yLoc = yLoc + this.LblProductName.Size.Height + gap;

            //this.LblProductSize.Text = "Size: " + "Size";
            this.LblProductSize.Location = new Point(xLoc, yLoc);
            this.LblProductSize.Size = LBL_PRODSIZE_SIZE;
            this.LblProductSize.Font = new Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.yLoc = yLoc + this.LblProductSize.Size.Height + gap;

            //this.BtnAddToCart.Text = "₱" + "ddd";
            this.BtnAddToCart.Size = BTN_ADDTOCART_SIZE;
            this.BtnAddToCart.Location = new Point(xLoc, yLoc);
            this.BtnAddToCart.BorderColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BtnAddToCart.EnteredBorderColor = Color.Silver;
            this.BtnAddToCart.InactiveColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BtnAddToCart.PressedBorderColor = Color.Black;
            this.BtnAddToCart.PressedColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //this.BtnAddToCart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddToCart.Click += eventHandler;

            //Debug.WriteLine(imageLocation);

            this.BackColor = Color.White;

            this.Controls.Add(this.PicBoxProductPicture);
            this.Controls.Add(this.LblProductName);
            this.Controls.Add(this.LblProductSize);
            this.Controls.Add(this.BtnAddToCart);
            this.Visible = false;
        }

        public Item Item 
        { 
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
                this.LblProductName.Text = this.item.Name;
                this.LblProductSize.Text = "Size: " + this.item.Size;
                this.BtnAddToCart.Text = "₱" + this.item.Price.ToString("N2");
                this.BtnAddToCart.Name = this.item.Name;
                this.Visible = true;

                InitializeImage();
            }
        }

        public void InitializeImage()
        {
            this.imageFolderDir = Path.Combine(currentDir, "..\\..\\ProductImages");
            this.imageLocation = Path.Combine(imageFolderDir, this.item.ImgName);

            try
            {
                //Debug.WriteLine(imageLocation);
                this.PicBoxProductPicture.ImageLocation = this.imageLocation;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int PanelWidth
        {
            get
            {
                return PANEL_SIZE.Width;
            }
        }

        public static int PanelHeight
        {
            get
            {
                return PANEL_SIZE.Height;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        public void DisableButton()
        {
            this.BtnAddToCart.Enabled = false;
            this.BtnAddToCart.InactiveColor = Color.Gray;
            this.BtnAddToCart.BorderColor = Color.Gray;
        }

        public void EnableButton()
        {
            this.BtnAddToCart.Enabled = true;
            this.BtnAddToCart.InactiveColor = Color.Black;
            this.BtnAddToCart.BorderColor = Color.Black;
        }
    }

    public class ProductsPanel : Panel
    {
        static int PDP_DISPLAY_HEIGHT = ProductDisplayPanel.PanelHeight;
        static int PDP_DISPLAY_WIDTH = ProductDisplayPanel.PanelWidth;

        private List<ProductDisplayPanel> pdpDisplays = new List<ProductDisplayPanel>();
        private List<Item> items;
        private EventHandler pdpEventHandler = null;
        private List<int> cartContententIds = new List<int>();

        int margin = 5;
        int xLoc = 0;
        int yLoc = 5;
        int gap = 5;
        int countPerRow;
        int countPerColumn;
        int totalCountPerDisplay;
        private int currentPage = 1;
        private int lastPage;

        public ProductsPanel()
        {
            this.xLoc += margin;
            this.Width = 430;
            this.Height = 600;
            this.Location = new Point(0, 0);
            //this.Visible = false;
            //this.countPerRow = GetCountPerRow();
            //this.BackColor = Color.Red;

            //foreach (Item item in items)
            //{
            //    this.AddPdpPanels(new ProductDisplayPanel(item, pdpEventHandler));
            //}

            //this.Visible = true;

        }

        // Winforms designer breaks when my custom panel receive parameters

        // this has to be initialized for the component to work (STEP 1)
        public void InitializeItems(List<Item> items, EventHandler pdpEventHandler)
        {
            this.items = items;
            this.pdpEventHandler = pdpEventHandler;
        }

        // this has to be initialized for the component to work (STEP 2)
        public void InitializeCards()
        {

            this.UpdateCountPerRow();
            this.UpdateCountPerColumn();
            this.totalCountPerDisplay = this.countPerColumn * this.countPerRow;
            int tempXLoc = this.xLoc;
            int tempYLoc = this.yLoc;

            this.lastPage = (int)Math.Ceiling((double)this.items.Count() / (double)this.totalCountPerDisplay );
            //Debug.WriteLine(lastPage);

            for (int i = 0; i < totalCountPerDisplay; i++)
            {
                this.pdpDisplays.Add(new ProductDisplayPanel(this.pdpEventHandler));
                this.pdpDisplays[i].Location = new Point(tempXLoc, tempYLoc);
                this.Controls.Add(this.pdpDisplays[i]);
                //this.pdpDisplays[i].Visible = true;

                if ((i + 1) % countPerRow == 0)
                {
                    tempXLoc = margin;
                    tempYLoc += PDP_DISPLAY_HEIGHT + this.gap;
                    continue;
                }

                tempXLoc += PDP_DISPLAY_WIDTH + gap;
            }

            //this.Visible = true;
        }

        public void ArrangeProductPanels(int page)
        {
            if ((this.IsOnLastPage() && !(page < this.lastPage && page > 0)) && page != 1) return;
            this.Visible = false;
            // the page is not zero indexed

            int starting = (page - 1) * this.totalCountPerDisplay;
            int cap = Math.Min((this.countPerColumn * this.countPerRow), this.items.Count());

            if (page - 1 < 0 || page - 1 * page > this.items.Count()) return;
            if (starting >= items.Count()) return;

            this.HideCards();

            this.currentPage = page;

            for (int i = 0; i < cap && ((i + starting) < this.items.Count()); i++)
            {
                int itemId;   
                this.pdpDisplays[i].Item = items[i + starting];
                itemId = this.pdpDisplays[i].Item.Id;
                this.pdpDisplays[i].InitializeImage();
                this.pdpDisplays[i].EnableButton();
                if (this.pdpDisplays[i].Item.CurrentStocks == 0 || this.cartContententIds.Contains(itemId)) 
                {
                    this.pdpDisplays[i].DisableButton();
                }
                
            }

            //Debug.WriteLine(this.countPerRow);

            this.Refresh();
            this.Visible = true;
        }

        public void AddCartContentId(int id)
        {
            this.cartContententIds.Add(id);
        }

        public void RemoveCartContentId(int id)
        {
            this.cartContententIds.Remove(id);
        }

        //public void ArrangePdpPanels()
        //{

        //    //if (page < 1) return;

        //    this.UpdateCountPerRow();
        //    this.UpdateCountPerColumn();
        //    int tempXLoc = this.xLoc;
        //    int tempYLoc = this.yLoc;

        //    int cap = Math.Min((this.countPerColumn * this.countPerRow), pdpDisplays.Count());

        //    for(int i = 0; i < cap; i++)
        //    {

        //        this.pdpDisplays[i].Location = new Point(tempXLoc, tempYLoc);

        //        if ((i + 1) % countPerRow == 0)
        //        {
        //            tempXLoc = margin;
        //            tempYLoc += PDP_DISPLAY_HEIGHT + this.gap;
        //            continue;
        //        }

        //        tempXLoc += PDP_DISPLAY_WIDTH + gap;
        //    }


        //}

        //private void AddPdpPanels(ProductDisplayPanel productDisplayPanel)
        //{
        //    this.pdpDisplays.Add(productDisplayPanel);
        //    this.Controls.Add(productDisplayPanel);
        //    this.ArrangePdpPanels();
        //    this.Refresh();
        //}

        // this does not work (not using it anyways)
        public void PanelSizeUpdated(int currentPage)
        {
            this.UpdateCountPerRow();
            this.UpdateCountPerColumn();
            this.totalCountPerDisplay = this.countPerColumn * this.countPerRow;
            this.ArrangeProductPanels(currentPage);
            this.Refresh();
        }

        private void UpdateCountPerRow()
        {
            this.countPerRow = (this.Width - margin) / (PDP_DISPLAY_WIDTH + gap);
        }

        private void UpdateCountPerColumn()
        {
            this.countPerColumn = (this.Height - margin) / (PDP_DISPLAY_HEIGHT + gap);
        }

        public List<ProductDisplayPanel> PdpDisplays
        {
            get { return this.pdpDisplays; }
        }

        public void HideCards()
        {
            foreach(ProductDisplayPanel p in this.pdpDisplays)
            {
                p.Visible = false;
            }
        }

        public bool IsOnLastPage()
        {
            return this.currentPage == this.lastPage;
        }

        public int Lastpage { get { return this.lastPage; } }

        public int Currentpage {  get { return this.currentPage; } }

    }

}
