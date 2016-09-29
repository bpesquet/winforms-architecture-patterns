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

namespace MVP_PassiveView_App.View
{
    public partial class MainForm : Form, View.IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<Login> LoginList
        {
            get { return (List<Login>)this.loginLB.DataSource; }
            set { this.loginLB.DataSource = value; }
        }

        public Login SelectedLogin
        {
            get { return (Login)loginLB.SelectedItem; }
        }

        public int SelectedLoginIndex
        {
            get { return loginLB.SelectedIndex; }
            set { loginLB.SelectedIndex = value; }
        }

        public string Title
        {
            get { return titleTB.Text; }
            set { titleTB.Text = value; }
        }

        public string Username { 
            get { return usernameTB.Text; } 
            set { usernameTB.Text = value; } 
        }

        public string Password
        {
            get { return passwordTB.Text; }
            set { passwordTB.Text = value; }
        }

        public string Url
        {
            get { return urlTB.Text; }
            set { urlTB.Text = value; }
        }

        public string EditButtonText
        {
            get { return editBtn.Text; }
            set { editBtn.Text = value; }
        }

        public bool TitleReadOnly
        {
            get { return titleTB.ReadOnly; }
            set { titleTB.ReadOnly = value; }
        }

        public bool UsernameReadOnly
        {
            get { return usernameTB.ReadOnly; }
            set { usernameTB.ReadOnly = value; }
        }

        public bool PasswordReadOnly
        {
            get { return passwordTB.ReadOnly; }
            set { passwordTB.ReadOnly = value; }
        }

        public bool UrlReadOnly
        {
            get { return urlTB.ReadOnly; }
            set { urlTB.ReadOnly = value; }
        }

        public bool CancelButtonVisible
        {
            get { return cancelBtn.Visible; }
            set { cancelBtn.Visible = value; }
        }

        public Presenter.MainPresenter Presenter { private get;  set; }

        private void loginLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.LoginSelectedAction();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Presenter.LoginEditedAction();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.EditCancelledAction();
        }
    }
}
