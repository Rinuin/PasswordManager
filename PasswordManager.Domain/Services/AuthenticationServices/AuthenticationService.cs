using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDataService<User> _userService;

        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IDataService<User> userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Register(string email, string username, string password, string confirmPassword)
        {
            bool success = false;

            if(password == confirmPassword)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword
                };

                await _userService.Create(user);
            }

            return success;
        }

        public async Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
