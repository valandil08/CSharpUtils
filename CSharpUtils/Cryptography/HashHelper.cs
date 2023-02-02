using CSharpUtils.Enum;
using System.Security.Cryptography;
using System.Text;

namespace CSharpUtils.Cryptography
{
    public static class HashHelper
    {
        public static string HashString(string text, string salt, HashAlg algorithm)
        {
            byte[] textData = Encoding.UTF8.GetBytes(text);
            byte[] saltData = Encoding.UTF8.GetBytes(salt);
            byte[] result = HashByteArray(textData, saltData, algorithm);

            return Convert.ToBase64String(result);
        }

        public static byte[] HashByteArray(byte[] data, byte[] salt, HashAlg algorithm)
        {
            byte[] array = data.Concat(salt).ToArray();

            switch (algorithm)
            {
                case HashAlg.MD5:
                    using (MD5 hashAlg = MD5.Create())
                    {
                        return hashAlg.ComputeHash(array);
                    }

                case HashAlg.SHA1:
                    using (SHA1 hashAlg = new SHA1Managed())
                    {
                        return hashAlg.ComputeHash(array);
                    }

                case HashAlg.SHA256:
                    using (SHA256 hashAlg = new SHA256Managed())
                    {
                        return hashAlg.ComputeHash(array);
                    }

                case HashAlg.SHA384:
                    using (SHA384 hashAlg = new SHA384Managed())
                    {
                        return hashAlg.ComputeHash(array);
                    }

                default: // HashAlg.SHA512
                    using (SHA512 hashAlg = new SHA512Managed())
                    {
                        return hashAlg.ComputeHash(array);
                    }
            }
        }
    }
}
