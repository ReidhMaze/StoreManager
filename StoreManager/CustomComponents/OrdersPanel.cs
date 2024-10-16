using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreManager.Properties;
using StoreObjects;
//using StoreManager.Textures;
using StoreManager.Icons;
using System.Drawing;
using Plasmoid.Extensions;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using static ReaLTaiizor.Controls.MaterialSlider;

namespace CustomComponents
{
    public class Order : ReaLTaiizor.Controls.MaterialCard
    {

        private static System.Drawing.Size PANEL_SIZE = new System.Drawing.Size(360, 35);
        private static System.Drawing.Size BTN_REMOVE_SIZE = new System.Drawing.Size(30, 25);
        private static System.Drawing.Size BTN_INCR_DECR_SIZE = new System.Drawing.Size(25, 25);
        private static System.Drawing.Size LBL_QTY_SIZE = new System.Drawing.Size(30, 25);
        private static System.Drawing.Size LBL_PROD_NAME_SIZE = new System.Drawing.Size(100, 35);
        private static System.Drawing.Size LBL_PRICE_SIZE = new System.Drawing.Size(80, 25);
        //private static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));


        private ReaLTaiizor.Controls.Button BtnRemove = new ReaLTaiizor.Controls.Button();
        private ReaLTaiizor.Controls.DreamButton BtnIncr = new ReaLTaiizor.Controls.DreamButton();
        private ReaLTaiizor.Controls.DreamButton BtnDecr = new ReaLTaiizor.Controls.DreamButton();
        //private ReaLTaiizor.Controls.CrownNumeric QtyLabel = new ReaLTaiizor.Controls.CrownNumeric();
        private ReaLTaiizor.Controls.MaterialLabel LblQty = new ReaLTaiizor.Controls.MaterialLabel();
        private ReaLTaiizor.Controls.NightLabel LblProdName = new ReaLTaiizor.Controls.NightLabel();
        private Label LblPrice = new Label();
        private OrdersPanel ordersPanel;
        private CartItem item;

        private int xLoc = 5;
        private int gap = 10;
        private int noPadding = 0 ;
        private int topPadding = 5;
        private double price;
        private double totalPrice;


        public Order(CartItem cartItem, OrdersPanel ordersPanel)
        {

            this.item = cartItem;

            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "orderPanel";
            this.Size = PANEL_SIZE;
            this.price = this.item.Price;
            this.totalPrice = this.item.Price;
            this.BackColor = System.Drawing.Color.Transparent;

            this.LblProdName.Text = this.item.Name;
            this.LblProdName.Location = new System.Drawing.Point(xLoc, noPadding);
            this.LblProdName.Size = LBL_PROD_NAME_SIZE;
            this.LblProdName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblProdName.AutoEllipsis = true;
            this.LblProdName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LblProdName.ForeColor = Color.Black;

            xLoc = xLoc + this.LblProdName.Size.Width + gap;

            this.BtnDecr.Location = new System.Drawing.Point(xLoc, topPadding);
            this.BtnDecr.Name = "BtnDecr";
            this.BtnDecr.Size = BTN_INCR_DECR_SIZE;
            this.BtnDecr.Text = "<";
            this.BtnDecr.Click += new System.EventHandler(this.BtnDecr_Clicked);
            this.BtnDecr.ForeColor = Color.White;

            xLoc = xLoc + this.BtnDecr.Size.Width + gap;

            this.LblQty.Text = "X" + this.item.Qty.ToString();
            this.LblQty.Location = new System.Drawing.Point(xLoc, topPadding);
            this.LblQty.Size = LBL_QTY_SIZE;
            this.LblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            xLoc = xLoc + this.LblQty.Size.Width + gap;

            this.BtnIncr.Location = new System.Drawing.Point(xLoc, topPadding);
            this.BtnIncr.Name = "BtnIncr";
            this.BtnIncr.Size = BTN_INCR_DECR_SIZE;
            this.BtnIncr.Text = ">";
            this.BtnIncr.Click += new System.EventHandler(this.BtnIncr_Clicked);
            this.BtnIncr.ForeColor = Color.White;

            xLoc = xLoc + this.BtnIncr.Size.Width + gap;

            this.LblPrice.Text = "₱" + price.ToString("N2");
            this.LblPrice.Location = new System.Drawing.Point(xLoc, topPadding);
            this.LblPrice.Size = LBL_PRICE_SIZE;
            this.LblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblPrice.ForeColor = Color.Black;
            this.LblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            xLoc = xLoc + this.LblPrice.Size.Width + gap;

            this.BtnRemove.Location = new System.Drawing.Point(xLoc, topPadding);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = BTN_REMOVE_SIZE;
            //this.BtnRemove.Text = "Remove";
            this.BtnRemove.Image = MyIcons.DeleteIcon;
            this.BtnRemove.ImageAlign = ContentAlignment.MiddleCenter;
            this.BtnRemove.BorderColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BtnRemove.EnteredBorderColor = Color.Silver;
            this.BtnRemove.InactiveColor = Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BtnRemove.PressedBorderColor = Color.Black;
            this.BtnRemove.PressedColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Clicked);

            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnDecr);
            this.Controls.Add(this.LblQty);
            this.Controls.Add(this.BtnIncr);
            this.Controls.Add(this.LblProdName);
            this.Controls.Add(this.LblPrice);

            this.ordersPanel = ordersPanel;
        }

        public void BtnDecr_Clicked(object sender, EventArgs e)
        {
            if (this.item.Qty > 1)
            {
                this.item.DecrementQty();
            }
            this.LblQty.Text = "X" + item.Qty.ToString();
            this.totalPrice = price * item.Qty;
            this.LblPrice.Text = "₱" + totalPrice.ToString("N2");
            this.ordersPanel.UpdateCheckoutLabels();
        }

        public void BtnIncr_Clicked(object sender, EventArgs e)
        {
            if (this.item.Qty == item.StocksLeft) return;
            this.item.IncrementQty();
            this.LblQty.Text = "X" + item.Qty.ToString();
            this.totalPrice = price * item.Qty;
            this.LblPrice.Text = "₱" + totalPrice.ToString("N2");
            this.ordersPanel.UpdateCheckoutLabels();
        }

        public void BtnRemove_Clicked(object sender, EventArgs e)
        {
            this.ordersPanel.DeleteOrder(this);
            this.ordersPanel.UpdateCheckoutLabels();
        }

        public CartItem CartItem { get { return this.item; } }

        public double TotalPrice { get { return this.totalPrice; } }

        public static int PanelHeight {  get { return PANEL_SIZE.Height; } }


        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
        //        return cp;
        //    }
        //}
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    //base.OnPaintBackground(e);
        //}

    }

    public class OrdersPanel : Panel
    {

        private List<Order> orders = new List<Order>();
        private Label lblTotal;
        private Label lblTax;
        private Label lblSubtotal;
        public double TaxRate { get; set; }
        int marginLeft = 5;
        int gap = 5;
        int yloc = 10;
        int orderPanelHeight = Order.PanelHeight;
        public EventHandler orderDeleted;
        public Order DeletedOrder { get; set; }

        public OrdersPanel()
        {
            TaxRate = 0;
            //this.BackColor = System.Drawing.SystemColors.ControlDarkDark;

        }

        public void DisplayOrderDetails()
        {
            for (int i = 0; i < orders.Count(); i++)
            {
                Debug.WriteLine(orders[i].CartItem.Name + ": " + orders[i].CartItem.Qty);
                //Debug.WriteLine(orders[i].CartItem.Qty);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int CornerRadius = 5;

            base.OnPaint(e);

            // Enable anti-aliasing for smooth edges
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a GraphicsPath with smooth rounded corners
            GraphicsPath path = new GraphicsPath();
            int diameter = CornerRadius * 2;

            // Calculate rounded corners for the panel
            path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90); // Top-left corner
            path.AddArc(new Rectangle(this.Width - diameter - 1, 0, diameter, diameter), 270, 90); // Top-right corner
            path.AddArc(new Rectangle(this.Width - diameter - 1, this.Height - diameter - 1, diameter, diameter), 0, 90); // Bottom-right corner
            path.AddArc(new Rectangle(0, this.Height - diameter - 1, diameter, diameter), 90, 90); // Bottom-left corner

            path.CloseAllFigures();

            // Clip the panel to the rounded rectangle
            this.Region = new Region(path);

        }

        public void InitializeCheckoutLabels(Label lblTotal, Label lblTax, Label lblSubtotal)
        {
            this.lblTotal = lblTotal;
            this.lblTax = lblTax;
            this.lblSubtotal = lblSubtotal;
        }

        public void AddOrder(CartItem cartItem)
        {

            Order order = new Order(cartItem, this);

            order.Location = new System.Drawing.Point(marginLeft, yloc);
            orders.Add(order);
            this.Controls.Add(order);

            yloc += orderPanelHeight + gap;
        }

        public void DeleteOrder(Order order)
        {
            this.orders.Remove(order);
            this.Controls.Remove(order);
            order.Dispose();
            this.DisplayOrders();

            this.DeletedOrder = order;

            OnOrderDeleted(EventArgs.Empty);
        }

        public event EventHandler OrderDeleted
        {
            add
            {
                orderDeleted += value;
            }
            remove
            {
                orderDeleted -= value;
            }
        }

        public virtual void OnOrderDeleted(EventArgs e)
        {
            orderDeleted?.Invoke(this, e);
            //Debug.WriteLine("delted order");
        }

        public void DisplayOrders()
        {
            yloc = 10;

            foreach (Order order in  this.orders)
            {
                order.Location = new System.Drawing.Point(marginLeft, yloc);
                yloc += orderPanelHeight + gap;
            }

            this.Refresh();
        }

        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;
                foreach(Order order in this.orders)
                {
                    totalPrice += order.TotalPrice;
                }
                return totalPrice;
            }
        }

        public void UpdateCheckoutLabels()
        {
            this.lblTotal.Text = "₱" + this.TotalPrice.ToString("N2");
            this.lblTax.Text = "₱" + (this.TotalPrice * this.TaxRate).ToString("N2");
            this.lblSubtotal.Text = "₱" + (this.TotalPrice - (this.TotalPrice * this.TaxRate)).ToString("N2");
        }

        public void ClearOrders()
        {
            for(int i = orders.Count() - 1; i >= 0; i--)
            {
                DeleteOrder(orders[i]);
            }
            UpdateCheckoutLabels();
        }

        public List<CartItem> Cart
        {
            get
            {
                List<CartItem > items = new List<CartItem>();
                for(int i = 0; i < this.orders.Count; i++)
                {
                    items.Add(orders[i].CartItem);
                }
                return items;
            }
        }

        public List<Order> Orders
        {
            get { return orders; }
        }

    }


}
