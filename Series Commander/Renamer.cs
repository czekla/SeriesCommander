using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Xml.XPath;
using System.Net;


namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of Renamer
    /// </summary>
    public class Renamer
    {
        private TreeView fileSystemTreeView;
        private ListBox videoListBox;
        private ListBox subtitleListBox;
        private ProgressBar renameProgressBar;
        private CheckedListBox videoCheckedListBox;
        private CheckedListBox subtitleCheckedListBox;
        private Button autoRenameButton;
        private BackgroundWorker backgroundWorker;
        private string today;
        private string logfile;
        private string logdir = "logs";
        private string logpath;
        private string separator = "==============================";
        private TextWriter writer;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="fileSystemTreeView"></param>
        /// <param name="videoListBox"></param>
        /// <param name="subtitleListBox"></param>
        /// <param name="renameProgressBar"></param>
        public Renamer(TreeView fileSystemTreeView, ListBox videoListBox, ListBox subtitleListBox,
            ProgressBar renameProgressBar, CheckedListBox videoCheckedListBox, CheckedListBox subtitleCheckedListBox, Button autoRenameButton)
        {
            this.fileSystemTreeView = fileSystemTreeView;
            this.videoListBox = videoListBox;
            this.subtitleListBox = subtitleListBox;
            this.renameProgressBar = renameProgressBar;
            this.videoCheckedListBox = videoCheckedListBox;
            this.subtitleCheckedListBox = subtitleCheckedListBox;
            this.autoRenameButton = autoRenameButton;
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = false;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            today = DateTime.Today.ToString("yyyy.MM.dd");
            logfile = "log " + today + ".txt";
            logpath = logdir + @"\" + logfile;
        }


        #region background worker

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            ArgumentObject arg = e.Argument as ArgumentObject;

            string dir = arg.dir;
            List<string> videoList = arg.videoList;
            List<string> subtitleList = arg.subtitleList;

            int counter = 0;

            DirectoryInfo di = new DirectoryInfo(logdir);
            if (!di.Exists) di.Create();
            FileInfo fi = new FileInfo(logfile);
            if (!fi.Exists)
            {
                fi.Create();
                using (TextWriter writerr = new StreamWriter(logpath))
                {
                    writerr.WriteLine(separator);
                    writerr.WriteLine("Dátum: " + today);
                    writerr.WriteLine(separator);
                    writerr.WriteLine();
                }
            }

            FileStream fs = new FileStream(logpath, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(fs);

            writer.WriteLine(separator);
            writer.WriteLine("Idő: " + DateTime.Now.ToString("HH:mm:ss"));
            writer.WriteLine("Könyvtár: " + dir);
            writer.WriteLine(separator);
            writer.WriteLine();
            writer.WriteLine(separator);

            foreach (string videoName in videoList)
            {
                //Console.WriteLine("v: "+videoName);
                string subName = SearchForSubtitle(videoName, subtitleList, arg.ignoretitle);
                if (subName.Length != 0)
                {
                    //Console.WriteLine("sub: "+subName);
                    writeLog(subName, Rename(videoName, subName, dir));
                }
                //System.Threading.Thread.Sleep(100);
                bw.ReportProgress(counter++);

            }

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.renameProgressBar.Value = e.ProgressPercentage;
            this.renameProgressBar.PerformStep();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshWindows();
            MessageBox.Show("Átnevezés elkészült!", this.fileSystemTreeView.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.renameProgressBar.Hide();
            this.autoRenameButton.Enabled = true;
            writer.WriteLine(separator);
            writer.WriteLine();
            writer.Flush();
            writer.Close();
        }

        private class ArgumentObject
        {
            public string dir { get; set; }
            public List<string> videoList { get; set; }
            public List<string> subtitleList { get; set; }
            public bool ignoretitle { get; set; }
        }

        private void writeLog(string from, string to)
        {
            //writer.WriteLine(separator);
            writer.WriteLine("Eredeti név: " + from);
            writer.WriteLine("Új név: " + to);
            //writer.WriteLine(separator);
            writer.WriteLine();
        }

        #endregion background worker

        #region rename

        /// <summary>
        /// Rename the subtitleName to videoName
        /// </summary>
        /// <param name="videoName"></param>
        /// <param name="subtitleName"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public string Rename(string videoName, string subtitleName, string dir)
        {
            string subkiterjesztes = subtitleName.Substring(subtitleName.LastIndexOf("."), 4);

            string from = subtitleName;
            string to = videoName.Substring(0, videoName.Length - 4) + subkiterjesztes;
            try
            {
                System.IO.File.Move(dir + @"\" + from, dir + @"\" + to);
                return to;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nem sikerült átnevezni a " + from + " -t " + Environment.NewLine + to + " -ra!", this.fileSystemTreeView.Parent.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "hiba!!! " + to;
            }
        }

        /// <summary>
        /// Rename all subtitle to proper videoname
        /// </summary>
        public void AutoRename(bool ignoretitle)
        {
            this.renameProgressBar.Value = 0;
            this.renameProgressBar.Maximum = this.videoListBox.Items.Count;
            this.renameProgressBar.Step = 1;
            this.renameProgressBar.Show();
            this.autoRenameButton.Enabled = false;

            backgroundWorker.RunWorkerAsync(new ArgumentObject
            {
                dir = this.fileSystemTreeView.SelectedNode.FullPath,
                videoList = this.videoListBox.DataSource as List<string>,
                subtitleList = this.subtitleListBox.DataSource as List<string>,
                ignoretitle = ignoretitle
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoNameText"></param>
        /// <param name="subtitleList"></param>
        /// <returns></returns>
        private string SearchForSubtitle(string videoNameText, List<string> subtitleList, bool ignoretitle)
        {

            foreach (string subName in subtitleList)
            {
                if (subName.Contains(videoNameText.Substring(0, videoNameText.LastIndexOf(".")))) return "";
            }

            ArrayList list = Renamer.Splitter(videoNameText);
            //string subName = "";
            string title = (string)list[0];
            string season = (string)list[1];
            string episode = (string)list[2];
            string info = (string)list[3];

            //Renamer.DownloadSubtitle(videoNameText, title, int.Parse(season), int.Parse(episode), info);
            //Console.WriteLine(title);
            //Console.WriteLine("s: " + season + " e: " + episode);

            if (season.Equals("") && episode.Equals("")) return "";

            string titleregex = (ignoretitle) ? @".*" : title.Replace(@".", @".*");
            //Console.WriteLine(titleregex);
            Regex titlePattern = new Regex(titleregex);

            foreach (string subName in subtitleList)
            {
                string tempsubName = subName.ToLower();
                StringBuilder sb;
                //Console.WriteLine(tempsubName);
                if (titlePattern.IsMatch(tempsubName))
                {
                    //s01e02
                    sb = new StringBuilder();
                    sb.Append("s" + season + "e" + episode);
                    if (tempsubName.Contains(sb.ToString()))
                    {
                        return subName;
                    }

                    //01x02
                    sb = new StringBuilder();
                    sb.Append(season + "x" + episode);
                    if (tempsubName.Contains(sb.ToString()))
                    {
                        return subName;
                    }

                    //1x02
                    sb = new StringBuilder();
                    sb.Append(season.Substring(1, 1) + "x" + episode);
                    if (tempsubName.Contains(sb.ToString()))
                    {
                        return subName;
                    }

                    //1302 = s13e02
                    sb = new StringBuilder();
                    sb.Append(season + "" + episode);
                    if (tempsubName.Contains(sb.ToString()))
                    {
                        return subName;
                    }

                    //102 = s01e02
                    sb = new StringBuilder();
                    sb.Append(season.Substring(1, 1) + "" + episode);
                    if (tempsubName.Contains(sb.ToString()))
                    {
                        return subName;
                    }

                }

            }
            //no subtitle found
            return "";
        }

        /// <summary>
        /// Split the video name to title-season-episode-info parts
        /// Separator: '.' (dot)
        /// </summary>
        /// <param name="videoNameText"></param>
        /// <returns></returns>
        public static ArrayList Splitter(string videoNameText)
        {
            Regex pattern;
            Match match;
            string matchResult = "";

            string videoName = Renamer.ConvertSpaceToDot(videoNameText.ToLower());

            string title = "";
            string season = "";
            string episode = "";
            string info = "";

            string[] videoNevDarabok = videoName.Split('.');

            // hány tagú a cím
            int count = -1;

            foreach (string s in videoNevDarabok)
            {
                count++;

                //s01e02
                pattern = new Regex(@"s[0-9][0-9]e[0-9][0-9]");
                match = pattern.Match(s);
                if (match.Success)
                {
                    matchResult = match.Value;
                    season = matchResult.Substring(1, 2);
                    episode = matchResult.Substring(4, 2);
                    break;
                }

                //01x02
                pattern = new Regex(@"[0-9][0-9]x[0-9][0-9]");
                match = pattern.Match(s);
                if (match.Success)
                {
                    matchResult = match.Value;
                    season = matchResult.Substring(0, 2);
                    episode = matchResult.Substring(3, 2);
                    break;

                }

                //1x02
                pattern = new Regex(@"[1-9]x[0-9][0-9]");
                match = pattern.Match(s);
                if (match.Success)
                {
                    matchResult = match.Value;
                    season = "0" + matchResult.Substring(0, 1);
                    episode = matchResult.Substring(2, 2);
                    break;
                }

                //102 = s01e02
                pattern = new Regex(@"[1-9][0-9]{2}");
                match = pattern.Match(s);
                if (match.Success)
                {
                    //102 in 2102? or 1302 = s13e02
                    Regex pattern2 = new Regex(@"[0-9]{4}");
                    Match match2 = pattern2.Match(s);
                    if (!match2.Success)
                    {
                        matchResult = match.Value;
                        season = "0" + matchResult.Substring(0, 1);
                        episode = matchResult.Substring(1, 2);
                    }
                    else
                    {
                        matchResult = match2.Value;
                        season = matchResult.Substring(0, 2);
                        episode = matchResult.Substring(2, 2);
                    }



                    //lehet hogy a címbe van ez a szám ugyhogy tovább kell keresni
                    for (int i = count + 1; i < videoNevDarabok.Length; i++)
                    {
                        string ss = videoNevDarabok[i];
                        if (ss.Equals("720p")) continue;
                        if (ss.Equals("x264")) continue;
                        if (ss.Equals("1080p")) continue;
                        if (ss.Equals("480p")) continue;

                        //s01e02
                        pattern = new Regex(@"s[0-9][0-9]e[0-9][0-9]");
                        match = pattern.Match(ss);
                        if (match.Success)
                        {
                            matchResult = match.Value;
                            season = matchResult.Substring(1, 2);
                            episode = matchResult.Substring(4, 2);
                            count = i;
                            break;
                        }

                        //01x02
                        pattern = new Regex(@"[0-9][0-9]x[0-9][0-9]");
                        match = pattern.Match(ss);
                        if (match.Success)
                        {
                            matchResult = match.Value;
                            season = matchResult.Substring(0, 2);
                            episode = matchResult.Substring(3, 2);
                            count = i;
                            break;
                        }

                        //1x02
                        pattern = new Regex(@"[1-9]x[0-9][0-9]");
                        match = pattern.Match(ss);
                        if (match.Success)
                        {
                            matchResult = match.Value;
                            season = "0" + matchResult.Substring(0, 1);
                            episode = matchResult.Substring(2, 2);
                            count = i;
                            break;
                        }

                        //102 = s01e02
                        pattern = new Regex(@"[1-9][0-9]{2}");
                        match = pattern.Match(ss);
                        if (match.Success)
                        {
                            // mivel szám után keresve talált egy másik számot ezért azonnal megkérdezi:
                            using (SeasonEpisodeQForm questionForm = new SeasonEpisodeQForm(videoNameText))
                            {
                                questionForm.ShowDialog();
                                season = questionForm.Season;
                                episode = questionForm.Episode;
                                string se = season + episode;
                                for (int j = 0; j < videoNevDarabok.Length; j++)
                                {
                                    // 4jegyű
                                    if (videoNevDarabok[j] == (se))
                                    {
                                        count = j;
                                        break;
                                    }
                                    // 3jegyű
                                    if (videoNevDarabok[j] == (se.Substring(1, 3)))
                                    {
                                        count = j;
                                        break;
                                    }
                                }
                            }
                        }

                    }
                    break;

                }
            }

            ArrayList list = new ArrayList();

            //title:
            for (int i = 0; i < count; i++)
            {
                title += (videoNevDarabok[i] + ".");
            }
            //title = title.Substring(0, title.Length - 1);
            title = (title.Length == 0) ? title : title.Substring(0, title.Length - 1);
            list.Add(title);

            //season-episode:
            list.Add(season);
            list.Add(episode);

            //info:
            for (int i = count + 1; i < videoNevDarabok.Length - 1; i++)
            {
                info += (videoNevDarabok[i] + ".");
            }
            if (info.Length > 0)
            {
                info = info.Substring(0, info.Length - 1);
                if (info.EndsWith("hu") || info.EndsWith("en")) info = info.Substring(0, info.Length - 3);

                if (info.EndsWith("hun") || info.EndsWith("eng")) info = info.Substring(0, info.Length - 4);

            }

            list.Add(info);


            return list;
        }

        #endregion rename


        #region public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ConvertSpaceToDot(string fileName)
        {
            fileName = fileName.Replace(" ", ".");

            while (fileName.Contains(@".."))
            {
                fileName = fileName.Replace(@"..", ".");
            }

            return fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ConvertDotToSpace(string fileName)
        {
            fileName = fileName.Replace(".", " ");

            while (fileName.Contains("  "))
            {
                fileName = fileName.Replace("  ", " ");
            }

            return fileName;
        }

        /// <summary>
        /// Refresh the Video and Subtitle ListWindow
        /// </summary>
        public void RefreshWindows()
        {
            ListFilesFromDirectory(this.videoListBox);
            ListFilesFromDirectory(this.subtitleListBox);
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeView FileSystemTreeView
        {
            get { return this.fileSystemTreeView; }
            set { this.fileSystemTreeView = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ListBox VideoListBox
        {
            get { return this.videoListBox; }
            set { this.videoListBox = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ListBox SubtitleListBox
        {
            get { return this.subtitleListBox; }
            set { this.subtitleListBox = value; }
        }

        #endregion public methods

        /// <summary>
        /// List the files from the specific directory
        /// </summary>
        /// <param name="box"></param>
        private void ListFilesFromDirectory(ListBox box)
        {
            box.BeginUpdate();
            string dir = this.fileSystemTreeView.SelectedNode.FullPath;

            box.DataSource = null;
            List<string> itemList = new List<string>();

            DirectoryInfo di = null;


            DriveInfo drive = new DriveInfo(dir);
            if (drive.IsReady)
            {
                di = drive.RootDirectory;
            }
            else
            {
                di = new DirectoryInfo(dir);
            }

            try
            {
                di = new DirectoryInfo(dir);
                if (box.Name.Equals(this.videoListBox.Name))
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        foreach (object item in this.videoCheckedListBox.CheckedItems)
                        {
                            if (fi.Name.EndsWith("." + item.ToString()))
                            {
                                itemList.Add(fi.Name);
                                continue;
                            }
                        }

                    }

                }

                if (box.Name.Equals(this.subtitleListBox.Name))
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        foreach (object item in this.subtitleCheckedListBox.CheckedItems)
                        {
                            if (fi.Name.EndsWith("." + item.ToString()))
                            {
                                itemList.Add(fi.Name);
                                continue;
                            }
                        }
                    }

                }

                box.DataSource = itemList;
                box.EndUpdate();
            }

            catch (IOException e)
            {
                box.EndUpdate();
                return;
            }

        }

    }


}
