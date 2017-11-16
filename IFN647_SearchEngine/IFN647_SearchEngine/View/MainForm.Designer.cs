namespace IFN647_SearchEngine
{
    partial class SearchCore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchCore));
            this.search_input = new System.Windows.Forms.TextBox();
            this.search_query = new System.Windows.Forms.Label();
            this.searchInput_label = new System.Windows.Forms.Label();
            this.Skip_process = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.TB_C1_R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_C2_T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_C3_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_C5_Bili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_C5_Abs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prev_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.page_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.queryIdLabel = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SearchFieldCB = new System.Windows.Forms.ComboBox();
            this.searchFieldLabel = new System.Windows.Forms.Label();
            this.SearchTimeLabel = new System.Windows.Forms.Label();
            this.SpellCheckLabel = new System.Windows.Forms.Label();
            this.FirstButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.autoText3 = new System.Windows.Forms.Label();
            this.autoText2 = new System.Windows.Forms.Label();
            this.autoText1 = new System.Windows.Forms.Label();
            this.QueryExpandCB = new System.Windows.Forms.CheckBox();
            this.search_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_input
            // 
            this.search_input.AcceptsTab = true;
            this.search_input.Location = new System.Drawing.Point(17, 33);
            this.search_input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_input.Multiline = true;
            this.search_input.Name = "search_input";
            this.search_input.Size = new System.Drawing.Size(545, 59);
            this.search_input.TabIndex = 2;
            this.search_input.TextChanged += new System.EventHandler(this.search_input_TextChanged);
            this.search_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_input_KeyDown);
            this.search_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.search_input_KeyPress);
            this.search_input.Leave += new System.EventHandler(this.search_input_Leave);
            // 
            // search_query
            // 
            this.search_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_query.AutoSize = true;
            this.search_query.Location = new System.Drawing.Point(14, 134);
            this.search_query.MaximumSize = new System.Drawing.Size(820, 0);
            this.search_query.Name = "search_query";
            this.search_query.Size = new System.Drawing.Size(104, 17);
            this.search_query.TabIndex = 3;
            this.search_query.Text = "Search Query: ";
            // 
            // searchInput_label
            // 
            this.searchInput_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchInput_label.AutoSize = true;
            this.searchInput_label.Location = new System.Drawing.Point(15, 14);
            this.searchInput_label.Name = "searchInput_label";
            this.searchInput_label.Size = new System.Drawing.Size(108, 17);
            this.searchInput_label.TabIndex = 4;
            this.searchInput_label.Text = "Input to Search:";
            // 
            // Skip_process
            // 
            this.Skip_process.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Skip_process.AutoSize = true;
            this.Skip_process.Location = new System.Drawing.Point(568, 67);
            this.Skip_process.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Skip_process.Name = "Skip_process";
            this.Skip_process.Size = new System.Drawing.Size(139, 21);
            this.Skip_process.TabIndex = 5;
            this.Skip_process.Text = "Skip Pre-Process";
            this.Skip_process.UseVisualStyleBackColor = true;
            this.Skip_process.CheckedChanged += new System.EventHandler(this.Skip_process_CheckedChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TB_C1_R,
            this.TB_C2_T,
            this.TB_C3_A,
            this.TB_C5_Bili,
            this.TB_C5_Abs,
            this.DOCID});
            this.dataGridView.Location = new System.Drawing.Point(12, 210);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(838, 276);
            this.dataGridView.TabIndex = 9;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // TB_C1_R
            // 
            this.TB_C1_R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TB_C1_R.HeaderText = "Rank";
            this.TB_C1_R.Name = "TB_C1_R";
            this.TB_C1_R.ReadOnly = true;
            this.TB_C1_R.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TB_C1_R.Width = 47;
            // 
            // TB_C2_T
            // 
            this.TB_C2_T.HeaderText = "Title";
            this.TB_C2_T.Name = "TB_C2_T";
            this.TB_C2_T.ReadOnly = true;
            this.TB_C2_T.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TB_C3_A
            // 
            this.TB_C3_A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TB_C3_A.HeaderText = "Author";
            this.TB_C3_A.Name = "TB_C3_A";
            this.TB_C3_A.ReadOnly = true;
            this.TB_C3_A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TB_C3_A.Width = 56;
            // 
            // TB_C5_Bili
            // 
            this.TB_C5_Bili.HeaderText = "Biliography";
            this.TB_C5_Bili.Name = "TB_C5_Bili";
            this.TB_C5_Bili.ReadOnly = true;
            this.TB_C5_Bili.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TB_C5_Abs
            // 
            this.TB_C5_Abs.HeaderText = "Abstract";
            this.TB_C5_Abs.Name = "TB_C5_Abs";
            this.TB_C5_Abs.ReadOnly = true;
            this.TB_C5_Abs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOCID
            // 
            this.DOCID.HeaderText = "Doc ID";
            this.DOCID.Name = "DOCID";
            this.DOCID.ReadOnly = true;
            this.DOCID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DOCID.Visible = false;
            // 
            // prev_button
            // 
            this.prev_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prev_button.Enabled = false;
            this.prev_button.Location = new System.Drawing.Point(91, 490);
            this.prev_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prev_button.Name = "prev_button";
            this.prev_button.Size = new System.Drawing.Size(75, 34);
            this.prev_button.TabIndex = 11;
            this.prev_button.Text = "Prev";
            this.prev_button.UseVisualStyleBackColor = true;
            this.prev_button.Click += new System.EventHandler(this.prev_button_Click);
            // 
            // next_button
            // 
            this.next_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.next_button.Enabled = false;
            this.next_button.Location = new System.Drawing.Point(171, 490);
            this.next_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 34);
            this.next_button.TabIndex = 12;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // page_label
            // 
            this.page_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.page_label.AutoSize = true;
            this.page_label.Location = new System.Drawing.Point(387, 498);
            this.page_label.Name = "page_label";
            this.page_label.Size = new System.Drawing.Size(92, 17);
            this.page_label.TabIndex = 13;
            this.page_label.Text = "page number";
            this.page_label.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(577, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Query Id:";
            // 
            // queryIdLabel
            // 
            this.queryIdLabel.Location = new System.Drawing.Point(580, 111);
            this.queryIdLabel.Margin = new System.Windows.Forms.Padding(4);
            this.queryIdLabel.Name = "queryIdLabel";
            this.queryIdLabel.Size = new System.Drawing.Size(139, 22);
            this.queryIdLabel.TabIndex = 16;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(731, 108);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(117, 30);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Save result";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // SearchFieldCB
            // 
            this.SearchFieldCB.AutoCompleteCustomSource.AddRange(new string[] {
            "All",
            "Title",
            "Author",
            "Biliography",
            "Abstract"});
            this.SearchFieldCB.FormattingEnabled = true;
            this.SearchFieldCB.Location = new System.Drawing.Point(580, 28);
            this.SearchFieldCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchFieldCB.Name = "SearchFieldCB";
            this.SearchFieldCB.Size = new System.Drawing.Size(139, 24);
            this.SearchFieldCB.TabIndex = 18;
            // 
            // searchFieldLabel
            // 
            this.searchFieldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchFieldLabel.AutoSize = true;
            this.searchFieldLabel.Location = new System.Drawing.Point(577, 9);
            this.searchFieldLabel.Name = "searchFieldLabel";
            this.searchFieldLabel.Size = new System.Drawing.Size(87, 17);
            this.searchFieldLabel.TabIndex = 19;
            this.searchFieldLabel.Text = "Search field:";
            // 
            // SearchTimeLabel
            // 
            this.SearchTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTimeLabel.AutoSize = true;
            this.SearchTimeLabel.Location = new System.Drawing.Point(602, 498);
            this.SearchTimeLabel.Name = "SearchTimeLabel";
            this.SearchTimeLabel.Size = new System.Drawing.Size(60, 17);
            this.SearchTimeLabel.TabIndex = 20;
            this.SearchTimeLabel.Text = "Found...";
            this.SearchTimeLabel.Visible = false;
            // 
            // SpellCheckLabel
            // 
            this.SpellCheckLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpellCheckLabel.AutoSize = true;
            this.SpellCheckLabel.Location = new System.Drawing.Point(15, 108);
            this.SpellCheckLabel.Name = "SpellCheckLabel";
            this.SpellCheckLabel.Size = new System.Drawing.Size(99, 17);
            this.SpellCheckLabel.TabIndex = 21;
            this.SpellCheckLabel.Text = "Did you mean:";
            this.SpellCheckLabel.Visible = false;
            // 
            // FirstButton
            // 
            this.FirstButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FirstButton.Enabled = false;
            this.FirstButton.Location = new System.Drawing.Point(9, 490);
            this.FirstButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FirstButton.Name = "FirstButton";
            this.FirstButton.Size = new System.Drawing.Size(75, 34);
            this.FirstButton.TabIndex = 24;
            this.FirstButton.Text = "First";
            this.FirstButton.UseVisualStyleBackColor = true;
            this.FirstButton.Click += new System.EventHandler(this.FirstButton_Click);
            // 
            // LastButton
            // 
            this.LastButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LastButton.Enabled = false;
            this.LastButton.Location = new System.Drawing.Point(252, 490);
            this.LastButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(75, 34);
            this.LastButton.TabIndex = 25;
            this.LastButton.Text = "Last";
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.autoText3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.autoText2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.autoText1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(125, 108);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 26);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // autoText3
            // 
            this.autoText3.AutoSize = true;
            this.autoText3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoText3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.autoText3.Location = new System.Drawing.Point(110, 0);
            this.autoText3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoText3.Name = "autoText3";
            this.autoText3.Size = new System.Drawing.Size(46, 17);
            this.autoText3.TabIndex = 27;
            this.autoText3.TabStop = true;
            this.autoText3.Text = "word3";
            this.autoText3.Visible = false;
            this.autoText3.Click += new System.EventHandler(this.AutoText_Clicked);
            // 
            // autoText2
            // 
            this.autoText2.AutoSize = true;
            this.autoText2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoText2.ForeColor = System.Drawing.Color.Olive;
            this.autoText2.Location = new System.Drawing.Point(56, 0);
            this.autoText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoText2.Name = "autoText2";
            this.autoText2.Size = new System.Drawing.Size(46, 17);
            this.autoText2.TabIndex = 27;
            this.autoText2.TabStop = true;
            this.autoText2.Text = "word2";
            this.autoText2.Visible = false;
            this.autoText2.Click += new System.EventHandler(this.AutoText_Clicked);
            // 
            // autoText1
            // 
            this.autoText1.AutoSize = true;
            this.autoText1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.autoText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoText1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.autoText1.Location = new System.Drawing.Point(3, 0);
            this.autoText1.Name = "autoText1";
            this.autoText1.Size = new System.Drawing.Size(46, 17);
            this.autoText1.TabIndex = 23;
            this.autoText1.TabStop = true;
            this.autoText1.Text = "word1";
            this.autoText1.Visible = false;
            this.autoText1.Click += new System.EventHandler(this.AutoText_Clicked);
            // 
            // QueryExpandCB
            // 
            this.QueryExpandCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryExpandCB.AutoSize = true;
            this.QueryExpandCB.Checked = true;
            this.QueryExpandCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.QueryExpandCB.Location = new System.Drawing.Point(712, 67);
            this.QueryExpandCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QueryExpandCB.Name = "QueryExpandCB";
            this.QueryExpandCB.Size = new System.Drawing.Size(138, 21);
            this.QueryExpandCB.TabIndex = 27;
            this.QueryExpandCB.Text = "Query Expansion";
            this.QueryExpandCB.UseVisualStyleBackColor = true;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.Image = global::IFN647_SearchEngine.Properties.Resources.small_size1;
            this.search_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_btn.Location = new System.Drawing.Point(731, 9);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(117, 43);
            this.search_btn.TabIndex = 1;
            this.search_btn.Text = "     Search   ";
            this.search_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // SearchCore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 533);
            this.Controls.Add(this.QueryExpandCB);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.FirstButton);
            this.Controls.Add(this.SpellCheckLabel);
            this.Controls.Add(this.SearchTimeLabel);
            this.Controls.Add(this.searchFieldLabel);
            this.Controls.Add(this.SearchFieldCB);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.queryIdLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.page_label);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.prev_button);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Skip_process);
            this.Controls.Add(this.searchInput_label);
            this.Controls.Add(this.search_query);
            this.Controls.Add(this.search_input);
            this.Controls.Add(this.search_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchCore";
            this.Text = "Search Core - GGezTTH";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox search_input;
        private System.Windows.Forms.Label search_query;
        private System.Windows.Forms.Label searchInput_label;
        private System.Windows.Forms.CheckBox Skip_process;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button prev_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Label page_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox queryIdLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox SearchFieldCB;
        private System.Windows.Forms.Label searchFieldLabel;
        private System.Windows.Forms.Label SearchTimeLabel;
        private System.Windows.Forms.Label SpellCheckLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TB_C1_R;
        private System.Windows.Forms.DataGridViewTextBoxColumn TB_C2_T;
        private System.Windows.Forms.DataGridViewTextBoxColumn TB_C3_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn TB_C5_Bili;
        private System.Windows.Forms.DataGridViewTextBoxColumn TB_C5_Abs;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCID;
        private System.Windows.Forms.Button FirstButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label autoText3;
        private System.Windows.Forms.Label autoText2;
        private System.Windows.Forms.Label autoText1;
        private System.Windows.Forms.CheckBox QueryExpandCB;
    }
}