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
    public partial class FormLogin : Form {

        public String UserName { get; set; }
        public String Password { get; set; }

        public FormLogin() {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            this.UserName = textBoxUser.Text;
            this.Password = textBoxPassword.Text;
            
        }

        private void FormLogin_Load(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(Settings.Default.UserName)) {
                textBoxUser.Text = Settings.Default.UserName;
                this.ActiveControl = textBoxPassword;
            }
        }
    }
}
