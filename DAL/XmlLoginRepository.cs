using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Domain;

namespace DAL
{
    public class XmlLoginRepository : ILoginRepository
    {
        private List<Login> loginList;
        private string filePath;

        public XmlLoginRepository()
        {
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
        }

        public List<Login> GetAll()
        {
            return loginList;
        }

        public void Save(Login login)
        {
            // Save the list
            StreamWriter writer = new StreamWriter(filePath);
            new XmlSerializer(typeof(List<Login>)).Serialize(writer, loginList);
            writer.Close();
        }
    }
}
