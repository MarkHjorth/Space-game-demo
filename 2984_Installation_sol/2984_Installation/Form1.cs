using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2984_Installation
{
    public partial class install_window : Form
    {
        string path;
        string saveDest;

        public install_window()
        {
            InitializeComponent();
            path = @"C:\Program Files (x86)";
            txtbx_installfolder.Text = path;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            path = fbd.SelectedPath;
            txtbx_installfolder.Text = path;
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            downloadExe();
            downloadDataFolder();
            bool shortcut = chkBx_dskShrt.Checked;
            createShortcut();

            MessageBox.Show("Installation has finished");
            launch();
        }

        private void downloadExe()
        {
            Directory.CreateDirectory(path + "\\wizzGames");
            saveDest = (path + "\\wizzGames\\2984.gif");
            using (var client = new WebClient())
            {
                client.DownloadFile("http://38.media.tumblr.com/81333094b16b087f3d51b2ab85147d27/tumblr_inline_o4b4piHMVG1s3v8a5_500.gif", saveDest);
            }
        }

        private void downloadDataFolder()
        {
            //Directory.CreateDirectory(path + "\\wizzGames");
            //saveDest = (path + "\\wizzGames\\2984\\");
            //using (var client = new WebClient())
            //{
            //    client.DownloadFile("http://38.media.tumblr.com/81333094b16b087f3d51b2ab85147d27/tumblr_inline_o4b4piHMVG1s3v8a5_500.gif", saveDest);
            //}
        }

        private void createShortcut()
        {
            WshShell shell = new WshShell();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktop = (desktop + "\\");
            IWshShortcut shortcut = shell.CreateShortcut(desktop + "2984.lnk");
            shortcut.TargetPath = saveDest;
            shortcut.Description = "Launch 2984!";
            shortcut.Save();
        }

        private void launch()
        {
            Process.Start(path + "\\wizzGames\\2984.gif");
        }
    }
}
