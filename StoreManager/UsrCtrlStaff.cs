using StoreManager.CustomComponentsLinker;
using StoreManager.Database;
using LaundrySystem;
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
using StoreObjects;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace StoreManager
{
    public partial class UsrCtrlStaff : UserControl
    {
        private DBConnect dbConnection;
        private GlobalProcedure gProc;

        Boolean addStaff, updateStaff, deleteStaff;

        public UsrCtrlStaff(DBConnect dbConnection, GlobalProcedure gproc)
        {
            InitializeComponent();
            StandardView(true);
            this.dbConnection = dbConnection;
            this.gProc = gproc;
            this.gProc.FncConnectToDatabase();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = TxtFirstName.Text;
            string lastName = TxtLastName.Text;
            string mobileNumber = TxtMobileNumber.Text;
            string emailAddress = TxtEmailAddress.Text;
            string gender = CmbGender.Text;
            DateTime birthDate = DpBirthdate.Value.Date;
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;
            string role = CmbRole.Text;

            try
            {
                if (addStaff)
                {
                    if (string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(role))
                    {
                        MessageBox.Show("Missing Inputs", "Error");
                        return;
                    }
                    else if (password != confirmPassword)
                    {
                        MessageBox.Show("Password does not match", "Error");
                        return;
                    }
                    else if (mobileNumber.Length < 11)
                    {
                        MessageBox.Show("Invalid Mobile Number", "Error");
                        return;
                    }
                    else
                    {

                        gProc.ProcAddStaff(firstName, lastName, birthDate, gender, emailAddress, mobileNumber, username, password, role);

                        var confirmAdd = MessageBox.Show("Are you sure you want to add this Staff?", "Confirm Add", MessageBoxButtons.YesNo);

                        if (confirmAdd == DialogResult.Yes)
                        {
                            //insert gproc for adding staff
                            MessageBox.Show("Staff Successfully Added");
                            ClearAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (updateStaff)
                {
                    if (string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(role))
                    {
                        MessageBox.Show("Missing Inputs", "Error");
                        return;
                    }
                    else if (password != confirmPassword)
                    {
                        MessageBox.Show("Password does not match", "Error");
                        return;
                    }
                    else if (mobileNumber.Length < 11)
                    {
                        MessageBox.Show("Invalid Mobile Number", "Error");
                        return;
                    }
                    else
                    {
                        var confirmUpdate = MessageBox.Show("Are you sure you want to change the information for this Staff?", "Confirm Update", MessageBoxButtons.YesNo);

                        if (confirmUpdate == DialogResult.Yes)
                        {
                            //insert gproc for updating staff
                            MessageBox.Show("Staff Successfully Updated");
                            ClearAll();
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                if (deleteStaff)
                {
                    var confirmDelete = MessageBox.Show("Are you sure you want to remove this Staff?", "Confirm Delete", MessageBoxButtons.YesNo);

                    if (confirmDelete == DialogResult.Yes)
                    {
                        //insert gproc for deleting staff
                        MessageBox.Show("Staff Successfully Deleted");
                        ClearAll();
                    }
                    else
                    {
                        return;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStaffMode();
        }

        private void AddStaffMode()
        {
            EnabledAll(true);

            addStaff = true;
            updateStaff = false;
            deleteStaff = false;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateStaffMode();
        }

        private void UpdateStaffMode()
        {
            EnabledAll(false);

            addStaff = false;
            updateStaff = true;
            deleteStaff = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteStaffMode();
        }

        private void DeleteStaffMode()
        {
            StandardView(false);

            addStaff = false;
            updateStaff = false;
            deleteStaff = true;
        }

        private void TbNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^0-9\s]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        public void StandardView(bool clear)
        {
            TxtFirstName.Enabled = false;
            TxtLastName.Enabled = false;
            TxtMobileNumber.Enabled = false;
            TxtEmailAddress.Enabled = false;
            CmbGender.Enabled = false;
            DpBirthdate.Enabled = false;
            TxtUsername.Enabled = false;
            TxtPassword.Enabled = false;
            TxtConfirmPassword.Enabled = false;
            CmbRole.Enabled = false;
            BtnSubmit.Enabled = false;
            if (clear) ClearAll();
        }

        public void EnabledAll(bool clear)
        {
            TxtFirstName.Enabled = true;
            TxtLastName.Enabled = true;
            TxtMobileNumber.Enabled = true;
            TxtEmailAddress.Enabled = true;
            CmbGender.Enabled = true;
            DpBirthdate.Enabled = true;
            TxtUsername.Enabled = true;
            TxtPassword.Enabled = true;
            TxtConfirmPassword.Enabled = true;
            CmbRole.Enabled = true;
            BtnSubmit.Enabled = true;
            if (clear) ClearAll();
        }

        public void ClearAll()
        {
            TxtFirstName.Clear();
            TxtLastName.Clear();
            TxtMobileNumber.Clear();
            TxtEmailAddress.Clear();
            CmbGender.SelectedIndex = -1;
            //DpBirthdate.CustomFormat = "";
            //DpBirthdate.Format = DateTimePickerFormat.Custom;
            TxtUsername.Clear();
            TxtPassword.Clear();
            TxtConfirmPassword.Clear();
            CmbRole.SelectedIndex = -1;
        }
    }
}
