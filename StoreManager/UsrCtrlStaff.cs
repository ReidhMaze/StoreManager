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

        private Boolean addStaff, updateStaff, deleteStaff;
        private Staff selectedStaff = null;
        private Dictionary<int, Staff> staffDict = new Dictionary<int, Staff>();

        public UsrCtrlStaff(DBConnect dbConnection, GlobalProcedure gproc)
        {
            InitializeComponent();
            StandardView(true);
            this.dbConnection = dbConnection;
            this.gProc = gproc;
            this.gProc.FncConnectToDatabase();
            InitializeDataGrid();
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

            if (selectedStaff == null && !addStaff) return;

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

                        var confirmAdd = MessageBox.Show("Are you sure you want to add this Staff?", "Confirm Add", MessageBoxButtons.YesNo);

                        if (confirmAdd == DialogResult.Yes)
                        {
                            //insert gproc for adding staff
                            gProc.ProcAddStaff(firstName, lastName, birthDate, gender, emailAddress, mobileNumber, username, password, role);
                            //MessageBox.Show("Staff Successfully Added");
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
                        this.gProc.ProcDeleteStaffById(selectedStaff.Id);
                        MessageBox.Show("Staff Successfully Deleted");
                        ClearAll();
                    }
                    else
                    {
                        return;
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            List<Staff> staffList = gProc.ProcSelectStaff();
            this.staffDict.Clear();
            this.DataGridStaff.RowCount = staffList.Count();

            for(int i = 0; i < staffList.Count; i++)
            {
                this.staffDict.Add(i, staffList[i]);
                this.DataGridStaff.Rows[i].Cells[0].Value = staffList[i].FirstName;
                this.DataGridStaff.Rows[i].Cells[1].Value = staffList[i].LastName;
                this.DataGridStaff.Rows[i].Cells[2].Value = staffList[i].BirthDate.ToShortDateString();
                this.DataGridStaff.Rows[i].Cells[3].Value = staffList[i].Gender;
                this.DataGridStaff.Rows[i].Cells[4].Value = staffList[i].EmailAddress;
                this.DataGridStaff.Rows[i].Cells[5].Value = staffList[i].MobileNum;
                this.DataGridStaff.Rows[i].Cells[6].Value = staffList[i].Username;
                this.DataGridStaff.Rows[i].Cells[7].Value = staffList[i].RoleType;
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
            this.BtnSubmit.Enabled = true;

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

        private void DataGridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0) return;

            staffDict.TryGetValue(e.RowIndex, out selectedStaff);

            this.TxtFirstName.Text = selectedStaff.FirstName;
            this.TxtLastName.Text = selectedStaff.LastName;
            this.TxtEmailAddress.Text = selectedStaff.EmailAddress;
            this.TxtMobileNumber.Text = selectedStaff.MobileNum;
            this.TxtUsername.Text = selectedStaff.Username;
            this.TxtPassword.Text = selectedStaff.Password;
            this.TxtConfirmPassword.Text = selectedStaff.Password;
            this.CmbGender.SelectedIndex = this.CmbGender.Items.IndexOf(selectedStaff.Gender);
            this.CmbRole.SelectedIndex = this.CmbRole.Items.IndexOf(selectedStaff.RoleType);
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
