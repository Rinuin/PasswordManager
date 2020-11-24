using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Encryption
{
    public class EncryptionXOR
    {
		private readonly string _encryptionKey;
        public EncryptionXOR()
        {
			_encryptionKey = "C%j8^xz)@X6<$sv5)@X6<$^>|QA5&23*,Z?";
		}
		public string encryptXOR(string data)
		{
			int dataLen = data.Length;
			int keyLen = _encryptionKey.Length;
			char[] output = new char[dataLen];

			for (int i = 0; i < dataLen; ++i)
			{
				output[i] = (char)(data[i] ^ _encryptionKey[i % keyLen]);
			}

			return new string(output);
		}

	}
}
