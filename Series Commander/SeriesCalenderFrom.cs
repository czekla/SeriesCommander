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
using System.Diagnostics;

namespace SeriesCommander
{
    //http://www.codeproject.com/Articles/9494/Manipulate-XML-data-with-XPath-and-XmlDocument-C
    public partial class SeriesCalenderFrom : Form
    {

        private const string XML_FILE = "schedule.xml";
        private XmlWriterSettings xmlsettings;
        private string[] daysOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private const int scale = 29;

        /// <summary>
        /// 
        /// </summary>
        public SeriesCalenderFrom()
        {
            InitializeComponent();

            this.groupBox1.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox2.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox3.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox4.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox5.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox6.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);
            this.groupBox7.MouseCaptureChanged += new EventHandler(groupBox_MouseCaptureChanged);

            this.button1.Click += new EventHandler(addbutton_Click);
            this.button2.Click += new EventHandler(addbutton_Click);
            this.button3.Click += new EventHandler(addbutton_Click);
            this.button4.Click += new EventHandler(addbutton_Click);
            this.button5.Click += new EventHandler(addbutton_Click);
            this.button6.Click += new EventHandler(addbutton_Click);
            this.button7.Click += new EventHandler(addbutton_Click);

            ToolTip buttonToolTip = new ToolTip();
            //buttonToolTip.ToolTipTitle = "Törlés";
            //buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 500;
            buttonToolTip.ReshowDelay = 500;
            buttonToolTip.SetToolTip(button1, "Új hozzáadása");
            buttonToolTip.SetToolTip(button2, "Új hozzáadása");
            buttonToolTip.SetToolTip(button3, "Új hozzáadása");
            buttonToolTip.SetToolTip(button4, "Új hozzáadása");
            buttonToolTip.SetToolTip(button5, "Új hozzáadása");
            buttonToolTip.SetToolTip(button6, "Új hozzáadása");
            buttonToolTip.SetToolTip(button7, "Új hozzáadása");      

            xmlsettings = new XmlWriterSettings();
            xmlsettings.Indent = true;

            LoadDataFromXMLFile();

        }

        /// <summary>
        /// Open groupbox by click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            GroupBox gb = (GroupBox)sender;

            if (gb.Controls[0].Visible)
            {
                foreach (Control c in gb.Controls)
                {
                    c.Visible = false;
                }
                gb.AutoSize = false;
                gb.Height = 60;
            }
            else
            {
                foreach (Control c in gb.Controls)
                {
                    c.Visible = true;
                }
                gb.AutoSize = true;
            }

        }

        /// <summary>
        /// Add new seriespanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addbutton_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            GroupBox gb = (GroupBox)(but.Parent);

            int heigh = gb.Height;
            string day = "";
            switch (gb.Text)
            {
                case "Hétfő": day = "Monday"; break;
                case "Kedd": day = "Tuesday"; break;
                case "Szerda": day = "Wednesday"; break;
                case "Csütörtök": day = "Thursday"; break;
                case "Péntek": day = "Friday"; break;
                case "Szombat": day = "Saturday"; break;
                case "Vasárnap": day = "Sunday"; break;
            }

            SeriesPanel sp = new SeriesPanel(day);
            sp.Location = new Point(5, heigh - 40 + 20);
            sp.Disposed += new EventHandler(SeriesPanel_Disposed);
            sp.Click += new EventHandler(SeriesPanel_Click);
            gb.Controls.Add(sp);
        }

        /// <summary>
        /// Save title by click or close(collapse) the groupbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriesPanel_Click(object sender, EventArgs e)
        {
            SeriesPanel sp = (SeriesPanel)sender;
            if (sp.IsTextBoxEditing)
            {
                sp.SaveTitle();
                return;
            }
            GroupBox gb;
            switch (sp.Day)
            {
                case "Monday": gb = this.groupBox1; break;
                case "Tuesday": gb = this.groupBox2; break;
                case "Wednesday": gb = this.groupBox3; break;
                case "Thursday": gb = this.groupBox4; break;
                case "Friday": gb = this.groupBox5; break;
                case "Saturday": gb = this.groupBox6; break;
                case "Sunday": gb = this.groupBox7; break;
                default: gb = new GroupBox(); break;
            }

            foreach (Control c in gb.Controls)
            {
                if (c == gb.Controls[0]) continue;
                SeriesPanel spc = c as SeriesPanel;
                if (spc.IsTextBoxEditing) return;
            }

            groupBox_MouseCaptureChanged(gb, e);
        }

        /// <summary>
        /// Delete seriespanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriesPanel_Disposed(object sender, EventArgs e)
        {
            SeriesPanel sp = (SeriesPanel)sender;

            GroupBox gb;
            switch (sp.Day)
            {
                case "Monday": gb = this.groupBox1; break;
                case "Tuesday": gb = this.groupBox2; break;
                case "Wednesday": gb = this.groupBox3; break;
                case "Thursday": gb = this.groupBox4; break;
                case "Friday": gb = this.groupBox5; break;
                case "Saturday": gb = this.groupBox6; break;
                case "Sunday": gb = this.groupBox7; break;
                default: gb = new GroupBox(); break;
            }

            int heigh = 60;

            foreach (Control c in gb.Controls)
            {
                if (c == gb.Controls[0]) continue;
                c.Location = new Point(5, heigh - 40 + 20);
                heigh += scale;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeriesCalenderFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #region xml

        /// <summary>
        /// 
        /// </summary>
        private void LoadDataFromXMLFile()
        {

            if (!File.Exists(XML_FILE))
            {
                this.CreateXMLFile();
            }

            try
            {
                XPathDocument doc = new XPathDocument(XML_FILE);
                XPathNavigator nav = doc.CreateNavigator();
                string expression;
                XPathExpression expr;
                XPathNodeIterator iterator;

                foreach (string day in daysOfWeek)
                {
                    Console.WriteLine("Loading {0}", day);
                    expression = @"/schedule/day[@name='" + day + "']/title";
                    expr = nav.Compile(expression);
                    iterator = nav.Select(expr);

                    GroupBox gb;
                    switch (day)
                    {
                        case "Monday": gb = this.groupBox1; break;
                        case "Tuesday": gb = this.groupBox2; break;
                        case "Wednesday": gb = this.groupBox3; break;
                        case "Thursday": gb = this.groupBox4; break;
                        case "Friday": gb = this.groupBox5; break;
                        case "Saturday": gb = this.groupBox6; break;
                        case "Sunday": gb = this.groupBox7; break;
                        default: gb = new GroupBox(); break;
                    }

                    int heigh = gb.Height;

                    while (iterator.MoveNext())
                    {
                        XPathNavigator nav2 = iterator.Current.Clone();
                        SeriesPanel sp = new SeriesPanel(day, nav2.Value);
                        sp.Location = new Point(5, heigh - 40 + 20);
                        sp.Disposed += new EventHandler(SeriesPanel_Disposed);
                        sp.Click += new EventHandler(SeriesPanel_Click);
                        gb.Controls.Add(sp);
                        heigh += scale;
                    }

                    foreach (Control c in gb.Controls)
                    {
                        c.Visible = false;
                    }
                    gb.AutoSize = false;
                    gb.Height = 60;

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateXMLFile()
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create(XML_FILE, xmlsettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("schedule");

                    foreach (string day in daysOfWeek)
                    {
                        writer.WriteStartElement("day");
                        writer.WriteAttributeString("name", day);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="title"></param>
        public static void DeleteFromXMLFile(string day, string title)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(XML_FILE);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();

                string expression = @"/schedule/day[@name='" + day + @"']/title[text()='" + title + @"']";
                XmlNode node = doc.SelectSingleNode(expression);
                XmlNode root = node.ParentNode;
                root.RemoveChild(node);

                doc.Save(XML_FILE);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool InsertIntoXMLFile(string day, string title)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(XML_FILE);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();


                if (doc.SelectSingleNode(@"/schedule/day[@name='" + day + @"']/title[text()='" + title + @"']") == null)
                {
                    string expression = @"/schedule/day[@name='" + day + "']";

                    XmlNode node = doc.SelectSingleNode(expression);

                    if (node == null)
                    {
                        var root = doc.DocumentElement;
                        node = doc.CreateElement("day");
                        XmlAttribute attr = doc.CreateAttribute("name");
                        attr.Value = day;
                        node.Attributes.Append(attr);
                        root.AppendChild(node);
                    }

                    XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
                    docFrag.InnerXml = "<title>" + title + "</title>";

                    node.InsertAfter(docFrag, node.LastChild);

                    doc.Save(XML_FILE);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <param name="oldtitle"></param>
        /// <param name="newtitle"></param>
        /// <returns></returns>
        public static bool UpdateXMLFile(string day, string oldtitle, string newtitle)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(XML_FILE);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();

                string expression = @"/schedule/day[@name='" + day + @"']/title[text()='" + oldtitle + @"']";

                XmlNode node = doc.SelectSingleNode(expression);
                if (node != null)
                //update
                {
                    node.InnerXml = newtitle;
                    doc.Save(XML_FILE);
                    return true;
                }
                else
                //insert
                {
                    return InsertIntoXMLFile(day, newtitle);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                return false;
            }
        }

        #endregion xml



        /// <summary>
        /// 
        /// </summary>
        private class SeriesPanel : Panel
        {
            private TextBox textBox;
            private Button torrentButton;
            private Button subtitleButton;
            //private Button findSubtitleButton;
            private Button deleteButton;
            private DownloadSubtitleForm dsf;
            private string day;
            private string title;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="day"></param>
            public SeriesPanel(string day) : this(day, "") { }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="day"></param>
            /// <param name="title"></param>
            public SeriesPanel(string day, string title)
                : base()
            {
                this.Size = new Size(800, 30);

                this.day = day;
                this.title = title;

                textBox = new TextBox();
                textBox.Name = "textbox";
                textBox.Text = title;
                textBox.TabIndex = 0;
                textBox.Size = new Size(300, 23);
                textBox.ReadOnly = true;
                textBox.Location = new Point(30, 2);
                textBox.Click += new EventHandler(textbox_Click);
                textBox.KeyDown += new KeyEventHandler(textbox_KeyDown);

                torrentButton = new Button();
                torrentButton.Name = "torrentButton";
                torrentButton.Text = "Torrent";
                torrentButton.TabIndex = 1;
                torrentButton.Location = new Point(350, 2);
                torrentButton.Size = new Size(75, 23);
                torrentButton.Click += new EventHandler(torrentButton_Click);

                subtitleButton = new Button();
                subtitleButton.Name = "subtitleButton";
                subtitleButton.Text = "Felirat";
                subtitleButton.TabIndex = 2;
                subtitleButton.Location = new Point(450, 2);
                subtitleButton.Size = new Size(75, 23);
                subtitleButton.Click += new EventHandler(subtitleButton_Click);

                //findSubtitleButton = new Button();
                //findSubtitleButton.Name = "findSubtitleButton";
                //findSubtitleButton.Text = "Feliratkereső";
                //findSubtitleButton.TabIndex = 3;
                //findSubtitleButton.Location = new Point(550, 2);
                //findSubtitleButton.Size = new Size(75, 23);
                //findSubtitleButton.Click += new EventHandler(findSubtitleButton_Click);

                deleteButton = new Button();
                deleteButton.Name = "deleteButton";
                deleteButton.Image = SeriesCommander.Properties.Resources.Delete.ToBitmap();
                deleteButton.TabIndex = 4;
                deleteButton.Location = new Point(550, 2);
                deleteButton.Size = new Size(23, 23);
                deleteButton.Click += new EventHandler(deleteButton_Click);

                ToolTip buttonToolTip = new ToolTip();
                //buttonToolTip.ToolTipTitle = "Törlés";
                //buttonToolTip.ToolTipIcon = ToolTipIcon.Info;
                buttonToolTip.UseFading = true;
                buttonToolTip.UseAnimation = true;
                buttonToolTip.IsBalloon = true;
                buttonToolTip.ShowAlways = true;
                buttonToolTip.AutoPopDelay = 5000;
                buttonToolTip.InitialDelay = 500;
                buttonToolTip.ReshowDelay = 500;
                buttonToolTip.SetToolTip(deleteButton, "Törlés");                

                this.Controls.Add(textBox);
                this.Controls.Add(torrentButton);
                this.Controls.Add(subtitleButton);
                //this.Controls.Add(findSubtitleButton);
                this.Controls.Add(deleteButton);

                this.dsf = new DownloadSubtitleForm(this.title);
                //this.Click += new EventHandler(SeriesPanel_Click);
            }

            /// <summary>
            /// Set textbox editable
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void textbox_Click(object sender, EventArgs e)
            {
                this.textBox.ReadOnly = false;
            }

            /// <summary>
            /// Save title by click
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void SeriesPanel_Click(object sender, EventArgs e)
            {
                if (!this.textBox.ReadOnly) SaveTitle();
            }

            /// <summary>
            /// Save title by enter
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void textbox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveTitle();
                }

            }

            /// <summary>
            /// 
            /// </summary>
            public void SaveTitle()
            {
                if (this.textBox.Text.Length != 0 && this.title != this.textBox.Text)
                {
                    bool succes = SeriesCalenderFrom.UpdateXMLFile(this.day, this.title, this.textBox.Text);
                    if (!succes)
                    {
                        MessageBox.Show("A " + this.title + " cím már létezik az adatbázisban!", this.day, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.textBox.ReadOnly = false;
                    }
                    else
                    {
                        this.title = this.textBox.Text;
                        this.textBox.ReadOnly = true;
                        this.dsf = new DownloadSubtitleForm(this.title);
                    }
                }
                else
                {
                    this.textBox.ReadOnly = true;
                }
            }

            /// <summary>
            /// Search torrent
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void torrentButton_Click(object sender, EventArgs e)
            {
                //Console.WriteLine("Torrent click");
                string link = @"http://thepiratebay.se/search/" + this.textBox.Text.Replace(" ", "%20") + @"/0/99/0";
                ProcessStartInfo info = new ProcessStartInfo(link);

                if (this.textBox.Text != "") Process.Start(info);
            }

            /// <summary>
            /// Search subtitle
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void subtitleButton_Click(object sender, EventArgs e)
            {
                //Console.WriteLine("Felirat click");
                //string link = @"http://www.feliratok.info/index.php?search=" + this.textBox.Text.Replace(" ", "+") + @"&nyelv=&searchB=Mehet";
                //if (this.textBox.Text != "") Process.Start(link);
                if (this.textBox.Text != "") this.dsf.Show();
            }

            /// <summary>
            /// Find subtitle
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void findSubtitleButton_Click(object sender, EventArgs e)
            {
                this.dsf.Show();
            }

            /// <summary>
            /// Delete series entry
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void deleteButton_Click(object sender, EventArgs e)
            {
                SeriesCalenderFrom.DeleteFromXMLFile(this.day, this.title);
                this.Dispose();
            }

            /// <summary>
            /// Get the day
            /// </summary>
            public string Day
            {
                get { return this.day; }
            }

            /// <summary>
            /// Get the title
            /// </summary>
            public string Title
            {
                get { return this.title; }
            }

            public bool IsTextBoxEditing
            {
                get { return !this.textBox.ReadOnly; }
            }
        }


    }



}
