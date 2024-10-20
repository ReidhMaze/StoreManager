using LaundrySystem;
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
    public partial class FormLogin : Form
    {

        private string userNameIn = "";
        private string passIn = "";
        private GlobalProcedure gProc = new GlobalProcedure();

        public FormLogin()
        {
            InitializeComponent();
            this.gProc.FncConnectToDatabase();
        }

        private void TbUsername_TextChanged(object sender, EventArgs e)
        {
            this.userNameIn = this.TbUsername.Text;
        }

        private void TbPassword_TextChanged(object sender, EventArgs e)
        {
            this.passIn = this.TbPassword.Text;
        }

        private void TbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = "^[a-zA-Z0-9_.-]*$";

            if (!char.IsControl(e.KeyChar))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), pattern))
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                LogIn();
            }
        }

        private void TbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = "^[a-zA-Z0-9_.-]*$";

            if (!char.IsControl(e.KeyChar))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), pattern))
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                LogIn();
            }
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        public void LogIn()
        {
            this.BtnLogin.Text = "LOGGING IN";

            int loggedStaffId = this.gProc.FncGetStaffId(userNameIn, passIn);
            MainWindow mainWindow = new MainWindow();

            this.BtnLogin.Text = "LOG IN";

            if (loggedStaffId == -1)
            {
                MessageBox.Show("Incorrect username or password");
                ClearFields();
                return;
            }

            ClearFields();
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
            this.TbUsername.Focus();
        }

        private void ClearFields()
        {
            this.TbUsername.Text = "";
            this.TbPassword.Text = "";
        }
    }
}
