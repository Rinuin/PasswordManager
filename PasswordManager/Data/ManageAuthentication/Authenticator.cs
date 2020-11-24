using Microsoft.AspNet.Identity;
using PasswordManager.Data.Exceptions;
using PasswordManager.Data.ManageData;
using PasswordManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data.ManageAuthentication
{
    public class Authenticator
    {

        //public User CurrentUser { get; private set; }

        //public bool IsLoggedIn => CurrentUser != null;

        public enum RegistrationResult
        {
            Success,
            PasswordsDoNotMatch,
            EmailAlreadyExists,
            UsernameAlreadyExists
        }

        private readonly UserDataManager _userDataManager;

        private readonly IPasswordHasher _passwordHasher;

        public Authenticator()
        {
            _userDataManager = new UserDataManager();
            _passwordHasher = new PasswordHasher();
        }

        public async Task<User> Login(string username, string password)
        {
            User storedUser = await _userDataManager.GetByUsername(username);

            if (username == "" || password == "")
            {
                throw new MissingValueException();
            }

            if (storedUser == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            PasswordManager.Properties.Settings.Default.LoggedInUserId = storedUser.Id;

            return storedUser;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (email == "" || username == "" || password == "" || confirmPassword == "")
            {
                throw new MissingValueException();
            }

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            User emailUser = await _userDataManager.GetByEmail(email);
            if (emailUser != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            User usernameUser = await _userDataManager.GetByUsername(username);
            if (usernameUser != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User
                {
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPassword
                };

                await _userDataManager.Create(user);
            }

            return result;
        }

    }
}
