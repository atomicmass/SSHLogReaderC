using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHLogViewer
{
    public delegate void MessageAvailableEventHandler(object sender, MessageAvailableEventArgs e);

    public class MessageAvailableEventArgs : EventArgs
    {
        public MessageAvailableEventArgs(String message) : base()
        {
            this.Message = message;
        }

        public String Message { get; private set; }
    }
}
