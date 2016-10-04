using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHLogViewer.Forms {
    public partial class FormCommandText : Form {
        public String CommandText { get; private set; }
        public FormCommandText() {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            CommandText = textBoxCommand.Text;
        }
    }
}
