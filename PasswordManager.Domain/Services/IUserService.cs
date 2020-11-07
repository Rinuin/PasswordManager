using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services
{
    interface IUserService : IDataService<User>
    {
            Task<User> GetByUsername(string username);
            Task<User> GetByEmail(string email);
    }
}
