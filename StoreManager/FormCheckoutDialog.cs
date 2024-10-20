using Bunifu.UI.WinForms;
using CustomComponents;
using Mysqlx.Crud;
using StoreObjects;
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
    public partial class FormCheckoutDialog : Form
    {

        private double total;
        private double cashInput;
        private int lastSelectionIdxFromRight = -1;
        private bool orderConfirmed = false;

        public FormCheckoutDialog(List<CartItem> cartItems)
        {
            InitializeComponent();
            InitializeGrid(cartItems);
            this.total = ComputeTotal(cartItems);

            this.TbTotal.Text = "₱" + total.ToString("#,###.00");
            this.TbCash.Focus();
        }

        public void InitializeGrid(List<CartItem> cartItems)
        {
            this.DataGridReceipt.RowCount = cartItems.Count;

            for(int i = 0; i < cartItems.Count; i++)
            {
                this.DataGridReceipt.Rows[i].Cells["ItemName"].Value = cartItems[i].Name;
                this.DataGridReceipt.Rows[i].Cells["Quantity"].Value = "X" + cartItems[i].Qty;
                this.DataGridReceipt.Rows[i].Cells["Subtotal"].Value = "₱" + (cartItems[i].Price * cartItems[i].Qty).ToString("#,###.00");
            }
        }

        public double ComputeTotal(List<CartItem> cartItems)
        {

            double total = 0;

            for(int i = 0;i < cartItems.Count;i++)
            {
                total += (cartItems[i].Qty * cartItems[i].Price);
            }

            return total;
        }

        private void TbCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            TextBox tb = sender as TextBox;
            if (e.KeyChar == '.' && tb.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            this.lastSelectionIdxFromRight = TbCash.Text.Length - TbCash.SelectionStart;
        }

        private void TbCash_TextChange(object sender, EventArgs e)
        {

            string cashText = this.TbCash.Text.Replace(",", "");

            string[] splitCash = cashText.Split('.');
            string wholeNums = splitCash[0];

            if (wholeNums.Length == 0) return;

            string decimals = (splitCash.Length > 1) ? "." + splitCash[1] : "";

            string separatedWholeNums = "";
            for (int i = wholeNums.Length - 1, counter = 0; i >= 0; i--, counter++)
            {
                if (counter > 0 && counter % 3 == 0)
                {
                    separatedWholeNums = "," + separatedWholeNums;
                }
                separatedWholeNums = wholeNums[i] + separatedWholeNums;
            }

            this.TbCash.Text = separatedWholeNums + decimals;

            try
            {
                this.TbCash.SelectionStart = this.TbCash.Text.Length - lastSelectionIdxFromRight;
            }catch(Exception ex)
            {

            }
            

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if(TbCash.Text.Length == 0 || TbCash.Text[0] == '.') { 
                MessageBox.Show("Invalid Input");
                return;
            }

            this.cashInput = double.Parse(TbCash.Text.Replace(",", ""));

            if(this.cashInput < this.total)
            {
                MessageBox.Show("Insufficient cash");
                return;
            }

            MessageBox.Show("Change: " + "₱" + (cashInput - total).ToString("#,###.00"));

            this.orderConfirmed = true;

            this.Hide();
        }

        public bool OrderConfirmed
        {
            get { return orderConfirmed; }
        }
        
    }
}