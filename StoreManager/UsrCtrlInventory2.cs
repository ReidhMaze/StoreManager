using StoreManager.Database;
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
    public partial class UsrCtrlInventory2 : UserControl
    {
        private DBConnect dbConnection;

        public UsrCtrlInventory2(DBConnect dbConnection)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
        }
    }
}
