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

namespace StoreManager
{
    public partial class UsrCtrlAnalytics2 : UserControl
    {
        public UsrCtrlAnalytics2()
        {
            InitializeComponent();
            addSalesToGrid();
            addChartValues();
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

        public void addChartValues()
        {

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 3000;

            
            DateTime dt1 = new DateTime(2024, 10, 24);
            DateTime dt2 = new DateTime(2024, 10, 25);
            DateTime dt3 = new DateTime(2024, 10, 26);
            DateTime dt4 = new DateTime(2024, 10, 27);
            DateTime dt5 = new DateTime(2024, 10, 28);
            DateTime dt6 = new DateTime(2024, 10, 29);

            this.chart1.Series["Sales"].Points.AddXY( dt1, 1000);
            this.chart1.Series["Sales"].Points.AddXY( dt2, 1500);
            this.chart1.Series["Sales"].Points.AddXY(dt3, 900);
            this.chart1.Series["Sales"].Points.AddXY(dt4, 800);
            this.chart1.Series["Sales"].Points.AddXY(dt5, 2000);
            this.chart1.Series["Sales"].Points.AddXY(dt6, 2500);


            this.chart1.Series["Customers"].Points.AddXY(dt1, 90);
            this.chart1.Series["Customers"].Points.AddXY(dt2, 100);
            this.chart1.Series["Customers"].Points.AddXY(dt3, 10);
            this.chart1.Series["Customers"].Points.AddXY(dt4, 150);
            this.chart1.Series["Customers"].Points.AddXY(dt5, 30);
            this.chart1.Series["Customers"].Points.AddXY(dt6, 70);


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
                    PointGeometrySize = 15
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
                //LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            /*  cartesianChart1.Series.Add(new LineSeries
              {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = System.Windows.Media.Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = System.Windows.Media.Brushes.Gray
              });*/

            //modifying any series values will also animate and update the chart
            cartesianChart1.Series[2].Values.Add(5d);

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
    }

}
