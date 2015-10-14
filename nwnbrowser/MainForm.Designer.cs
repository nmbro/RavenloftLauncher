using System.Collections.Generic;
using System.Windows.Forms;
namespace NWNBrowser
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblServerIP = new MarkJohansen.Forms.MSJLabel();
            this.lblServerStatus = new MarkJohansen.Forms.MSJLabel();
            this.lblPlayers = new MarkJohansen.Forms.MSJLabel();
            this.chkDM = new System.Windows.Forms.CheckBox();
            this.txtServerIP = new MarkJohansen.Forms.MSJTextBox();
            this.txtServerStatus = new MarkJohansen.Forms.MSJTextBox();
            this.txtPlayers = new MarkJohansen.Forms.MSJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChecking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDownload = new NWNBrowser.DataGridViewProgressColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewProgressColumn1 = new NWNBrowser.DataGridViewProgressColumn();
            this.dataGridViewProgressColumn2 = new NWNBrowser.DataGridViewProgressColumn();
            this.msjLabel1 = new MarkJohansen.Forms.MSJLabel();
            this.txtNWNInstall = new MarkJohansen.Forms.MSJTextBox();
            this.btnUpdate = new MarkJohansen.Forms.MSJButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnClose = new MarkJohansen.Forms.MSJButton();
            this.btnToggleWindow = new MarkJohansen.Forms.MSJButton();
            this.btnJoin = new MarkJohansen.Forms.MSJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkCenter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServerIP
            // 
            this.lblServerIP.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerIP.ForeColor = System.Drawing.Color.White;
            this.lblServerIP.Location = new System.Drawing.Point(2, 162);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(100, 18);
            this.lblServerIP.TabIndex = 1;
            this.lblServerIP.Text = "Server IP:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.White;
            this.lblServerStatus.Location = new System.Drawing.Point(2, 180);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(100, 18);
            this.lblServerStatus.TabIndex = 2;
            this.lblServerStatus.Text = "Server status:";
            // 
            // lblPlayers
            // 
            this.lblPlayers.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.ForeColor = System.Drawing.Color.White;
            this.lblPlayers.Location = new System.Drawing.Point(2, 198);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(100, 18);
            this.lblPlayers.TabIndex = 4;
            this.lblPlayers.Text = "Players:";
            // 
            // chkDM
            // 
            this.chkDM.BackColor = System.Drawing.Color.Transparent;
            this.chkDM.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDM.ForeColor = System.Drawing.Color.White;
            this.chkDM.Location = new System.Drawing.Point(2, 19);
            this.chkDM.Name = "chkDM";
            this.chkDM.Size = new System.Drawing.Size(62, 22);
            this.chkDM.TabIndex = 12;
            this.chkDM.Text = "DM";
            this.chkDM.UseVisualStyleBackColor = false;
            // 
            // txtServerIP
            // 
            this.txtServerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.txtServerIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServerIP.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtServerIP.ForeColor = System.Drawing.Color.White;
            this.txtServerIP.Location = new System.Drawing.Point(108, 162);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.ReadOnly = true;
            this.txtServerIP.Size = new System.Drawing.Size(292, 18);
            this.txtServerIP.TabIndex = 14;
            this.txtServerIP.Text = "checking...";
            this.txtServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServerStatus
            // 
            this.txtServerStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.txtServerStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServerStatus.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtServerStatus.ForeColor = System.Drawing.Color.White;
            this.txtServerStatus.Location = new System.Drawing.Point(108, 180);
            this.txtServerStatus.Name = "txtServerStatus";
            this.txtServerStatus.ReadOnly = true;
            this.txtServerStatus.Size = new System.Drawing.Size(292, 18);
            this.txtServerStatus.TabIndex = 15;
            this.txtServerStatus.Text = "checking...";
            this.txtServerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPlayers
            // 
            this.txtPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.txtPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlayers.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtPlayers.ForeColor = System.Drawing.Color.White;
            this.txtPlayers.Location = new System.Drawing.Point(108, 198);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.ReadOnly = true;
            this.txtPlayers.Size = new System.Drawing.Size(292, 18);
            this.txtPlayers.TabIndex = 17;
            this.txtPlayers.Text = "checking...";
            this.txtPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(577, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "Files.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFilename,
            this.ColumnChecking,
            this.ColumnDownload});
            this.dataGridView1.Location = new System.Drawing.Point(580, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(600, 265);
            this.dataGridView1.TabIndex = 35;
            // 
            // ColumnFilename
            // 
            this.ColumnFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFilename.HeaderText = "Filename";
            this.ColumnFilename.Name = "ColumnFilename";
            this.ColumnFilename.ReadOnly = true;
            // 
            // ColumnChecking
            // 
            this.ColumnChecking.HeaderText = "Status";
            this.ColumnChecking.MinimumWidth = 100;
            this.ColumnChecking.Name = "ColumnChecking";
            this.ColumnChecking.ReadOnly = true;
            this.ColumnChecking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnChecking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnDownload
            // 
            this.ColumnDownload.HeaderText = "Download";
            this.ColumnDownload.MinimumWidth = 150;
            this.ColumnDownload.Name = "ColumnDownload";
            this.ColumnDownload.ReadOnly = true;
            this.ColumnDownload.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(422, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Packages.";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ForeColor = System.Drawing.Color.White;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Base Files",
            "GUI Files",
            "Music Files",
            "Portrait Files",
            "Sky Files"});
            this.checkedListBox1.Location = new System.Drawing.Point(423, 43);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(151, 210);
            this.checkedListBox1.TabIndex = 33;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(412, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 283);
            this.label3.TabIndex = 39;
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "Check";
            this.dataGridViewProgressColumn1.MinimumWidth = 150;
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.Width = 150;
            // 
            // dataGridViewProgressColumn2
            // 
            this.dataGridViewProgressColumn2.HeaderText = "Download";
            this.dataGridViewProgressColumn2.MinimumWidth = 150;
            this.dataGridViewProgressColumn2.Name = "dataGridViewProgressColumn2";
            this.dataGridViewProgressColumn2.Width = 150;
            // 
            // msjLabel1
            // 
            this.msjLabel1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msjLabel1.ForeColor = System.Drawing.Color.White;
            this.msjLabel1.Location = new System.Drawing.Point(2, 216);
            this.msjLabel1.Name = "msjLabel1";
            this.msjLabel1.Size = new System.Drawing.Size(100, 18);
            this.msjLabel1.TabIndex = 40;
            this.msjLabel1.Text = "NWN Install:";
            // 
            // txtNWNInstall
            // 
            this.txtNWNInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.txtNWNInstall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNWNInstall.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Italic);
            this.txtNWNInstall.ForeColor = System.Drawing.Color.White;
            this.txtNWNInstall.Location = new System.Drawing.Point(109, 216);
            this.txtNWNInstall.Name = "txtNWNInstall";
            this.txtNWNInstall.ReadOnly = true;
            this.txtNWNInstall.Size = new System.Drawing.Size(292, 18);
            this.txtNWNInstall.TabIndex = 41;
            this.txtNWNInstall.Text = "Doubbleclick to select your NWN Install";
            this.txtNWNInstall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNWNInstall.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.actionDoubleClickFindGame);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(438, 266);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 42);
            this.btnUpdate.TabIndex = 37;
            this.btnUpdate.Text = "Update Files";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.actionBtnHover);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.actionBtnLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::NWNBrowser.Properties.Resources.menustrip_top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1184, 20);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 323);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1184, 20);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(280, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 42);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.actionBtnHover);
            this.btnClose.MouseLeave += new System.EventHandler(this.actionBtnLeave);
            // 
            // btnToggleWindow
            // 
            this.btnToggleWindow.FlatAppearance.BorderSize = 0;
            this.btnToggleWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleWindow.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnToggleWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleWindow.Image")));
            this.btnToggleWindow.Location = new System.Drawing.Point(142, 266);
            this.btnToggleWindow.Name = "btnToggleWindow";
            this.btnToggleWindow.Size = new System.Drawing.Size(120, 42);
            this.btnToggleWindow.TabIndex = 19;
            this.btnToggleWindow.Text = "Update system";
            this.btnToggleWindow.UseVisualStyleBackColor = true;
            this.btnToggleWindow.Click += new System.EventHandler(this.button2_Click);
            this.btnToggleWindow.MouseEnter += new System.EventHandler(this.actionBtnHover);
            this.btnToggleWindow.MouseLeave += new System.EventHandler(this.actionBtnLeave);
            // 
            // btnJoin
            // 
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Image = ((System.Drawing.Image)(resources.GetObject("btnJoin.Image")));
            this.btnJoin.Location = new System.Drawing.Point(4, 266);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(120, 42);
            this.btnJoin.TabIndex = 18;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            this.btnJoin.MouseEnter += new System.EventHandler(this.actionBtnHover);
            this.btnJoin.MouseLeave += new System.EventHandler(this.actionBtnLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.actionDoubleClickLogo);
            // 
            // chkCenter
            // 
            this.chkCenter.BackColor = System.Drawing.Color.Transparent;
            this.chkCenter.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCenter.ForeColor = System.Drawing.Color.White;
            this.chkCenter.Location = new System.Drawing.Point(2, 313);
            this.chkCenter.Name = "chkCenter";
            this.chkCenter.Size = new System.Drawing.Size(122, 22);
            this.chkCenter.TabIndex = 42;
            this.chkCenter.Text = "Autocenter";
            this.chkCenter.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.ClientSize = new System.Drawing.Size(1184, 343);
            this.Controls.Add(this.chkCenter);
            this.Controls.Add(this.txtNWNInstall);
            this.Controls.Add(this.msjLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.chkDM);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnToggleWindow);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtPlayers);
            this.Controls.Add(this.txtServerStatus);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 370);
            this.MinimumSize = new System.Drawing.Size(420, 370);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ravenloft - Prisoners of the Mist";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void checkedListBox1_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                manager.AddFilesToView(checkedListBox1.Items[e.Index].ToString());
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                manager.RemoveFilesFromView(checkedListBox1.Items[e.Index].ToString());
            }

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MarkJohansen.Forms.MSJLabel lblServerIP;
        private MarkJohansen.Forms.MSJLabel lblServerStatus;
        private MarkJohansen.Forms.MSJLabel lblPlayers;
        private System.Windows.Forms.CheckBox chkDM;
        private MarkJohansen.Forms.MSJButton btnJoin;
        private MarkJohansen.Forms.MSJButton btnClose;
        public MarkJohansen.Forms.MSJTextBox txtServerIP;
        public MarkJohansen.Forms.MSJTextBox txtServerStatus;
        public MarkJohansen.Forms.MSJTextBox txtPlayers;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DataGridViewProgressColumn dataGridViewProgressColumn1;
        private DataGridViewProgressColumn dataGridViewProgressColumn2;
        private MarkJohansen.Forms.MSJLabel msjLabel1;
        public MarkJohansen.Forms.MSJTextBox txtNWNInstall;
        private System.Windows.Forms.CheckBox chkCenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChecking;
        private DataGridViewProgressColumn ColumnDownload;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public MarkJohansen.Forms.MSJButton btnUpdate;
        public MarkJohansen.Forms.MSJButton btnToggleWindow;
    }
}

