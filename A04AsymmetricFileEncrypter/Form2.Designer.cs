namespace A04AsymmetricFileEncrypter
{
    partial class NewPubKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPubKeyForm));
            this.keyNameLbl = new System.Windows.Forms.Label();
            this.keyFileLbl = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.fileTb = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyNameLbl
            // 
            this.keyNameLbl.AutoSize = true;
            this.keyNameLbl.Location = new System.Drawing.Point(13, 13);
            this.keyNameLbl.Name = "keyNameLbl";
            this.keyNameLbl.Size = new System.Drawing.Size(38, 13);
            this.keyNameLbl.TabIndex = 0;
            this.keyNameLbl.Text = "Name:";
            // 
            // keyFileLbl
            // 
            this.keyFileLbl.AutoSize = true;
            this.keyFileLbl.Location = new System.Drawing.Point(13, 41);
            this.keyFileLbl.Name = "keyFileLbl";
            this.keyFileLbl.Size = new System.Drawing.Size(26, 13);
            this.keyFileLbl.TabIndex = 1;
            this.keyFileLbl.Text = "File:";
            // 
            // nameTb
            // 
            this.nameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTb.Location = new System.Drawing.Point(56, 10);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(451, 20);
            this.nameTb.TabIndex = 2;
            // 
            // fileTb
            // 
            this.fileTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTb.Location = new System.Drawing.Point(56, 38);
            this.fileTb.Name = "fileTb";
            this.fileTb.Size = new System.Drawing.Size(324, 20);
            this.fileTb.TabIndex = 3;
            // 
            // browseBtn
            // 
            this.browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBtn.Location = new System.Drawing.Point(386, 36);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(121, 23);
            this.browseBtn.TabIndex = 4;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(56, 65);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(451, 136);
            this.textBox3.TabIndex = 5;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.Location = new System.Drawing.Point(96, 207);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(367, 207);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // NewPubKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 242);
            this.ControlBox = false;
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.fileTb);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.keyFileLbl);
            this.Controls.Add(this.keyNameLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(287, 254);
            this.Name = "NewPubKeyForm";
            this.ShowInTaskbar = false;
            this.Text = "New public Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label keyNameLbl;
        private System.Windows.Forms.Label keyFileLbl;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox fileTb;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}