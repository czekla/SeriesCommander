namespace SeriesCommander
{
    partial class SeasonEpisodeQForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeasonEpisodeQForm));
            this.label1 = new System.Windows.Forms.Label();
            this.seriesTitleLabel = new System.Windows.Forms.Label();
            this.seasonNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.episodeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.kihagyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seasonNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "A következő sorozat résznek nem sikerült egyértelműen meghatározni az évad és epi" +
    "zód számát:";
            // 
            // seriesTitleLabel
            // 
            this.seriesTitleLabel.AutoEllipsis = true;
            this.seriesTitleLabel.AutoSize = true;
            this.seriesTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seriesTitleLabel.Location = new System.Drawing.Point(11, 57);
            this.seriesTitleLabel.Name = "seriesTitleLabel";
            this.seriesTitleLabel.Size = new System.Drawing.Size(76, 16);
            this.seriesTitleLabel.TabIndex = 1;
            this.seriesTitleLabel.Text = "sorozat cim";
            // 
            // seasonNumericUpDown
            // 
            this.seasonNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seasonNumericUpDown.Location = new System.Drawing.Point(133, 107);
            this.seasonNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.seasonNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seasonNumericUpDown.Name = "seasonNumericUpDown";
            this.seasonNumericUpDown.Size = new System.Drawing.Size(62, 22);
            this.seasonNumericUpDown.TabIndex = 2;
            this.seasonNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // episodeNumericUpDown
            // 
            this.episodeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.episodeNumericUpDown.Location = new System.Drawing.Point(274, 107);
            this.episodeNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.episodeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.episodeNumericUpDown.Name = "episodeNumericUpDown";
            this.episodeNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.episodeNumericUpDown.TabIndex = 3;
            this.episodeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(85, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "évad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(216, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "epizód:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(88, 168);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // kihagyButton
            // 
            this.kihagyButton.Location = new System.Drawing.Point(258, 168);
            this.kihagyButton.Name = "kihagyButton";
            this.kihagyButton.Size = new System.Drawing.Size(75, 23);
            this.kihagyButton.TabIndex = 7;
            this.kihagyButton.Text = "Kihagy";
            this.kihagyButton.UseVisualStyleBackColor = true;
            this.kihagyButton.Click += new System.EventHandler(this.kihagyButton_Click);
            // 
            // SeasonEpisodeQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.Controls.Add(this.kihagyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.episodeNumericUpDown);
            this.Controls.Add(this.seasonNumericUpDown);
            this.Controls.Add(this.seriesTitleLabel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeasonEpisodeQForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Series Commander";
            ((System.ComponentModel.ISupportInitialize)(this.seasonNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label seriesTitleLabel;
        private System.Windows.Forms.NumericUpDown seasonNumericUpDown;
        private System.Windows.Forms.NumericUpDown episodeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button kihagyButton;
    }
}