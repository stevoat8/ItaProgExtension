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
            this.label1 = new System.Windows.Forms.Label();
            this.sha1Lbl = new System.Windows.Forms.Label();
            this.md5Lbl = new System.Windows.Forms.Label();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.sha1Tb = new System.Windows.Forms.TextBox();
            this.md5Tb = new System.Windows.Forms.TextBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pfad:";
            // 
            // sha1Lbl
            // 
            this.sha1Lbl.AutoSize = true;
            this.sha1Lbl.Location = new System.Drawing.Point(20, 101);
            this.sha1Lbl.Name = "sha1Lbl";
            this.sha1Lbl.Size = new System.Drawing.Size(38, 13);
            this.sha1Lbl.TabIndex = 1;
            this.sha1Lbl.Text = "SHA1:";
            // 
            // md5Lbl
            // 
            this.md5Lbl.AutoSize = true;
            this.md5Lbl.Location = new System.Drawing.Point(20, 74);
            this.md5Lbl.Name = "md5Lbl";
            this.md5Lbl.Size = new System.Drawing.Size(33, 13);
            this.md5Lbl.TabIndex = 2;
            this.md5Lbl.Text = "MD5:";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(20, 12);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(98, 23);
            this.openFileBtn.TabIndex = 3;
            this.openFileBtn.Text = "Datei auswählen";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // filePathTb
            // 
            this.filePathTb.Location = new System.Drawing.Point(64, 44);
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.ReadOnly = true;
            this.filePathTb.Size = new System.Drawing.Size(471, 20);
            this.filePathTb.TabIndex = 4;
            // 
            // sha1Tb
            // 
            this.sha1Tb.Location = new System.Drawing.Point(64, 98);
            this.sha1Tb.Name = "sha1Tb";
            this.sha1Tb.ReadOnly = true;
            this.sha1Tb.Size = new System.Drawing.Size(471, 20);
            this.sha1Tb.TabIndex = 5;
            // 
            // md5Tb
            // 
            this.md5Tb.Location = new System.Drawing.Point(64, 71);
            this.md5Tb.Name = "md5Tb";
            this.md5Tb.ReadOnly = true;
            this.md5Tb.Size = new System.Drawing.Size(471, 20);
            this.md5Tb.TabIndex = 6;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(64, 125);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 13);
            this.statusLbl.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status:";
            // 
            // HashCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 150);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.md5Tb);
            this.Controls.Add(this.sha1Tb);
            this.Controls.Add(this.filePathTb);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.md5Lbl);
            this.Controls.Add(this.sha1Lbl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HashCheckerForm";
            this.Text = "Hash Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sha1Lbl;
        private System.Windows.Forms.Label md5Lbl;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.TextBox filePathTb;
        private System.Windows.Forms.TextBox sha1Tb;
        private System.Windows.Forms.TextBox md5Tb;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Label label4;
    }
}

