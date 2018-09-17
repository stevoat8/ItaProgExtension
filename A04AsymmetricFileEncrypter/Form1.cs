using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A04AsymmetricFileEncrypter
{
    public partial class FileEncrypterForm : Form
    {
        public string SelectedFile { get; private set; }
        internal RsaManager RsaManager { get; }

        internal FileEncrypterForm(RsaManager rsaManager)
        {
            InitializeComponent();
            RsaManager = rsaManager;
            publicKeysCb.DataSource = new BindingSource(rsaManager.PublicKeys, null); ////klicky
            publicKeysCb.DisplayMember = "Key";
            publicKeysCb.ValueMember = "Value";
        }

        private void ExportPKeyBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "xml",
                Filter = "XML files|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RsaManager.ExportPublicKey(dialog.FileName);
            }
        }

        private void ImportPublicKeyBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "XML files|*.xml|All files|*.*",
                FilterIndex = 0
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RsaManager.ImportPublicKey(dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Error public key import",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                publicKeysCb.Refresh();
            }
        }

        private void publicKeysCB_SelectedValueChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void OpenPlainTextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShowText(dialog.FileName, plainTextTb);
            }
        }

        private void OpenCipherTextBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShowText(dialog.FileName, cipherTextTb);
            }
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            //TODO: statt den Text aus der Textbox holen, lieber wieder die Datei auslesen
            string file = File.ReadAllText(SelectedFile).Trim();
            byte[] content = Encoding.UTF8.GetBytes(file);
            byte[] encrypted = RsaManager.Encrypt(content);

            cipherTextTb.Text = Encoding.UTF8.GetString(encrypted);
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            string file = File.ReadAllText(SelectedFile).Trim();
            byte[] content = Encoding.UTF8.GetBytes(file);
            byte[] decrypted = RsaManager.Decrypt(content);

            plainTextTb.Text = Encoding.UTF8.GetString(decrypted);
        }

        private void ShowText(string fileName, TextBox textBox)
        {
            textBox.Text = File.ReadAllText(fileName);
            SelectedFile = fileName;
        }

        private void Reset()
        {
            SelectedFile = null;
            plainTextTb.Text = "";
            cipherTextTb.Text = "";
        }
    }
}
