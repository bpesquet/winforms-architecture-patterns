using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain;
using DAL;
using MVP_PassiveView_App.View;
using MVP_PassiveView_App.Presenter;

namespace Tests
{
    /// <summary>
    /// Description résumée pour TestMainPresenter
    /// </summary>
    [TestClass]
    public class TestMainPresenter
    {
        private List<Login> stubLoginList = new List<Login> {
                new Login(1, "Hacker News", "spesquet", "xyz", "https://news.ycombinator.com/"),
                new Login(2, "Reddit", "spesquet", "abc", "https://www.reddit.com/")
        };

        private IMainView mockMainView;
        private ILoginRepository mockLoginRepository;
        private MainPresenter presenter;

        public TestMainPresenter()
        {
            mockMainView = Mock.Of<IMainView>(view =>
               view.LoginList == new List<Login>());
            mockLoginRepository = Mock.Of<ILoginRepository>(repository =>
                repository.GetAll() == stubLoginList);

            presenter = new MainPresenter(mockLoginRepository, mockMainView);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MainPresenter_InitialRefresh()
        {
            Assert.AreEqual(stubLoginList, mockMainView.LoginList);
        }

        [TestMethod]
        public void MainPresenter_LoginSelectedAction()
        {
            Login selectedLogin = stubLoginList[0];
            var mockView = Mock.Get(mockMainView);
            mockView.Setup(view => view.SelectedLoginIndex).Returns(0);
            mockView.Setup(view => view.SelectedLogin).Returns(selectedLogin);

            presenter.LoginSelectedAction();

            Assert.AreEqual(selectedLogin.Title, mockMainView.Title);
        }

        [TestMethod]
        public void MainPresenter_LoginEditedAction()
        {
            Login selectedLogin = stubLoginList[1];
            var mockView = Mock.Get(mockMainView);
            mockView.Setup(view => view.SelectedLoginIndex).Returns(1);
            mockView.Setup(view => view.SelectedLogin).Returns(selectedLogin);

            presenter.LoginEditedAction();

            Assert.AreEqual("Save", mockMainView.EditButtonText);
            Assert.AreEqual(false, mockMainView.TitleReadOnly);
            Assert.AreEqual(false, mockMainView.UsernameReadOnly);
            // ...
            //Assert.AreEqual(selectedLogin.Title, mockMainView.Title);
        }
    }
}
