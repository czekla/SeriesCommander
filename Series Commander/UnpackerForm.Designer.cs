namespace SeriesCommander
{
    partial class UnpackerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnpackerForm));
            this.hovaFileSystemTreeView = new System.Windows.Forms.TreeView();
            this.honnanFileSystemTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unpackButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.unpackProgressBar = new System.Windows.Forms.ProgressBar();
            this.mindButton = new System.Windows.Forms.Button();
            this.egyikseButton = new System.Windows.Forms.Button();
            this.unpackProgressLabel = new System.Windows.Forms.Label();
            this.backgroundWorkerUnpack = new System.ComponentModel.BackgroundWorker();
            this.movetoButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorkerMoveto = new System.ComponentModel.BackgroundWorker();
            this.movetoProgressLabel = new System.Windows.Forms.Label();
            this.movetoProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // hovaFileSystemTreeView
            // 
            this.hovaFileSystemTreeView.HideSelection = false;
            this.hovaFileSystemTreeView.Location = new System.Drawing.Point(12, 42);
            this.hovaFileSystemTreeView.Name = "hovaFileSystemTreeView";
            this.hovaFileSystemTreeView.ShowNodeToolTips = true;
            this.hovaFileSystemTreeView.Size = new System.Drawing.Size(298, 566);
            this.hovaFileSystemTreeView.TabIndex = 2;
            // 
            // honnanFileSystemTreeView
            // 
            this.honnanFileSystemTreeView.CheckBoxes = true;
            this.honnanFileSystemTreeView.HideSelection = false;
            this.honnanFileSystemTreeView.Location = new System.Drawing.Point(536, 42);
            this.honnanFileSystemTreeView.Name = "honnanFileSystemTreeView";
            this.honnanFileSystemTreeView.ShowNodeToolTips = true;
            this.honnanFileSystemTreeView.Size = new System.Drawing.Size(298, 566);
            this.honnanFileSystemTreeView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(115, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hova";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(658, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Honnan";
            // 
            // unpackButton
            // 
            this.unpackButton.Location = new System.Drawing.Point(359, 388);
            this.unpackButton.Name = "unpackButton";
            this.unpackButton.Size = new System.Drawing.Size(127, 38);
            this.unpackButton.TabIndex = 6;
            this.unpackButton.Text = "<------";
            this.unpackButton.UseVisualStyleBackColor = true;
            this.unpackButton.Click += new System.EventHandler(this.unpackButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(381, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kicsomagol";
            // 
            // unpackProgressBar
            // 
            this.unpackProgressBar.Location = new System.Drawing.Point(319, 505);
            this.unpackProgressBar.MarqueeAnimationSpeed = 50;
            this.unpackProgressBar.Name = "unpackProgressBar";
            this.unpackProgressBar.Size = new System.Drawing.Size(214, 19);
            this.unpackProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.unpackProgressBar.TabIndex = 9;
            // 
            // mindButton
            // 
            this.mindButton.Location = new System.Drawing.Point(591, 638);
            this.mindButton.Name = "mindButton";
            this.mindButton.Size = new System.Drawing.Size(75, 23);
            this.mindButton.TabIndex = 10;
            this.mindButton.Text = "Összeset";
            this.mindButton.UseVisualStyleBackColor = true;
            this.mindButton.Click += new System.EventHandler(this.mindButton_Click);
            // 
            // egyikseButton
            // 
            this.egyikseButton.Location = new System.Drawing.Point(720, 638);
            this.egyikseButton.Name = "egyikseButton";
            this.egyikseButton.Size = new System.Drawing.Size(75, 23);
            this.egyikseButton.TabIndex = 11;
            this.egyikseButton.Text = "Semelyiket";
            this.egyikseButton.UseVisualStyleBackColor = true;
            this.egyikseButton.Click += new System.EventHandler(this.egyikseButton_Click);
            // 
            // unpackProgressLabel
            // 
            this.unpackProgressLabel.AutoSize = true;
            this.unpackProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unpackProgressLabel.Location = new System.Drawing.Point(316, 463);
            this.unpackProgressLabel.MaximumSize = new System.Drawing.Size(214, 32);
            this.unpackProgressLabel.Name = "unpackProgressLabel";
            this.unpackProgressLabel.Size = new System.Drawing.Size(16, 13);
            this.unpackProgressLabel.TabIndex = 12;
            this.unpackProgressLabel.Text = "...";
            // 
            // backgroundWorkerUnpack
            // 
            this.backgroundWorkerUnpack.WorkerReportsProgress = true;
            this.backgroundWorkerUnpack.WorkerSupportsCancellation = true;
            this.backgroundWorkerUnpack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUnpack_DoWork);
            this.backgroundWorkerUnpack.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUnpack_ProgressChanged);
            this.backgroundWorkerUnpack.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUnpack_RunWorkerCompleted);
            // 
            // movetoButton
            // 
            this.movetoButton.Location = new System.Drawing.Point(359, 143);
            this.movetoButton.Name = "movetoButton";
            this.movetoButton.Size = new System.Drawing.Size(127, 38);
            this.movetoButton.TabIndex = 13;
            this.movetoButton.Text = "<------";
            this.movetoButton.UseVisualStyleBackColor = true;
            this.movetoButton.Click += new System.EventHandler(this.moveToButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(351, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Videó filek áthelyezése";
            // 
            // backgroundWorkerMoveto
            // 
            this.backgroundWorkerMoveto.WorkerReportsProgress = true;
            this.backgroundWorkerMoveto.WorkerSupportsCancellation = true;
            this.backgroundWorkerMoveto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMoveto_DoWork);
            this.backgroundWorkerMoveto.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerMoveto_ProgressChanged);
            this.backgroundWorkerMoveto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerMoveto_RunWorkerCompleted);
            // 
            // movetoProgressLabel
            // 
            this.movetoProgressLabel.AutoSize = true;
            this.movetoProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.movetoProgressLabel.Location = new System.Drawing.Point(316, 214);
            this.movetoProgressLabel.MaximumSize = new System.Drawing.Size(214, 32);
            this.movetoProgressLabel.Name = "movetoProgressLabel";
            this.movetoProgressLabel.Size = new System.Drawing.Size(16, 13);
            this.movetoProgressLabel.TabIndex = 15;
            this.movetoProgressLabel.Text = "...";
            // 
            // movetoProgressBar
            // 
            this.movetoProgressBar.Location = new System.Drawing.Point(316, 256);
            this.movetoProgressBar.MarqueeAnimationSpeed = 50;
            this.movetoProgressBar.Name = "movetoProgressBar";
            this.movetoProgressBar.Size = new System.Drawing.Size(214, 19);
            this.movetoProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.movetoProgressBar.TabIndex = 16;
            // 
            // UnpackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 704);
            this.Controls.Add(this.movetoProgressBar);
            this.Controls.Add(this.movetoProgressLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.movetoButton);
            this.Controls.Add(this.unpackProgressLabel);
            this.Controls.Add(this.egyikseButton);
            this.Controls.Add(this.mindButton);
            this.Controls.Add(this.unpackProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unpackButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.honnanFileSystemTreeView);
            this.Controls.Add(this.hovaFileSystemTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnpackerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kicsomagoló";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnpackerForm_FormClosing);
            this.Load += new System.EventHandler(this.UnpackerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView hovaFileSystemTreeView;
        private System.Windows.Forms.TreeView honnanFileSystemTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button unpackButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar unpackProgressBar;
        private System.Windows.Forms.Button mindButton;
        private System.Windows.Forms.Button egyikseButton;
        private System.Windows.Forms.Label unpackProgressLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUnpack;
        private System.Windows.Forms.Button movetoButton;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMoveto;
        private System.Windows.Forms.Label movetoProgressLabel;
        private System.Windows.Forms.ProgressBar movetoProgressBar;

    }
}