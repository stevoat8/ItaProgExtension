namespace A04AsymmetricFileEncrypter
{
    partial class FileEncrypterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileEncrypterForm));
            this.ExportPublicKeyBtn = new System.Windows.Forms.Button();
            this.KeyNameLbl = new System.Windows.Forms.Label();
            this.publicKeysCb = new System.Windows.Forms.ComboBox();
            this.rsaManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ImportPublicKeyBtn = new System.Windows.Forms.Button();
            this.plainTextLbl = new System.Windows.Forms.Label();
            this.cipherTextLbl = new System.Windows.Forms.Label();
            this.plainTextTb = new System.Windows.Forms.TextBox();
            this.cipherTextTb = new System.Windows.Forms.TextBox();
            this.openPlainTextBtn = new System.Windows.Forms.Button();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.openCipherTextBtn = new System.Windows.Forms.Button();
            this.decryptBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rsaManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportPublicKeyBtn
            // 
            this.ExportPublicKeyBtn.Location = new System.Drawing.Point(586, 15);
            this.ExportPublicKeyBtn.Name = "ExportPublicKeyBtn";
            this.ExportPublicKeyBtn.Size = new System.Drawing.Size(110, 23);
            this.ExportPublicKeyBtn.TabIndex = 0;
            this.ExportPublicKeyBtn.Text = "Export Public Key";
            this.ExportPublicKeyBtn.UseVisualStyleBackColor = true;
            this.ExportPublicKeyBtn.Click += new System.EventHandler(this.ExportPKeyBtn_Click);
            // 
            // KeyNameLbl
            // 
            this.KeyNameLbl.AutoSize = true;
            this.KeyNameLbl.Location = new System.Drawing.Point(12, 20);
            this.KeyNameLbl.Name = "KeyNameLbl";
            this.KeyNameLbl.Size = new System.Drawing.Size(28, 13);
            this.KeyNameLbl.TabIndex = 1;
            this.KeyNameLbl.Text = "Key:";
            // 
            // publicKeysCb
            // 
            this.publicKeysCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.publicKeysCb.DataSource = this.rsaManagerBindingSource;
            this.publicKeysCb.DisplayMember = "PublicKeys";
            this.publicKeysCb.FormattingEnabled = true;
            this.publicKeysCb.Location = new System.Drawing.Point(46, 17);
            this.publicKeysCb.Name = "publicKeysCb";
            this.publicKeysCb.Size = new System.Drawing.Size(429, 21);
            this.publicKeysCb.TabIndex = 3;
            this.publicKeysCb.ValueMember = "PublicKeys";
            this.publicKeysCb.SelectedValueChanged += new System.EventHandler(this.publicKeysCB_SelectedValueChanged);
            // 
            // rsaManagerBindingSource
            // 
            this.rsaManagerBindingSource.DataSource = typeof(A04AsymmetricFileEncrypter.RsaManager);
            // 
            // ImportPublicKeyBtn
            // 
            this.ImportPublicKeyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportPublicKeyBtn.Location = new System.Drawing.Point(481, 15);
            this.ImportPublicKeyBtn.Name = "ImportPublicKeyBtn";
            this.ImportPublicKeyBtn.Size = new System.Drawing.Size(99, 23);
            this.ImportPublicKeyBtn.TabIndex = 4;
            this.ImportPublicKeyBtn.Text = "Import Public Key";
            this.ImportPublicKeyBtn.UseVisualStyleBackColor = true;
            this.ImportPublicKeyBtn.Click += new System.EventHandler(this.ImportPublicKeyBtn_Click);
            // 
            // plainTextLbl
            // 
            this.plainTextLbl.AutoSize = true;
            this.plainTextLbl.Location = new System.Drawing.Point(12, 51);
            this.plainTextLbl.Name = "plainTextLbl";
            this.plainTextLbl.Size = new System.Drawing.Size(53, 13);
            this.plainTextLbl.TabIndex = 5;
            this.plainTextLbl.Text = "Plain text:";
            // 
            // cipherTextLbl
            // 
            this.cipherTextLbl.AutoSize = true;
            this.cipherTextLbl.Location = new System.Drawing.Point(12, 176);
            this.cipherTextLbl.Name = "cipherTextLbl";
            this.cipherTextLbl.Size = new System.Drawing.Size(60, 13);
            this.cipherTextLbl.TabIndex = 6;
            this.cipherTextLbl.Text = "Cipher text:";
            // 
            // plainTextTb
            // 
            this.plainTextTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plainTextTb.Location = new System.Drawing.Point(15, 67);
            this.plainTextTb.Multiline = true;
            this.plainTextTb.Name = "plainTextTb";
            this.plainTextTb.Size = new System.Drawing.Size(565, 100);
            this.plainTextTb.TabIndex = 7;
            // 
            // cipherTextTb
            // 
            this.cipherTextTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cipherTextTb.Location = new System.Drawing.Point(15, 192);
            this.cipherTextTb.Multiline = true;
            this.cipherTextTb.Name = "cipherTextTb";
            this.cipherTextTb.Size = new System.Drawing.Size(565, 100);
            this.cipherTextTb.TabIndex = 8;
            // 
            // openPlainTextBtn
            // 
            this.openPlainTextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openPlainTextBtn.Location = new System.Drawing.Point(586, 67);
            this.openPlainTextBtn.Name = "openPlainTextBtn";
            this.openPlainTextBtn.Size = new System.Drawing.Size(110, 23);
            this.openPlainTextBtn.TabIndex = 9;
            this.openPlainTextBtn.Text = "Open";
            this.openPlainTextBtn.UseVisualStyleBackColor = true;
            this.openPlainTextBtn.Click += new System.EventHandler(this.OpenPlainTextBtn_Click);
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptBtn.Location = new System.Drawing.Point(586, 97);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(110, 23);
            this.EncryptBtn.TabIndex = 10;
            this.EncryptBtn.Text = "Encrypt";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // openCipherTextBtn
            // 
            this.openCipherTextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openCipherTextBtn.Location = new System.Drawing.Point(586, 192);
            this.openCipherTextBtn.Name = "openCipherTextBtn";
            this.openCipherTextBtn.Size = new System.Drawing.Size(110, 23);
            this.openCipherTextBtn.TabIndex = 11;
            this.openCipherTextBtn.Text = "Open";
            this.openCipherTextBtn.UseVisualStyleBackColor = true;
            this.openCipherTextBtn.Click += new System.EventHandler(this.OpenCipherTextBtn_Click);
            // 
            // decryptBtn
            // 
            this.decryptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.decryptBtn.Location = new System.Drawing.Point(586, 221);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(110, 23);
            this.decryptBtn.TabIndex = 12;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // FileEncrypterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 309);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.openCipherTextBtn);
            this.Controls.Add(this.EncryptBtn);
            this.Controls.Add(this.openPlainTextBtn);
            this.Controls.Add(this.cipherTextTb);
            this.Controls.Add(this.plainTextTb);
            this.Controls.Add(this.cipherTextLbl);
            this.Controls.Add(this.plainTextLbl);
            this.Controls.Add(this.ImportPublicKeyBtn);
            this.Controls.Add(this.publicKeysCb);
            this.Controls.Add(this.KeyNameLbl);
            this.Controls.Add(this.ExportPublicKeyBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileEncrypterForm";
            this.Text = "RSA file encrypter";
            ((System.ComponentModel.ISupportInitialize)(this.rsaManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExportPublicKeyBtn;
        private System.Windows.Forms.Label KeyNameLbl;
        private System.Windows.Forms.ComboBox publicKeysCb;
        private System.Windows.Forms.Button ImportPublicKeyBtn;
        private System.Windows.Forms.Label plainTextLbl;
        private System.Windows.Forms.Label cipherTextLbl;
        private System.Windows.Forms.TextBox plainTextTb;
        private System.Windows.Forms.TextBox cipherTextTb;
        private System.Windows.Forms.Button openPlainTextBtn;
        private System.Windows.Forms.Button EncryptBtn;
        private System.Windows.Forms.Button openCipherTextBtn;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.BindingSource rsaManagerBindingSource;
    }
}

