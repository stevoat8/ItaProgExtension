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
        //Input e.g.: –e –a aes –f C:\Users\user\Desktop\aFile.txt 
        static void Main(string[] args)
        {
            string operationInput = args[0];
            string algorithmInput = args[2];
            string fileName = args[4];


            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("file name");
            }
            else if (File.Exists(fileName) == false)
            {
                throw new FileNotFoundException(fileName);
            }

            CryptoTransformOperationsEnum operation;
            switch (operationInput) //Watch out for "–" does not equal "-" !!!
            {
                case "–e":
                    operation = CryptoTransformOperationsEnum.Encrypt;
                    break;
                case "–d":
                    operation = CryptoTransformOperationsEnum.Decrypt;
                    break;
                default:
                    throw new ArgumentNullException("The passed crypto transform operation is invalid");
            }

            SymetricAlgorithmsEnum algorithm;
            switch (algorithmInput) //Watch out for "–" does not equal "-" !!!
            {
                case "aes":
                    algorithm = SymetricAlgorithmsEnum.AES;
                    break;
                case "des":
                    algorithm = SymetricAlgorithmsEnum.DES;
                    break;
                case "rc2":
                    algorithm = SymetricAlgorithmsEnum.RC2;
                    break;
                default:
                    throw new ArgumentNullException("The passed algorithm is invalid");
            }

            string operationStr = Enum.GetName(operation.GetType(), operation);
            string algorithmStr = Enum.GetName(algorithm.GetType(), algorithm);
            Console.WriteLine($"{algorithmStr}-{operationStr} file \"{fileName}\"");

            StartCryptoProcessing(fileName, operation, algorithm);
        }

        private static void StartCryptoProcessing(
            string fileName, CryptoTransformOperationsEnum operation, SymetricAlgorithmsEnum algorithm)
        {
            SymmetricAlgorithm algo;
            switch (algorithm)
            {
                case SymetricAlgorithmsEnum.AES:
                    algo = new AesManaged();
                    break;
                case SymetricAlgorithmsEnum.DES:
                    algo = new DESCryptoServiceProvider();
                    break;
                case SymetricAlgorithmsEnum.RC2:
                    algo = new RC2CryptoServiceProvider();
                    break;
                default:
                    throw new Exception();
            }

            byte[] key = GetCredencial("Key", algo.BlockSize);
            byte[] iv = GetCredencial("IV", algo.BlockSize);
            algo.IV = iv;
            algo.Key = key;

            byte[] transformedFile = CryptoTransform(fileName, operation, algo);

            string newFileName = "";
            if (operation == CryptoTransformOperationsEnum.Decrypt)
            {
                newFileName = Path.Combine(
                    Path.GetDirectoryName(fileName),
                    Path.GetFileNameWithoutExtension(fileName));
                newFileName = GetNextFileName(newFileName);
            }
            else if (operation == CryptoTransformOperationsEnum.Encrypt)
            {
                newFileName = fileName + ".enc";
            }

            File.WriteAllBytes(newFileName, transformedFile);
        }

        private static byte[] CryptoTransform(
            string fileName, CryptoTransformOperationsEnum operation, SymmetricAlgorithm algo)
        {
            byte[] orignalFile = File.ReadAllBytes(fileName);
            byte[] processedFile;

            ICryptoTransform cryptoTransform;
            switch (operation)
            {
                case CryptoTransformOperationsEnum.Encrypt:
                    cryptoTransform = algo.CreateEncryptor();
                    break;
                case CryptoTransformOperationsEnum.Decrypt:
                    cryptoTransform = algo.CreateDecryptor();
                    break;
                default:
                    throw new Exception();
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(orignalFile, 0, orignalFile.Length);
                }
                algo.Dispose();
                processedFile = memoryStream.ToArray();
            }
            return processedFile;
        }

        private static byte[] GetCredencial(string type, int blockSize)
        {
            SecureString credencial;
            do
            {
                Console.Write("\t" + type + ": ");
                credencial = GetSecureInput();
                Console.WriteLine();
            } while (credencial.Length == 0);

            byte[] salt = Encoding.UTF8.GetBytes("randomSalt");
            var generator = new Rfc2898DeriveBytes(ConvertToUnsecureString(credencial), salt, 10000);

            return generator.GetBytes(blockSize / 8);
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
                    fileName = fileName.Replace($"{extension}", $"({++i}){extension}");
                else
                    fileName = fileName.Replace($"({i}){extension}", $"({++i}){extension}");
            }

            return fileName;
        }
    }

    enum CryptoTransformOperationsEnum
    {
        Encrypt, Decrypt
    }

    enum SymetricAlgorithmsEnum
    {
        AES, DES, RC2
    }
}
