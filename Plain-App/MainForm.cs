using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Domain;

namespace Plain_App
{
    public partial class MainForm : Form
    {
        private List<Login> loginList; // List of logins
        private string filePath; // Path to login file on disk
        private bool isEditMode; // Indicates if logins are displayed or edited

        public MainForm()
        {
            InitializeComponent();

            // Load logins from file
            filePath = @"passwords.xml";
            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                loginList = (List<Login>)new XmlSerializer(typeof(List<Login>)).Deserialize(reader);
                reader.Close();
            }
            else
            {
                // Fill the list with sample data
                loginList = new List<Login>();
                loginList.Add(new Login(1, "BlaBlaCar", "bpesquet", "azerty", "https://www.blablacar.fr"));
                loginList.Add(new Login(2, "OpenClassrooms", "bpesquet", "qwerty", "https://openclassrooms.com"));
                loginList.Add(new Login(3, "Deezer", "bpesquet", "123456", "https://www.deezer.com"));
            }
            // Link view to login list
            loginLB.DataSource = loginList;
            loginLB.SelectedIndex = 0; // List should always contain items

            isEditMode = false; // Display mode
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

                // Save the list
                StreamWriter writer = new StreamWriter(filePath);
                new XmlSerializer(typeof(List<Login>)).Serialize(writer, loginList);
                writer.Close();

                // Refresh login view in case a title has been modified
                loginLB.DataSource = null;
                loginLB.DataSource = loginList;
                loginLB.SelectedIndex = 0; // List should always contain items

                editBtn.Text = "Edit";
            }
            else
            {
                editBtn.Text = "Save";
            }

            isEditMode = !isEditMode; // Switch edit mode
            // Switch control states
            titleTB.ReadOnly = !titleTB.ReadOnly;
            usernameTB.ReadOnly = !usernameTB.ReadOnly;
            passwordTB.ReadOnly = !passwordTB.ReadOnly;
            urlTB.ReadOnly = !urlTB.ReadOnly;
            cancelBtn.Visible = !cancelBtn.Visible;    
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Reset login details
            Login selectedLogin = (Login)loginLB.SelectedItem;
            titleTB.Text = selectedLogin.Title;
            usernameTB.Text = selectedLogin.Username;
            passwordTB.Text = selectedLogin.Password;
            urlTB.Text = selectedLogin.Url;

            editBtn.Text = "Edit";
            isEditMode = !isEditMode; // Switch edit mode
            // Switch control states
            titleTB.ReadOnly = !titleTB.ReadOnly;
            usernameTB.ReadOnly = !usernameTB.ReadOnly;
            passwordTB.ReadOnly = !passwordTB.ReadOnly;
            urlTB.ReadOnly = !urlTB.ReadOnly;
            cancelBtn.Visible = !cancelBtn.Visible;
        }
    }
}
