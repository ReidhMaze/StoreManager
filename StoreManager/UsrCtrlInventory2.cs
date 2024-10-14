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
    public partial class UsrCtrlInventory2 : UserControl
    {
        private DBConnect dbConnection;
        string imgLocation;

        public UsrCtrlInventory2(DBConnect dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
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
            File.Copy(imgLocation, Path.Combine(@"C:\\Users\\Administrator\\Source\\Repos\\StoreManagerReiVersion\\StoreManager\\ProductImages\", Path.GetFileName(imgLocation)), true);
        }
    }
}
