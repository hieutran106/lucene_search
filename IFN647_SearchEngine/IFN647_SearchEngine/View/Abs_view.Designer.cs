namespace IFN647_SearchEngine
{
    partial class Abs_view_f
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abs_view_f));
            this.AV_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.AV_author = new System.Windows.Forms.Label();
            this.AV_abs = new System.Windows.Forms.Label();
            this.AV_title = new System.Windows.Forms.Label();
            this.AV_tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // AV_tableLayout
            // 
            this.AV_tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AV_tableLayout.AutoScroll = true;
            this.AV_tableLayout.AutoSize = true;
            this.AV_tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AV_tableLayout.ColumnCount = 1;
            this.AV_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AV_tableLayout.Controls.Add(this.AV_author, 0, 1);
            this.AV_tableLayout.Controls.Add(this.AV_abs, 0, 2);
            this.AV_tableLayout.Controls.Add(this.AV_title, 0, 0);
            this.AV_tableLayout.Location = new System.Drawing.Point(12, 12);
            this.AV_tableLayout.Name = "AV_tableLayout";
            this.AV_tableLayout.RowCount = 3;
            this.AV_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AV_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AV_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.AV_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.AV_tableLayout.Size = new System.Drawing.Size(120, 65);
            this.AV_tableLayout.TabIndex = 1;
            // 
            // AV_author
            // 
            this.AV_author.AutoSize = true;
            this.AV_author.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AV_author.Location = new System.Drawing.Point(3, 25);
            this.AV_author.Name = "AV_author";
            this.AV_author.Size = new System.Drawing.Size(64, 20);
            this.AV_author.TabIndex = 2;
            this.AV_author.Text = "Author";
            // 
            // AV_abs
            // 
            this.AV_abs.AutoSize = true;
            this.AV_abs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AV_abs.Location = new System.Drawing.Point(3, 45);
            this.AV_abs.Name = "AV_abs";
            this.AV_abs.Size = new System.Drawing.Size(114, 20);
            this.AV_abs.TabIndex = 0;
            this.AV_abs.Text = "Abstract Here";
            // 
            // AV_title
            // 
            this.AV_title.AutoSize = true;
            this.AV_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AV_title.Location = new System.Drawing.Point(3, 0);
            this.AV_title.Name = "AV_title";
            this.AV_title.Size = new System.Drawing.Size(54, 25);
            this.AV_title.TabIndex = 3;
            this.AV_title.Text = "Title";
            // 
            // Abs_view_f
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(148, 93);
            this.Controls.Add(this.AV_tableLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Abs_view_f";
            this.Text = "Abstract View";
            this.AV_tableLayout.ResumeLayout(false);
            this.AV_tableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel AV_tableLayout;
        private System.Windows.Forms.Label AV_author;
        private System.Windows.Forms.Label AV_abs;
        private System.Windows.Forms.Label AV_title;
    }
}