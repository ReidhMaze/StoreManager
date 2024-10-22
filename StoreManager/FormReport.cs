using StoreManagerDb;
using StoreManager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManager
{
    public partial class FormReport : Form
    {
        string customers;
        private GlobalProcedure gProc = new GlobalProcedure();
        string analyticsReportLocation = Path.Combine(Environment.CurrentDirectory, "..\\..\\AnalyticsReport.rpt");

        public FormReport(GlobalProcedure gProc)
        {
            this.gProc = gProc;
            InitializeComponent();
            SetUpAnalyticsReport();
        }

      private void SetUpAnalyticsReport()
        {
            double sales = gProc.FncTotalSales();
            string convert = sales.ToString();


            AnalyticsReport report = new AnalyticsReport();



            report.SetParameterValue(0, convert);
            report.SetParameterValue(1, gProc.FncGetTotalCustomers());
            report.SetParameterValue(2, gProc.FncTotalOrder().ToString());
            report.SetParameterValue(3, gProc.FncGetCurrentSales().ToString());
            report.SetParameterValue(4, gProc.FncGetCurrentCustomers().ToString());
            report.SetParameterValue(5, gProc.FncGetTopProducts(0).ToString());
            report.SetParameterValue(6, gProc.FncGetTopProducts(1).ToString());
            report.SetParameterValue(7, gProc.FncGetTopProducts(2).ToString());
            report.SetParameterValue(8, gProc.FncGetTopProducts(3).ToString());
            report.SetParameterValue(9, gProc.FncGetTopProducts(4).ToString());


            crystalReportViewer1.ReportSource = report;
           crystalReportViewer1.Refresh();


        }
    }
}
