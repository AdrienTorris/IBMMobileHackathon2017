namespace IBM.Books.IdentityCore.Infrastructure.Helpers
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class CryptographyHelper
    {
        private const string _USER_PASSWORD_KEY = "E546C8DF278CD5931069B522E695D4F2";

        public static string EncryptUserPassword(string clearPassword)
        {
            return EncryptString(clearPassword, _USER_PASSWORD_KEY);
        }

        public static string DecryptUserPassword(string encryptedPassword)
        {
            return DecryptString(encryptedPassword, _USER_PASSWORD_KEY);
        }

        private static string EncryptString(string text, string keyString)
        {
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        private static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }

        //        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        //        {
        //            // Check arguments.
        //            if (plainText == null || plainText.Length <= 0)
        //                throw new ArgumentNullException("plainText");
        //            if (Key == null || Key.Length <= 0)
        //                throw new ArgumentNullException("Key");
        //            if (IV == null || IV.Length <= 0)
        //                throw new ArgumentNullException("IV");
        //            byte[] encrypted;
        //            // Create an Aes object
        //            // with the specified key and IV.
        //            using (Aes aesAlg = Aes.Create())
        //            {
        //                aesAlg.Key = Key;
        //                aesAlg.IV = IV;

        //                // Create a decrytor to perform the stream transform.
        //                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
        //, aesAlg.IV);

        //                // Create the streams used for encryption.
        //                using (MemoryStream msEncrypt = new MemoryStream())
        //                {
        //                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
        //, encryptor, CryptoStreamMode.Write))
        //                    {
        //                        using (StreamWriter swEncrypt = new StreamWriter(
        //csEncrypt))
        //                        {

        //                            //Write all data to the stream.
        //                            swEncrypt.Write(plainText);
        //                        }
        //                        encrypted = msEncrypt.ToArray();
        //                    }
        //                }
        //            }


        //            // Return the encrypted bytes from the memory stream.
        //            return encrypted;

        //        }

        //        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        //        {
        //            // Check arguments.
        //            if (cipherText == null || cipherText.Length <= 0)
        //                throw new ArgumentNullException("cipherText");
        //            if (Key == null || Key.Length <= 0)
        //                throw new ArgumentNullException("Key");
        //            if (IV == null || IV.Length <= 0)
        //                throw new ArgumentNullException("IV");

        //            // Declare the string used to hold
        //            // the decrypted text.
        //            string plaintext = null;

        //            // Create an Aes object
        //            // with the specified key and IV.
        //            using (Aes aesAlg = Aes.Create())
        //            {
        //                aesAlg.Key = Key;
        //                aesAlg.IV = IV;

        //                // Create a decrytor to perform the stream transform.
        //                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
        //, aesAlg.IV);

        //                // Create the streams used for decryption.
        //                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
        //                {
        //                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
        //, decryptor, CryptoStreamMode.Read))
        //                    {
        //                        using (StreamReader srDecrypt = new StreamReader(
        //csDecrypt))
        //                        {

        //                            plaintext = srDecrypt.ReadToEnd();
        //                        }
        //                    }
        //                }

        //            }

        //            return plaintext;

        //        }
    }
}