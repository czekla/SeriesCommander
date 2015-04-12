namespace SeriesCommander
{
    partial class OrganizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizerForm));
            this.mintaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.perjelButton = new System.Windows.Forms.Button();
            this.sorozatcimButton = new System.Windows.Forms.Button();
            this.evadButton = new System.Windows.Forms.Button();
            this.epizodButton = new System.Windows.Forms.Button();
            this.pontButton = new System.Windows.Forms.Button();
            this.fileSystemTreeView = new System.Windows.Forms.TreeView();
            this.mindButton = new System.Windows.Forms.Button();
            this.egyikseButton = new System.Windows.Forms.Button();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.torolButton = new System.Windows.Forms.Button();
            this.organizerButton = new System.Windows.Forms.Button();
            this.editStringButton = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.szokozButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mintaLabel
            // 
            this.mintaLabel.AutoSize = true;
            this.mintaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mintaLabel.Location = new System.Drawing.Point(105, 82);
            this.mintaLabel.Name = "mintaLabel";
            this.mintaLabel.Size = new System.Drawing.Size(105, 16);
            this.mintaLabel.TabIndex = 0;
            this.mintaLabel.Text = "Ide kerül a minta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(49, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minta: ";
            // 
            // perjelButton
            // 
            this.perjelButton.Location = new System.Drawing.Point(52, 29);
            this.perjelButton.Name = "perjelButton";
            this.perjelButton.Size = new System.Drawing.Size(23, 23);
            this.perjelButton.TabIndex = 2;
            this.perjelButton.Text = "\\";
            this.perjelButton.UseVisualStyleBackColor = true;
            this.perjelButton.Click += new System.EventHandler(this.perjelButton_Click);
            // 
            // sorozatcimButton
            // 
            this.sorozatcimButton.Location = new System.Drawing.Point(215, 29);
            this.sorozatcimButton.Name = "sorozatcimButton";
            this.sorozatcimButton.Size = new System.Drawing.Size(75, 23);
            this.sorozatcimButton.TabIndex = 3;
            this.sorozatcimButton.Text = "{sorozatcím}";
            this.sorozatcimButton.UseVisualStyleBackColor = true;
            this.sorozatcimButton.Click += new System.EventHandler(this.sorozatcimButton_Click);
            // 
            // evadButton
            // 
            this.evadButton.Location = new System.Drawing.Point(313, 29);
            this.evadButton.Name = "evadButton";
            this.evadButton.Size = new System.Drawing.Size(75, 23);
            this.evadButton.TabIndex = 4;
            this.evadButton.Text = "{évad}";
            this.evadButton.UseVisualStyleBackColor = true;
            this.evadButton.Click += new System.EventHandler(this.evadButton_Click);
            // 
            // epizodButton
            // 
            this.epizodButton.Location = new System.Drawing.Point(411, 29);
            this.epizodButton.Name = "epizodButton";
            this.epizodButton.Size = new System.Drawing.Size(75, 23);
            this.epizodButton.TabIndex = 5;
            this.epizodButton.Text = "{epizód}";
            this.epizodButton.UseVisualStyleBackColor = true;
            this.epizodButton.Click += new System.EventHandler(this.epizodButton_Click);
            // 
            // pontButton
            // 
            this.pontButton.Location = new System.Drawing.Point(95, 29);
            this.pontButton.Name = "pontButton";
            this.pontButton.Size = new System.Drawing.Size(24, 23);
            this.pontButton.TabIndex = 6;
            this.pontButton.Text = ".";
            this.pontButton.UseVisualStyleBackColor = true;
            this.pontButton.Click += new System.EventHandler(this.pontButton_Click);
            // 
            // fileSystemTreeView
            // 
            this.fileSystemTreeView.CheckBoxes = true;
            this.fileSystemTreeView.HideSelection = false;
            this.fileSystemTreeView.Location = new System.Drawing.Point(52, 153);
            this.fileSystemTreeView.Name = "fileSystemTreeView";
            this.fileSystemTreeView.ShowNodeToolTips = true;
            this.fileSystemTreeView.Size = new System.Drawing.Size(370, 420);
            this.fileSystemTreeView.TabIndex = 7;
            // 
            // mindButton
            // 
            this.mindButton.Location = new System.Drawing.Point(108, 599);
            this.mindButton.Name = "mindButton";
            this.mindButton.Size = new System.Drawing.Size(75, 23);
            this.mindButton.TabIndex = 11;
            this.mindButton.Text = "Összeset";
            this.mindButton.UseVisualStyleBackColor = true;
            this.mindButton.Click += new System.EventHandler(this.mindButton_Click);
            // 
            // egyikseButton
            // 
            this.egyikseButton.Location = new System.Drawing.Point(274, 599);
            this.egyikseButton.Name = "egyikseButton";
            this.egyikseButton.Size = new System.Drawing.Size(75, 23);
            this.egyikseButton.TabIndex = 12;
            this.egyikseButton.Text = "Semelyiket";
            this.egyikseButton.UseVisualStyleBackColor = true;
            this.egyikseButton.Click += new System.EventHandler(this.egyikseButton_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.HorizontalScrollbar = true;
            this.fileListBox.ItemHeight = 16;
            this.fileListBox.Location = new System.Drawing.Point(520, 153);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(284, 420);
            this.fileListBox.TabIndex = 13;
            this.fileListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileListBox_KeyPress);
            this.fileListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListBox_MouseDoubleClick);
            // 
            // torolButton
            // 
            this.torolButton.Location = new System.Drawing.Point(729, 79);
            this.torolButton.Name = "torolButton";
            this.torolButton.Size = new System.Drawing.Size(75, 23);
            this.torolButton.TabIndex = 14;
            this.torolButton.Text = "Töröl";
            this.torolButton.UseVisualStyleBackColor = true;
            this.torolButton.Click += new System.EventHandler(this.torolButton_Click);
            // 
            // organizerButton
            // 
            this.organizerButton.Location = new System.Drawing.Point(633, 599);
            this.organizerButton.Name = "organizerButton";
            this.organizerButton.Size = new System.Drawing.Size(75, 23);
            this.organizerButton.TabIndex = 15;
            this.organizerButton.Text = "Rendszerez";
            this.organizerButton.UseVisualStyleBackColor = true;
            this.organizerButton.Click += new System.EventHandler(this.organizerButton_Click);
            // 
            // editStringButton
            // 
            this.editStringButton.Location = new System.Drawing.Point(729, 29);
            this.editStringButton.Name = "editStringButton";
            this.editStringButton.Size = new System.Drawing.Size(75, 23);
            this.editStringButton.TabIndex = 16;
            this.editStringButton.Text = "Szerkeszt";
            this.editStringButton.UseVisualStyleBackColor = true;
            this.editStringButton.Click += new System.EventHandler(this.editStringButton_Click);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(505, 29);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(75, 23);
            this.infoButton.TabIndex = 17;
            this.infoButton.Text = "{info}";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // szokozButton
            // 
            this.szokozButton.Location = new System.Drawing.Point(141, 29);
            this.szokozButton.Name = "szokozButton";
            this.szokozButton.Size = new System.Drawing.Size(51, 23);
            this.szokozButton.TabIndex = 18;
            this.szokozButton.Text = "szóköz";
            this.szokozButton.UseVisualStyleBackColor = true;
            this.szokozButton.Click += new System.EventHandler(this.szokozButton_Click);
            // 
            // OrganizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 647);
            this.Controls.Add(this.szokozButton);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.editStringButton);
            this.Controls.Add(this.organizerButton);
            this.Controls.Add(this.torolButton);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.egyikseButton);
            this.Controls.Add(this.mindButton);
            this.Controls.Add(this.fileSystemTreeView);
            this.Controls.Add(this.pontButton);
            this.Controls.Add(this.epizodButton);
            this.Controls.Add(this.evadButton);
            this.Controls.Add(this.sorozatcimButton);
            this.Controls.Add(this.perjelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mintaLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrganizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendszerező";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrganizerForm_FormClosing);
            this.Load += new System.EventHandler(this.OrganizerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mintaLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button perjelButton;
        private System.Windows.Forms.Button sorozatcimButton;
        private System.Windows.Forms.Button evadButton;
        private System.Windows.Forms.Button epizodButton;
        private System.Windows.Forms.Button pontButton;
        private System.Windows.Forms.TreeView fileSystemTreeView;
        private System.Windows.Forms.Button mindButton;
        private System.Windows.Forms.Button egyikseButton;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button torolButton;
        private System.Windows.Forms.Button organizerButton;
        private System.Windows.Forms.Button editStringButton;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Button szokozButton;
    }
}