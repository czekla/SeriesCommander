namespace SeriesCommander
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileSystemTreeView = new System.Windows.Forms.TreeView();
            this.videoListBox = new System.Windows.Forms.ListBox();
            this.subtitleListBox = new System.Windows.Forms.ListBox();
            this.videoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.renameButton = new System.Windows.Forms.Button();
            this.autoRenameButton = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seriesCalendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemTreeView
            // 
            this.fileSystemTreeView.FullRowSelect = true;
            this.fileSystemTreeView.HideSelection = false;
            this.fileSystemTreeView.Location = new System.Drawing.Point(12, 37);
            this.fileSystemTreeView.Name = "fileSystemTreeView";
            this.fileSystemTreeView.ShowNodeToolTips = true;
            this.fileSystemTreeView.Size = new System.Drawing.Size(298, 650);
            this.fileSystemTreeView.TabIndex = 1;
            // 
            // videoListBox
            // 
            this.videoListBox.BackColor = System.Drawing.SystemColors.Window;
            this.videoListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.videoListBox.FormattingEnabled = true;
            this.videoListBox.HorizontalScrollbar = true;
            this.videoListBox.ItemHeight = 16;
            this.videoListBox.Location = new System.Drawing.Point(351, 85);
            this.videoListBox.Name = "videoListBox";
            this.videoListBox.Size = new System.Drawing.Size(262, 500);
            this.videoListBox.TabIndex = 2;
            this.videoListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.videoListBox_KeyPress);
            this.videoListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.videoListBox_MouseDoubleClick);
            // 
            // subtitleListBox
            // 
            this.subtitleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subtitleListBox.FormattingEnabled = true;
            this.subtitleListBox.HorizontalScrollbar = true;
            this.subtitleListBox.ItemHeight = 16;
            this.subtitleListBox.Location = new System.Drawing.Point(652, 85);
            this.subtitleListBox.Name = "subtitleListBox";
            this.subtitleListBox.Size = new System.Drawing.Size(257, 500);
            this.subtitleListBox.TabIndex = 3;
            this.subtitleListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subtitleListBox_KeyPress);
            this.subtitleListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.subtitleListBox_MouseDoubleClick);
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.videoLabel.Location = new System.Drawing.Point(451, 57);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(54, 16);
            this.videoLabel.TabIndex = 4;
            this.videoLabel.Text = "Videók:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(747, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Feliratok:";
            // 
            // renameButton
            // 
            this.renameButton.AutoEllipsis = true;
            this.renameButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.renameButton.Location = new System.Drawing.Point(454, 640);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 6;
            this.renameButton.Text = "Átnevez";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // autoRenameButton
            // 
            this.autoRenameButton.AutoEllipsis = true;
            this.autoRenameButton.Location = new System.Drawing.Point(736, 640);
            this.autoRenameButton.Name = "autoRenameButton";
            this.autoRenameButton.Size = new System.Drawing.Size(92, 23);
            this.autoRenameButton.TabIndex = 7;
            this.autoRenameButton.Text = "Auto Átnevez";
            this.autoRenameButton.UseVisualStyleBackColor = true;
            this.autoRenameButton.Click += new System.EventHandler(this.autoRenameButton_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "Fájl";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "Beállítások";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.exitToolStripMenuItem.Text = "Kilépés";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(947, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unpackerToolStripMenuItem,
            this.seriesCalendarToolStripMenuItem,
            this.organizerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.toolsToolStripMenuItem.Text = "Eszközök";
            // 
            // unpackerToolStripMenuItem
            // 
            this.unpackerToolStripMenuItem.Name = "unpackerToolStripMenuItem";
            this.unpackerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unpackerToolStripMenuItem.Text = "Kicsomagoló";
            this.unpackerToolStripMenuItem.Click += new System.EventHandler(this.unpackerToolStripMenuItem_Click);
            // 
            // seriesCalendarToolStripMenuItem
            // 
            this.seriesCalendarToolStripMenuItem.Name = "seriesCalendarToolStripMenuItem";
            this.seriesCalendarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.seriesCalendarToolStripMenuItem.Text = "Sorozat Naptár";
            this.seriesCalendarToolStripMenuItem.Click += new System.EventHandler(this.seriesCalendarToolStripMenuItem_Click);
            // 
            // organizerToolStripMenuItem
            // 
            this.organizerToolStripMenuItem.Name = "organizerToolStripMenuItem";
            this.organizerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.organizerToolStripMenuItem.Text = "Rendszerező";
            this.organizerToolStripMenuItem.Click += new System.EventHandler(this.organizerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.helpToolStripMenuItem.Text = "Súgó";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.viewHelpToolStripMenuItem.Text = "Tartalom";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "Névjegy";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // renameProgressBar
            // 
            this.renameProgressBar.Location = new System.Drawing.Point(504, 604);
            this.renameProgressBar.MarqueeAnimationSpeed = 50;
            this.renameProgressBar.Name = "renameProgressBar";
            this.renameProgressBar.Size = new System.Drawing.Size(255, 19);
            this.renameProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.renameProgressBar.TabIndex = 8;
            this.renameProgressBar.UseWaitCursor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(947, 699);
            this.Controls.Add(this.renameProgressBar);
            this.Controls.Add(this.autoRenameButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoLabel);
            this.Controls.Add(this.subtitleListBox);
            this.Controls.Add(this.videoListBox);
            this.Controls.Add(this.fileSystemTreeView);
            this.Controls.Add(this.mainMenuStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Series Commander";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fileSystemTreeView;
        private System.Windows.Forms.ListBox videoListBox;
        private System.Windows.Forms.ListBox subtitleListBox;
        private System.Windows.Forms.Label videoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button autoRenameButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seriesCalendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizerToolStripMenuItem;
        private System.Windows.Forms.ProgressBar renameProgressBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
    }
}

