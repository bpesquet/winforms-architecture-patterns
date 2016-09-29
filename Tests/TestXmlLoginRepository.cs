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
        public void Test_GetAll()
        {
            List<Login> loginList = loginRepository.GetAll();

            Assert.AreEqual(3, loginList.Count);
        }

        [TestMethod]
        public void Test_Get()
        {
            Login login = loginRepository.Get(2);

            Assert.AreEqual(2, login.Id);
            Assert.AreEqual("OpenClassrooms", login.Title);
            Assert.AreEqual("bpesquet", login.Username);
            Assert.AreEqual("qwerty", login.Password);
            Assert.AreEqual("https://openclassrooms.com", login.Url);
        }

        [TestMethod]
        public void Test_Update()
        {
            string newTitle = "Spotify";
            Login login = loginRepository.Get(3);
            login.Title = newTitle;
            loginRepository.Update(login);

            Assert.AreEqual(newTitle, loginRepository.Get(3).Title);
        }
    }
}
