using StoreManager.CustomComponentsLinker;
using StoreManager.Database;
using StoreManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreManager
{
    public partial class UsrCtrlInventory2 : UserControl
    {
        private DBConnect dbConnection;
        string imgLocation;
        Boolean needImage = true;

        public UsrCtrlInventory2(DBConnect dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            StandardView();
        }

        private void BtnUploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "Images Files (*.jpg;*.jpeg;*.png;*.bmp;*.gif;)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                imgLocation = ofdPic.FileName;
                ImgItem.Image = new Bitmap(ofdPic.FileName);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

            string currentDir = Environment.CurrentDirectory;
            string imageFolderDir = Path.Combine(currentDir, "..\\..\\ProductImages");

            try 
            {
                if (needImage == true)
                {
                    File.Copy(imgLocation, Path.Combine(imageFolderDir, Path.GetFileName(imgLocation)), true);
                    StandardView();
                }
                else
                {
                    StandardView();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error Message" + err.Message);
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            EnabledAll();
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            EnabledAll();
        }

        private void BtnRemoveProduct_Click(object sender, EventArgs e)
        {
            StandardView();
            BtnSubmit.Enabled = true;
            needImage = false;
        }

        private void BtnRestock_Click(object sender, EventArgs e)
        {
            EnabledAll();
            TxtName.Enabled = false;
            TxtRemainingStocks.Enabled = false;
            TxtQuantity.Visible = true;
            LblQuantity.Visible = true;
            needImage = false;
        }

        private void BtnDisposeStock_Click(object sender, EventArgs e)
        {
            StandardView();
            TxtQuantity.Visible = true;
            LblQuantity.Visible = true;
            BtnSubmit.Enabled = true;
            needImage = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            StandardView();
        }

        private void TbNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^.0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void TbInvSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^a-zA-Z0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        public void StandardView()
        {
            TxtName.Enabled = false;
            CmbSizeInfo.Enabled = false;
            CmbTypeInfo.Enabled = false;
            TxtPrice.Enabled = false;
            TxtCostPerItem.Enabled = false;
            TxtRestockThreshold.Enabled = false;
            TxtRemainingStocks.Enabled = false;
            TxtSupplier.Enabled = false;
            BtnUploadImg.Enabled = false;
            BtnSubmit.Enabled = false;
            TxtQuantity.Visible = false;
            LblQuantity.Visible = false;
            ClearAll();
        }

        public void EnabledAll()
        {
            TxtName.Enabled = true;
            CmbSizeInfo.Enabled = true;
            CmbTypeInfo.Enabled = true;
            TxtPrice.Enabled = true;
            TxtCostPerItem.Enabled = true;
            TxtRestockThreshold.Enabled = true;
            TxtRemainingStocks.Enabled = true;
            TxtSupplier.Enabled = true;
            BtnUploadImg.Enabled = true;
            BtnSubmit.Enabled = true;
            TxtQuantity.Visible = false;
            LblQuantity.Visible = false;
            ClearAll();
        }

        public void ClearAll()
        {
            TxtName.Clear();
            CmbSizeInfo.Items.Clear();
            CmbTypeInfo.Items.Clear();
            TxtPrice.Clear();
            TxtCostPerItem.Clear();
            TxtRestockThreshold.Clear();
            TxtRemainingStocks.Clear();
            TxtSupplier.Clear();
            TxtQuantity.Clear();
            ImgItem.Image = null;
            imgLocation = null;
            needImage = true;
        }

    }
}

