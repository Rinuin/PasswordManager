using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data.ManageData
{
    public class UserDataManager : DataManager<User> 
    {

        public async Task<User> GetByEmail(string email)
        {

            return await _context.Users
                    .FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users
                    .FirstOrDefaultAsync(a => a.Username == username);
        }

    }
}
