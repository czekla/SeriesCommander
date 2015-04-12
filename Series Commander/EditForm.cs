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
    /// Initiate instance of EditForm
    /// </summary>
    public partial class EditForm : Form
    {

        private Label minta;

        /// <summary>
        /// Base constructor
        /// </summary>
        public EditForm(Label mintalabel)
        {
            InitializeComponent();

            this.minta = mintalabel;
            this.mintaTextBox.Text = minta.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyButton_Click(object sender, EventArgs e)
        {
            this.mintaTextBox.Text = OrganizerForm.PathValidator(this.mintaTextBox.Text);
            
            if (this.mintaTextBox.Text == "") this.mintaTextBox.Text = "Ide kerül a minta";
            this.minta.Text = this.mintaTextBox.Text;
            this.Close();
            
        }
    }
}
