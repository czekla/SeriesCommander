namespace SeriesCommander
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.videoCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.subtitleCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.defaultPath = new System.Windows.Forms.Label();
            this.defaultUnpackPath = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spaceRadioButton = new System.Windows.Forms.RadioButton();
            this.dotRadioButton = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.episodeTextBox = new System.Windows.Forms.TextBox();
            this.seasonTextBox = new System.Windows.Forms.TextBox();
            this.logFilesButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(45, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Videó típusok:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(330, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Felirat típusok:";
            // 
            // videoCheckedListBox
            // 
            this.videoCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.videoCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.videoCheckedListBox.CheckOnClick = true;
            this.videoCheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.videoCheckedListBox.FormattingEnabled = true;
            this.videoCheckedListBox.Items.AddRange(new object[] {
            "avi",
            "mkv",
            "wmv",
            "mp4",
            "ogg",
            "3gp",
            "m4v"});
            this.videoCheckedListBox.Location = new System.Drawing.Point(51, 56);
            this.videoCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.videoCheckedListBox.Name = "videoCheckedListBox";
            this.videoCheckedListBox.Size = new System.Drawing.Size(123, 68);
            this.videoCheckedListBox.TabIndex = 3;
            this.videoCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.videoCheckedListBox_ItemCheck);
            // 
            // subtitleCheckedListBox
            // 
            this.subtitleCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.subtitleCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subtitleCheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subtitleCheckedListBox.FormattingEnabled = true;
            this.subtitleCheckedListBox.Items.AddRange(new object[] {
            "srt",
            "sub"});
            this.subtitleCheckedListBox.Location = new System.Drawing.Point(336, 56);
            this.subtitleCheckedListBox.Name = "subtitleCheckedListBox";
            this.subtitleCheckedListBox.Size = new System.Drawing.Size(116, 68);
            this.subtitleCheckedListBox.TabIndex = 4;
            this.subtitleCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.subtitleCheckedListBox_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(45, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sorozat könyvtár:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(486, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Tallóz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(45, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Letöltés könyvtár:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(486, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Tallóz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteCheckBox.Location = new System.Drawing.Point(48, 306);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(224, 20);
            this.deleteCheckBox.TabIndex = 13;
            this.deleteCheckBox.Text = "Fájlok törlése kicsomagolás után";
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            this.deleteCheckBox.CheckedChanged += new System.EventHandler(this.deleteCheckBox_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(384, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Alapértelmezett";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 511);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.logFilesButton);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.subtitleCheckedListBox);
            this.tabPage1.Controls.Add(this.defaultPath);
            this.tabPage1.Controls.Add(this.videoCheckedListBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.defaultUnpackPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.deleteCheckBox);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(646, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Általános";
            // 
            // defaultPath
            // 
            this.defaultPath.AutoEllipsis = true;
            this.defaultPath.Location = new System.Drawing.Point(162, 180);
            this.defaultPath.Name = "defaultPath";
            this.defaultPath.Size = new System.Drawing.Size(316, 14);
            this.defaultPath.TabIndex = 8;
            this.defaultPath.Text = global::SeriesCommander.Settings.Default.defaultPath;
            this.defaultPath.TextChanged += new System.EventHandler(this.defaultPath_TextChanged);
            // 
            // defaultUnpackPath
            // 
            this.defaultUnpackPath.AutoEllipsis = true;
            this.defaultUnpackPath.Location = new System.Drawing.Point(163, 236);
            this.defaultUnpackPath.Name = "defaultUnpackPath";
            this.defaultUnpackPath.Size = new System.Drawing.Size(315, 13);
            this.defaultUnpackPath.TabIndex = 10;
            this.defaultUnpackPath.Text = global::SeriesCommander.Settings.Default.defaultUnpackPath;
            this.defaultUnpackPath.TextChanged += new System.EventHandler(this.defaultUnpackPath_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.spaceRadioButton);
            this.tabPage2.Controls.Add(this.dotRadioButton);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.episodeTextBox);
            this.tabPage2.Controls.Add(this.seasonTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(646, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rendszerező";
            // 
            // spaceRadioButton
            // 
            this.spaceRadioButton.AutoSize = true;
            this.spaceRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.spaceRadioButton.Location = new System.Drawing.Point(352, 53);
            this.spaceRadioButton.Name = "spaceRadioButton";
            this.spaceRadioButton.Size = new System.Drawing.Size(68, 20);
            this.spaceRadioButton.TabIndex = 11;
            this.spaceRadioButton.TabStop = true;
            this.spaceRadioButton.Text = "szóköz";
            this.spaceRadioButton.UseVisualStyleBackColor = true;
            this.spaceRadioButton.CheckedChanged += new System.EventHandler(this.spaceRadioButton_CheckedChanged);
            // 
            // dotRadioButton
            // 
            this.dotRadioButton.AutoSize = true;
            this.dotRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dotRadioButton.Location = new System.Drawing.Point(261, 53);
            this.dotRadioButton.Name = "dotRadioButton";
            this.dotRadioButton.Size = new System.Drawing.Size(52, 20);
            this.dotRadioButton.TabIndex = 10;
            this.dotRadioButton.TabStop = true;
            this.dotRadioButton.Text = "pont";
            this.dotRadioButton.UseVisualStyleBackColor = true;
            this.dotRadioButton.CheckedChanged += new System.EventHandler(this.dotRadioButton_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(421, 417);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Alapértelmezett";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(179, 417);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "OK";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(34, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Epizód:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(34, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Évad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(34, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sorozat cím és info elhatároló:";
            // 
            // episodeTextBox
            // 
            this.episodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.episodeTextBox.Location = new System.Drawing.Point(135, 202);
            this.episodeTextBox.Name = "episodeTextBox";
            this.episodeTextBox.Size = new System.Drawing.Size(178, 22);
            this.episodeTextBox.TabIndex = 2;
            this.episodeTextBox.TextChanged += new System.EventHandler(this.episodeTextBox_TextChanged);
            // 
            // seasonTextBox
            // 
            this.seasonTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seasonTextBox.Location = new System.Drawing.Point(135, 127);
            this.seasonTextBox.Name = "seasonTextBox";
            this.seasonTextBox.Size = new System.Drawing.Size(178, 22);
            this.seasonTextBox.TabIndex = 1;
            this.seasonTextBox.TextChanged += new System.EventHandler(this.seasonTextBox_TextChanged);
            // 
            // logFilesButton
            // 
            this.logFilesButton.Location = new System.Drawing.Point(486, 306);
            this.logFilesButton.Name = "logFilesButton";
            this.logFilesButton.Size = new System.Drawing.Size(75, 23);
            this.logFilesButton.TabIndex = 15;
            this.logFilesButton.Text = "Log fájlok";
            this.logFilesButton.UseVisualStyleBackColor = true;
            this.logFilesButton.Click += new System.EventHandler(this.logFilesButton_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 511);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Beállítások";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox videoCheckedListBox;
        private System.Windows.Forms.CheckedListBox subtitleCheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label defaultPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label defaultUnpackPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox episodeTextBox;
        private System.Windows.Forms.TextBox seasonTextBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton spaceRadioButton;
        private System.Windows.Forms.RadioButton dotRadioButton;
        private System.Windows.Forms.Button logFilesButton;
    }
}