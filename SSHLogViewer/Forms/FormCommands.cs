using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHLogViewer.Forms {
    public partial class FormCommands : Form {
        public StringCollection Commands { get; set; }
        public FormCommands() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            String cmd = textBoxCommand.Text;
            if (String.IsNullOrWhiteSpace(cmd))
                return;

            if (listBoxConnections.Items.Contains(cmd))
                return;

            listBoxConnections.Items.Add(cmd);
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            Commands = new StringCollection();
            foreach (String s in listBoxConnections.Items)
                Commands.Add(s);
        }

        private void FormCommands_Load(object sender, EventArgs e) {
            foreach (String s in Settings.Default.Commands)
                listBoxConnections.Items.Add(s);
        }
    }
}
