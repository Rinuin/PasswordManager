using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Encryption
{
    public static class Encryptor
    {

        private static EncryptionXOR _encryption = null;

        public static EncryptionXOR EncryptionInstance
        {
            get
            {
                if (_encryption == null)
                {
                    _encryption = new EncryptionXOR();
                }
                return _encryption;
            }
        }


    }
}
