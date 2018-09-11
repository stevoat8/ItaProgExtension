using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "source",
                "repos");

            Console.WriteLine("Verzeichnis:\t" + dirPath);

            //Hier kann der hash-Algorithmus gewählt werden.
            HashAlgorithm algo = GetHashAlgorithm(HashAlgoEnum.sha256);

            //TODO: Auch alle Unterverzeichnisse öffnen und deren Daten hashen

            DirectoryInfo directory = new DirectoryInfo(dirPath);
            FileInfo[] files = directory.GetFiles();

            //Paralles hashen. Ein Thread pro file.
            Parallel.ForEach(files, file =>
            {
                byte[] hash = HashFile(file, algo);
                Console.WriteLine(file + ":\t" + BitConverter.ToString(hash));
            });

            Console.ReadKey(false);
        }

        /// <summary>
        /// Erzeugt instanzen der Hash-Algorithmen.
        /// </summary>
        private static HashAlgorithm GetHashAlgorithm(HashAlgoEnum algo)
        {
            switch (algo)
            {
                case HashAlgoEnum.md5:
                    return MD5.Create();
                case HashAlgoEnum.sha256:
                    return SHA256.Create();
                case HashAlgoEnum.sha512:
                    return SHA512.Create();
                default:
                    return MD5.Create();
            }
        }

        /// <summary>
        /// Wendet den übergebenen Hash-Algorithmus auf die übergebene Datei an.
        /// </summary>
        private static byte[] HashFile(FileInfo file, HashAlgorithm algo)
        {
            byte[] hash;
            using (FileStream fs = file.OpenRead())
            {
                hash = algo.ComputeHash(fs);
            }
            return hash;
        }
    }

    /// <summary>
    /// Die verfügbaren Hash-Algorithmen.
    /// </summary>
    internal enum HashAlgoEnum
    {
        md5, sha256, sha512
    }
}
