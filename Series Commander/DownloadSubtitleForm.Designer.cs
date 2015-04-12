namespace SeriesCommander
{
    partial class DownloadSubtitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadSubtitleForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.subtitleListDataGridView = new System.Windows.Forms.DataGridView();
            this.Letölt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nyelv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MagyarCím = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EredetiCím = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dátum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.seasonNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.episodeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.seasonPackCheckBox = new System.Windows.Forms.CheckBox();
            this.complexSearchButton = new System.Windows.Forms.Button();
            this.onlyMagyarCheckBox = new System.Windows.Forms.CheckBox();
            this.goodTitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sidTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.subtitleListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoEllipsis = true;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(41, 26);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(86, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Sorozat címe";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(211, 533);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Keresés";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(529, 533);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 2;
            this.downloadButton.Text = "Letöltés";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // subtitleListDataGridView
            // 
            this.subtitleListDataGridView.AllowUserToAddRows = false;
            this.subtitleListDataGridView.AllowUserToDeleteRows = false;
            this.subtitleListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subtitleListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Letölt,
            this.Nyelv,
            this.MagyarCím,
            this.EredetiCím,
            this.Link,
            this.Dátum});
            this.subtitleListDataGridView.Location = new System.Drawing.Point(41, 112);
            this.subtitleListDataGridView.Name = "subtitleListDataGridView";
            this.subtitleListDataGridView.RowHeadersVisible = false;
            this.subtitleListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subtitleListDataGridView.Size = new System.Drawing.Size(811, 400);
            this.subtitleListDataGridView.TabIndex = 3;
            // 
            // Letölt
            // 
            this.Letölt.HeaderText = "Letölt";
            this.Letölt.Name = "Letölt";
            this.Letölt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Letölt.Width = 50;
            // 
            // Nyelv
            // 
            this.Nyelv.HeaderText = "Nyelv";
            this.Nyelv.Name = "Nyelv";
            this.Nyelv.ReadOnly = true;
            this.Nyelv.Width = 70;
            // 
            // MagyarCím
            // 
            this.MagyarCím.HeaderText = "Magyar Cím";
            this.MagyarCím.Name = "MagyarCím";
            this.MagyarCím.ReadOnly = true;
            this.MagyarCím.Width = 300;
            // 
            // EredetiCím
            // 
            this.EredetiCím.HeaderText = "Eredeti Cím";
            this.EredetiCím.Name = "EredetiCím";
            this.EredetiCím.ReadOnly = true;
            this.EredetiCím.Width = 300;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            this.Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Link.Visible = false;
            // 
            // Dátum
            // 
            this.Dátum.HeaderText = "Dátum";
            this.Dátum.Name = "Dátum";
            this.Dátum.ReadOnly = true;
            this.Dátum.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Évad:";
            this.label1.Visible = false;
            // 
            // seasonNumericUpDown
            // 
            this.seasonNumericUpDown.Location = new System.Drawing.Point(82, 56);
            this.seasonNumericUpDown.Name = "seasonNumericUpDown";
            this.seasonNumericUpDown.Size = new System.Drawing.Size(36, 20);
            this.seasonNumericUpDown.TabIndex = 5;
            this.seasonNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seasonNumericUpDown.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Epizód:";
            this.label2.Visible = false;
            // 
            // episodeNumericUpDown
            // 
            this.episodeNumericUpDown.Location = new System.Drawing.Point(189, 56);
            this.episodeNumericUpDown.Name = "episodeNumericUpDown";
            this.episodeNumericUpDown.Size = new System.Drawing.Size(38, 20);
            this.episodeNumericUpDown.TabIndex = 7;
            this.episodeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.episodeNumericUpDown.Visible = false;
            // 
            // seasonPackCheckBox
            // 
            this.seasonPackCheckBox.AutoSize = true;
            this.seasonPackCheckBox.Checked = true;
            this.seasonPackCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.seasonPackCheckBox.Location = new System.Drawing.Point(256, 57);
            this.seasonPackCheckBox.Name = "seasonPackCheckBox";
            this.seasonPackCheckBox.Size = new System.Drawing.Size(75, 17);
            this.seasonPackCheckBox.TabIndex = 8;
            this.seasonPackCheckBox.Text = "Évadpakk";
            this.seasonPackCheckBox.UseVisualStyleBackColor = true;
            this.seasonPackCheckBox.Visible = false;
            // 
            // complexSearchButton
            // 
            this.complexSearchButton.Location = new System.Drawing.Point(317, 533);
            this.complexSearchButton.Name = "complexSearchButton";
            this.complexSearchButton.Size = new System.Drawing.Size(106, 23);
            this.complexSearchButton.TabIndex = 9;
            this.complexSearchButton.Text = "Összetett Keresés";
            this.complexSearchButton.UseVisualStyleBackColor = true;
            this.complexSearchButton.Click += new System.EventHandler(this.complexSearchButton_Click);
            // 
            // onlyMagyarCheckBox
            // 
            this.onlyMagyarCheckBox.AutoSize = true;
            this.onlyMagyarCheckBox.Location = new System.Drawing.Point(646, 537);
            this.onlyMagyarCheckBox.Name = "onlyMagyarCheckBox";
            this.onlyMagyarCheckBox.Size = new System.Drawing.Size(115, 17);
            this.onlyMagyarCheckBox.TabIndex = 10;
            this.onlyMagyarCheckBox.Text = "Csak magyar nyelv";
            this.onlyMagyarCheckBox.UseVisualStyleBackColor = true;
            this.onlyMagyarCheckBox.CheckedChanged += new System.EventHandler(this.onlyMagyarCheckBox_CheckedChanged);
            // 
            // goodTitleTextBox
            // 
            this.goodTitleTextBox.Location = new System.Drawing.Point(420, 54);
            this.goodTitleTextBox.Name = "goodTitleTextBox";
            this.goodTitleTextBox.Size = new System.Drawing.Size(138, 20);
            this.goodTitleTextBox.TabIndex = 11;
            this.goodTitleTextBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Pontos cím:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sorozat ID:";
            this.label4.Visible = false;
            // 
            // sidTextBox
            // 
            this.sidTextBox.Location = new System.Drawing.Point(634, 54);
            this.sidTextBox.Name = "sidTextBox";
            this.sidTextBox.Size = new System.Drawing.Size(100, 20);
            this.sidTextBox.TabIndex = 14;
            this.sidTextBox.Visible = false;
            // 
            // DownloadSubtitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 617);
            this.Controls.Add(this.sidTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goodTitleTextBox);
            this.Controls.Add(this.onlyMagyarCheckBox);
            this.Controls.Add(this.complexSearchButton);
            this.Controls.Add(this.seasonPackCheckBox);
            this.Controls.Add(this.episodeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seasonNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subtitleListDataGridView);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadSubtitleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feliratkereső";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadSubtitleForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.subtitleListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.DataGridView subtitleListDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown seasonNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown episodeNumericUpDown;
        private System.Windows.Forms.CheckBox seasonPackCheckBox;
        private System.Windows.Forms.Button complexSearchButton;
        private System.Windows.Forms.CheckBox onlyMagyarCheckBox;
        private System.Windows.Forms.TextBox goodTitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sidTextBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Letölt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nyelv;
        private System.Windows.Forms.DataGridViewTextBoxColumn MagyarCím;
        private System.Windows.Forms.DataGridViewTextBoxColumn EredetiCím;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dátum;
    }
}