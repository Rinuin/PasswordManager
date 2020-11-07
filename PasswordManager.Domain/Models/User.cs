using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Domain.Models
{
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
