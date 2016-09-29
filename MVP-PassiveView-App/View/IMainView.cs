using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace MVP_PassiveView_App.View
{
    public interface IMainView
    {
        List<Login> LoginList { get; set; }

        int SelectedLoginIndex { get; set; }

        Login SelectedLogin { get; }

        string Title { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Url { get; set; }

        string EditButtonText { get; set; }

        bool TitleReadOnly { get; set; }

        bool UsernameReadOnly { get; set; }

        bool PasswordReadOnly { get; set; }

        bool UrlReadOnly { get; set; }

        bool CancelButtonVisible { get; set; }

        Presenter.MainPresenter Presenter { set; }
    }
}
