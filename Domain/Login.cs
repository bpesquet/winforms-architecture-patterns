using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// POCO class representing a user login
    /// </summary>
    public class Login
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }

        public Login(int id, string title, string username, string password, string url)
        {
            Id = id;
            Title = title;
            Username = username;
            Password = password;
            Url = url;
        }

        public Login() { } // Needed for XML serialization

        public override string ToString()
        {
            return Title;
        }
    }
}
