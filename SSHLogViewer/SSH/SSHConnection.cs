using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SSHLogViewer.SSH {
    class SSHConnection : MessageProducer, IDisposable {
        private IAsyncResult asyncResult;
        private SshClient client;
        private SshCommand command;

        public Boolean Connect(String host, String user, String password) {
            client = new SshClient(host, user, password);
            try {
                client.Connect();
            }
            catch (SshAuthenticationException) {
                return false;
            }


            return true;
        }

        public Boolean Connect(ConnectionInfo con) {
            return this.Connect(con.Host, con.UserName, con.Password);
        }

        protected override void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            WatchNextStandardStream();
            WatchNextExtendedStream();
        }

        public override void ExecuteCommand(String commandString, String commandArguments, String terminateCommand, String terminateCommandParameters) {
            if (command != null)
                command.Dispose();

            command = client.CreateCommand(commandString);
            asyncResult = command.BeginExecute();

            //return command;
        }

        public override void TerminateCommand() {
            if (command != null)
                command.Dispose();
        }

        public override void Dispose() {
            if (timer != null) {
                timer.Stop();
                timer.Dispose();
            }
            if (command != null)
                command.Dispose();
            if (client != null) {
                client.Disconnect();
                client.Dispose();
            }
        }

        public async void WatchNextStandardStream() {
            if(command != null)
                await ReadStream(command.OutputStream);
        }

        public async void WatchNextExtendedStream() {
            if (command != null)
                await ReadStream(command.ExtendedOutputStream);
        }

        


    }
}
