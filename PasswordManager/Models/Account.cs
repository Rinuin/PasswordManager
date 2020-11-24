using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PasswordManager.Domain.Models
{
    [Table("Accounts")]
    public class Account : DomainObject
    {
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }
        //public Account(string accountName, string email, string username, string password, string notes) =>
        //    (AccountName, Email, Username, Password, Notes) = (accountName, email, username, password, notes);
    }
}
