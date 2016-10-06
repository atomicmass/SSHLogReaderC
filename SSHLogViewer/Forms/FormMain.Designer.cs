namespace SSHLogViewer
{
    partial class FormMain
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
            this.TabControlConnections = new SSHLogViewer.Controls.TabControlFlash();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItemSub = new System.Windows.Forms.ToolStripMenuItem();
            this.stopCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adHocCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startJBossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopJBossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlConnections
            // 
            this.TabControlConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlConnections.Location = new System.Drawing.Point(0, 24);
            this.TabControlConnections.Name = "TabControlConnections";
            this.TabControlConnections.SelectedIndex = 0;
            this.TabControlConnections.Size = new System.Drawing.Size(888, 427);
            this.TabControlConnections.TabIndex = 1;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.connectionsToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.localToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(888, 24);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "&File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.loginToolStripMenuItem.Text = "&Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.newConnectionToolStripMenuItem});
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.connectionsToolStripMenuItem.Text = "&Connections";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newConnectionToolStripMenuItem.Text = "&New connection";
            this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeCommandToolStripMenuItem,
            this.commandsToolStripMenuItemSub,
            this.stopCommandToolStripMenuItem,
            this.adHocCommandToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "C&ommands";
            // 
            // executeCommandToolStripMenuItem
            // 
            this.executeCommandToolStripMenuItem.Name = "executeCommandToolStripMenuItem";
            this.executeCommandToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.executeCommandToolStripMenuItem.Text = "&Execute command";
            // 
            // commandsToolStripMenuItemSub
            // 
            this.commandsToolStripMenuItemSub.Name = "commandsToolStripMenuItemSub";
            this.commandsToolStripMenuItemSub.Size = new System.Drawing.Size(172, 22);
            this.commandsToolStripMenuItemSub.Text = "C&ommands";
            this.commandsToolStripMenuItemSub.Click += new System.EventHandler(this.commandsToolStripMenuItemSub_Click);
            // 
            // stopCommandToolStripMenuItem
            // 
            this.stopCommandToolStripMenuItem.Name = "stopCommandToolStripMenuItem";
            this.stopCommandToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.stopCommandToolStripMenuItem.Text = "&Stop command";
            this.stopCommandToolStripMenuItem.Click += new System.EventHandler(this.stopCommandToolStripMenuItem_Click);
            // 
            // adHocCommandToolStripMenuItem
            // 
            this.adHocCommandToolStripMenuItem.Name = "adHocCommandToolStripMenuItem";
            this.adHocCommandToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.adHocCommandToolStripMenuItem.Text = "&Ad hoc command";
            this.adHocCommandToolStripMenuItem.Click += new System.EventHandler(this.adHocCommandToolStripMenuItem_Click);
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startJBossToolStripMenuItem,
            this.stopJBossToolStripMenuItem,
            this.localTerminalToolStripMenuItem});
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.localToolStripMenuItem.Text = "&Local";
            // 
            // startJBossToolStripMenuItem
            // 
            this.startJBossToolStripMenuItem.Name = "startJBossToolStripMenuItem";
            this.startJBossToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startJBossToolStripMenuItem.Text = "Start &JBoss";
            this.startJBossToolStripMenuItem.Click += new System.EventHandler(this.startJBossToolStripMenuItem_Click);
            // 
            // stopJBossToolStripMenuItem
            // 
            this.stopJBossToolStripMenuItem.Name = "stopJBossToolStripMenuItem";
            this.stopJBossToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopJBossToolStripMenuItem.Text = "&Stop JBoss";
            this.stopJBossToolStripMenuItem.Click += new System.EventHandler(this.stopJBossToolStripMenuItem_Click);
            // 
            // localTerminalToolStripMenuItem
            // 
            this.localTerminalToolStripMenuItem.Name = "localTerminalToolStripMenuItem";
            this.localTerminalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.localTerminalToolStripMenuItem.Text = "Local &Terminal";
            this.localTerminalToolStripMenuItem.Click += new System.EventHandler(this.localTerminalToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 451);
            this.Controls.Add(this.TabControlConnections);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "SSH Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.TabControlFlash TabControlConnections;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItemSub;
        private System.Windows.Forms.ToolStripMenuItem executeCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adHocCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startJBossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopJBossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localTerminalToolStripMenuItem;
    }
}

