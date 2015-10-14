using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace NWNBrowser
{
    public partial class MainForm : Form
    {
        private WorkManager manager = WorkManager.Instance;
        private string ip = "84.238.55.137";
        private int port = 5121;
        private ServerStatus _srvStatus = null;
        private bool _isExpanded = false;
        private bool _gameFound = false;
        private Configuration conf;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MainForm()
        {
            Repository r = new Repository("http://files.markjohansen.dk/nwn/ravenloft_downloader/", "nothing");
            manager.setMirror(r);
            manager.SetForm(this);

            try
            {
                conf = Configuration.Load();
            }
            catch (FileNotFoundException e)
            {
                conf = new Configuration();
            }

            InitializeComponent();

            this.txtServerIP.Text = ip + ":" + port;

            this._isExpanded = true;
            this.ToggleExpandForm();

            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * (10);             // Timer will tick evert 10 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer

            Random rnd = new Random();

            this.findGameInstall();

            if (!_gameFound)
            {
                this.btnJoin.Enabled = false;
                this.btnToggleWindow.Enabled = false;
            }

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            this.manager.getPackages();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
            timer.Dispose();

            foreach (Control c in this.Controls)
            {
                c.Dispose();
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            _srvStatus = new ServerStatus(ip, port, this);
            Thread thread1 = new Thread(new ThreadStart(_srvStatus.CheckServer));
            thread1.Start();
        }

        public void ToggleExpandForm()
        {
            if (_isExpanded)
            {
                _isExpanded = false;

                Size newSize = new Size(420, 370);
                this.MaximumSize = newSize;
                this.Size = newSize;

                if (this.chkCenter.CheckState == CheckState.Checked)
                {
                    this.CenterToScreen();
                }
            }
            else
            {
                _isExpanded = true;

                Size newSize = new Size(1200, 370);
                this.MaximumSize = newSize;
                this.Size = newSize;

                if (this.chkCenter.CheckState == CheckState.Checked)
                {
                    this.CenterToScreen();
                }
            }
        }

        private void findGameInstall()
        {
            if (conf.NeverWinterNightsInstall != "" && File.Exists(conf.NeverWinterNightsInstall))
            {
                this.txtNWNInstall.Text = conf.NeverWinterNightsInstall;
                this._gameFound = true;
            }
            else{
                string[] regKeys = new string[] { @"SOFTWARE\Wow6432Node\BioWare\NWN\Neverwinter" };

                foreach (string regkey in regKeys)
                {
                    RegistryKey k = Registry.LocalMachine.OpenSubKey(regkey);
                    if (k != null)
                    {
                        string dir = k.GetValue("Location").ToString();

                        if (dir.Length > 3)
                        {
                            dir += "\\nwmain.exe";

                            if (File.Exists(dir))
                            {
                                this.txtNWNInstall.Text = dir;
                                _gameFound = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ToggleExpandForm();
        }

        private void actionBtnHover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Image = global::NWNBrowser.Properties.Resources.button_on;
        }

        private void actionBtnLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Image = global::NWNBrowser.Properties.Resources.button_off;
        }

        private void actionDoubleClickFindGame(object sender, MouseEventArgs e)
        {
            OpenFileDialog selectNWN = new OpenFileDialog();
            selectNWN.Filter = "Neverwinter Nights|nwmain.exe";
            selectNWN.Multiselect = false;
            selectNWN.Title = "Select your Neverwinter Nights nwmain.exe file.";
            selectNWN.ShowHelp = false;
            selectNWN.DereferenceLinks = true;

            if (selectNWN.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(selectNWN.FileName))
                {
                    this._gameFound = true;
                    this.txtNWNInstall.Text = selectNWN.FileName;
                    this.btnJoin.Enabled = true;
                    this.btnClose.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnToggleWindow.Enabled = true;

                    conf.NeverWinterNightsInstall = selectNWN.FileName;
                    conf.Save();
                }
            }
        }

        private void actionDoubleClickLogo(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Tag != null && pictureBox1.Tag.ToString() == "MSJ")
            {
                pictureBox1.Tag = "POTM";
                pictureBox1.Image = global::NWNBrowser.Properties.Resources.logo;
            }
            else
            {
                pictureBox1.Tag = "MSJ";
                pictureBox1.Image = global::NWNBrowser.Properties.Resources.markjohansen;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;

            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();

            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = "+connect "+this.txtServerIP.Text;

            start.WorkingDirectory = this.txtNWNInstall.Text.Substring(0, (this.txtNWNInstall.Text.Length-11));

            // Enter the executable to run, including the complete path
            if (chkDM.Checked)
            {
                start.Arguments += " -dmc +connect "+this.txtServerIP.Text+" +password " + Pompt.AskForPassword();

                start.FileName = "nwmain.exe";
            }
            else
            {
                start.FileName = "nwmain.exe";
            }

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

            timer.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.checkedListBox1.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnToggleWindow.Enabled = false;

            foreach (string i in this.checkedListBox1.CheckedItems)
            {
                manager.AddGroup(i);
            }

            this.manager.StartSlave();
            this.manager.StartSlave();
            this.manager.StartSlave();
        }
    }
}
