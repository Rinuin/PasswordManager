using Microsoft.EntityFrameworkCore;
using PasswordManager.Data.Encryption;
using PasswordManager.Data.Exceptions;
using PasswordManager.Domain.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Data.ManageData
{
    public class AccountDataManager : DataManager<Account>
    {
        private readonly EncryptionXOR encryptor = Encryptor.EncryptionInstance;
        public enum AccountCreationResult
        {
            Success,
            AccountNameAlreadyExists
        }

        public async Task<Account> GetByAccountName(string accountName)
        {
            var e =  await _context.Accounts
                    .FirstOrDefaultAsync(a => a.AccountName == accountName);
            if (e != null)
            {
                e.AccountName = encryptor.encryptXOR(e.AccountName);
                e.Email = encryptor.encryptXOR(e.Email);
                e.Username = encryptor.encryptXOR(e.Username);
                e.Password = encryptor.encryptXOR(e.Password);
                e.Notes = encryptor.encryptXOR(e.Notes);
            }

            return e;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsByOwnerId(int owenrId)
        {
            //var entities = await Task.FromResult(_context.Accounts.Where(a=>a.OwnerId == owenrId).ToListAsync());
            var entities = await _context.Accounts.Where(a => a.OwnerId == owenrId).ToListAsync();
            foreach (Account e in entities)
            {
                e.AccountName = encryptor.encryptXOR(e.AccountName);
                e.Email = encryptor.encryptXOR(e.Email);
                e.Username = encryptor.encryptXOR(e.Username);
                e.Password = encryptor.encryptXOR(e.Password);
                e.Notes = encryptor.encryptXOR(e.Notes);
            }
            return entities;
        }

        public async Task<AccountCreationResult> CreateAccount(string accountName, string email, string username, string password, string notes)
        {
            AccountCreationResult result = AccountCreationResult.Success;

            if (accountName == "" || email == "" || username == "" || password == "")
            {
                throw new MissingValueException();
            }

            Account accountWithName = await GetByAccountName(accountName);
            if (accountWithName != null)
            {
                result = AccountCreationResult.AccountNameAlreadyExists;
            }

            if (result == AccountCreationResult.Success)
            {
                
                Account account = new Account
                {
                    AccountName = encryptor.encryptXOR(accountName),
                    Email = encryptor.encryptXOR(email),
                    Username = encryptor.encryptXOR(username),
                    Password = encryptor.encryptXOR(password),
                    Notes = encryptor.encryptXOR(notes),
                    OwnerId = PasswordManager.Properties.Settings.Default.LoggedInUserId
                };

                await this.Create(account);
            }

            return result;
        }

    }
}
