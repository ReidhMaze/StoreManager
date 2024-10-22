using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace StoreManager
{
    public partial class Report : Form
    {
        AnalyticsReport report = new AnalyticsReport();
        public Report()
        {
            InitializeComponent();
            
            addReportDetails();

        }

        private void addReportDetails()
        {
            
            report.SetParameterValue(0, "");

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();

        }
    }
}
