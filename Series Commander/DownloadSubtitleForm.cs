using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Net;
using System.Globalization;
using HtmlAgilityPack;
using System.Diagnostics;

namespace SeriesCommander
{
    public partial class DownloadSubtitleForm : Form
    {

        private string title;
        private static string website = @"http://www.feliratok.info";
        private BackgroundWorker backgroundWorker;
        private string webpagefile = "webpage.html";
        private string nextpagelink = "";
        private XPathNavigator nav;
        private XPathExpression expr;
        private XPathNodeIterator iterator;

        public DownloadSubtitleForm(string title)
        {
            InitializeComponent();
            this.title = title;
            this.titleLabel.Text = "Sorozat címe: " + title;

            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {


            BackgroundWorker bw = sender as BackgroundWorker;

            ArgumentObject arg = e.Argument as ArgumentObject;

            string link = arg.link;
            //DataGridView datagridview = arg.dgv;

            while (link != "")
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                nextpagelink = "";

                using (WebClient client = new WebClient())
                {

                    client.Encoding = System.Text.Encoding.UTF8;
                    string resultPage = "";
                    try
                    {
                        resultPage = client.DownloadString(link);
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show("Nem sikerült csatlakozni a " + website + " oldalhoz!" + Environment.NewLine + "Ellenőrizd az internet kapcsolatod!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    StreamWriter tw = new StreamWriter(webpagefile);
                    tw.Write(resultPage);
                    tw.Close();
                    //Console.WriteLine("letöltve");


                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.Load(webpagefile, System.Text.Encoding.UTF8);
                    //Console.WriteLine("betöltve");

                    string expression = @"//tr[@id='vilagit']";  //ebbe a tagbe vannak a sorozatok egyessével
                    var nodes = doc.DocumentNode.SelectNodes(expression);  // az oldalon található összes sorozat bejegyzés

                    if (nodes == null)
                    {
                        File.Delete(webpagefile);
                        break;
                    }


                    foreach (var node in nodes)
                    {
                        //int newrowIndex = this.subtitleListDataGridView.Rows.Add();
                        //DataGridViewRow newrow = this.subtitleListDataGridView.Rows[newrowIndex];
                        //Console.WriteLine(this.subtitleListDataGridView.RowTemplate);
                        //DataGridViewRow newrow = this.subtitleListDataGridView.RowTemplate;
                        FillRow(node);

                        //bw.ReportProgress(1, newrow);
                    }
                    // következő oldal ">"
                    var nextPageNode = doc.DocumentNode.SelectSingleNode(@"//div[@class='pagination']");
                    if (nextPageNode != null)
                    {
                        nav = nextPageNode.CreateNavigator();
                        expr = nav.Compile(@"./a[.='>']");
                        iterator = nav.Select(expr);
                        while (iterator.MoveNext())
                        {
                            XPathNavigator nav2 = iterator.Current.Clone();
                            //Console.WriteLine("link:" + website + nav2.GetAttribute("href", ""));
                            nextpagelink = website + nav2.GetAttribute("href", "");
                        }
                    }
                }
                // ha vége a feldolgozásnak file törlés
                File.Delete(webpagefile);

                link = nextpagelink;
            }
            
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int newrow = this.subtitleListDataGridView.Rows.Add();
            NewRowObject obj = (NewRowObject)e.UserState;
            this.subtitleListDataGridView.Rows[newrow].Cells[0].Value = obj.letolt;
            this.subtitleListDataGridView.Rows[newrow].Cells[1].Value = obj.nyelv;
            this.subtitleListDataGridView.Rows[newrow].Cells[2].Value = obj.magyar;
            this.subtitleListDataGridView.Rows[newrow].Cells[3].Value = obj.eredeti;
            this.subtitleListDataGridView.Rows[newrow].Cells[4].Value = obj.link;
            this.subtitleListDataGridView.Rows[newrow].Cells[5].Value = obj.datum;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "yyyy.MM.dd";
            this.subtitleListDataGridView.Rows[newrow].Cells[5].Style = style;
            this.subtitleListDataGridView.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Cursor = Cursors.Default;
            this.searchButton.Enabled = true;
        }

        private class ArgumentObject
        {
            public string link { get; set; }
        }

        private class NewRowObject
        {
            public bool letolt { get; set; }
            public string nyelv { get; set; }
            public string magyar { get; set; }
            public string eredeti { get; set; }
            public string link { get; set; }
            public DateTime datum { get; set; }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //string link = website + @"/index.php?search=" + title.Replace(".", "+") + @"&nyelv=&searchB=Mehet";
            string link = website + @"/index.php?search=" + title.Replace(".", "+");
            //+ @"&soriSorszam=&nyelv=&sorozatnev=&sid=&complexsearch=true&knyelv=0&evad=&epizod1=&cimke=0&minoseg=0&rlsr=0&tab=all";
            //this.Cursor = Cursors.WaitCursor;
            this.searchButton.Enabled = false;
            this.OpenLink(link);
        }

        private void complexSearchButton_Click(object sender, EventArgs e)
        {
            //int season = (int)this.seasonNumericUpDown.Value;
            //int episode = (int)this.episodeNumericUpDown.Value;
            //bool seasonpack = this.seasonPackCheckBox.Checked;
            //string goodtitle = this.goodTitleTextBox.Text;
            //int sid = 0;
            //int.TryParse(this.sidTextBox.Text, out sid);

            //StringBuilder link = new StringBuilder();
            //link.Append(website);
            //link.Append(@"/index.php?search=");
            //link.Append(@"&soriSorszam=&nyelv=&sorozatnev=");
            //link.Append(goodtitle.Replace(".", "+").Replace("(", "%28").Replace(")", "%29")); //ide pontos cím kellene a feliratok.info oldalon tárolt :(
            //link.Append(@"&sid=");
            //link.Append(sid); //ide pontos SID kellene a feliratok.info oldalon tárolt :(
            //link.Append("&complexsearch=true&knyelv=0");
            //link.Append(@"&evad=");
            //link.Append(season);
            //link.Append(@"&epizod1=");
            //link.Append(episode);
            //if (seasonpack) link.Append(@"&evadpakk=on");
            //link.Append(@"&cimke=0&minoseg=0&rlsr=0&tab=all");

            //this.OpenLink(link.ToString());

            string link = website + @"/index.php?search=" + title.Replace(".", "+");
            Process.Start(link);
        }

        private void OpenLink(string link)
        {
            
            this.subtitleListDataGridView.Rows.Clear();

            //DataGridViewRow newrow = this.subtitleListDataGridView.RowTemplate;

            this.backgroundWorker.RunWorkerAsync(new ArgumentObject()
            {
                link = link
            });

            //while ((link = LoadDataFromPage(link)) != "")
            //{
            //    //Console.WriteLine("uj oldal: ");
            //}

            
        }


        private void FillRow(HtmlAgilityPack.HtmlNode node)
        {

            nav = node.CreateNavigator();

            bool letolt = false;
            string nyelv = "";
            string magyar = "";
            string eredeti = "";
            string link = "";
            DateTime datum = DateTime.Now;


            //expr = nav.Compile(@"./td/small");
            //expr = nav.Compile(@"./td[small='Magyar']");
            //expr = nav.Compile(@"./td/div[@class='eredeti']");

            // Nyelv:
            expr = nav.Compile(@"./td/small");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                //Console.WriteLine("nyelv:" + nav2.Value);
                nyelv = nav2.Value;
            }

            // magyar cím:
            expr = nav.Compile(@"./td/div[@class='magyar']");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                //Console.WriteLine("magyar cím:" + nav2.Value);
                magyar = nav2.Value;

            }

            // eredeti cím:
            expr = nav.Compile(@"./td/div[@class='eredeti']");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                //Console.WriteLine("eredeti cím:" + nav2.Value);
                eredeti = nav2.Value;

            }

            // Link:
            expr = nav.Compile(@"./td/a[@href]");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                //Console.WriteLine("link:" + website + nav2.GetAttribute("href", ""));
                link = website + nav2.GetAttribute("href", "");
            }

            // dátum:
            expr = nav.Compile(@"./td");
            iterator = nav.Select(expr);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();

                string datestring = nav2.Value.Trim();
                string format = "yyyy-MM-dd";
                DateTime dt;
                if (DateTime.TryParseExact(datestring, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    datum = dt.Date;
                    //DataGridViewCellStyle style = new DataGridViewCellStyle();
                    //style.Format = "yyyy.MM.dd";
                    //newrow.Cells[5].Style = style;
                }

            }

            backgroundWorker.ReportProgress(1, new NewRowObject()
            {
                datum = datum,
                eredeti = eredeti,
                letolt = letolt,
                link = link,
                magyar = magyar,
                nyelv = nyelv
            });
        }

        private string LoadDataFromPage(string link)
        {
            string webpagefile = "webpage.html";
            string nextpagelink = "";

            using (WebClient client = new WebClient())
            {

                client.Encoding = System.Text.Encoding.UTF8;
                string resultPage = "";
                try
                {
                    resultPage = client.DownloadString(link);
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Nem sikerült csatlakozni a " + website + " oldalhoz!" + Environment.NewLine + "Ellenőrizd az internet kapcsolatod!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

                StreamWriter tw = new StreamWriter(webpagefile);
                tw.Write(resultPage);
                tw.Close();
                //Console.WriteLine("letöltve");


                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(webpagefile, System.Text.Encoding.UTF8);
                //Console.WriteLine("betöltve");
                string expression = @"//tr[@id='vilagit']";  //ebbe a tagbe vannak a sorozatok egyessével
                var nodes = doc.DocumentNode.SelectNodes(expression);

                if (nodes == null)
                {
                    File.Delete(webpagefile);
                    return "";
                }

                XPathNavigator nav;
                XPathExpression expr;
                XPathNodeIterator iterator;
                int newrow;

                foreach (var node in nodes)
                {
                    nav = node.CreateNavigator();

                    newrow = this.subtitleListDataGridView.Rows.Add();
                    this.subtitleListDataGridView.Rows[newrow].Cells[0].Value = false;

                    //expr = nav.Compile(@"./td/small");
                    //expr = nav.Compile(@"./td[small='Magyar']");
                    //expr = nav.Compile(@"./td/div[@class='eredeti']");

                    // Nyelv:
                    expr = nav.Compile(@"./td/small");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        //Console.WriteLine("nyelv:" + nav2.Value);
                        this.subtitleListDataGridView.Rows[newrow].Cells[1].Value = nav2.Value;
                    }

                    // magyar cím:
                    expr = nav.Compile(@"./td/div[@class='magyar']");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        //Console.WriteLine("magyar cím:" + nav2.Value);
                        this.subtitleListDataGridView.Rows[newrow].Cells[2].Value = nav2.Value;

                    }

                    // eredeti cím:
                    expr = nav.Compile(@"./td/div[@class='eredeti']");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        //Console.WriteLine("eredeti cím:" + nav2.Value);
                        this.subtitleListDataGridView.Rows[newrow].Cells[3].Value = nav2.Value;

                    }

                    // Link:
                    expr = nav.Compile(@"./td/a[@href]");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        //Console.WriteLine("link:" + website + nav2.GetAttribute("href", ""));
                        this.subtitleListDataGridView.Rows[newrow].Cells[4].Value = website + nav2.GetAttribute("href", "");
                    }

                    // dátum:
                    expr = nav.Compile(@"./td");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();

                        string datestring = nav2.Value.Trim();
                        string format = "yyyy-MM-dd";
                        DateTime dt;
                        if (DateTime.TryParseExact(datestring, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                        {
                            this.subtitleListDataGridView.Rows[newrow].Cells[5].Value = dt.Date;
                            DataGridViewCellStyle style = new DataGridViewCellStyle();
                            style.Format = "yyyy.MM.dd";
                            this.subtitleListDataGridView.Rows[newrow].Cells[5].Style = style;
                        }

                    }

                }

                // következő oldal ">"
                var nextPageNode = doc.DocumentNode.SelectSingleNode(@"//div[@class='pagination']");
                if (nextPageNode != null)
                {
                    nav = nextPageNode.CreateNavigator();
                    expr = nav.Compile(@"./a[.='>']");
                    iterator = nav.Select(expr);
                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        //Console.WriteLine("link:" + website + nav2.GetAttribute("href", ""));
                        nextpagelink = website + nav2.GetAttribute("href", "");
                    }
                }



            }

            // ha vége a feldolgozásnak file törlés
            File.Delete(webpagefile);

            return nextpagelink;
        }


        private void downloadButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("download");
            if (!di.Exists) di.Create();
            for (int row = 0; row < this.subtitleListDataGridView.Rows.Count; row++)
            {
                DataGridViewCheckBoxCell cell = this.subtitleListDataGridView.Rows[row].Cells[0] as DataGridViewCheckBoxCell;
                if ((bool)cell.Value == true) DownloadSubtitle(this.subtitleListDataGridView.Rows[row].Cells["Link"].Value.ToString());
            }

            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.Extension == ".rar" || fi.Extension == ".zip")
                {
                    //Console.WriteLine("{0}{1}{2}", di.FullName, Settings.Default.defaultPath, fi.Name);
                    if (UnpackerForm.UnZip(di.FullName, Settings.Default.defaultPath, fi.Name) == 0) fi.Delete();
                }
                else
                {
                    //Console.WriteLine("{0}{1}", fi.FullName, Settings.Default.defaultPath + @"\" + fi.Name);

                    File.Copy(fi.FullName, Settings.Default.defaultPath + @"\" + fi.Name, true);
                    fi.Delete();
                }
            }

            MessageBox.Show("Letöltés kész!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Console.WriteLine("letöltés kész teljesen");

        }

        private void DownloadSubtitle(string link)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;

                string filename = link.Substring(link.IndexOf("&fnev") + 6, link.IndexOf("&felirat") - link.IndexOf("&fnev") - 6);

                client.DownloadFile(link, @"download\" + filename);
                //Console.WriteLine("letöltés kész ok");
            }


        }

        private void onlyMagyarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.onlyMagyarCheckBox.Checked)
            {
                foreach (DataGridViewRow row in this.subtitleListDataGridView.Rows)
                {
                    DataGridViewTextBoxCell cell = row.Cells[1] as DataGridViewTextBoxCell;
                    if ((string)cell.Value != "Magyar") row.Visible = false;

                }
            }
            else
            {
                foreach (DataGridViewRow row in this.subtitleListDataGridView.Rows)
                {
                    row.Visible = true;
                }
            }
            this.subtitleListDataGridView.Update();
        }

        private void DownloadSubtitleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.backgroundWorker.CancelAsync();
            e.Cancel = true;
            this.Hide();
        }









    }
}
