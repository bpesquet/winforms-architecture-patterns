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
    /// Test class for MainPresenter
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
        }

        [TestInitialize]
        public void Initialize()
        {
            presenter = new MainPresenter(mockLoginRepository, mockMainView);
        }

        [TestMethod]
        public void MainPresenter_InitView()
        {
            Assert.AreEqual(stubLoginList, mockMainView.LoginList);
            Assert.AreEqual(0, mockMainView.SelectedLoginIndex);
            Assert.AreEqual("Edit", mockMainView.EditButtonText);
            Assert.AreEqual(true, mockMainView.TitleReadOnly);
            Assert.AreEqual(true, mockMainView.UsernameReadOnly);
            Assert.AreEqual(true, mockMainView.PasswordReadOnly);
            Assert.AreEqual(true, mockMainView.UrlReadOnly);
            Assert.AreEqual(false, mockMainView.CancelButtonVisible);
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
            Assert.AreEqual(selectedLogin.Username, mockMainView.Username);
            Assert.AreEqual(selectedLogin.Password, mockMainView.Password);
            Assert.AreEqual(selectedLogin.Url, mockMainView.Url);
        }

        [TestMethod]
        public void MainPresenter_LoginEditedAction_Save()
        {
            presenter.LoginEditedAction(); // Switch to edit mode

            // Check UI elements's states
            Assert.AreEqual("Save", mockMainView.EditButtonText);
            Assert.AreEqual(false, mockMainView.TitleReadOnly);
            Assert.AreEqual(false, mockMainView.UsernameReadOnly);
            Assert.AreEqual(false, mockMainView.PasswordReadOnly);
            Assert.AreEqual(false, mockMainView.UrlReadOnly);
            Assert.AreEqual(true, mockMainView.CancelButtonVisible);

            Login selectedLogin = stubLoginList[1];

            var mockView = Mock.Get(mockMainView);
            mockView.Setup(view => view.SelectedLoginIndex).Returns(1);
            mockView.Setup(view => view.SelectedLogin).Returns(selectedLogin);
            mockView.Setup(view => view.Title).Returns(selectedLogin.Title);
            mockView.Setup(view => view.Username).Returns(selectedLogin.Username);
            mockView.Setup(view => view.Password).Returns(selectedLogin.Password);
            mockView.Setup(view => view.Url).Returns(selectedLogin.Url);

            presenter.LoginEditedAction(); // Save the updated login

            var mockRepo = Mock.Get(mockLoginRepository);
            // Check that Update method is called on repository with the right parameter
            mockRepo.Verify(repository => repository.Update(selectedLogin));
            // Check UI elements's states
            Assert.AreEqual("Edit", mockMainView.EditButtonText);
            Assert.AreEqual(true, mockMainView.TitleReadOnly);
            Assert.AreEqual(true, mockMainView.UsernameReadOnly);
            Assert.AreEqual(true, mockMainView.PasswordReadOnly);
            Assert.AreEqual(true, mockMainView.UrlReadOnly);
            Assert.AreEqual(false, mockMainView.CancelButtonVisible);
        }

        [TestMethod]
        public void MainPresenter_LoginEditedAction_Cancel()
        {
            presenter.LoginEditedAction(); // Switch to edit mode

            Login selectedLogin = stubLoginList[1];
            var mockView = Mock.Get(mockMainView);
            mockView.Setup(view => view.SelectedLoginIndex).Returns(1);
            mockView.Setup(view => view.SelectedLogin).Returns(selectedLogin);
            
            presenter.EditCancelledAction(); // Cancel edit

            var mockRepo = Mock.Get(mockLoginRepository);
            // Check that Update method is never called on repository
            mockRepo.Verify(repository => repository.Update(It.IsAny<Login>()), Times.Never());
            // Check that setters are called on view
            mockView.VerifySet(view => view.Title = selectedLogin.Title);
            mockView.VerifySet(view => view.Username = selectedLogin.Username);
            mockView.VerifySet(view => view.Password = selectedLogin.Password);
            mockView.VerifySet(view => view.Url = selectedLogin.Url);
            // Check UI elements's states
            Assert.AreEqual("Edit", mockMainView.EditButtonText);
            Assert.AreEqual(true, mockMainView.TitleReadOnly);
            Assert.AreEqual(true, mockMainView.UsernameReadOnly);
            Assert.AreEqual(true, mockMainView.PasswordReadOnly);
            Assert.AreEqual(true, mockMainView.UrlReadOnly);
            Assert.AreEqual(false, mockMainView.CancelButtonVisible);
        }
    }
}
