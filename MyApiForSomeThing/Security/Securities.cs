using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace MyApiForSomeThing.Security
{
    public class Securities
    {
        private static Random random = new Random();
        // Create Random Salt For UserAccount Password
        public string Salt()
        {
            var builder = new StringBuilder();
            string salt = "";

            using (RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[10];
                for (int i = 0; i < 10; i++)
                {
                    Rng.GetBytes(data);
                    char c = (char) data[0];
                    builder.Append(c);
                }

                salt = builder.ToString();
            }

            return salt;
        }

        // Encode string to Md5
        public string Md5Crypto(string input)
        {
            var builder = new StringBuilder();
            string md5cript = "";
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(new UTF8Encoding().GetBytes(input));
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                md5cript = builder.ToString();
            }

            return md5cript;
        }

        // Encode 

        // Create Token with something input
        public string CreateToken(string inputUser, string inputPassword)
        {
            var builder1 = new StringBuilder();
            var builder2 = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                var char1 = inputUser[random.Next(0, inputUser.Length)];
                builder1.Append(char1);
                var char2 = inputPassword[random.Next(0, inputPassword.Length)];
                builder2.Append(char2);
            }

            var token1 = builder1.ToString();
            var token2 = builder2.ToString();
            var token = token1 + token2;
            return token;
        }
    }
}
