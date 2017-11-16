namespace IFN647_SearchEngine
{
    partial class IndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.docPathLabel = new System.Windows.Forms.Label();
            this.indexPathLabel = new System.Windows.Forms.Label();
            this.documentPathBtn = new System.Windows.Forms.Button();
            this.indexPathBtn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.indexBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.journalArticleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalArticleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Index Directory:";
            // 
            // docPathLabel
            // 
            this.docPathLabel.AutoSize = true;
            this.docPathLabel.Location = new System.Drawing.Point(155, 32);
            this.docPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.docPathLabel.Name = "docPathLabel";
            this.docPathLabel.Size = new System.Drawing.Size(0, 17);
            this.docPathLabel.TabIndex = 2;
            // 
            // indexPathLabel
            // 
            this.indexPathLabel.AutoSize = true;
            this.indexPathLabel.Location = new System.Drawing.Point(124, 68);
            this.indexPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indexPathLabel.Name = "indexPathLabel";
            this.indexPathLabel.Size = new System.Drawing.Size(0, 17);
            this.indexPathLabel.TabIndex = 3;
            // 
            // documentPathBtn
            // 
            this.documentPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.documentPathBtn.Location = new System.Drawing.Point(573, 26);
            this.documentPathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.documentPathBtn.Name = "documentPathBtn";
            this.documentPathBtn.Size = new System.Drawing.Size(100, 28);
            this.documentPathBtn.TabIndex = 4;
            this.documentPathBtn.Text = "Browse";
            this.documentPathBtn.UseVisualStyleBackColor = true;
            this.documentPathBtn.Click += new System.EventHandler(this.documentPathBtn_Click);
            // 
            // indexPathBtn
            // 
            this.indexPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexPathBtn.Location = new System.Drawing.Point(573, 62);
            this.indexPathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.indexPathBtn.Name = "indexPathBtn";
            this.indexPathBtn.Size = new System.Drawing.Size(100, 28);
            this.indexPathBtn.TabIndex = 5;
            this.indexPathBtn.Text = "Browse";
            this.indexPathBtn.UseVisualStyleBackColor = true;
            this.indexPathBtn.Click += new System.EventHandler(this.indexPathBtn_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(21, 126);
            this.textBox.Margin = new System.Windows.Forms.Padding(4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(674, 217);
            this.textBox.TabIndex = 6;
            // 
            // indexBtn
            // 
            this.indexBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexBtn.Location = new System.Drawing.Point(716, 22);
            this.indexBtn.Margin = new System.Windows.Forms.Padding(4);
            this.indexBtn.Name = "indexBtn";
            this.indexBtn.Size = new System.Drawing.Size(100, 28);
            this.indexBtn.TabIndex = 7;
            this.indexBtn.Text = "Index";
            this.indexBtn.UseVisualStyleBackColor = true;
            this.indexBtn.Click += new System.EventHandler(this.indexBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Enabled = false;
            this.nextBtn.Location = new System.Drawing.Point(716, 70);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(100, 28);
            this.nextBtn.TabIndex = 8;
            this.nextBtn.Text = "Start";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Visible = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(20, 357);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(676, 23);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.docPathLabel);
            this.groupBox2.Controls.Add(this.indexPathLabel);
            this.groupBox2.Controls.Add(this.documentPathBtn);
            this.groupBox2.Controls.Add(this.indexPathBtn);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(681, 103);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folder Setting";
            // 
            // journalArticleBindingSource
            // 
            this.journalArticleBindingSource.DataSource = typeof(IFN647_SearchEngine.JournalArticle);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.indexBtn);
            this.Controls.Add(this.textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(850, 437);
            this.Name = "IndexForm";
            this.Text = "GGezTTH - Indexing";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.journalArticleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label docPathLabel;
        private System.Windows.Forms.Label indexPathLabel;
        private System.Windows.Forms.Button documentPathBtn;
        private System.Windows.Forms.Button indexPathBtn;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button indexBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource journalArticleBindingSource;
    }
}

