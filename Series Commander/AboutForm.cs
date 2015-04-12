using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SeriesCommander
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paypalDonateButton_Click(object sender, EventArgs e)
        {
            String link = "https://www.paypal.com/cgi-bin/webscr";
            Process.Start(link + "?cmd=_s-xclick&hosted_button_id=6Z3YHEBHLED2C");
        }

        
    }
}
