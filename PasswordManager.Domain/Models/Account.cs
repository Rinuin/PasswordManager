using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Domain.Models
{
    public class Account : DomainObject
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }
    }
}
