using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of OptionsForm
    /// </summary>
    public partial class OptionsForm : Form
    {

        private bool defaultPathChanged;
        private bool defaultUnpackPathChanged;
        private string logdir = "logs";

        /// <summary>
        /// Base constructor
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
            this.defaultPathChanged = false;
            this.defaultUnpackPathChanged = false;
            LoadGeneralSettings();
            LoadOrganizerSettings();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.defaultPathChanged = false;
            this.defaultUnpackPathChanged = false;
        }

        /**
         * General Settings 
         */
        #region General Settings

        /// <summary>
        /// Load the general settings
        /// </summary>
        private void LoadGeneralSettings()
        {
            this.videoCheckedListBox.SetItemChecked(0, Settings.Default.avi);
            this.videoCheckedListBox.SetItemChecked(1, Settings.Default.mkv);
            this.videoCheckedListBox.SetItemChecked(2, Settings.Default.wmv);
            this.videoCheckedListBox.SetItemChecked(3, Settings.Default.mp4);
            this.videoCheckedListBox.SetItemChecked(4, Settings.Default.ogg);
            this.videoCheckedListBox.SetItemChecked(5, Settings.Default.threegp);
            this.videoCheckedListBox.SetItemChecked(6, Settings.Default.m4v);
            this.subtitleCheckedListBox.SetItemChecked(0, Settings.Default.srt);
            this.subtitleCheckedListBox.SetItemChecked(1, Settings.Default.sub);
            this.deleteCheckBox.Checked = Settings.Default.delete;
            this.defaultPath.Text = Settings.Default.defaultPath;
            this.defaultUnpackPath.Text = Settings.Default.defaultUnpackPath;
            DirectoryInfo di = new DirectoryInfo(logdir);
            if (!di.Exists) di.Create();
        }

        /// <summary>
        /// OK Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            Settings.Default.Upgrade();
            this.Cursor = Cursors.WaitCursor;
            this.Close();
        }

        /// <summary>
        /// Tallóz Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = this.defaultPath.Text;
            this.folderBrowserDialog.ShowDialog();
            this.defaultPath.Text = Settings.Default.defaultPath = this.folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// Tallóz Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = this.defaultUnpackPath.Text;
            this.folderBrowserDialog.ShowDialog();
            this.defaultUnpackPath.Text = Settings.Default.defaultUnpackPath = this.folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.delete = this.deleteCheckBox.Checked;
        }

        /// <summary>
        /// Alapértelmezett Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            LoadGeneralSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultPath_TextChanged(object sender, EventArgs e)
        {
            this.defaultPathChanged = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultUnpackPath_TextChanged(object sender, EventArgs e)
        {
            this.defaultUnpackPathChanged = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Console.WriteLine(e.Index);
            //Console.WriteLine(e.NewValue);
            switch (e.Index)
            {
                case 0:
                    {
                        Settings.Default.avi = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 1:
                    {
                        Settings.Default.mkv = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 2:
                    {
                        Settings.Default.wmv = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 3:
                    {
                        Settings.Default.mp4 = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 4:
                    {
                        Settings.Default.ogg = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 5:
                    {
                        Settings.Default.threegp = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 6:
                    {
                        Settings.Default.m4v = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                
            }
   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subtitleCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Console.WriteLine(e.Index);
            //Console.WriteLine(e.NewValue);
            switch (e.Index)
            {
                case 0:
                    {
                        Settings.Default.srt = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
                case 1:
                    {
                        Settings.Default.sub = (e.NewValue == CheckState.Checked) ? true : false;
                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logFilesButton_Click(object sender, EventArgs e)
        {
            Process.Start(logdir);
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckedListBox VideoCheckedListBox
        {
            get { return this.videoCheckedListBox; }
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckedListBox SubtitleCheckedListBox
        {
            get { return this.subtitleCheckedListBox; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Label DefaultPath
        {
            get { return this.defaultPath; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Label DefaultUnpackPath
        {
            get { return this.defaultUnpackPath; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DefaultPathChanged
        {
            get { return this.defaultPathChanged; }
            set { this.defaultPathChanged = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DefaultUnpackPathChanged
        {
            get { return this.defaultUnpackPathChanged; }
            set { this.defaultUnpackPathChanged = value; }
        }

        #endregion

        /**
         * Organizer Settings 
         */
        #region Organizer Settings

        /// <summary>
        /// Load the special settings
        /// </summary>
        private void LoadOrganizerSettings()
        {
            if (SettingsOrganizer.Default.title == "dot") this.dotRadioButton.Checked = true;
            else this.spaceRadioButton.Checked = true;

            this.seasonTextBox.Text = SettingsOrganizer.Default.season;
            this.episodeTextBox.Text = SettingsOrganizer.Default.episode;
        }

        /// <summary>
        /// OK Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            SettingsOrganizer.Default.Save();
            SettingsOrganizer.Default.Upgrade();
            this.Cursor = Cursors.WaitCursor;
            this.Close();
        }

        /// <summary>
        /// Alapértelmezett Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            SettingsOrganizer.Default.Reset();
            LoadOrganizerSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seasonTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingsOrganizer.Default.season = this.seasonTextBox.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void episodeTextBox_TextChanged(object sender, EventArgs e)
        {
            SettingsOrganizer.Default.episode = this.episodeTextBox.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dotRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dotRadioButton.Checked == true) SettingsOrganizer.Default.title = "dot";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spaceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.spaceRadioButton.Checked == true) SettingsOrganizer.Default.title = "space";
        }

        #endregion

        


    }
}
