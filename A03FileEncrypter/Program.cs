using Fclp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A03FileEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[1];
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("file name");
            }
            else if (File.Exists(fileName) == false)
            {
                throw new FileNotFoundException(fileName);
            }

            //Watch out for "–" does not equal "-" !!!
            string operation = args[0];
            if (operation == "–e")
            {
                Console.WriteLine($"Encrypt file \"{fileName}\"");
                Transform(CryptoOperationsEnum.Encrypt, fileName);
            }
            else if (operation == "–d")
            {
                Console.WriteLine($"Decrypt file \"{fileName}\"");
                Transform(CryptoOperationsEnum.Decrypt, fileName);
            }
            else
            {
                throw new ArgumentNullException("No Crypto transform operation passed");
            }
        }

        private static void Transform(CryptoOperationsEnum operation, string fileName)
        {
            byte[] transformedFile = CrytoTransform(fileName, operation);

            string newFileName = "";
            if (operation == CryptoOperationsEnum.Decrypt)
            {
                newFileName = Path.Combine(
                    Path.GetDirectoryName(fileName),
                    Path.GetFileNameWithoutExtension(fileName));
                newFileName = GetNextFileName(newFileName);
            }
            else if (operation == CryptoOperationsEnum.Encrypt)
            {
                newFileName = fileName + ".enc";
            }

            File.WriteAllBytes(newFileName, transformedFile);
        }

        private static byte[] CrytoTransform(string fileName, CryptoOperationsEnum operation)
        {
            byte[] key = GetCredencial("Key");
            byte[] iv = GetCredencial("IV");

            byte[] orignalFile = File.ReadAllBytes(fileName);
            byte[] processedFile;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (AesManaged aes = new AesManaged())
                {
                    aes.IV = iv;
                    aes.Key = key;

                    ICryptoTransform cryptoTransform;
                    switch (operation)
                    {
                        case CryptoOperationsEnum.Encrypt:
                            cryptoTransform = aes.CreateEncryptor();
                            break;
                        case CryptoOperationsEnum.Decrypt:
                            cryptoTransform = aes.CreateDecryptor();
                            break;
                        default:
                            throw new Exception();
                    }

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(orignalFile, 0, orignalFile.Length);
                    }
                    processedFile = memoryStream.ToArray();
                }
            }

            return processedFile;
        }

        private static byte[] GetCredencial(string type)
        {
            SecureString credencial;
            do
            {
                Console.Write(type + ": ");
                credencial = GetSecureInput();
                Console.WriteLine();
            } while (credencial.Length == 0);

            byte[] salt = Encoding.UTF8.GetBytes("randomSalt");
            var generator = new Rfc2898DeriveBytes(ConvertToUnsecureString(credencial), salt, 10000);
            return generator.GetBytes(16);
        }

        private static SecureString GetSecureInput()
        {
            SecureString input = new SecureString();

            // Erstes Zeichen einlesen
            ConsoleKeyInfo nextKey = Console.ReadKey(true);

            while (nextKey.Key != ConsoleKey.Enter)
            {
                // Backspace gedrückt?
                if (nextKey.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        // Letztes Zeichen entfernen
                        input.RemoveAt(input.Length - 1);

                        // Letzten * entfernen
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }
                }
                else
                {
                    // Zeichen an den SecureString anhängen
                    input.AppendChar(nextKey.KeyChar);
                    Console.Write("*");
                }

                nextKey = Console.ReadKey(true);
            }
            input.MakeReadOnly();
            return input;
        }

        private static string ConvertToUnsecureString(SecureString secureString)
        {
            // Speicherbereich für den Klartext
            IntPtr unmanagedString = IntPtr.Zero;
            string unsecureString;
            try
            {
                // Sicheren String in Klartext kopieren
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                // Klartext in String umwandeln
                unsecureString = Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Klartext wieder aus dem Arbeitsspeicher löschen
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            return unsecureString;
        }

        private static string GetNextFileName(string fileName)
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

    enum CryptoOperationsEnum
    {
        Encrypt, Decrypt
    }
}
