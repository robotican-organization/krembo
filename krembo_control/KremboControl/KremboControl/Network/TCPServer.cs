using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KremboControl.Network;

namespace KremboControl.Network
{
    public class TCPServer
    {
        //MainForm main_form_;
        Task check_alive_task_ = new Task(() => { });
        Task listen_to_cons_task_ = new Task(() => { });
        TcpListener server_;
        List<KremboClient> clients_ = new List<KremboClient>();
        List<Action<WKCKrembo2PC>> msgs_subs_list_ = new List<Action<WKCKrembo2PC>>();
       // List<Action<KremboClient>> clients_subs_list_ = new List<Action<KremboClient>>();
        TcpClient temp_client_;

        public TCPServer(/*MainForm form*/)
        {
           // main_form_ = form;
        }

        public void asyncListenAt(NetAddr local_addr)
        {
            asyncListen(local_addr.IP, local_addr.Port);
        }


        public void asyncListen(IPAddress local_ip_addr, int port)
        {
            if (server_ == null)
            {
                //---listen at the specified IP and port no.---
                server_ = new TcpListener(local_ip_addr, port);
                server_.Start();
                listen_to_cons_task_ = Task.Run(() =>
                {
                    while (server_ != null)
                    {
                        //---incoming client connected---
                        try
                        {
                            temp_client_ = server_.AcceptTcpClient();
                           // MessageBox.Show("got tcp connection");
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        clients_.Add(new KremboClient(temp_client_ , this));
                    }
                });
            }
        }

        public void subscribeToMsgs(Action<WKCKrembo2PC> subCallBack)
        {
            msgs_subs_list_.Add(subCallBack);
        }

       /* public void subscribeToClients(Action<KremboClient> subCallBack)
        {
            clients_subs_list_.Add(subCallBack);
        }*/

        public void onMsgRcvdCallBack(WKCKrembo2PC wkc_msg)
        {
        //    MessageBox.Show("New msg recved");
            
            foreach (Action<WKCKrembo2PC> subCallBack in msgs_subs_list_)
            {
                subCallBack(wkc_msg);
            }
        }

        public void sendToClient(int client_id, WKCPC2Krembo wkc_msg)
        {
            foreach (KremboClient client in clients_)
            {
                if (client.ID == client_id)
                    client.send(wkc_msg);
            }
        }

        public void handleNewClientMsg()
        {
           
        }

        /*
         check_alive_task_ = Task.Run(() =>
            {
                //check if client is alive
                while (alive)
                {
                    Thread.Sleep(500);

                    if (!IsConnected(client_))
                    {
                        if (alive)
                        {
                             alive = false;
        
                             
                          
                        }
                    }
                    else
                    {
                        if (!alive)
                        {
                            alive = true;

                            server_.onClientRcvdCallBack();
                        }
                    }
                }
            });
        }
*/



        /*
        public void close()
        {
            foreach (CamClient cam_client in clients_) //shutdown clients connection
            {
                cam_client.close();

            }

            server_.Stop(); //stop listening for new clients
        }8/
        /*
        public List<CamClient> getClients() { return clients_; }

        static Predicate<CamClient> FindClientByID(int id)
        {
            return delegate (CamClient cam_client)
            {
                return cam_client.cam_id == id;
            };
        }*/

        public bool IsConnected(TcpClient client)
        {
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    /* pear to the documentation on Poll:
                        * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                        * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                        * -or- true if data is available for reading; 
                        * -or- true if the connection has been closed, reset, or terminated; 
                        * otherwise, returns false
                        */

                    // Detect if client disconnected
                    if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
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
}
