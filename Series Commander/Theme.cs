using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SeriesCommander
{
    public class Theme
    {

        public const int DEFAULT = 1;
        public const int DARK = 2;


        public static void SetWindow(Form form, int theme)
        {
            if (theme == 1)
            {
                form.BackColor = SystemColors.Control;
                form.ForeColor = SystemColors.ControlText;
            }
            if (theme == 2)
            {
                form.BackColor = SystemColors.ControlDarkDark;
                form.ForeColor = SystemColors.ControlLightLight;
            }
        }

        public static void SetListBox(ListBox box, int theme)
        {
            if (theme == 1)
            {
                box.BackColor = SystemColors.Window;
                box.ForeColor = SystemColors.WindowText;
            }
            if (theme == 2)
            {
                box.BackColor = SystemColors.ControlDarkDark;
                box.ForeColor = SystemColors.ControlLightLight;
            }
        }        

        public static void SetButton(Button button, int theme)
        {
            if (theme == 1)
            {
                button.BackColor = SystemColors.Control;
                button.ForeColor = SystemColors.ControlText;
                button.FlatStyle = FlatStyle.Standard;
            }
            if (theme == 2)
            {
                button.BackColor = SystemColors.ControlDarkDark;
                button.ForeColor = SystemColors.ControlLightLight;
                button.FlatStyle = FlatStyle.Flat;
            }
        }

        public static void SetTreeView(TreeView tree, int theme)
        {
            if (theme == 1)
            {
                tree.BackColor = SystemColors.Window;
                tree.ForeColor = SystemColors.WindowText;
            }
            if (theme == 2)
            {
                tree.BackColor = SystemColors.ControlDarkDark;
                tree.ForeColor = SystemColors.ControlLightLight;
            }
        }
        /*
        public static void SetMenu()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetTextBox()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetCheckBox()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetDataGrid()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetTabPage()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetCheckedListBox()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetLabel()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetNumericUpDown()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetGroupBox()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }

        public static void SetPanel()
        {
            if (theme == 1)
            {

            }
            if (theme == 2)
            {

            }
        }
        */
    }
}
