using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace DAL
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Retrieve all logins
        /// </summary>
        /// <returns></returns>
        List<Login> GetAll();

        /// <summary>
        /// Save a login
        /// </summary>
        /// <param name="login">The login to be saved</param>
        void Save(Login login);
    }
}
