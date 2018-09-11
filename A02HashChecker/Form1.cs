using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A02HashChecker
{
    public partial class HashCheckerForm : Form
    {
        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        public HashCheckerForm()
        {
            InitializeComponent();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            StartHashing();
        }

        /// <summary>
        /// Starts a new hashing process.
        /// </summary>
        private async void StartHashing()
        {
            ResetUi();
            ConcurrentDictionary<string, string> hashValues = new ConcurrentDictionary<string, string>();

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openFileBtn.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    statusLbl.Text = "Hashing...";
                    filePathTb.Text = dialog.FileName;

                    CancellationToken token = tokenSource.Token;

                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    Task t1 = Task.Run(() => hashValues.TryAdd("sha1", GetHash(dialog.FileName, SHA1.Create(), token)));
                    Task t2 = Task.Run(() => hashValues.TryAdd("md5", GetHash(dialog.FileName, MD5.Create(), token)));
                    await Task.WhenAll(t1, t2);
                    watch.Stop();

                    hashValues.TryGetValue("sha1", out string sha1Hash);
                    sha1Tb.Text = sha1Hash;

                    hashValues.TryGetValue("md5", out string md5Hash);
                    md5Tb.Text = md5Hash;

                    string elapsedTime = String.Format("{0:D2}:{1:D2}:{2:D3}", watch.Elapsed.Minutes, watch.Elapsed.Seconds, watch.Elapsed.Milliseconds);
                    statusLbl.Text = "Hashing Complete (" + elapsedTime + ")";

                    Cursor = Cursors.Default;
                    openFileBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    ResetUi();
                    statusLbl.Text = "Error: " + ex;
                }
            }
        }

        /// <summary>
        /// Applies the given hash algorithm on the given file an returns a short string representation of the computed hash value.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private static string GetHash(string fileName, HashAlgorithm algo, CancellationToken token)
        {
            byte[] hash;
            using (FileStream fs = File.OpenRead(fileName))
            {
                hash = algo.ComputeHash(fs);
            }
            StringBuilder builder = new StringBuilder();
            foreach (byte byteVal in hash)
            {
                builder.Append(byteVal.ToString("X2"));
            }
            return builder.ToString();
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
        /// Resets the UI.
        /// </summary>
        private void ResetUi()
        {
            statusLbl.Text = "";
            filePathTb.Text = "";
            sha1Tb.Text = "";
            md5Tb.Text = "";
            Cursor = Cursors.Default;
        }
    }
}
