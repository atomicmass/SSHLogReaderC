using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHLogViewer.Forms
{
    public partial class FormConnectionInfo : Form
    {
        public ConnectionInfo Connection { get; private set; }

        public FormConnectionInfo()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            this.Connection = new ConnectionInfo(textBoxName.Text, textBoxHost.Text);

            this.Close();
        }
    }
}
