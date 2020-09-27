using PosSystem.DataAcessLayer;
using PosSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosSystem.Services
{
    /// <summary>
    /// DataAccessService is an entity used for the purpose of acessing database.
    /// </summary>
    public class DataAccessService : IDataAccessService
    {
        private readonly PosDbContext _posDbContext;

        public DataAccessService(PosDbContext posDbContext)
        {
            _posDbContext = posDbContext;
        }

        /// <summary>
        /// GetUserByEmailId is the method used for the purpose ofr getting user by email id.
        /// </summary>
        /// <param name="emailId">Email Id</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public User GetUserByEmailId(string emailId, string password)
        {
            return _posDbContext.User.SingleOrDefault(user => user.UserEmailId == emailId && user.Password == password);
        }
    }
}
