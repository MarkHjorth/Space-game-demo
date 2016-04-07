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
using System.IO.Compression;
using System.Threading;

namespace _2984_Installation
{
    public partial class install_window : Form
    {
        string path;
        string zipPath;
        string savePath;
        int percent = 0;
        bool downloadComplete = false;

        public install_window()
        {
            InitializeComponent();
            lbl_status.Hide();
            path = @"C:\Program Files (x86)";
            txtbx_installfolder.Text = path;
            center();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            path = fbd.SelectedPath;
            txtbx_installfolder.Text = path;
            center();
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            btn_install.Hide();
            lbl_status.Show();
            txtbx_installfolder.Enabled = false;
            btn_browse.Enabled = false;
            chkBx_dskShrt.Enabled = false;
            chkBx_Launch.Enabled = false;

            downloadZip();
            extractZip();
            deleteZip();

            bool shortcut = chkBx_dskShrt.Checked;
            if (shortcut)
            {
                createShortcut();
            }

            lbl_status.Text = "Done";
            MessageBox.Show("Installation has finished");

            if (chkBx_Launch.Checked)
            {
                launch();
            }
            Application.Exit();
        }

        private void downloadZip()
        {
            lbl_status.Text = "Downloading files";
            center();
            Thread.Sleep(10);
            
            Directory.CreateDirectory(path + "\\wizzGames");
            zipPath = (path + "\\wizzGames\\RS1_2984_win.zip");
            WebClient client = new WebClient();
            
            // Specify a progress notification handler.
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);

            // Specify that the DownloadFileCallback method gets called
            // when the download completes.
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
            
            Uri uri = new Uri("http://46.101.132.22/pages/download.php?ref=8&ext=zip&k=99354e9945");
            client.DownloadFileAsync(uri, zipPath);

            while(!downloadComplete)
            {
                Application.DoEvents();
                if(percent <= 100)
                {
                    progBar.Value = percent;
                }
            }
        }

        void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            percent = e.ProgressPercentage;
        }

        void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                downloadComplete = true;
            });
        }

        private void extractZip()
        {
            lbl_status.Text = "Extracting files";
            center();
            Thread.Sleep(10);
            try
            {
                savePath = (path + "\\wizzGames\\2984\\");

                ZipFile.ExtractToDirectory(zipPath, savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteZip()
        {
            lbl_status.Text = "Deleting old files";
            center();

            try
            {
                System.IO.File.Delete(zipPath);
            }
            catch { }
        }

        private void createShortcut()
        {
            lbl_status.Text = "Creating shortcur";
            center();

            WshShell shell = new WshShell();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktop = (desktop + "\\");
            IWshShortcut shortcut = shell.CreateShortcut(desktop + "2984.lnk");
            shortcut.TargetPath = (savePath + "2984.exe");
            shortcut.Description = "Launch 2984!";
            shortcut.Save();
        }

        private void launch()
        {
            Process.Start(savePath + "2984.exe");
        }

        private void center()
        {
            lbl_title.Left = (this.ClientSize.Width - lbl_title.Width) / 2;
            btn_install.Left = (this.ClientSize.Width - btn_install.Width) / 2;
            lbl_status.Left = (this.ClientSize.Width - lbl_status.Width) / 2;
            progBar.Left = (this.ClientSize.Width - progBar.Width) / 2;
        }
    }
}
