using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.FileIO;

namespace SeriesCommander
{
    /// <summary>
    /// Initiate instance of FileTree
    /// </summary>
    public class FileTree
    {

        private TreeView fileSystemTreeView;
        private string defaultPath;
        private ArrayList fileSystemWatcherList;
        private Timer scrollTimer;
        //private ToolTip tooltip;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="fstv"></param>
        /// <param name="defaultPath"></param>
        public FileTree(TreeView fstv, string defaultPath)
        {
            this.fileSystemTreeView = fstv;
            this.defaultPath = defaultPath;
            this.fileSystemTreeView.TreeViewNodeSorter = new NodeSorter();
            this.CreateFileTreeView();
            this.fileSystemTreeView.BeforeExpand += new TreeViewCancelEventHandler(this.fileSystemTreeView_BeforeExpand);
            this.fileSystemTreeView.AfterCollapse += new TreeViewEventHandler(this.fileSystemTreeView_AfterCollapse);

            ImageList il = new ImageList();
            il.Images.Add(SeriesCommander.Properties.Resources.Folder_Closed_Yellow);
            il.Images.Add(SeriesCommander.Properties.Resources.Folder_Open_Yellow);
            this.fileSystemTreeView.ImageList = il;

            this.fileSystemTreeView.ContextMenuStrip = AddNewContextMenuStrip();

            this.fileSystemTreeView.AllowDrop = true;
            this.fileSystemTreeView.ItemDrag += new ItemDragEventHandler(fileSystemTreeView_ItemDrag);
            this.fileSystemTreeView.DragDrop += new DragEventHandler(fileSystemTreeView_DragDrop);
            this.fileSystemTreeView.DragEnter += new DragEventHandler(fileSystemTreeView_DragEnter);
            this.fileSystemTreeView.DragOver += new DragEventHandler(fileSystemTreeView_DragOver);
            this.fileSystemTreeView.DragLeave += new EventHandler(fileSystemTreeView_DragLeave);
            this.fileSystemTreeView.GiveFeedback += new GiveFeedbackEventHandler(fileSystemTreeView_GiveFeedback);

            this.scrollTimer = new Timer();
            this.scrollTimer.Interval = 200;
            this.scrollTimer.Tick += new EventHandler(scrollTimer_Tick);

            this.fileSystemTreeView.ShowNodeToolTips = true;
            
            //this.tooltip = new ToolTip();
            //this.fileSystemTreeView.MouseMove += new MouseEventHandler(fileSystemTreeView_MouseMove);
            

        }

        
        #region filetree controll

        /// <summary>
        /// 
        /// </summary>
        private void CreateFileTreeView()
        {
            string[] drives = System.Environment.GetLogicalDrives();
            this.fileSystemWatcherList = new ArrayList();

            foreach (string dr in drives)
            {
                DriveInfo di = new DriveInfo(dr);

                if (di.IsReady)
                {
                    DirectoryInfo rootDir = di.RootDirectory;
                    TreeNode newNode = new TreeNode(rootDir.Name);
                    newNode.ToolTipText = rootDir.Name;
                    //newNode.Name = rootDir.Name;
                    this.fileSystemTreeView.Nodes.Add(newNode);
                    newNode.Name = newNode.FullPath.Replace(@"\\", @"\");
                    newNode.Tag = newNode.Text;
                    this.Fill(newNode);
                    this.fileSystemWatcherList.Add(AddNewFileSystemWatcher(newNode.FullPath));
                }
                else
                {
                    TreeNode newNode = new TreeNode(di.Name);
                    newNode.ToolTipText = di.Name;
                    //newNode.Name = di.Name;
                    this.fileSystemTreeView.Nodes.Add(newNode);
                    newNode.Name = newNode.FullPath.Replace(@"\\", @"\");
                    newNode.Tag = newNode.Text;
                    //this.fileSystemWatcherList.Add(addNewFileSystemWatcher(newNode.FullPath));
                }
            }

            this.OpenPath(defaultPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
            e.Node.StateImageIndex = 0;
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("*");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
            }
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
            e.Node.StateImageIndex = 1;
            Fill(e.Node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirNode"></param>
        private void Fill(TreeNode dirNode)
        {
            DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
            try
            {
                foreach (DirectoryInfo dirItem in dir.GetDirectories())
                {
                    if (!dirItem.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        TreeNode newNode = new TreeNode(dirItem.Name);
                        try
                        {
                            if (dirItem.GetDirectories().Count() != 0)
                            {
                                newNode.Nodes.Add("*");
                            }
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            System.Diagnostics.Debug.WriteLine("UnauthorizedAccessException: " + e.Message);
                        }
                        newNode.ToolTipText = dirItem.Name;
                        
                        bool bennevan = false;
                        foreach (TreeNode tn in dirNode.Nodes)
                        {
                            if (tn.Text == newNode.Text) bennevan = true;
                        }
                        if (!bennevan)
                        {
                            dirNode.Nodes.Add(newNode);
                            newNode.Name = newNode.FullPath.Replace(@"\\", @"\");
                            newNode.Tag = newNode.Text;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                System.Diagnostics.Debug.WriteLine("UnauthorizedAccessException: " + e.Message);
            }
        }

        #endregion filetree controll

        #region open path

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullpath"></param>
        private void OpenPath(string fullpath)
        {
            if (fullpath[fullpath.Length - 1] == '\\')
            {
                fullpath = fullpath.Substring(0, fullpath.Length - 1);
            }

            string[] path = fullpath.Split('\\');
            path[0] = path[0] + "\\";  //drive

            foreach (TreeNode node in this.fileSystemTreeView.Nodes)
            {
                if (node.Text.Equals(path[0]))
                {
                    this.fileSystemTreeView.SelectedNode = node;
                    break;
                }

            }

            this.fileSystemTreeView.SelectedNode.Nodes.Clear();
            this.fileSystemTreeView.SelectedNode.ImageIndex = 1;
            this.fileSystemTreeView.SelectedNode.SelectedImageIndex = 1;
            this.fileSystemTreeView.SelectedNode.StateImageIndex = 1;
            this.Fill(this.fileSystemTreeView.SelectedNode);
            this.fileSystemTreeView.SelectedNode.Expand();
            string[] pathsRemaining = new string[path.Length - 1];

            for (int i = 0; i < path.Length - 1; ++i)
            {
                pathsRemaining[i] = path[i + 1];
            }

            if (pathsRemaining.Length != 0) this.ExpandTree(pathsRemaining);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paths"></param>
        private void ExpandTree(string[] paths)
        {
            if (paths.Length == 1)
            {

                foreach (TreeNode node in this.fileSystemTreeView.SelectedNode.Nodes)
                {
                    if (node.Text.Equals(paths[0]))
                    {
                        this.fileSystemTreeView.SelectedNode = node;
                        this.fileSystemTreeView.SelectedNode.Nodes.Clear();
                        this.fileSystemTreeView.SelectedNode.ImageIndex = 1;
                        this.fileSystemTreeView.SelectedNode.SelectedImageIndex = 1;
                        this.fileSystemTreeView.SelectedNode.StateImageIndex = 1;
                        this.Fill(this.fileSystemTreeView.SelectedNode);
                        //this.fileSystemTreeView.SelectedNode.Nodes.Add("*");
                        this.fileSystemTreeView.SelectedNode.Expand();
                        break;
                    }
                }

                return;
            }

            foreach (TreeNode node in this.fileSystemTreeView.SelectedNode.Nodes)
            {
                if (node.Text.Equals(paths[0]))
                {
                    this.fileSystemTreeView.SelectedNode = node;
                    this.fileSystemTreeView.SelectedNode.Nodes.Clear();
                    this.fileSystemTreeView.SelectedNode.ImageIndex = 1;
                    this.fileSystemTreeView.SelectedNode.SelectedImageIndex = 1;
                    this.fileSystemTreeView.SelectedNode.StateImageIndex = 1;
                    this.Fill(this.fileSystemTreeView.SelectedNode);
                    this.fileSystemTreeView.SelectedNode.Expand();

                    string[] pathsRemaining = new string[paths.Length - 1];

                    for (int i = 0; i < paths.Length - 1; ++i)
                    {
                        pathsRemaining[i] = paths[i + 1];
                    }

                    this.ExpandTree(pathsRemaining);

                    break;
                }
            }

        }
        #endregion open path

        #region watcher

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private FileSystemWatcher AddNewFileSystemWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.DirectoryName;
            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (this.fileSystemTreeView.InvokeRequired)
            {
                this.fileSystemTreeView.Invoke(new MethodInvoker(delegate() { watcher_Created(sender, e); }));
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(e.FullPath);
                DirectoryInfo dirParent = dir.Parent;
                var result = this.fileSystemTreeView.Nodes.Find(dirParent.FullName, true);
                if (result.Length == 1)
                {
                    Fill(result[0]);
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (this.fileSystemTreeView.InvokeRequired)
            {
                this.fileSystemTreeView.Invoke(new MethodInvoker(delegate() { watcher_Deleted(sender, e); }));
            }
            else
            {
                var result = this.fileSystemTreeView.Nodes.Find(e.FullPath, true);

                if (result.Length == 1)
                {
                    this.fileSystemTreeView.Nodes.Remove(result[0]);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (this.fileSystemTreeView.InvokeRequired)
            {
                this.fileSystemTreeView.Invoke(new MethodInvoker(delegate() { watcher_Renamed(sender, e); }));
            }
            else
            {
                var result = this.fileSystemTreeView.Nodes.Find(e.OldFullPath, true);

                if (result.Length == 1)
                {
                    var text = e.FullPath.Replace(@"\", @".").Split('.');
                    result[0].Text = text[text.Length - 1];
                    result[0].ToolTipText = text[text.Length - 1];
                    result[0].Name = e.FullPath.Replace(@"\\", @"\");
                }
            }

        }

        #endregion watcher

        #region contextmenu

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip AddNewContextMenuStrip()
        {
            ContextMenuStrip cms = new ContextMenuStrip();

            ToolStripMenuItem openToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Text = "Megnyit";
            openToolStripMenuItem.Image = SeriesCommander.Properties.Resources.Open.ToBitmap();
            openToolStripMenuItem.Click += new EventHandler(openToolStripMenuItem_Click);

            ToolStripMenuItem deleteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Text = "Töröl";
            deleteToolStripMenuItem.Image = SeriesCommander.Properties.Resources.Delete.ToBitmap();
            deleteToolStripMenuItem.Click += new EventHandler(deleteToolStripMenuItem_Click);

            ToolStripMenuItem renameToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Text = "Átnevez";
            renameToolStripMenuItem.Image = SeriesCommander.Properties.Resources.Rename.ToBitmap();
            renameToolStripMenuItem.Click += new EventHandler(renameToolStripMenuItem_Click);

            this.fileSystemTreeView.AfterLabelEdit += new NodeLabelEditEventHandler(fileSystemTreeView_AfterLabelEdit);

            cms.Items.AddRange(new ToolStripItem[] { 
                openToolStripMenuItem,
                renameToolStripMenuItem,
                deleteToolStripMenuItem
            });

            cms.Opening += new System.ComponentModel.CancelEventHandler(ContextMenuStrip_Opening);

            return cms;
        }

        /// <summary>
        /// open(automat) contextmenu by mouse right click and select the node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.fileSystemTreeView.SelectedNode = this.fileSystemTreeView.GetNodeAt(this.fileSystemTreeView.PointToClient(Control.MousePosition));
        }

        /// <summary>
        /// Open folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("open {0}", this.fileSystemTreeView.SelectedNode.Text);
            Process.Start(this.fileSystemTreeView.SelectedNode.FullPath);
        }

        /// <summary>
        /// Delete folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("delete {0}", this.fileSystemTreeView.SelectedNode.Text);
            DialogResult dr = MessageBox.Show("Biztosan törlöd a " + Environment.NewLine + 
                this.fileSystemTreeView.SelectedNode.FullPath.Replace(@"\\", @"\") + " könytárat?", "Töröl", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Directory.Delete(this.fileSystemTreeView.SelectedNode.FullPath, true);
                FileSystem.DeleteDirectory(this.fileSystemTreeView.SelectedNode.FullPath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        /// <summary>
        /// Enable to rename folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("rename {0}", this.fileSystemTreeView.SelectedNode.Text);
            this.fileSystemTreeView.LabelEdit = true;
            if (!this.fileSystemTreeView.SelectedNode.IsEditing)
            {
                this.fileSystemTreeView.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        /// Rename folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                Directory.Move(e.Node.FullPath, e.Node.Parent.FullPath + @"\" + e.Label);
                e.Node.EndEdit(false);
                this.fileSystemTreeView.LabelEdit = false;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("hiba");
                e.CancelEdit = true;
                e.Node.EndEdit(true);
                this.fileSystemTreeView.LabelEdit = false;

            }

        }

        #endregion contextmenu

        #region dragndrop
        //http://www.codeproject.com/Articles/9391/Dragging-tree-nodes-in-C

        // Node being dragged
        private TreeNode dragNode = null;
        // Temporary drop node for selection
        private TreeNode tempDropNode = null;
        //private ImageList imageListDrag = new ImageList();

        /// <summary>
        /// This event is fired as soon as a drag operation is started. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.dragNode = (TreeNode)e.Item;
            this.fileSystemTreeView.SelectedNode = this.dragNode;
            Console.WriteLine("dragnode: {0}", this.dragNode.Text);

            Bitmap bmp = new Bitmap(32, 32);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawImage(this.fileSystemTreeView.ImageList.Images[0], 0, 0);
            
            Point p = this.fileSystemTreeView.PointToClient(Control.MousePosition);
            int dx = p.X + this.fileSystemTreeView.Indent - this.dragNode.Bounds.Left - this.fileSystemTreeView.Location.X;
            int dy = p.Y - this.dragNode.Bounds.Top - this.fileSystemTreeView.Location.Y;

            if (DragHelper.ImageList_BeginDrag(this.fileSystemTreeView.ImageList.Handle, 0, dx, dy))
            {
                // Begin dragging
                this.fileSystemTreeView.DoDragDrop(bmp, DragDropEffects.Move);
                // End dragging image
                DragHelper.ImageList_EndDrag();
            }
        }

        /// <summary>
        /// This event is fired when the user releases the mouse over the drop target.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_DragDrop(object sender, DragEventArgs e)
        {
            // Unlock updates
            DragHelper.ImageList_DragLeave(this.fileSystemTreeView.Handle);

            Console.WriteLine("drag: {0}", dragNode.Text);
            Point position = this.fileSystemTreeView.PointToClient(new Point(e.X, e.Y));
            TreeNode dropNode = this.fileSystemTreeView.GetNodeAt(position);
            Console.WriteLine("drop: {0}", dropNode.Text);

            if (this.dragNode != dropNode)
            {
                // node is a drive
                if (this.dragNode.Parent == null) { }
                // node is a folder
                else
                {
                    try
                    {
                        Directory.Move(this.dragNode.FullPath.Replace(@"\\", @"\"), dropNode.FullPath.Replace(@"\\", @"\") + @"\" + this.dragNode.Text);

                        if (this.dragNode.Parent.Nodes.Count == 1)
                        {
                            this.dragNode.Parent.ImageIndex = 0;
                            this.dragNode.Parent.SelectedImageIndex = 0;
                            this.dragNode.Parent.StateImageIndex = 0;
                        }
                    }
                    catch (IOException ex)
                    {
                        
                    }
                    
                    //if ((e.KeyState & 8) == 8) //ctrl - copy
                    //{
                    //    Directory.Copy()
                    //}
                    //else
                    //{
                    //    Directory.Move()
                    //}
                }
            }

            this.dragNode = null;
            this.scrollTimer.Enabled = false;
            //this.tooltip.Hide(this.fileSystemTreeView);
        }

        /// <summary>
        /// This event is fired when the user moves the mouse onto the control while dragging an element. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_DragEnter(object sender, DragEventArgs e)
        {
            Console.WriteLine("dragenter");
            DragHelper.ImageList_DragEnter(this.fileSystemTreeView.Handle, e.X - this.fileSystemTreeView.Left, e.Y - this.fileSystemTreeView.Top);
            this.scrollTimer.Enabled = true;
        }

        /// <summary>
        /// This event is fired when the user leaves the control with the mouse while dragging an element. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_DragLeave(object sender, EventArgs e)
        {
            Console.WriteLine("dragleave");
            DragHelper.ImageList_DragLeave(this.fileSystemTreeView.Handle);
            this.scrollTimer.Enabled = false;
        }

        /// <summary>
        /// This event is fired when the user drags over a drag and drop control with the mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_DragOver(object sender, DragEventArgs e)
        {
            //Console.WriteLine("dragover");

            // Compute drag position and move image
            Point position = this.fileSystemTreeView.PointToClient(new Point(e.X, e.Y));
            DragHelper.ImageList_DragMove(position.X - this.fileSystemTreeView.Left, position.Y - this.fileSystemTreeView.Top);

            // Get actual drop node
            TreeNode dropNode = this.fileSystemTreeView.GetNodeAt(position);
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            //if ((e.KeyState & 8) == 8) //ctrl - copy
            //{
            //    ShowToolTip(position.X, position.Y, "Copy to ");
            //}
            //else
            //{
            //    ShowToolTip(position.X, position.Y, "Move to ");
            //}

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            if (this.tempDropNode != dropNode)
            {
                DragHelper.ImageList_DragShowNolock(false);
                this.fileSystemTreeView.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node 
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == this.dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }

        }

        /// <summary>
        /// This event gives feedback about the current drag effect and cursor. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSystemTreeView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                // Show pointer cursor while dragging
                e.UseDefaultCursors = false;
                this.fileSystemTreeView.Cursor = Cursors.Default;
            }
            else e.UseDefaultCursors = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            // get node at mouse position
            Point pt = this.fileSystemTreeView.PointToClient(Control.MousePosition);
            TreeNode node = this.fileSystemTreeView.GetNodeAt(pt);

            if (node == null) return;

            // if mouse is near to the top, scroll up
            if (pt.Y < 30)
            {
                // set actual node to the upper one
                if (node.PrevVisibleNode != null)
                {
                    node = node.PrevVisibleNode;

                    // hide drag image
                    DragHelper.ImageList_DragShowNolock(false);
                    // scroll and refresh
                    node.EnsureVisible();
                    this.fileSystemTreeView.Refresh();
                    // show drag image
                    DragHelper.ImageList_DragShowNolock(true);

                }
            }
            // if mouse is near to the bottom, scroll down
            else if (pt.Y > this.fileSystemTreeView.Size.Height - 30)
            {
                if (node.NextVisibleNode != null)
                {
                    node = node.NextVisibleNode;

                    DragHelper.ImageList_DragShowNolock(false);
                    node.EnsureVisible();
                    this.fileSystemTreeView.Refresh();
                    DragHelper.ImageList_DragShowNolock(true);
                }
            }
        }

        #endregion dragndrop

        #region public methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fstv"></param>
        /// <param name="defaultPath"></param>
        public void RefreshFileTreeView(TreeView fstv, string defaultPath)
        {
            this.fileSystemTreeView = fstv;
            this.defaultPath = defaultPath;
            this.fileSystemTreeView.BeginUpdate();
            this.fileSystemTreeView.Nodes.Clear();
            CreateFileTreeView();
            this.fileSystemTreeView.EndUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultPath"></param>
        public void RefreshFileTreeView(string defaultPath)
        {
            this.defaultPath = defaultPath;
            this.fileSystemTreeView.BeginUpdate();
            this.fileSystemTreeView.Nodes.Clear();
            CreateFileTreeView();
            this.fileSystemTreeView.EndUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public static void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                UncheckAllNodes(node.Nodes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        public static void ReExpandNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.ImageIndex == 1) node.Expand();
                ReExpandNodes(node.Nodes);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public TreeView FileSystemTreeView
        {
            get { return this.fileSystemTreeView; }
            set { this.fileSystemTreeView = value; }
        }

        #endregion public methods

        public class NodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                return string.Compare(tx.Text, ty.Text);
            }
        }
    }
}
