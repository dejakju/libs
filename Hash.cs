using System;
using System.Security.Cryptography;
using System.Text;

namespace libs
{
    public static class Hash
    {
        /// <summary>
        /// Calculates the MD5 hash of a string
        /// <input="input">The string to be hashed</input>
        /// </summary>
        public static string MD5(string input)
        {
            MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
            return BitConverter.ToString(hash.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Calculates the SHA1 hash of a string
        /// <input="input">The string to be hashed</input>
        /// </summary>
        public static string SHA1(string input)
        {
            SHA1CryptoServiceProvider hash = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(hash.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Encrypt a string with the TrippleDES method
        /// <input="input">The string to decrypt</input>
        /// <input="key">The key to encrypt the input string with</input>
        /// <input="initVector">The initialization vector</input>
        /// </summary>
        public static byte[] Encrypt(byte[] input, string key, string initVector = "26436535")
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

            des.BlockSize = 64;
            des.Key = md5.ComputeHash(utf8.GetBytes(key));
            des.IV = ASCIIEncoding.ASCII.GetBytes(initVector);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            ICryptoTransform trans = des.CreateEncryptor(des.Key, des.IV);
            return trans.TransformFinalBlock(input, 0, input.Length);
        }

        /// <summary>
        /// Decrypts a string with the TrippleDES method
        /// <input="input">The string to decrypt</input>
        /// <input="key">The key to decrypt the input string with</input>
        /// <input="initVector">The initialization vector</input>
        /// </summary>
        public static byte[] Decrypt(byte[] input, string key, string initVector = "26436535")
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

            des.BlockSize = 64;
            des.Key = md5.ComputeHash(utf8.GetBytes(key));
            des.IV = ASCIIEncoding.ASCII.GetBytes(initVector);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            ICryptoTransform trans = des.CreateDecryptor(des.Key, des.IV);
            return trans.TransformFinalBlock(input, 0, input.Length);
        }
		
        /// <summary>
        /// Encodes a string into a byte array
        /// <input="inputString">The string to be encoded</input>
        /// </summary>
        public static byte[] Encode(string inputString)
        {
            return UTF8Encoding.Default.GetBytes(inputString);
        }

        /// <summary>
        /// Decodes a byte array back into a string
        /// <input="byteArray">The byte array to be decoded</input>
        /// </summary>
        public static string Decode(byte[] byteArray)
        {
            return UTF8Encoding.Default.GetString(byteArray);
        }

    }

}