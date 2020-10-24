using PasswordManager.Data;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repositories
{
    class UserRepository
    {
        private PasswordManagerDatabseContext passDb;
        public UserRepository(PasswordManagerDatabseContext passDb)
        {
            this.passDb = passDb;
        }

        public Task<UserEntity> GetAllUserAsync()
        {
            return Task.FromResult(passDb.UserEntities.FirstOrDefault());
        }
    }
}
