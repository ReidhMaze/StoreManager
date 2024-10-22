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
using StoreManagerDb;

namespace StoreManager
{
    public partial class UsrCtrlAnalytics2 : UserControl
    {
        private GlobalProcedure gProc;
      
        public UsrCtrlAnalytics2(GlobalProcedure gProc)
        {
            InitializeComponent();
            this.gProc = gProc;
            displayTotalOrders();
            displayTotalSales();
            gProc.ProcAddCmbProductSoldItems(cmbProductSold);
            //displayTotalSales();
            addSalesToGrid();
           
            //addChartValues();
        }

        private void bMiddlePanel_Click(object sender, EventArgs e)
        {
                    
        }

       

        public void addSalesToGrid()
        {

            string[] names = { "James", "John", "Mark" };

            int[] sales = { 1000, 2000, 3000 };

            bDgvSales.Rows.Add(names[0], sales[0]);
            bDgvSales.Rows.Add(names[1], sales[1]);
            bDgvSales.Rows.Add(names[2], sales[2]);

            
        }


        private void bMainPanel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void UsrCtrlAnalytics2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            //272, 408

            LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            cartesianChart1.Width = 450;
            cartesianChart1.Height = pnlSideBottom.Height;
            cartesianChart1.Visible = false;
           
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

            this.pnlSideBottom.Controls.Clear();
            this.pnlSideBottom.Controls.Add(cartesianChart1);
            cartesianChart1.Visible = true;

        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSideBottom_Click(object sender, EventArgs e)
        {

        }

        private void txtBestSeller_TextChanged(object sender, EventArgs e)
        {

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
            lblTotalOrder.Text =  totalOrders;
        }

        private void bunifuDropdown1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(bunifuDropdown1.Text == "Last 30 Days")
            {
                lblProuductSales.Text = "30 days";
            }
            else if(bunifuDropdown1.Text == "Last 15 days")
            {
                lblProuductSales.Text = "15 days";
            }
            else if (bunifuDropdown1.Text == "Last 7 days")
            {
                lblProuductSales.Text = "7 days";
            }
        }

        private void cmbProductSold_SelectedValueChanged(object sender, EventArgs e)
        {
            string itemName = cmbProductSold.Text;
            gProc.ProcGetProductSoldCount(itemName, lblProductSold);
        }
    }

}
