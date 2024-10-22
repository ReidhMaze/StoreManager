using CustomComponents;
using StoreManagerDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManager
{
    public partial class FormSettings : Form
    {

        private GlobalProcedure gProc = new GlobalProcedure();
        private int currentTax;
        private double taxInput;

        public FormSettings()
        {
            InitializeComponent();
            this.gProc.FncConnectToDatabase();
            this.currentTax = (int)(gProc.FncGetLatestTaxRate() * 100);
            this.TbTaxRateOut.Text = currentTax.ToString() + "%";
        }

        private void TbTaxRateIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Disallow the key press
            }

            
        }

        private void TbTaxRateIn_TextChange(object sender, EventArgs e)
        {
            if (TbTaxRateIn.Text == String.Empty) return;

            taxInput = double.Parse(TbTaxRateIn.Text) / 100.0;
            Debug.WriteLine(taxInput);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(TbTaxRateIn.Text == String.Empty || (taxInput > 1))
            {
                MessageBox.Show("Invalid input");
            }

            this.gProc.ProcAddTaxRate(taxInput);

            MessageBox.Show("New tax rate set");

            this.currentTax = (int)(gProc.FncGetLatestTaxRate() * 100);
            this.TbTaxRateOut.Text = currentTax.ToString() + "%";

            this.TbTaxRateIn.Text = "";
            this.taxInput = 0;


        }
    }
}
