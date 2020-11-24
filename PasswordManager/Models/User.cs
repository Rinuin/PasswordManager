using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PasswordManager.Domain.Models
{
    [Table("Users")]
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public User()
        {
            Accounts = new HashSet<Account>();
        }

        //public User(string email, string username, string passwordHash) =>
            //(Email, Username, PasswordHash, Accounts) = (email, username, passwordHash, new HashSet<Account>());
    }
}
