using System.Drawing;
using System.Windows.Forms;
namespace Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.txtUpdateLog = new MarkJohansen.Forms.MSJTextBox();
            this.chkListPackages = new MarkJohansen.Forms.MSJCheckboxList();
            this.processVerify = new MarkJohansen.Forms.MSJProgressBar();
            this.processTotalDownload = new MarkJohansen.Forms.MSJProgressBar();
            this.ProgressFileDownload = new MarkJohansen.Forms.MSJProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPlayers = new MarkJohansen.Forms.MSJLabel();
            this.txtServerStatus = new MarkJohansen.Forms.MSJLabel();
            this.lblServerIP = new MarkJohansen.Forms.MSJLabel();
            this.txtServerIP = new System.Windows.Forms.Label();
            this.picJoinServer = new System.Windows.Forms.PictureBox();
            this.picUpdateClient = new System.Windows.Forms.PictureBox();
            this.picCloseProgram = new System.Windows.Forms.PictureBox();
            this.lblServerStatus = new MarkJohansen.Forms.MSJLabel();
            this.lblPlayers = new MarkJohansen.Forms.MSJLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSelectInstall = new System.Windows.Forms.PictureBox();
            this.tpSelectNWNInstall = new System.Windows.Forms.ToolTip(this.components);
            this.tpRefreshServerStatus = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoinServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdateClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectInstall)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Image = global::Launcher.Properties.Resources.SmallBackground;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(1200, 340);
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            this.picBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // picUpdate
            // 
            this.picUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picUpdate.Image = global::Launcher.Properties.Resources.Update_off;
            this.picUpdate.Location = new System.Drawing.Point(1068, 274);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(120, 42);
            this.picUpdate.TabIndex = 14;
            this.picUpdate.TabStop = false;
            this.picUpdate.Click += new System.EventHandler(this.picClick);
            this.picUpdate.MouseEnter += new System.EventHandler(this.mousein);
            this.picUpdate.MouseLeave += new System.EventHandler(this.mouseout);
            // 
            // txtUpdateLog
            // 
            this.txtUpdateLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.txtUpdateLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateLog.ForeColor = System.Drawing.Color.White;
            this.txtUpdateLog.Location = new System.Drawing.Point(469, 26);
            this.txtUpdateLog.Multiline = true;
            this.txtUpdateLog.Name = "txtUpdateLog";
            this.txtUpdateLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUpdateLog.Size = new System.Drawing.Size(593, 240);
            this.txtUpdateLog.TabIndex = 15;
            this.txtUpdateLog.WordWrap = false;
            // 
            // chkListPackages
            // 
            this.chkListPackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.chkListPackages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkListPackages.CheckOnClick = true;
            this.chkListPackages.ForeColor = System.Drawing.Color.White;
            this.chkListPackages.FormattingEnabled = true;
            this.chkListPackages.Location = new System.Drawing.Point(1068, 26);
            this.chkListPackages.Name = "chkListPackages";
            this.chkListPackages.Size = new System.Drawing.Size(120, 153);
            this.chkListPackages.TabIndex = 13;
            // 
            // processVerify
            // 
            this.processVerify.Location = new System.Drawing.Point(469, 274);
            this.processVerify.Name = "processVerify";
            this.processVerify.Size = new System.Drawing.Size(593, 10);
            this.processVerify.TabIndex = 16;
            // 
            // processTotalDownload
            // 
            this.processTotalDownload.Location = new System.Drawing.Point(469, 290);
            this.processTotalDownload.Name = "processTotalDownload";
            this.processTotalDownload.Size = new System.Drawing.Size(593, 10);
            this.processTotalDownload.TabIndex = 17;
            // 
            // ProgressFileDownload
            // 
            this.ProgressFileDownload.Location = new System.Drawing.Point(469, 305);
            this.ProgressFileDownload.Name = "ProgressFileDownload";
            this.ProgressFileDownload.Size = new System.Drawing.Size(593, 10);
            this.ProgressFileDownload.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Controls.Add(this.txtPlayers, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtServerStatus, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblServerIP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtServerIP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picJoinServer, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.picUpdateClient, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.picCloseProgram, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblServerStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPlayers, 0, 3);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 134);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 182);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // txtPlayers
            // 
            this.txtPlayers.AutoSize = true;
            this.txtPlayers.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.txtPlayers, 5);
            this.txtPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlayers.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtPlayers.ForeColor = System.Drawing.Color.White;
            this.txtPlayers.Location = new System.Drawing.Point(164, 77);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(280, 18);
            this.txtPlayers.TabIndex = 32;
            this.txtPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServerStatus
            // 
            this.txtServerStatus.AutoSize = true;
            this.txtServerStatus.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.txtServerStatus, 5);
            this.txtServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerStatus.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtServerStatus.ForeColor = System.Drawing.Color.White;
            this.txtServerStatus.Location = new System.Drawing.Point(164, 59);
            this.txtServerStatus.Name = "txtServerStatus";
            this.txtServerStatus.Size = new System.Drawing.Size(280, 18);
            this.txtServerStatus.TabIndex = 31;
            this.txtServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.lblServerIP, 3);
            this.lblServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerIP.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblServerIP.ForeColor = System.Drawing.Color.White;
            this.lblServerIP.Location = new System.Drawing.Point(3, 41);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(155, 18);
            this.lblServerIP.TabIndex = 30;
            this.lblServerIP.Text = "Address :";
            this.lblServerIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServerIP
            // 
            this.txtServerIP.AutoSize = true;
            this.txtServerIP.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.txtServerIP, 5);
            this.txtServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtServerIP.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtServerIP.ForeColor = System.Drawing.Color.White;
            this.txtServerIP.Location = new System.Drawing.Point(164, 41);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(280, 18);
            this.txtServerIP.TabIndex = 23;
            this.txtServerIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picJoinServer
            // 
            this.picJoinServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.SetColumnSpan(this.picJoinServer, 2);
            this.picJoinServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picJoinServer.Image = global::Launcher.Properties.Resources.JoinServer_off;
            this.picJoinServer.Location = new System.Drawing.Point(3, 139);
            this.picJoinServer.Name = "picJoinServer";
            this.picJoinServer.Size = new System.Drawing.Size(118, 40);
            this.picJoinServer.TabIndex = 20;
            this.picJoinServer.TabStop = false;
            this.picJoinServer.Click += new System.EventHandler(this.picClick);
            this.picJoinServer.MouseEnter += new System.EventHandler(this.mousein);
            this.picJoinServer.MouseLeave += new System.EventHandler(this.mouseout);
            // 
            // picUpdateClient
            // 
            this.picUpdateClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.SetColumnSpan(this.picUpdateClient, 2);
            this.picUpdateClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUpdateClient.Image = global::Launcher.Properties.Resources.UpdateClient_off;
            this.picUpdateClient.Location = new System.Drawing.Point(164, 139);
            this.picUpdateClient.Name = "picUpdateClient";
            this.picUpdateClient.Size = new System.Drawing.Size(118, 40);
            this.picUpdateClient.TabIndex = 21;
            this.picUpdateClient.TabStop = false;
            this.picUpdateClient.Click += new System.EventHandler(this.picClick);
            this.picUpdateClient.MouseEnter += new System.EventHandler(this.mousein);
            this.picUpdateClient.MouseLeave += new System.EventHandler(this.mouseout);
            // 
            // picCloseProgram
            // 
            this.picCloseProgram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.SetColumnSpan(this.picCloseProgram, 2);
            this.picCloseProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCloseProgram.Image = global::Launcher.Properties.Resources.Close_off;
            this.picCloseProgram.Location = new System.Drawing.Point(325, 139);
            this.picCloseProgram.Name = "picCloseProgram";
            this.picCloseProgram.Size = new System.Drawing.Size(119, 40);
            this.picCloseProgram.TabIndex = 22;
            this.picCloseProgram.TabStop = false;
            this.picCloseProgram.Click += new System.EventHandler(this.picClick);
            this.picCloseProgram.MouseEnter += new System.EventHandler(this.mousein);
            this.picCloseProgram.MouseLeave += new System.EventHandler(this.mouseout);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.lblServerStatus, 3);
            this.lblServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerStatus.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblServerStatus.ForeColor = System.Drawing.Color.White;
            this.lblServerStatus.Location = new System.Drawing.Point(3, 59);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(155, 18);
            this.lblServerStatus.TabIndex = 24;
            this.lblServerStatus.Text = "Server :";
            this.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.lblPlayers, 3);
            this.lblPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayers.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblPlayers.ForeColor = System.Drawing.Color.White;
            this.lblPlayers.Location = new System.Drawing.Point(3, 77);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(155, 18);
            this.lblPlayers.TabIndex = 25;
            this.lblPlayers.Text = "Players :";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.tpRefreshServerStatus.SetToolTip(this.pictureBox1, "Click to refresh the server status.");
            // 
            // picSelectInstall
            // 
            this.picSelectInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.picSelectInstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSelectInstall.Image = global::Launcher.Properties.Resources.nwn;
            this.picSelectInstall.InitialImage = ((System.Drawing.Image)(resources.GetObject("picSelectInstall.InitialImage")));
            this.picSelectInstall.Location = new System.Drawing.Point(40, 28);
            this.picSelectInstall.Name = "picSelectInstall";
            this.picSelectInstall.Size = new System.Drawing.Size(24, 24);
            this.picSelectInstall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSelectInstall.TabIndex = 31;
            this.picSelectInstall.TabStop = false;
            this.tpSelectNWNInstall.SetToolTip(this.picSelectInstall, "Click to change your installation directory for Neverwinter Nights");
            this.picSelectInstall.Click += new System.EventHandler(this.picClick);
            // 
            // tpSelectNWNInstall
            // 
            this.tpSelectNWNInstall.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tpSelectNWNInstall.ToolTipTitle = "Neverwinter Nights Installation.";
            // 
            // tpRefreshServerStatus
            // 
            this.tpRefreshServerStatus.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tpRefreshServerStatus.ToolTipTitle = "Server Status.";
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1200, 340);
            this.ControlBox = false;
            this.Controls.Add(this.picSelectInstall);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ProgressFileDownload);
            this.Controls.Add(this.processTotalDownload);
            this.Controls.Add(this.processVerify);
            this.Controls.Add(this.txtUpdateLog);
            this.Controls.Add(this.picUpdate);
            this.Controls.Add(this.chkListPackages);
            this.Controls.Add(this.picBackground);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoinServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdateClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectInstall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void mousein(object sender, System.EventArgs e)
        {
            System.Windows.Forms.PictureBox picture = sender as System.Windows.Forms.PictureBox;

            switch (picture.Name.ToString())
            {
                case "picJoinServer":
                    this.picJoinServer.Image = global::Launcher.Properties.Resources.JoinServer_on;
                    break;
                case "picUpdateClient":
                    this.picUpdateClient.Image = global::Launcher.Properties.Resources.UpdateClient_on;
                    break;
                case "picCloseProgram":
                    this.picCloseProgram.Image = global::Launcher.Properties.Resources.Close_on;
                    break;
                case "picUpdate":
                    this.picUpdate.Image = global::Launcher.Properties.Resources.Update_on;
                    break;
            }
        }

        private void mouseout(object sender, System.EventArgs e)
        {
            System.Windows.Forms.PictureBox picture = sender as System.Windows.Forms.PictureBox;

            switch (picture.Name.ToString())
            {
                case "picJoinServer":
                    this.picJoinServer.Image = global::Launcher.Properties.Resources.JoinServer_off;
                    break;
                case "picUpdateClient":
                    this.picUpdateClient.Image = global::Launcher.Properties.Resources.UpdateClient_off;
                    break;
                case "picCloseProgram":
                    this.picCloseProgram.Image = global::Launcher.Properties.Resources.Close_off;
                    break;
                case "picUpdate":
                    this.picUpdate.Image = global::Launcher.Properties.Resources.Update_off;
                    break;
            }
        }

        #endregion

        private System.Windows.Forms.PictureBox picBackground;
        private MarkJohansen.Forms.MSJCheckboxList chkListPackages;
        private System.Windows.Forms.PictureBox picUpdate;
        private MarkJohansen.Forms.MSJTextBox txtUpdateLog;
        private MarkJohansen.Forms.MSJProgressBar processVerify;
        private MarkJohansen.Forms.MSJProgressBar processTotalDownload;
        private MarkJohansen.Forms.MSJProgressBar ProgressFileDownload;
        private TableLayoutPanel tableLayoutPanel1;
        private Label txtServerIP;
        private PictureBox picJoinServer;
        private PictureBox picUpdateClient;
        private PictureBox picCloseProgram;
        private MarkJohansen.Forms.MSJLabel lblServerStatus;
        private MarkJohansen.Forms.MSJLabel lblPlayers;
        private MarkJohansen.Forms.MSJLabel lblServerIP;
        private MarkJohansen.Forms.MSJLabel txtPlayers;
        private MarkJohansen.Forms.MSJLabel txtServerStatus;
        private PictureBox pictureBox1;
        private PictureBox picSelectInstall;
        private ToolTip tpSelectNWNInstall;
        private ToolTip tpRefreshServerStatus;
        
    }
}

