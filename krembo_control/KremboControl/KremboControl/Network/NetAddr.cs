using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace KremboControl.Network
{
    public class NetAddr
    {
        public NetAddr()
        {

        }
        public NetAddr(string ip, string port)
        {
            IP = parseIP(ip);
            Port = parsePort(port);
        }

        public NetAddr(string ip, int port)
        {
            IP = parseIP(ip);
            Port = port;
        }

        public NetAddr(IPAddress ip, int port)
        {
            IP = ip;
            Port = port;
        }

        private IPAddress ip_;
        public IPAddress IP
        {
            get { return ip_; }
            set { ip_ = value; }
        }

        private int port_;
        public int Port
        {
            get { return port_; }
            set { port_ = value; }
        }

        public IPEndPoint getEndPoint()
        {
            return new IPEndPoint(IP, Port);
        }

        public IPAddress parseIP(string ip)
        {
            IPAddress temp_ip = null;
            if (!IPAddress.TryParse(ip, out temp_ip))
            {
                //MessageBox.show("Parsing Error", "Invalid Local IP");
                return null;
            }
            return temp_ip;
        }

        public static string getLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                try
                {
                    socket.Connect("10.0.0.255", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint.Address.ToString();
                }
                catch (System.Net.Sockets.SocketException e)
                {
                    return "";
                }
            }
        }

        public int parsePort(string port)
        {
            try
            {
                int int_port = int.Parse(port);
                if (int_port > 65535)
                {
                    //MsgBxLogger.errorMsg("Parsing Error", "Invalid Radar Port");
                    return -1;
                }
                else return int_port;
            }
            catch (FormatException)
            {
                //MsgBxLogger.errorMsg("Parsing Error", "Invalid local Port");
            }
            return -1;
        }

    }
}
