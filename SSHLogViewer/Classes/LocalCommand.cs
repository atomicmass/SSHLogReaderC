using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SSHLogViewer.Classes {
    class LocalCommand : MessageProducer, IDisposable {

        private Process process;
        private ProcessStartInfo processInfo;
        public String TerminateCommandString { get; private set; }
        public String TerminateCommandParameters { get; private set; }

        public override void ExecuteCommand(String command, String commandArguments, String terminateCommand, String terminateCommandParameters) {
            processInfo = new ProcessStartInfo(command, commandArguments);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

            TerminateCommandString = terminateCommand;
            TerminateCommandParameters = terminateCommandParameters;
        }

        protected override void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            WatchNextStandardStream();
        }

        public async void WatchNextStandardStream() {
            if (process != null && !process.HasExited)
                await ReadStream(process.StandardOutput.BaseStream);
        }

        public override void TerminateCommand() {
            if (process == null)
                return;

            ProcessStartInfo processInfo = new ProcessStartInfo(TerminateCommandString, TerminateCommandParameters);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            Process proc = Process.Start(processInfo);
            proc.WaitForExit();
            proc.Dispose();

            process.Dispose();
            process = null;
        }

        public override void Dispose() {
            TerminateCommand();
        }
    }
}
