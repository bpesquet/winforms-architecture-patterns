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
        /// Retrieve a login based on its id
        /// </summary>
        /// <param name="id">The login id</param>
        /// <returns>The login or null if not found</returns>
        Login Get(int id);

        /// <summary>
        /// Update a login
        /// </summary>
        /// <param name="login">The login to be saved</param>
        void Update(Login login);
    }
}
