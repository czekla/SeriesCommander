using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of OrganizerForm
    /// </summary>
    public partial class OrganizerForm : Form
    {

        private FileTree ft;
        private EditForm editForm;
        //private SeasonEpisodeQForm questionForm;

        /// <summary>
        /// Base constructor
        /// </summary>
        public OrganizerForm()
        {
            InitializeComponent();

            ft = new FileTree(this.fileSystemTreeView, Settings.Default.defaultPath);
            this.fileSystemTreeView.AfterSelect += new TreeViewEventHandler(fileSystemTreeView_AfterSelect);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            FileTree.ReExpandNodes(this.fileSystemTreeView.Nodes);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFileTree()
        {
            ft.RefreshFileTreeView(this.fileSystemTreeView, Settings.Default.defaultPath);
            //RefreshWindows();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshWindows();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void perjelButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.perjelButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pontButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.pontButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void szokozButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += " ";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sorozatcimButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.sorozatcimButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evadButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.evadButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void epizodButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.epizodButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoButton_Click(object sender, EventArgs e)
        {
            if (this.mintaLabel.Text == "Ide kerül a minta") this.mintaLabel.Text = "";
            this.mintaLabel.Text += this.infoButton.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editStringButton_Click(object sender, EventArgs e)
        {
            this.editForm = new EditForm(this.mintaLabel);
            this.editForm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void torolButton_Click(object sender, EventArgs e)
        {
            this.mintaLabel.Text = "Ide kerül a minta";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mindButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.fileSystemTreeView.SelectedNode.Nodes)
            {
                node.Checked = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void egyikseButton_Click(object sender, EventArgs e)
        {
            FileTree.UncheckAllNodes(this.fileSystemTreeView.Nodes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.fileListBox.IndexFromPoint(e.Location) != -1) OpenFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) OpenFile();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenFile()
        {
            string path = this.fileSystemTreeView.SelectedNode.FullPath + @"\" + this.fileListBox.SelectedItem.ToString();
            Process.Start(path);
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshWindows()
        {
            ListFilesFromDirectory(this.fileListBox);
        }

        /// <summary>
        /// 
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

                foreach (FileInfo fi in di.GetFiles())
                {
                    itemList.Add(fi.Name);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void organizerButton_Click(object sender, EventArgs e)
        {
            mintaLabel.Text = PathValidator(mintaLabel.Text);

            Organize(this.fileSystemTreeView.Nodes);

            //ft.RefreshFileTreeView(this.fileSystemTreeView, this.fileSystemTreeView.SelectedNode.FullPath);
        }

        /// <summary>
        /// Check valid directory path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string PathValidator(string path)
        {
            //Console.WriteLine(Path.GetInvalidPathChars().Length); // =36
            foreach (char invalidChar in Path.GetInvalidPathChars())
            {
                if (path.IndexOf(invalidChar) > -1)
                    path = path.Replace(invalidChar.ToString(), string.Empty);
            }

            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        private void Organize(TreeNodeCollection nodes)
        {
            string seriesDirPath = Settings.Default.defaultPath;

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    DirectoryInfo dir = new DirectoryInfo(node.FullPath);

                    try
                    {
                        foreach (FileInfo fi in dir.GetFiles())
                        {

                            ArrayList list = Renamer.Splitter(fi.Name);
                            string title = (string)list[0];
                            string season = (string)list[1];
                            string episode = (string)list[2];
                            string info = (string)list[3];

                            if (season.Equals("") && episode.Equals("")) continue;

                            if (SettingsOrganizer.Default.title == "space")
                            {
                                title = Renamer.ConvertDotToSpace(title);
                                info = Renamer.ConvertDotToSpace(info);
                            }

                            //Console.WriteLine(title);
                            //Console.WriteLine(season);
                            //Console.WriteLine(episode);
                            //Console.WriteLine(info);

                            string newDirName = mintaLabel.Text;

                            newDirName = newDirName.Replace("{sorozatcím}", title);
                            newDirName = newDirName.Replace("{évad}", SettingsOrganizer.Default.season + season);
                            newDirName = newDirName.Replace("{epizód}", SettingsOrganizer.Default.episode + episode);
                            newDirName = newDirName.Replace("{info}", info);
                            //Console.WriteLine(newDirName);
                            //Console.WriteLine(fi.DirectoryName + @"\" + newDirName);
                            DirectoryInfo newDir = new DirectoryInfo(seriesDirPath + @"\" + newDirName);
                            if (!newDir.Exists)
                            {
                                try
                                {
                                    newDir.Create();
                                    File.Move(fi.DirectoryName + @"\" + fi.Name, newDir + @"\" + fi.Name);
                                }
                                catch (IOException)
                                {

                                }
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(dir.Name + " device not ready", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Organize(node.Nodes);
            }
        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
