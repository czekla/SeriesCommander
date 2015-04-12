using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of SeasonEpisodeQForm
    /// </summary>
    public partial class SeasonEpisodeQForm : Form
    {

        private string season;
        private string episode;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="seriesTitle"></param>
        public SeasonEpisodeQForm(string seriesTitle)
        {
            InitializeComponent();
            this.seriesTitleLabel.Text = seriesTitle;
            this.season = "";
            this.episode = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.season = seasonNumericUpDown.Value.ToString();
            if (this.season.Length == 1) this.season = this.season.Insert(0, "0");
            this.episode = episodeNumericUpDown.Value.ToString();
            if (this.episode.Length == 1) this.episode = this.episode.Insert(0, "0");
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kihagyButton_Click(object sender, EventArgs e)
        {
            this.season = "";
            this.episode = "";
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Season 
        {
            get { return this.season; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Episode
        {
            get { return this.episode; }
        }
        
    }
}
