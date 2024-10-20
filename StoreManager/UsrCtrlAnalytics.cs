using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using LaundrySystem;
using StoreManager.Database;

namespace StoreManager
{
    public partial class UsrCtrlAnalytics : UserControl
    {
        private DBConnect dbConnection;
        private GlobalProcedure gProc;
        public UsrCtrlAnalytics(DBConnect dbConnection, GlobalProcedure gProc)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.gProc = gProc;
            displayTotalOrders();
            displayTotalSales();
            gProc.ProcAddCmbProductSoldItems(cmbProductSold);
            gProc.ProcAddCmbProductSoldItems(cmbProductSales);
            gProc.ProcGetTotalCustomers(lblTotalCustomer);
            //displayTotalSales();
            getTopProducts();
            addChart(pnlBottom);
            addChart(pnlMiddle);

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UsrCtrllAnalytics_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel7_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void addChart(BunifuPanel pnl)
        {

            LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            cartesianChart1.Width = pnl.Width ;
            cartesianChart1.Height = pnl.Height;
            cartesianChart1.Visible = false;
            cartesianChart1.BackColor = Color.Transparent;

            cartesianChart1.Anchor.Equals(Left);
            cartesianChart1.Anchor.Equals(Right);

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Shoes",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "T-Shirt",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Shorts",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 5
                 }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            /*    cartesianChart1.Series.Add(new LineSeries
                {
                  Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                  LineSmoothness = 0, //straight lines, 1 really smooth lines
                  PointGeometry = System.Windows.Media.Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                  PointGeometrySize = 50,
                  PointForeground = System.Windows.Media.Brushes.Gray
                });*/

            //modifying any series values will also animate and update the chart
            //cartesianChart1.Series[2].Values.Add(5d);

            cartesianChart1.DataClick += CartesianChart1OnDataClick;

            pnl.Controls.Clear();
            pnl.Controls.Add(cartesianChart1);
            cartesianChart1.Visible = true;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            addChart(pnlBottom);
            addChart(pnlMiddle);
           
        }

        public void displayTotalSales()
        {
            double sales = gProc.FncTotalSales();
            string totalSales = sales.ToString("0.00");
            lblTotalSales.Text = "₱" + totalSales;

        }

        public void displayTotalOrders()
        {
            int orders = gProc.FncTotalOrder();
            string totalOrders = orders.ToString();
            lblTotalOrder.Text = totalOrders;
        }

       /* private void bunifuDropdown1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown1.Text == "Last 30 Days")
            {
                lblProuductSales.Text = "30 days";
            }
            else if (bunifuDropdown1.Text == "Last 15 days")
            {
                lblProuductSales.Text = "15 days";
            }
            else if (bunifuDropdown1.Text == "Last 7 days")
            {
                lblProuductSales.Text = "7 days";
            }
        }*/

      

        private void cmbProductSales_SelectedValueChanged(object sender, EventArgs e)
        {
            string itemName = cmbProductSales.Text;
            gProc.ProcGetProductSales(itemName, lblProductSales);
        }

        private void cmbProductSold_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string itemName = cmbProductSold.Text;
            gProc.ProcGetProductSoldCount(itemName, lblProductSold);
        }

        public void getTopProducts()
        {
           gProc.ProcGetTopProducts(product1, 0);
           gProc.ProcGetTopProducts(product2, 1);
           gProc.ProcGetTopProducts(product3, 2);
           gProc.ProcGetTopProducts(product4, 3);
           gProc.ProcGetTopProducts(product5, 4);
        }
    }
    
}
