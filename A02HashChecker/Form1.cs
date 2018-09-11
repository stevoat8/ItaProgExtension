using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A02HashChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            StartHashing();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelHashing();
        }

        /// <summary>
        /// Starts a new hashing process.
        /// </summary>
        private void StartHashing()
        {
            ResetUi();
            ConcurrentDictionary<string, string> hashValues = new ConcurrentDictionary<string, string>();

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    statusLbl.Text = "Hashing...";
                    cancelBtn.Visible = true;
                    filePathTb.Text = dialog.FileName;

                    Parallel.Invoke(
                        () => hashValues.TryAdd("sha1", GetHash(dialog.FileName, SHA1.Create())),
                        () => hashValues.TryAdd("md5", GetHash(dialog.FileName, MD5.Create()))
                    );

                    hashValues.TryGetValue("sha1", out string sha1Hash);
                    sha1Tb.Text = sha1Hash;

                    hashValues.TryGetValue("md5", out string md5Hash);
                    md5Tb.Text = md5Hash;

                    cancelBtn.Visible = false;
                    statusLbl.Text = "Hashing Complete";
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    statusLbl.Text = "Error: " + ex;
                    cancelBtn.Visible = false;
                }
            }
        }

        /// <summary>
        /// Cancels the current hashing process.
        /// </summary>
        private void CancelHashing()
        {
            ResetUi();
            statusLbl.Text = "Canceled by user";
        }

        /// <summary>
        /// Applies the given hash algorithm on the given file an returns the computed hash value.
        /// </summary>
        private static byte[] GetHashValue(string fileName, HashAlgorithm algo)
        {
            byte[] hash;
            using (FileStream fs = File.OpenRead(fileName))
            {
                hash = algo.ComputeHash(fs);
            }
            return hash;
        }

        /// <summary>
        /// Applies the given hash algorithm on the given file an returns a short string representation of the computed hash value.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private static string GetHash(string fileName, HashAlgorithm algo)
        {
            byte[] hash;
            using (FileStream fs = File.OpenRead(fileName))
            {
                hash = algo.ComputeHash(fs);
            }
            StringBuilder builder = new StringBuilder();
            foreach (byte byteVal in hash)
            {
                builder.Append(byteVal.ToString("x2").ToUpper());
            }
            return builder.ToString();
        }

        /// <summary>
        /// Resets the UI.
        /// </summary>
        private void ResetUi()
        {
            statusLbl.Text = "";
            filePathTb.Text = "";
            sha1Tb.Text = "";
            md5Tb.Text = "";
            Cursor.Current = Cursors.Default;
            cancelBtn.Visible = false;
        }
    }
}
