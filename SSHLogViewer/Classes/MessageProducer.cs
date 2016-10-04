using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SSHLogViewer {
    abstract class MessageProducer : IDisposable {
        protected Encoding DEFAULT_ENCODING = Encoding.UTF8;
        protected const int READ_SIZE = 5120;
        public event MessageAvailableEventHandler MessageAvailable;
        protected System.Timers.Timer timer;
        private Boolean currentlyReading = false;

        public MessageProducer() {
            timer = new System.Timers.Timer(100);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        public void InvokeMessageHandler(byte[] outputBuffer) {
            if (MessageAvailable != null) {
                MessageAvailable(this, new MessageAvailableEventArgs(DEFAULT_ENCODING.GetString(outputBuffer)));
            }
        }

        protected abstract void Timer_Elapsed(object sender, ElapsedEventArgs e);
        public void ExecuteCommand(String command) {
            ExecuteCommand(command, null, null, null);
        }
        public abstract void TerminateCommand();

        public abstract void ExecuteCommand(String command, String commandArguments, String terminateCommand, String terminateCommandParameters);

        protected async Task ReadStream(Stream stream) {
            if (currentlyReading || stream == null || !stream.CanRead)
                return;

            currentlyReading = true;

            byte[] outputBuffer = new byte[READ_SIZE];
            int readBytes = await stream.ReadAsync(outputBuffer, 0, READ_SIZE);
            if (readBytes > 0) {
                this.InvokeMessageHandler(outputBuffer);
            }
            currentlyReading = false;
        }

        public abstract void Dispose();
    }
}
