using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KremboControl.Network
{
    class TCPServer
    {
       // MainForm main_form_;
        Task listen_to_cons_task_ = new Task(() => { });
        TcpListener server_;
       // List<CamClient> clients_ = new List<CamClient>();
        TcpClient temp_client_;

        public TCPServer(/*MainForm form*/)
        {
           // main_form_ = form;
        }

        public void asyncListenAt(NetAddr local_addr)
        {
            asyncListenAt(local_addr.IP, local_addr.Port);
        }


        public void asyncListenAt(IPAddress local_ip_addr, int port)
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
                            MessageBox.Show("got tcp connection");
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        //clients_.FindIndex(FindClientByID(1));
                        //clients_.Add(new CamClient(temp_client_, main_form_));
                        //connected!
                        // Get a stream object for reading and writing

                    }
                });
            }
        }
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
    }
}
