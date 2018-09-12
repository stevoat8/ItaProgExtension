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

        public HashCheckerForm()
        {
            InitializeComponent();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePathTb.Text = dialog.FileName;
            }
        }

        private void CheckHashBtn_Click(object sender, EventArgs e)
        {
            StartCheckingHash();
        }

        private void StartCheckingHash()
        {
            statusTb.Text = "";

            string filePath = filePathTb.Text;
            if (File.Exists(filePath) == false)
            {
                statusTb.Text = "Error: Filename does not exist";
                return;
            }

            string hashInput = hashTb.Text;
            if (string.IsNullOrWhiteSpace(hashInput))
            {
                statusTb.Text = "Error: No Hash value";
                return;
            }

            statusTb.Text = "Hashing...";
            LockUi();
            StartHashing(filePath, hashInput);
        }

        private void LockUi()
        {
            filePathTb.Enabled = false;
            hashTb.Enabled = false;
            openFileBtn.Enabled = false;
            checkHashBtn.Enabled = false;

            cancelBtn.Enabled = true;
            cancelBtn.Visible = true;
            progressBar.Visible = true;
            Cursor = Cursors.WaitCursor;
        }

        private void UnlockUi()
        {
            filePathTb.Enabled = true;
            hashTb.Enabled = true;
            openFileBtn.Enabled = true;
            checkHashBtn.Enabled = true;

            cancelBtn.Enabled = false;
            cancelBtn.Visible = false;
            progressBar.Visible = false;
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Starts a new hashing process.
        /// </summary>
        private async void StartHashing(string filePath, string hashInput)
        {
            try
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;

                Stopwatch watch = new Stopwatch();
                watch.Start();
                string generatedHash = await GetHash(filePath, token);
                watch.Stop();

                string elapsedTime = string.Format("Time elapsed: {0:D2}:{1:D2}:{2:D3}",
                    watch.Elapsed.Minutes,
                    watch.Elapsed.Seconds,
                    watch.Elapsed.Milliseconds);

                string result = hashInput.Equals(generatedHash, StringComparison.OrdinalIgnoreCase)
                    ? "Hash is correct!"
                    : "Hash is not correct!" + Environment.NewLine + "Hash was " + generatedHash;

                statusTb.Text = result + Environment.NewLine + elapsedTime;
            }
            catch (OperationCanceledException)
            {
                statusTb.Text = "Canceled by user";
            }
            catch (Exception ex)
            {
                statusTb.Text = "Error: " + ex;
            }
            finally
            {
                UnlockUi();
            }
        }

        /// <summary>
        /// Applies the given hash algorithm on the given file an returns a short string representation of the computed hash value.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private static async Task<string> GetHash(string fileName, CancellationToken token)
        {
            HashAlgorithm algo = SHA1.Create();
            byte[] hash = new byte[0];
            using (FileStream fs = File.OpenRead(fileName))
            {
                //TODO: hier eigene computeHash Methode einfügen, die parallel läuft, 
                //durch das Token abbrechbar ist und den Progressbalken erweitert.
                await Task.Run(() =>
                    hash = algo.ComputeHash(fs)
                );
            }
            StringBuilder builder = new StringBuilder();
            foreach (byte byteVal in hash)
            {
                builder.Append(byteVal.ToString("X2"));
            }
            return builder.ToString();
        }

    }
}
