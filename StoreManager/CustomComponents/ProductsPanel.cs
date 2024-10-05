﻿using System;
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

        public string ProdName { get; }

        int gap = 5;
        int xLoc = 5;
        int yLoc = 5;

        public ProductDisplayPanel(EventHandler eventHandler)
        {

            //this.Item = item;
            //this.ProdName = item.Name;

            this.PicBoxProductPicture = new PictureBox();
            this.LblProductName = new Label();
            this.LblProductSize = new Label();
            this.BtnAddToCart = new ReaLTaiizor.Controls.Button();

            this.Size = PANEL_SIZE;
            this.Location = new Point(10, 10);

            this.PicBoxProductPicture.ImageLocation = @"Image\airforce.png";
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
                //this.Refresh();
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
    }

    public class ProductsPanel : Panel
    {
        static int PDP_DISPLAY_HEIGHT = ProductDisplayPanel.PanelHeight;
        static int PDP_DISPLAY_WIDTH = ProductDisplayPanel.PanelWidth;

        private List<ProductDisplayPanel> pdpDisplays = new List<ProductDisplayPanel>();
        private List<Item> items;
        private EventHandler pdpEventHandler = null;

        int margin = 5;
        int xLoc = 0;
        int yLoc = 5;
        int gap = 5;
        int countPerRow;
        int countPerColumn;
        int totalCountPerDisplay;
        int currentPage = 1;
        int lastPage;

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
            if (this.IsOnLastPage() && !(page < this.lastPage && page > 0)) return;
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
                
                this.pdpDisplays[i].Item = items[i + starting];
                
            }

            //Debug.WriteLine(this.countPerRow);

            this.Refresh();
            this.Visible = true;
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

        public void PanelSizeUpdated(int currentPage)
        {
            this.UpdateCountPerRow();
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

    }

}
