using SSHLogViewer.SSH;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SSHLogViewer {
    class ConnectionTab : IDisposable {
        public TabPage TabPageControl { get; private set; }
        public RichTextBox TextControl { get; private set; }
        public MessageProducer Connection { get; private set; }
        public FormMain MainForm { get; private set; }

        private static Color InfoColor = Color.FromArgb(20, 255, 20);
        private static Color ErrorColor = Color.FromArgb(255, 20, 20);
        private static Color WarnColor = Color.Orange;
        private static Color BackColor = Color.Black;
        private Color CurrentColor = InfoColor;
        
        private Regex ErrorRegex;
        private Regex InfoRegex;
        private Regex WarnRegex;

        delegate void SetTextCallback(object sender, MessageAvailableEventArgs e);

        public ConnectionTab(TabPage tabPageControl, RichTextBox textControl, MessageProducer connection, FormMain mainForm) {
            TabPageControl = tabPageControl;
            Connection = connection;
            TextControl = textControl;
            MainForm = mainForm;

            TextControl.Font = new System.Drawing.Font("Lucida Console", 9, FontStyle.Regular);
            TextControl.BackColor = BackColor;
            CurrentColor = InfoColor;
            TextControl.ForeColor = CurrentColor;

            Connection.MessageAvailable += Connection_MessageAvailable;

            ErrorRegex = new Regex("^[\\d,\\.:\\s-]*ERROR");
            InfoRegex = new Regex("^[\\d,\\.:\\s-]*INFO");
            WarnRegex = new Regex("^[\\d,\\.:\\s-]*WARN");
        }

        public void Execute(String command, String commandArguments, String terminateCommand, String terminateCommandParameters) {
            Connection.ExecuteCommand(command, commandArguments, terminateCommand, terminateCommandParameters);
        }

        private void Connection_MessageAvailable(object sender, MessageAvailableEventArgs e) {
            if (TextControl.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(Connection_MessageAvailable);
                if(!MainForm.IsDisposed)
                    MainForm.Invoke(d, new object[] { sender, e });
            }
            else {
                String msg = e.Message.Trim('\0', ' ');
                Boolean endsWithNewLine = msg.EndsWith("\n") || msg.EndsWith("\r");
                msg = e.Message.Trim('\r', '\n', '\0', ' ');
                String[] strs = msg.Split('\n');

                for (int i = 0; i < strs.Length; i++) {
                    String str = strs[i].Replace("\r", "");
                
                    DetermineColor(str);

                    TextControl.SelectionStart = TextControl.TextLength;
                    TextControl.SelectionLength = 0;

                    TextControl.SelectionColor = CurrentColor;
                    TextControl.AppendText(str);
                    TextControl.SelectionColor = TextControl.ForeColor;
                    if(i < strs.Length - 1 || endsWithNewLine)
                        TextControl.AppendText("\n");

                    TextControl.SelectionStart = TextControl.TextLength;
                    TextControl.SelectionLength = 0;
                    TextControl.ScrollToCaret();
                }
            }
        }

        private void DetermineColor(string s) {
            if (s.Length < 18)
                return;
            if (ErrorRegex.IsMatch(s)) {
                CurrentColor = ErrorColor;
                return;
            }

            if (WarnRegex.IsMatch(s)) {
                CurrentColor = WarnColor;
                return;
            }

            if (InfoRegex.IsMatch(s)) {
                CurrentColor = InfoColor;
                return;
            }
        }

        public void Dispose() {
            if (Connection != null)
                Connection.Dispose();
        }
    }
}
