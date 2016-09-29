using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain;
using DAL;

namespace Layered_App
{
    public partial class MainForm : Form
    {
        private ILoginRepository loginRepository; // data source for logins
        private bool isEditMode; // Indicates if logins are displayed or edited

        public MainForm(ILoginRepository loginRepository)
        {
            InitializeComponent();

            this.loginRepository = loginRepository;
            isEditMode = false;  // Display mode

            RefreshLoginListView(); // Initial refresh
        }

        private void loginLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loginLB.SelectedItem != null)
            {
                // Display login details
                Login selectedLogin = (Login)loginLB.SelectedItem;
                titleTB.Text = selectedLogin.Title;
                usernameTB.Text = selectedLogin.Username;
                passwordTB.Text = selectedLogin.Password;
                urlTB.Text = selectedLogin.Url;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Update the login
                Login selectedLogin = (Login)loginLB.SelectedItem;
                selectedLogin.Title = titleTB.Text;
                selectedLogin.Username = usernameTB.Text;
                selectedLogin.Password = passwordTB.Text;
                selectedLogin.Url = urlTB.Text;

                // Save it
                loginRepository.Update(selectedLogin);

                // Refresh login view in case a title has been modified
                RefreshLoginListView();
            }
            SwitchEditMode();    
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Reset login details
            Login selectedLogin = (Login)loginLB.SelectedItem;
            titleTB.Text = selectedLogin.Title;
            usernameTB.Text = selectedLogin.Username;
            passwordTB.Text = selectedLogin.Password;
            urlTB.Text = selectedLogin.Url;

            SwitchEditMode();
        }

        /// <summary>
        /// Switch between display and edit modes
        /// </summary>
        private void SwitchEditMode()
        {
            isEditMode = !isEditMode;
            editBtn.Text = (isEditMode) ? "Save" : "Edit";
            titleTB.ReadOnly = !titleTB.ReadOnly;
            usernameTB.ReadOnly = !usernameTB.ReadOnly;
            passwordTB.ReadOnly = !passwordTB.ReadOnly;
            urlTB.ReadOnly = !urlTB.ReadOnly;
            cancelBtn.Visible = !cancelBtn.Visible;
        }

        /// <summary>
        /// Refresh the login list view
        /// </summary>
        private void RefreshLoginListView()
        {
            loginLB.DataSource = null;
            loginLB.DataSource = loginRepository.GetAll();
            loginLB.SelectedIndex = 0; // List should always contain items
        }
    }
}
