using SSHLogViewer.Classes;
using SSHLogViewer.Forms;
using SSHLogViewer.SSH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SSHLogViewer {
    public partial class FormMain : Form {
        private List<ConnectionTab> ConnectionTabs;
        private String Password;
        private LocalCommand JBossCommand;

        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            if(Settings.Default.Connections == null)
                Settings.Default.Connections = new ConnectionInfoCollection();
            if(Settings.Default.Commands == null)
                Settings.Default.Commands = new System.Collections.Specialized.StringCollection();

            ConnectionTabs = new List<ConnectionTab>();
            
            BuildConnectionMenu();
            BuildCommandMenu();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Default.Save();
            foreach (var tab in ConnectionTabs)
                tab.Dispose();
        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e) {
            FormConnectionInfo frm = new FormConnectionInfo();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK) {
                Settings.Default.Connections.Add(frm.Connection);
                Settings.Default.Connections.Sort();
                Settings.Default.Save();
                BuildConnectionMenu();

                Connect(frm.Connection.ConnectionName);
            }
                
        }

        private void BuildConnectionMenu() {
            if (Settings.Default.Connections != null) {
                ToolStripMenuItem mnu = (ToolStripMenuItem)menuStripMain.Items.Find("connectToolStripMenuItem", true)[0];
                mnu.DropDownItems.Clear();
                foreach (var con in Settings.Default.Connections) {
                    if (mnu.DropDownItems.Find(con.ConnectionName, false).Count() == 0) {
                        ToolStripMenuItem itm = new ToolStripMenuItem(con.ConnectionName);
                        itm.Name = con.ConnectionName;
                        itm.Click += ConnectionMenuItem_Click;
                        
                        ToolStripMenuItem del = new ToolStripMenuItem("Delete");
                        del.Name = con.ConnectionName;
                        del.Click += ConnectionMenuItemDelete_Click;
                        del.Name = con.ConnectionName;
                        itm.DropDownItems.Add(del);

                        mnu.DropDownItems.Add(itm);
                    }
                }
            }
        }

        private void BuildCommandMenu() {
            if (Settings.Default.Commands != null) {
                ToolStripMenuItem mnu = (ToolStripMenuItem)menuStripMain.Items.Find("executeCommandToolStripMenuItem", true)[0];
                mnu.DropDownItems.Clear();
                foreach (var com in Settings.Default.Commands) {
                    if (mnu.DropDownItems.Find(com, false).Count() == 0) {
                        ToolStripMenuItem itm = new ToolStripMenuItem(com);
                        
                        itm.Click += CommandMenuItem_Click;

                        mnu.DropDownItems.Add(itm);
                    }
                }
            }
        }

        private void CommandMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            ExecuteCommand(itm.Text);
        }

        private void ConnectionMenuItemDelete_Click(object sender, EventArgs e) {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            foreach (var con in Settings.Default.Connections) {
                if (con.ConnectionName.Equals(itm.Name)) {
                    Settings.Default.Connections.Remove(con);
                    break;
                }
            }
            Settings.Default.Save();
            BuildConnectionMenu();
        }

        private void ConnectionMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;
            Connect(itm.Text);
        }

        private void Connect(String name) {
            foreach (var con in Settings.Default.Connections) {
                if (con.ConnectionName.Equals(name))
                    Connect(con);
            }
        }

        private void Connect(ConnectionInfo con) {
            if (String.IsNullOrWhiteSpace(Password)) {
                DialogResult res = Login();
                if (res != DialogResult.OK) {
                    return;
                }
            }

            con.Password = Password;
            con.UserName = Settings.Default.UserName;

            this.Cursor = Cursors.WaitCursor;

            SSHConnection ssh = new SSHConnection();
            if(!ssh.Connect(con)) {
                Password = "";
                Connect(con);
                this.Cursor = Cursors.Default;
                return;
            }


            this.SuspendLayout();
            ConnectionTab tab = CreateTab(String.Format("{0} - {1}", con.ConnectionName, con.Host), ssh);

            //commandString = "tail -f /apps/jboss/wildfly/standalone/log/server.log";
            //tab.Connection.ExecuteCommand("tail -f -n 100 /apps/jboss/wildfly/standalone/log/server.log");

            this.ResumeLayout();
            this.Cursor = Cursors.Default;

        }

        private ConnectionTab CreateTab(String title, MessageProducer msgProducer) {
            TabPage tabPage = new TabPage();
            tabPage.Text = title;

            RichTextBox tb = new RichTextBox();
            tb.ReadOnly = false;
            tb.Dock = DockStyle.Fill;

            tabPage.Controls.Add(tb);
            TabControlConnections.Controls.Add(tabPage);
            TabControlConnections.SelectedIndex = TabControlConnections.TabCount - 1;

            ConnectionTab tab = new ConnectionTab(tabPage, tb, msgProducer, this);
            ConnectionTabs.Add(tab);

            return tab;
        }

        private DialogResult Login() {
            FormLogin frm = new FormLogin();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK) {
                Settings.Default.UserName = frm.UserName;
                Password = frm.Password;
                Settings.Default.Save();
            }

            return res;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e) {
            Login();
        }

        private void commandsToolStripMenuItemSub_Click(object sender, EventArgs e) {
            FormCommands frm = new FormCommands();
            if(frm.ShowDialog() == DialogResult.OK) {
                Settings.Default.Commands = frm.Commands;
                Settings.Default.Save();

                BuildCommandMenu();
            }
        }

        private void stopCommandToolStripMenuItem_Click(object sender, EventArgs e) {
            ConnectionTabs[TabControlConnections.SelectedIndex].Connection.TerminateCommand();
        }

        private void adHocCommandToolStripMenuItem_Click(object sender, EventArgs e) {
            FormCommandText frm = new FormCommandText();
            if(frm.ShowDialog() == DialogResult.OK) {
                ExecuteCommand(frm.CommandText);
            }
        }

        private void ExecuteCommand(string commandText) {
            ConnectionTabs[TabControlConnections.SelectedIndex].Connection.ExecuteCommand(commandText);
        }

        private void startJBossToolStripMenuItem_Click(object sender, EventArgs e) {
            if (JBossCommand != null) {
                MessageBox.Show("JBoss already running!");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            JBossCommand = new LocalCommand();

            this.SuspendLayout();
            ConnectionTab tab = CreateTab("JBoss", JBossCommand);

            JBossCommand.ExecuteCommand(Settings.Default.JBossCommand, Settings.Default.JBossCommandArguments, 
                Settings.Default.JBossTerminate, Settings.Default.JBossTerminateArguments);

            this.ResumeLayout();
            this.Cursor = Cursors.Default;
        }

        private void stopJBossToolStripMenuItem_Click(object sender, EventArgs e) {
            if (JBossCommand != null) {
                JBossCommand.TerminateCommand();
                JBossCommand = null;
            }
        }
    }
}
