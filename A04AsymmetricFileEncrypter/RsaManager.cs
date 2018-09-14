using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A04AsymmetricFileEncrypter
{
    internal class RsaManager
    {
        private static readonly string containerName = "MyRSAKey";
        private static readonly string publicKeyChainPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Public Keys");

        public SortedDictionary<string, string> PublicKeys
        {
            get
            {
                return GetPublicKeyList();
            }
        }

        private SortedDictionary<string, string> GetPublicKeyList()
        {
            if (Directory.Exists(publicKeyChainPath) == false)
            {
                Directory.CreateDirectory(publicKeyChainPath);
            }

            var publicKeyDict = new SortedDictionary<string, string>();
            string[] keyFiles = Directory.GetFiles(publicKeyChainPath, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (string keyPath in keyFiles)
            {
                string keyName = Path.GetFileNameWithoutExtension(keyPath);
                publicKeyDict.Add(keyName, keyPath);
            }
            return publicKeyDict;
        }

        /// <summary>
        /// Liefert den für die RSA-Verschlüsselung verwendeten Dienstleister.
        /// </summary>
        /// <returns>RSA-Verschlüsselungsdienstleister.</returns>
        internal RSACryptoServiceProvider GetRSACryptoProvider()
        {
            CspParameters csp = new CspParameters()
            {
                KeyContainerName = containerName
            };
            csp.Flags |= CspProviderFlags.UseMachineKeyStore;
            return new RSACryptoServiceProvider(csp);
        }

        /// <summary>
        /// Liefert meinen Public Key.
        /// </summary>
        internal string GetMyPublicKeyXml()
        {
            var rsa = GetRSACryptoProvider();
            return rsa.ToXmlString(false);
        }

        internal void ImportPublicKey(string fileName)
        {
            string newKeyFileName = Path.Combine(publicKeyChainPath, Path.GetFileName(fileName));
            //TODO:Abfangen, ob vorhandene überschrieben werden dürfen
            File.Copy(fileName, newKeyFileName);
        }

        internal void ExportPublicKey(string fileName)
        {
            string xml = GetMyPublicKeyXml();
            File.WriteAllText(fileName, xml, Encoding.UTF8);
        }

        internal string Encrypt(byte[] text)
        {
            var rsa = GetRSACryptoProvider();
            rsa.Encrypt(text, true);
            throw new NotImplementedException();
        }

        internal string Decrypt(byte[] text)
        {
            throw new NotImplementedException();
        }
    }
}
