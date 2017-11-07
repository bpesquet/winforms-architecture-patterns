using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using DAL;

namespace Tests
{
    [TestClass]
    public class TestXmlLoginRepository
    {
        private XmlLoginRepository loginRepository;

        public TestXmlLoginRepository()
        {
            loginRepository = new XmlLoginRepository();
        }

        [TestMethod]
        public void XmlLoginRepository_GetAll()
        {
            List<Login> loginList = loginRepository.GetAll();

            Assert.AreEqual(3, loginList.Count);
        }

        [TestMethod]
        public void XmlLoginRepository_Get()
        {
            Login login = loginRepository.Get(2);

            Assert.AreEqual(2, login.Id);
            Assert.AreEqual("OpenClassrooms", login.Title);
            Assert.AreEqual("bpesquet", login.Username);
            Assert.AreEqual("qwerty", login.Password);
            Assert.AreEqual("https://openclassrooms.com", login.Url);
        }

        [TestMethod]
        public void XmlLoginRepository_Get_NonExistent()
        {
            Assert.IsNull(loginRepository.Get(4));
        }

        [TestMethod]
        public void XmlLoginRepository_Update()
        {
            string newTitle = "Spotify";
            Login login = loginRepository.Get(3);
            login.Title = newTitle;
            loginRepository.Update(login);

            Assert.AreEqual(newTitle, loginRepository.Get(3).Title);
        }

        [TestMethod]
        public void XmlLoginRepository_Update_NonExistent()
        {
            Login login = new Login(4, "", "", "", "");
            loginRepository.Update(login);

            Assert.IsNull(loginRepository.Get(4));
        }
    }
}
