using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Domain;

namespace MVP_PassiveView_App.Presenter
{
    public class MainPresenter
    {
        private ILoginRepository loginRepository;
        private View.IMainView view;
        private bool isEditMode; // Indicates if logins are displayed or edited

        public MainPresenter(ILoginRepository loginRepository, View.IMainView mainView)
        {
            this.loginRepository = loginRepository;
            view = mainView;
            mainView.Presenter = this;
            isEditMode = false;  // Display mode

            RefreshLoginListView(); // Initial refresh
        }

        /// <summary>
        /// Handles login selection
        /// </summary>
        public void LoginSelectedAction()
        {
            if (view.SelectedLoginIndex >= 0)
            {
                Login login = view.SelectedLogin;
                view.Title = login.Title;
                view.Username = login.Username;
                view.Password = login.Password;
                view.Url = login.Username;
            }
        }

        /// <summary>
        /// Handles login edition or save
        /// </summary>
        public void LoginEditedAction()
        {
            if (isEditMode)
            {
                // Update the login
                Login selectedLogin = view.SelectedLogin;
                selectedLogin.Title = view.Title;
                selectedLogin.Username = view.Username;
                selectedLogin.Password = view.Password;
                selectedLogin.Url = view.Url;

                // Save it
                loginRepository.Update(selectedLogin);

                // Refresh login view in case a title has been modified
                RefreshLoginListView();
            }
            SwitchEditMode();
        }

        /// <summary>
        /// Handles edit cancellation
        /// </summary>
        public void EditCancelledAction()
        {
            // Reset login details
            Login selectedLogin = view.SelectedLogin;
            view.Title = selectedLogin.Title;
            view.Username = selectedLogin.Username;
            view.Password = selectedLogin.Password;
            view.Url = selectedLogin.Url;

            SwitchEditMode();
        }

        /// <summary>
        /// Refresh the login list view
        /// </summary>
        private void RefreshLoginListView()
        {
            view.LoginList = null;
            view.LoginList = loginRepository.GetAll();
            view.SelectedLoginIndex = 0; // List should always contain items
        }

        /// <summary>
        /// Switch between display and edit modes
        /// </summary>
        private void SwitchEditMode()
        {
            isEditMode = !isEditMode;
            view.EditButtonText = (isEditMode) ? "Save" : "Edit";
            view.TitleReadOnly = !view.TitleReadOnly;
            view.UsernameReadOnly = !view.UsernameReadOnly;
            view.PasswordReadOnly = !view.PasswordReadOnly;
            view.UrlReadOnly = !view.UrlReadOnly;
            view.CancelButtonVisible = !view.CancelButtonVisible;
        }
    }
}
