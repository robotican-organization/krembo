
using System;

using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Timers;
using System.Net.NetworkInformation;
using System.Linq;

namespace KremboControl.Network
{
    public class KremboClient
    {
        const string NAME_PREFIX = "Krembo"; //the prefix before id. i.e for Krembo1 prefix is Krembo TODO: move to settings?
        TcpClient client_;
        TCPServer server_;
        NetworkStream net_stream_;
        byte[] bytes_in_;
        int num_of_bytes_rcved_;
        Task listen_task_ = new Task(() => { });
        System.Timers.Timer alive_timer_ = new System.Timers.Timer(1000);
        public bool alive = true;
        public string ID { get; private set; }

        public KremboClient(TcpClient client, TCPServer server)
        {
            //id = client_id;
            client_ = client;
            server_ = server;
            bytes_in_ = new byte[WKCKrembo2PC.MSG_SIZE];
            alive_timer_.Elapsed += OnCheckAliveTimer;
            alive_timer_.Start(); 
            asyncListen();
        }

        public void asyncListen()
        {
            listen_task_ = Task.Run(() =>
            {
                //---get the incoming data through a network stream---
                try
                {
                    net_stream_ = client_.GetStream();

                    while ((num_of_bytes_rcved_ = net_stream_.Read(bytes_in_, 0, bytes_in_.Length)) != 0)
                    {
                        /*ConsoleLogger.write("CamMessage",
                             "got msg: " + bytes_in_ +
                             " | size: " + bytes_in_.Length, DEBUG_MODE);*/
                        WKCKrembo2PC wkc_msg = new WKCKrembo2PC(bytes_in_);
                        ID = wkc_msg.ID;
                        server_.onMsgRcvdCallBack(wkc_msg);
                    }
                }
                catch (Exception)
                {

                }
            });
        }

        public void send(WKCPC2Krembo wkc_msg)
        {
            //send user msg (Krembo expecting to get it after WKC msg)
            //byte[] user_msg_buff = Encoding.ASCII.GetBytes(wkc_msg.user_msg);

            // byte[] buff = new byte[WKCPC2Krembo.];
            byte[] buff = wkc_msg.toBytes();
            net_stream_.Write(buff, 0, buff.Length);

            
        }

        private void OnCheckAliveTimer(Object source, ElapsedEventArgs e)
        {
            
            
            if (IsConnected)
            {
                // Connection is OK
            }
            else
            {
                WKCKrembo2PC wkc_msg = new WKCKrembo2PC();
                wkc_msg.ID = ID;
                wkc_msg.Disconnected = true;
                server_.onMsgRcvdCallBack(wkc_msg);
            }

            
            //client_.Close();
        }

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (client_ != null && client_.Client != null && client_.Client.Connected)
                    {
                        /* pear to the documentation on Poll:
                         * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                         * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                         * -or- true if data is available for reading; 
                         * -or- true if the connection has been closed, reset, or terminated; 
                         * otherwise, returns false
                         */

                        // Detect if client disconnected
                        if (client_.Client.Poll(0, SelectMode.SelectRead))
                        {
                            byte[] buff = new byte[1];
                            if (client_.Client.Receive(buff, SocketFlags.Peek) == 0)
                            {
                                // Client disconnected
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public void close()
        {
            client_.Close();
        }
   
    }
}
