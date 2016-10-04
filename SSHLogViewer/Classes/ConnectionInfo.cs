using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHLogViewer {

    [TypeConverter(typeof(ConnectionInfoCollectionConverter))]
    public class ConnectionInfoCollection : List<ConnectionInfo> {
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (var c in this)
                sb.AppendFormat("{0}~", c.ToString());

            return sb.ToString();
        }

        public static ConnectionInfoCollection FromString(String input) {
            ConnectionInfoCollection collection = new ConnectionInfoCollection();
            if (string.IsNullOrWhiteSpace(input))
                return collection;

            string[] inputs = input.Split('~');
            foreach (var i in inputs)
                if (!String.IsNullOrWhiteSpace(i))
                    collection.Add(ConnectionInfo.FromString(i));

            return collection;
        }
    }

    public class ConnectionInfo : IComparable<ConnectionInfo> {
        public String ConnectionName { get; private set; }
        public String Host { get; private set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        public ConnectionInfo(String connectionName, String host, String user, String password) {
            this.ConnectionName = connectionName;
            this.Host = host;
            this.UserName = user;
            this.Password = password;
        }

        public ConnectionInfo(String connectionName, String host) : this(connectionName, host, null, null) {
        }

        public ConnectionInfo() {
        }

        public override string ToString() {
            return String.Format("{0}|{1}", ConnectionName, Host);
        }

        public static ConnectionInfo FromString(String input) {
            if (String.IsNullOrWhiteSpace(input))
                return null;

            string[] strs = input.Split('|');
            return new ConnectionInfo(strs[0], strs[1]);
        }

        int IComparable<ConnectionInfo>.CompareTo(ConnectionInfo other) {
            return this.ConnectionName.CompareTo(other.ConnectionName);
        }
    }

    class ConnectionInfoCollectionConverter : TypeConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
            string str = value as string;
            if (str != null)
                return ConnectionInfoCollection.FromString(str);
            else
                return base.ConvertFrom(context, culture, value);
        }
    }
}
