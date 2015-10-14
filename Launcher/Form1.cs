using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Library;
using System.IO;
using Microsoft.Win32;
using MarkJohansen.Forms;
using System.Diagnostics;

namespace Launcher
{
    public partial class Form1 : Form
    {
        private const int formMaxWidth = 1200;
        private const int formMinWidth = 465;
        private const string ip = "104.155.20.124";
        private const int port = 5121;
        private UpdateManager manager;
        private bool _gameFound = false;
        private Configuration conf;

        private GameServerInfo.GameServer _gameserver;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private delegate void setCallBack(string s);

        public Form1()
        {
            Cursor cursor = new Cursor(GetType(), "Ankh.CUR");

            this.Icon = global::Library.Properties.Resources.potm;

            this.manager = UpdateManager.Instance;
            this.conf = Configuration.Load();


            InitializeComponent();
            this.Cursor = cursor;

            lblPlayers.BackColor = Color.Transparent;
            lblPlayers.ForeColor = Color.White;
            lblPlayers.Cursor = cursor;

            txtPlayers.BackColor = Color.Transparent;
            txtPlayers.ForeColor = Color.White;
            txtPlayers.Cursor = cursor;

            lblServerIP.BackColor = Color.Transparent;
            lblServerIP.ForeColor = Color.White;
            lblServerIP.Cursor = cursor;

            txtServerIP.BackColor = Color.Transparent;
            txtServerIP.ForeColor = Color.White;
            txtServerIP.Cursor = cursor;

            lblServerStatus.BackColor = Color.Transparent;
            lblServerStatus.ForeColor = Color.White;
            lblServerStatus.Cursor = cursor;

            txtServerStatus.BackColor = Color.Transparent;
            txtServerStatus.ForeColor = Color.White;
            txtServerStatus.Cursor = cursor;

            CenterToScreen();

            this.txtServerIP.Text = ip + ":" + port;

            this.picClickOnline(null, null);
            this.txtPlayers.Text = "";
            this.txtServerStatus.Text = "";

            this.PopulateCheckbox();
            this.checkGameInstall();

            if (this._gameFound == false)
            {
                this.picUpdateClient.Enabled = false;   
                this.picJoinServer.Enabled = false;
            }

            this.Width = formMinWidth;
        }

        private void PopulateCheckbox()
        {
            Thread thread = new Thread(new ThreadStart(this.PopulateCheckboxAsync));
            thread.Start();
        }

        private void PopulateCheckboxAsync()
        {
            this.manager.DownloadSchema();

            if (this.manager.GetCollection != null)
            {
                foreach (FileCollection col in this.manager.GetCollection.Collections)
                {
                    if (this.chkListPackages.InvokeRequired)
                    {
                        this.chkListPackages.Add(col.Name);
                    }
                    else
                    {
                        this.chkListPackages.Items.Add(col.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("System was unable to get the packages.");
            }
        }

        private void picClickOnline(object sender, EventArgs e)
        {
            this.pictureBox1.Image = global::Launcher.Properties.Resources.refresh;
            Thread thread = new Thread(new ThreadStart(this.checkServerOnline));
            thread.Start();
        }

        private void checkServerOnline()
        {
            try
            {
                this._gameserver = new GameServerInfo.GameServer(ip, port, GameServerInfo.GameType.NeverwinterNights);

                this._gameserver.QueryServer();

                if (this._gameserver.IsOnline)
                {
                    string maxplayers = _gameserver.Parameters["maxplayers"];
                    string currentplayers = _gameserver.Parameters["numplayers"]; ;

                    this.txtServerStatus.Text = "Online";
                    this.txtPlayers.Text = currentplayers + "/" + maxplayers;
                }
                else
                {
                    this.txtServerStatus.Text = "Offline";
                    this.txtPlayers.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void picClick(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;

            switch (picture.Name.ToString())
            {
                case "picJoinServer":

                    // Prepare the process to run
                    ProcessStartInfo start = new ProcessStartInfo();

                    // Enter in the command line arguments, everything you would enter after the executable name itself
                    start.Arguments = "+connect " + this.txtServerIP.Text;

                    start.WorkingDirectory = new FileInfo(this.conf.nwninstall).Directory.FullName;

                    // Enter the executable to run, including the complete path
                    //if (chkDM.Checked)
                    //{
                    //    start.Arguments += " -dmc +connect " + this.txtServerIP.Text + " +password " + Pompt.AskForPassword();

                    //    start.FileName = "nwmain.exe";
                    //}
                    //else
                    //{
                    start.FileName = "nwmain.exe";
                    //}

                    // Do you want to show a console window?
                    start.WindowStyle = ProcessWindowStyle.Hidden;
                    start.CreateNoWindow = true;

                    this.WindowState = FormWindowState.Minimized;

                    // Run the external process & wait for it to finish
                    using (Process proc = Process.Start(start))
                    {
                        proc.WaitForExit();
                    }

                    this.WindowState = FormWindowState.Normal;

                    break;
                case "picSelectInstall":
                    this.SelectGameInstall();
                    break;
                case "picUpdateClient":
                    switch(this.Width){
                        case formMaxWidth:
                            if (SystemSettings.isDebuggingEnabled)
                            {
                                this.picBackground.Image = global::Launcher.Properties.Resources.SmallBackgroundDev;
                            }
                            else
                            {
                                this.picBackground.Image = global::Launcher.Properties.Resources.SmallBackground;
                            }
                            this.Width = formMinWidth;
                            break;
                        case formMinWidth:
                            if (SystemSettings.isDebuggingEnabled)
                            {
                                this.picBackground.Image = global::Launcher.Properties.Resources.LargeBackgroundDev;
                            }
                            else
                            {
                                this.picBackground.Image = global::Launcher.Properties.Resources.LargeBackground;
                            }
                            this.Width = formMaxWidth;
                            break;
                    }
                    break;
                case "picCloseProgram":
                    this.Close();
                    break;
                case "picUpdate":
                    List<FileCollection> collections = new List<FileCollection>();

                    foreach (string package in this.chkListPackages.CheckedItems)
                    {
                        FileCollection col = this.manager.GetCollection.Collections.Find(FileCollection => FileCollection.Name.ToLower() == package.ToLower());

                        collections.Add(col);
                    }
                    this.manager.LoggingArea = this.txtUpdateLog;
                    this.manager.UpdatePath = this.conf.nwninstall;
                    this.manager.ProgressVerify = this.processVerify;
                    this.manager.ProgressFileDownload = this.ProgressFileDownload;
                    this.manager.ProgressTotalDownload = this.processTotalDownload;
                    this.manager.SetDownload = collections;

                    Thread thread = new Thread(new ThreadStart(this.manager.UpdateFiles));
                    thread.Start();
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F8)
            {
                if (SystemSettings.isDebuggingEnabled)
                {
                    SystemSettings.isDebuggingEnabled = false;
                    if (this.Width == formMaxWidth)
                    {
                        picBackground.Image = global::Launcher.Properties.Resources.LargeBackground;
                    }
                    else
                    {
                        picBackground.Image = global::Launcher.Properties.Resources.SmallBackground;
                    }

                    AddToLog("Debugging mode Disabled.\n");
                }
                else
                {
                    SystemSettings.isDebuggingEnabled = true;
                    if (this.Width == formMaxWidth)
                    {
                        picBackground.Image = global::Launcher.Properties.Resources.LargeBackgroundDev;
                    }
                    else
                    {
                        picBackground.Image = global::Launcher.Properties.Resources.SmallBackgroundDev;
                    }

                    AddToLog("Debugging mode Enabled.");
                }

                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void AddToLog(string line)
        {
            DateTime time = DateTime.Now;

            line = "["+time.ToString("HH:mm:ss")+"] "+line+"\n";

            if (this.InvokeRequired)
            {
                setCallBack d = new setCallBack(AddToLog);
                this.Invoke(d, new object[] { line });
            }
            else
            {
                this.txtUpdateLog.AppendText(line);
            }
        }

        private void checkGameInstall()
        {
            if (conf.nwninstall != "" && File.Exists(conf.nwninstall))
            {
                this._gameFound = true;
            }
            else
            {
                string[] regKeys = new string[] { @"SOFTWARE\Wow6432Node\BioWare\NWN\Neverwinter", @"SOFTWARE\BioWare\NWN\Neverwinter", @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\GameUX\S-1-5-21-3718306922-674844077-4179127537-1000\{589DB1F8-A723-4BBE-A901-56B965E08144}" };

                foreach (string regkey in regKeys)
                {
                    RegistryKey k = Registry.LocalMachine.OpenSubKey(regkey);
                    if (k != null)
                    {
                        try
                        {
                            foreach (string name in k.GetValueNames())
                            {
                                string filelocation = "";

                                switch (name)
                                {
                                    case "ConfigApplicationPath":
                                    case "Location":
                                        filelocation = k.GetValue(name).ToString();
                                        break;
                                }

                                if (filelocation.Length > 3)
                                {
                                    filelocation += "\\nwmain.exe";

                                    if (File.Exists(filelocation))
                                    {
                                        conf.nwninstall = filelocation;
                                        conf.Save();

                                        _gameFound = true;
                                        break;
                                    }
                                }
                            }


                        }
                        catch (Exception ex){}
                    }
                }
            }

            if (!_gameFound)
            {
                MessageBox.Show("The system was unable to locate Neverwinter Nights,\nPlease select your neverwinter nights nwmain.exe file.", "Can't find Neverwinter Nights", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                this.SelectGameInstall();
            }
        }

        private void SelectGameInstall()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Filter = "Neverwinter Nights|nwmain.exe";

                if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckFileExists)
                {
                    conf.nwninstall = dialog.FileName;
                    conf.Save();

                    this._gameFound = true;

                    this.picUpdateClient.Enabled = true;
                    this.picJoinServer.Enabled = true;
                }
            }
        }

        private void findNWNInstall(object sender, EventArgs e)
        {
            this.SelectGameInstall();
        }
    }
}
