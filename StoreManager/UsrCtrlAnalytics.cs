using Bunifu.UI.WinForms;
using StoreManagerDb;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;
using LiveCharts.Definitions.Charts;
using System.Globalization;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;

namespace StoreManager
{
    public partial class UsrCtrlAnalytics : UserControl
    {
        private GlobalProcedure gProc = new GlobalProcedure();


        public UsrCtrlAnalytics(GlobalProcedure gProc)
        {
            InitializeComponent();
            
            this.gProc = gProc;
            loadDefaults();
            

        }

        public void loadDefaults()
        {
            displayTotalOrders();
            displayTotalSales();
            gProc.ProcAddCmbProductSoldItems(cmbProductSold);
            gProc.ProcAddCmbProductSoldItems(cmbProductSales);
            gProc.ProcGetTotalCustomers(lblTotalCustomer);
            displaySalesPercentageDifference();
            displayCustomersPercentageDifference();
            defaultProductSoldSalesValue();
            defaultGraphValue();
            getTopProducts();
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
        public void addChartSales(BunifuPanel pnl, List<String> list, List<string> days, string month)
        {
            List<string> convert = list;

            List<double> sales = convert.Select(Convert.ToDouble).ToList();

            LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            cartesianChart1.Width = pnl.Width;
            cartesianChart1.Height = pnl.Height;
            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.Visible = false;
            cartesianChart1.BackColor = Color.Transparent;

          

            if (sales != null && sales.Count > 0)
            {
                cartesianChart1.Series = new SeriesCollection
                {
                   
                    new LineSeries { 
                        Title = "Sales",
                        Values = new ChartValues<double>(sales) }
                };
            }
            else
            {
                // Optional: Handle the case where sales data is empty
                MessageBox.Show("No sales data available for the last 30 days.");
                return; // Exit the method if there's no data
            }


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = month,
                Labels = days

            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C", new CultureInfo("en-PH"))
            });



            cartesianChart1.LegendLocation = LegendLocation.Right;

           

            cartesianChart1.DataClick += CartesianChart1OnDataClick;

            pnl.Controls.Clear();
            pnl.Controls.Add(cartesianChart1);
            cartesianChart1.Visible = true;
        }

        public void addChartCustomers(BunifuPanel pnl, List<String> list, List<string> days, string month)
        {
            List<string> convert = list;

            List<double> customers = convert.Select(Convert.ToDouble).ToList();



            LiveCharts.WinForms.CartesianChart cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            cartesianChart1.Width = pnl.Width;
            cartesianChart1.Height = pnl.Height;
            cartesianChart1.Visible = false;
            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.BackColor = Color.Transparent;



            if (customers != null && customers.Count > 0)
            {
                cartesianChart1.Series = new SeriesCollection
                {

                    new LineSeries {
                        Title = "Customers",
                        Values = new ChartValues<double>(customers) }
                };
            }
            else
            {
                // Optional: Handle the case where sales data is empty
                MessageBox.Show("No customers data available for the last 30 days.");
                return; // Exit the method if there's no data
            }


            cartesianChart1.AxisX.Add(new Axis
            {
                Title = month,
                Labels = days

            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Customers",
                LabelFormatter = value => value.ToString("N0")
            });



            cartesianChart1.LegendLocation = LegendLocation.Right;



            cartesianChart1.DataClick += CartesianChart1OnDataClick;

            pnl.Controls.Clear();
            pnl.Controls.Add(cartesianChart1);
            cartesianChart1.Visible = true;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }


        public void displayTotalSales()
        {
            double sales = gProc.FncTotalSales();
           
            string formatted = String.Format("{0:###,###.00}", sales);
            lblTotalSales.Text = "₱" + formatted;

        }

        public void displayTotalOrders()
        {
            int orders = gProc.FncTotalOrder();
            string totalOrders = orders.ToString();
            lblTotalOrder.Text = totalOrders;
        }


        public void getTopProducts()
        {
            gProc.ProcGetTopProducts(product1, 0, pbProduct1);
            gProc.ProcGetTopProducts(product2, 1, pbProduct2);
            gProc.ProcGetTopProducts(product3, 2, pbProduct3);
            gProc.ProcGetTopProducts(product4, 3, pbProduct4);
            gProc.ProcGetTopProducts(product5, 4, pbProduct5);
        }




      

        private void cmbProductSales_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string itemName = cmbProductSales.Text;
            gProc.ProcGetProductSales(itemName, lblProductSales);
        }

        public void defaultProductSoldSalesValue()
        {
            string itemName = gProc.addDefaultProductToProductSoldSales();
            cmbProductSales.Text = itemName;
            cmbProductSold.Text = itemName;
            gProc.ProcGetProductSales(itemName, lblProductSales);
            gProc.ProcGetProductSoldCount(itemName, lblProductSold);
        }
        private void cmbProductSold_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string itemName = cmbProductSold.Text;
            gProc.ProcGetProductSoldCount(itemName, lblProductSold);
        }

        private void cmbDays_SelectedValueChanged(object sender, EventArgs e)
        {
            displayCustomersPercentageDifference();
            displaySalesPercentageDifference();
            if(cmbDays.SelectedIndex == 0)
            {
                addChartSales(pnlMiddle,gProc.FncGetLast30DaysSales(), gProc.FncGetLast30Days(), gProc.FncGetMonth());
                addChartCustomers(pnlBottom,gProc.FncGetLast30DaysCustomers(), gProc.FncGetLast30Days(), gProc.FncGetMonth());
              
                //addChartCustomers(pnlMiddle);
            }
            else if(cmbDays.SelectedIndex == 1)
            {
                addChartSales(pnlMiddle, gProc.FncGetLast15DaysSales(), gProc.FncGetLast15Days(), gProc.FncGetMonth());
                addChartCustomers(pnlBottom, gProc.FncGetLast15DaysCustomers(), gProc.FncGetLast15Days(), gProc.FncGetMonth());

            }
            else
            {
                addChartSales(pnlMiddle, gProc.FncGetLast7DaysSales(), gProc.FncGetLast7Days(), gProc.FncGetMonth());
                addChartCustomers(pnlBottom, gProc.FncGetLast7DaysCustomers(), gProc.FncGetLast7Days(), gProc.FncGetMonth());
            }
        }

        public void defaultGraphValue()
        {
            cmbDays.Text = "30 days";
            addChartSales(pnlMiddle, gProc.FncGetLast30DaysSales(), gProc.FncGetLast30Days(), gProc.FncGetMonth());
            addChartCustomers(pnlBottom, gProc.FncGetLast30DaysCustomers(), gProc.FncGetLast30Days(), gProc.FncGetMonth());
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        public void displaySalesPercentageDifference()
        {
            gProc.ProcGetSalesPercentageDifference(lblSalesPercentageDifference);
        }

        public void displayCustomersPercentageDifference()
        {
            gProc.ProcGetCustomersPercentageDifference(lblCustomerPercentageDifference);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDefaults();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport(gProc);
            report.ShowDialog();
        }
    }
}
