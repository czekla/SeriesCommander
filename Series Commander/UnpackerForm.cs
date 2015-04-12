using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Microsoft.Win32;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of UnpackerForm
    /// </summary>
    public partial class UnpackerForm : Form
    {

        private CheckedListBox videoCheckedListBox;
        private FileTree honnanFileTree;
        private FileTree hovaFileTree;
        private Process unpackProcess;
        private string winrar;
        private ArrayList allpath;

        /// <summary>
        /// Base constructor
        /// </summary>
        public UnpackerForm(CheckedListBox videoCheckedListBox)
        {
            InitializeComponent();
            this.videoCheckedListBox = videoCheckedListBox;
            this.hovaFileTree = new FileTree(this.hovaFileSystemTreeView, Settings.Default.defaultPath);
            this.honnanFileTree = new FileTree(this.honnanFileSystemTreeView, Settings.Default.defaultUnpackPath);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnpackerForm_Load(object sender, EventArgs e)
        {
            FileTree.ReExpandNodes(this.hovaFileSystemTreeView.Nodes);
            FileTree.ReExpandNodes(this.honnanFileSystemTreeView.Nodes);
            this.unpackProgressBar.Hide();
            this.unpackProgressLabel.Visible = false;
            this.movetoProgressBar.Hide();
            this.movetoProgressLabel.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFileTreeHonnan()
        {
            honnanFileTree.RefreshFileTreeView(Settings.Default.defaultUnpackPath);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFileTreeHova()
        {
            hovaFileTree.RefreshFileTreeView(Settings.Default.defaultPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mindButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.honnanFileSystemTreeView.SelectedNode.Nodes)
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
            FileTree.UncheckAllNodes(this.honnanFileSystemTreeView.Nodes);
        }

        /// <summary>
        /// Count all checked nodes
        /// </summary>
        /// <param name="c"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private int CheckedNodesCount(int c, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked) ++c;

                c = CheckedNodesCount(c, node.Nodes);
            }

            return c;
        }

        #region unpack

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unpackButton_Click(object sender, EventArgs e)
        {
            if (this.unpackButton.Text == "Stop")
            {
                unpackProcess.Kill();
                backgroundWorkerUnpack.CancelAsync();
                return;
            }

            this.unpackProgressBar.Maximum = CheckedNodesCount(0, this.honnanFileSystemTreeView.Nodes);
            if (this.unpackProgressBar.Maximum == 0) return;
            this.unpackProgressBar.Value = 0;
            this.unpackProgressBar.Step = 1;
            this.unpackProgressBar.Show();
            this.unpackProgressLabel.Visible = true;

            try
            {
                RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(@"WinRAR\Shell\Open\Command");
                winrar = regKey.GetValue("").ToString();
                regKey.Close();
                winrar = winrar.Substring(1, winrar.Length - 7);

                if (Settings.Default.delete)
                {
                    DialogResult dr = MessageBox.Show("A könyvtár(ak) törölve lesz(nek) a kicsomagolás után. Biztosan folytatod?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //ProcessUnpacking(this.honnanFileSystemTreeView.Nodes);
                        this.unpackButton.Text = "Stop";
                        backgroundWorkerUnpack.RunWorkerAsync(new ArgumentObject
                            {
                                TNC = this.honnanFileSystemTreeView.Nodes,
                                Path = this.hovaFileSystemTreeView.SelectedNode.FullPath
                            });
                    }
                }
                else
                {
                    //ProcessUnpacking(this.honnanFileSystemTreeView.Nodes);
                    this.unpackButton.Text = "Stop";
                    backgroundWorkerUnpack.RunWorkerAsync(new ArgumentObject
                    {
                        TNC = this.honnanFileSystemTreeView.Nodes,
                        Path = this.hovaFileSystemTreeView.SelectedNode.FullPath
                    });
                }

                //this.unpackProgressLabel.Text = this.unpackProgressBar.Value + @"/" + this.unpackProgressBar.Maximum +
                //                    " kész." + Environment.NewLine;
                //this.Refresh();

                //MessageBox.Show("Kicsomagolás elkészült!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.unpackProgressBar.Hide();
                //this.unpackProgressLabel.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Nem található a WinRAR!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.unpackProgressBar.Hide();
                this.unpackProgressLabel.Visible = false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPath"></param>
        /// <param name="outPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public int Unpack(string inPath, string outPath, string fileName)
        {
            ProcessStartInfo startInfo;

            inPath = inPath.Replace(@"\\", @"\");
            outPath = outPath.Replace(@"\\", @"\");

            string info = @"-ibck " + @" X """ + inPath + "\\" + fileName + @""" ";

            startInfo = new ProcessStartInfo();
            startInfo.FileName = winrar;
            startInfo.Arguments = info;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.WorkingDirectory = outPath;

            unpackProcess = new Process();
            unpackProcess.StartInfo = startInfo;

            Console.WriteLine("UnZip Start");
            unpackProcess.Start();
            unpackProcess.WaitForExit();

            return unpackProcess.ExitCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inPath">honnan</param>
        /// <param name="outPath">hova</param>
        /// <param name="fileName">fájl név</param>
        /// <returns>
        /// 0: Successful operation.
        /// 255: User break.
        /// other: error.
        /// </returns>
        public static int UnZip(string inPath, string outPath, string fileName)
        {
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(@"WinRAR\Shell\Open\Command");
            string winrar = regKey.GetValue("").ToString();
            regKey.Close();
            winrar = winrar.Substring(1, winrar.Length - 7);

            ProcessStartInfo startInfo;

            inPath = inPath.Replace(@"\\", @"\");
            outPath = outPath.Replace(@"\\", @"\");

            string info = @"-ibck " + @" X """ + inPath + "\\" + fileName + @""" ";

            startInfo = new ProcessStartInfo();
            startInfo.FileName = winrar;
            startInfo.Arguments = info;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.WorkingDirectory = outPath;

            Process unpackProcess = new Process();
            unpackProcess.StartInfo = startInfo;

            //Console.WriteLine("UnZip Start");
            unpackProcess.Start();
            unpackProcess.WaitForExit();

            return unpackProcess.ExitCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        private void ProcessUnpacking(TreeNodeCollection nodes)
        {

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    DirectoryInfo dir = new DirectoryInfo(node.FullPath);
                    try
                    {
                        bool finished = true;
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (file.Extension == ".rar" || file.Extension == ".zip")
                            {
                                //bool success = Unpack(dir.FullName, this.hovaFileSystemTreeView.SelectedNode.FullPath, file.Name);
                                //if (!success) finished = false;
                                this.unpackProgressLabel.Text = this.unpackProgressBar.Value + @"/" + this.unpackProgressBar.Maximum +
                                    " kész. Kicsomagolás alatt: " + Environment.NewLine + file.Name;
                                this.unpackProgressBar.PerformStep();
                                switch (Unpack(dir.FullName, this.hovaFileSystemTreeView.SelectedNode.FullPath, file.Name))
                                {
                                    //Successful operation.
                                    case 0: { Console.WriteLine("UnZip Successfully."); break; }
                                    //User break.
                                    case 255: { Console.WriteLine("UnZip Failed."); finished = false; break; }
                                    //Other error
                                    default: { Console.WriteLine("UnZip Failed."); finished = false; break; }
                                }
                            }
                        }
                        if (finished && Settings.Default.delete)
                        {
                            dir.Delete(true);
                            Console.WriteLine(dir.Name + " has been deleted.");
                        }
                        this.unpackProgressBar.Refresh();

                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(dir.Name + " device not ready", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Update();
                }
                ProcessUnpacking(node.Nodes);
            }

        }

        #endregion unpack

        #region background worker unpack

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerUnpack_DoWork(object sender, DoWorkEventArgs e)
        {
            //Console.WriteLine("running");
            BackgroundWorker bw = sender as BackgroundWorker;

            //1. ArrayList be az összes checked node könyvtár elérést
            //2. cél könyvtár string
            //3. sorba menni a ArrayList elemein és arra call unpack
            //4. minden unpack után report
            //5. megszakitás

            ArgumentObject arg = e.Argument as ArgumentObject;
            //1.
            allpath = new ArrayList();
            GetAllCheckedFolderPath(arg.TNC);
            //1. pipa
            //2.
            string destpath = arg.Path;
            //2. pipa
            //3.
            int counter = 0;
            foreach (string nodepath in allpath)
            {
                DirectoryInfo dir = new DirectoryInfo(nodepath);
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                //5. pipa
                try
                {
                    bool finished = false;  //at least one successfully unpack
                    bool allfinished = true;  //all unpack was succesfully
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        if (file.Extension == ".rar" || file.Extension == ".zip")
                        {

                            bw.ReportProgress(counter, file.Name); //4. pipa
                            switch (Unpack(dir.FullName, destpath, file.Name))
                            {
                                //Successful operation.
                                case 0: { Console.WriteLine("UnZip Successfully."); finished = true; break; }
                                //User break.
                                case 255: { Console.WriteLine("UnZip Failed."); allfinished = false; break; }
                                //Other error
                                default: { Console.WriteLine("UnZip Failed."); allfinished = false; break; }
                            }
                        }

                    }
                    if (allfinished && finished && Settings.Default.delete)
                    {
                        //dir.Delete(true);
                        FileSystem.DeleteDirectory(dir.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        Console.WriteLine(dir.Name + " has been deleted.");
                    }
                    counter++;


                }
                catch (IOException ex)
                {
                    MessageBox.Show(dir.Name + " device not ready", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            //3. pipa
            bw.ReportProgress(counter, "");
        }

        private void backgroundWorkerUnpack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.unpackProgressBar.Value = e.ProgressPercentage;
            this.unpackProgressLabel.Text = this.unpackProgressBar.Value + @"/" + this.unpackProgressBar.Maximum +
                                        " kész. Kicsomagolás alatt: " + Environment.NewLine + e.UserState;
        }

        private void backgroundWorkerUnpack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Kicsomagolás megszakítva!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kicsomagolás elkészült!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.unpackProgressBar.Hide();
            this.unpackProgressLabel.Visible = false;
            this.unpackButton.Text = "<------";
        }

        private void GetAllCheckedFolderPath(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    allpath.Add(node.FullPath);
                }
                GetAllCheckedFolderPath(node.Nodes);
            }
        }

        private class ArgumentObject
        {
            public TreeNodeCollection TNC { get; set; }
            public string Path { get; set; }
        }

        #endregion background worker unpack




        #region MoveTo

        private void moveToButton_Click(object sender, EventArgs e)
        {
            if (this.movetoButton.Text == "Stop")
            {
                backgroundWorkerMoveto.CancelAsync();
                return;
            }

            this.movetoProgressBar.Maximum = CheckedNodesCount(0, this.honnanFileSystemTreeView.Nodes);
            if (this.movetoProgressBar.Maximum == 0) return;
            this.movetoProgressBar.Value = 0;
            this.movetoProgressBar.Step = 1;
            this.movetoProgressBar.Show();
            this.movetoProgressLabel.Visible = true;

            try
            {
                this.movetoButton.Text = "Stop";
                backgroundWorkerMoveto.RunWorkerAsync(new ArgumentObject
                {
                    TNC = this.honnanFileSystemTreeView.Nodes,
                    Path = this.hovaFileSystemTreeView.SelectedNode.FullPath
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Upsz valami hiba történt :(", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.movetoProgressBar.Hide();
                this.movetoProgressLabel.Visible = false;
            }
        }

        public bool MoveTo(string sourcePath, string targetPath, string fileName)
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            try
            {
                System.IO.File.Move(sourceFile, destFile);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion MoveTo

        #region background worker moveto

        private void backgroundWorkerMoveto_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            ArgumentObject arg = e.Argument as ArgumentObject;

            allpath = new ArrayList();
            GetAllCheckedFolderPath(arg.TNC);

            string destpath = arg.Path;

            int counter = 0;

            
            foreach (string nodepath in allpath)
            {
                DirectoryInfo dir = new DirectoryInfo(nodepath);
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                try
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        bool finished = false;
                        foreach (object item in this.videoCheckedListBox.CheckedItems)
                        {
                            if (file.Extension.Equals("." + item.ToString()))
                            {
                                bw.ReportProgress(counter, file.Name);
                                finished = MoveTo(dir.FullName, destpath, file.Name);
                                continue;
                            }
                        }
                        if (finished)
                        {
                            //FileSystem.DeleteDirectory(dir.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            Console.WriteLine(file.Name + " has been deleted.");
                        }
                    }
                    counter++;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(dir.Name + " device not ready", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            bw.ReportProgress(counter, "");
        }

        private void backgroundWorkerMoveto_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.movetoProgressBar.Value = e.ProgressPercentage;
            this.movetoProgressLabel.Text = this.movetoProgressBar.Value + @"/" + this.movetoProgressBar.Maximum +
                                        " kész. Áthelyezés alatt: " + Environment.NewLine + e.UserState;
        }

        private void backgroundWorkerMoveto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Áthelyezés megszakítva!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Áthelyezés elkészült!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.movetoProgressBar.Hide();
            this.movetoProgressLabel.Visible = false;
            this.movetoButton.Text = "<------";
        }

        #endregion background worker moveto


        private void UnpackerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
