namespace A02HashChecker
{
    partial class HashCheckerForm
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
            this.filePathLbl = new System.Windows.Forms.Label();
            this.hashLbl = new System.Windows.Forms.Label();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.hashTb = new System.Windows.Forms.TextBox();
            this.checkHashBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.statusTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePathLbl
            // 
            this.filePathLbl.AutoSize = true;
            this.filePathLbl.Location = new System.Drawing.Point(9, 9);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(32, 13);
            this.filePathLbl.TabIndex = 0;
            this.filePathLbl.Text = "Pfad:";
            // 
            // hashLbl
            // 
            this.hashLbl.AutoSize = true;
            this.hashLbl.Location = new System.Drawing.Point(9, 35);
            this.hashLbl.Name = "hashLbl";
            this.hashLbl.Size = new System.Drawing.Size(35, 13);
            this.hashLbl.TabIndex = 2;
            this.hashLbl.Text = "Hash:";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileBtn.Location = new System.Drawing.Point(434, 4);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(98, 23);
            this.openFileBtn.TabIndex = 3;
            this.openFileBtn.Text = "Datei auswählen";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // filePathTb
            // 
            this.filePathTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTb.Location = new System.Drawing.Point(50, 6);
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.Size = new System.Drawing.Size(378, 20);
            this.filePathTb.TabIndex = 4;
            this.filePathTb.Text = "\\\\srv-dc\\Software\\Visual Studio 2013 Ultimate + TFS\\vs2013.5_ult_deu.iso";
            // 
            // hashTb
            // 
            this.hashTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hashTb.Location = new System.Drawing.Point(50, 32);
            this.hashTb.Name = "hashTb";
            this.hashTb.Size = new System.Drawing.Size(378, 20);
            this.hashTb.TabIndex = 6;
            this.hashTb.Text = "198c8ca5e80cc5f1ef579a6b2b6d5d2a55dc099b";
            // 
            // checkHashBtn
            // 
            this.checkHashBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkHashBtn.Location = new System.Drawing.Point(434, 30);
            this.checkHashBtn.Name = "checkHashBtn";
            this.checkHashBtn.Size = new System.Drawing.Size(98, 23);
            this.checkHashBtn.TabIndex = 7;
            this.checkHashBtn.Text = "Check Hash";
            this.checkHashBtn.UseVisualStyleBackColor = true;
            this.checkHashBtn.Click += new System.EventHandler(this.CheckHashBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(50, 129);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(378, 23);
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Location = new System.Drawing.Point(434, 129);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(98, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            // 
            // statusTb
            // 
            this.statusTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTb.Location = new System.Drawing.Point(50, 58);
            this.statusTb.Multiline = true;
            this.statusTb.Name = "statusTb";
            this.statusTb.ReadOnly = true;
            this.statusTb.Size = new System.Drawing.Size(378, 63);
            this.statusTb.TabIndex = 11;
            // 
            // HashCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 164);
            this.Controls.Add(this.statusTb);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkHashBtn);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.hashTb);
            this.Controls.Add(this.filePathLbl);
            this.Controls.Add(this.hashLbl);
            this.Controls.Add(this.filePathTb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(400, 160);
            this.Name = "HashCheckerForm";
            this.Text = "Hash Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filePathLbl;
        private System.Windows.Forms.Label hashLbl;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.TextBox filePathTb;
        private System.Windows.Forms.TextBox hashTb;
        private System.Windows.Forms.Button checkHashBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox statusTb;
    }
}

