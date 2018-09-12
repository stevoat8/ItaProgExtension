using Fclp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A03FileEncrypter
{
    class Program
    {
        private const string encryptedFileExt = ".enc";

        static void Main(string[] args)
        {
            string fileName = File.Exists(args[1]) ? args[1] : "";
            if (string.IsNullOrWhiteSpace(args[1]))
            {
                throw new ArgumentNullException("file name");
            }
            else if (File.Exists(args[1]) == false)
            {
                throw new FileNotFoundException(fileName);
            }

            //Watch out for "–" does not equal "-"!
            switch (args[0])
            {
                case "–encrypt":
                    Encrypt(fileName);
                    break;
                case "–decrypt":
                    Decrypt(fileName);
                    break;
                default:
                    Console.WriteLine("Invalid Command " + args[0].Substring(1, args[0].Length - 1));
                    break;
            }
        }

        private static void Encrypt(string origFileName)
        {
            Console.WriteLine("Encrypt file " + origFileName);

            byte[] key = GetCredencialBytes("Key");
            byte[] iv = GetCredencialBytes("IV");

            byte[] orignalFile = File.ReadAllBytes(origFileName);
            byte[] encryptedFile;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.IV = iv;
                    aes.Key = key;
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(orignalFile, 0, orignalFile.Length);
                    }
                    encryptedFile = memoryStream.ToArray();
                }
            }
            
            origFileName = getNextFileName(origFileName + encryptedFileExt);
            File.WriteAllBytes(origFileName + encryptedFileExt, encryptedFile);
        }

        private static void Decrypt(string encryptedfileName)
        {
            Console.WriteLine("Decrypt file " + encryptedfileName);

            byte[] key = GetCredencialBytes("Key");
            byte[] iv = GetCredencialBytes("IV");

            byte[] encryptedFile = File.ReadAllBytes(encryptedfileName);
            byte[] orignalFile;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedFile, 0, encryptedFile.Length);
                    }
                    orignalFile = memoryStream.ToArray();
                }
            }
            string origFileName = Path.Combine(
                Path.GetDirectoryName(encryptedfileName), 
                Path.GetFileNameWithoutExtension(encryptedfileName));
            origFileName = getNextFileName(origFileName);
            File.WriteAllBytes(origFileName, orignalFile);
        }

        private static byte[] GetCredencialBytes(string credencial)
        {
            string input;
            do
            {
                Console.Write(credencial + ": ");
                input = Console.ReadLine();
                input = (input?.Length > 0) ? input : "";
            } while (input == "");

            byte[] salt = Encoding.UTF8.GetBytes("randomSalt");
            var generator = new Rfc2898DeriveBytes(input, salt, 10000);

            return generator.GetBytes(16);
        }

        private static string getNextFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            int i = 0;
            while (File.Exists(fileName))
            {
                if (i == 0)
                    fileName = fileName.Replace(extension, "(" + ++i + ")" + extension);
                else
                    fileName = fileName.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
            }

            return fileName;
        }
    }
}
