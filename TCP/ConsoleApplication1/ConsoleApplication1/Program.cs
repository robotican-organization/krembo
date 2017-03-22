
/*
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class serv
{
    public static void Main()
    {
        try
        {
            IPAddress ipAd = IPAddress.Parse("10.0.0.3");
            // use local m/c IP address, and 
            // use the same in the client

           
            TcpListener myList = new TcpListener(ipAd, 8001);

           
            myList.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                              myList.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            Socket s = myList.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
           
            s.Close();
            myList.Stop();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }

}*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections;

namespace RoboticanGS.Network
{
    class TCPServer
    {
      //  MainForm main_form_;
        Task listen_to_cons_task_ = new Task(() => { });
        TcpListener server_;
        List<Client> clients_ = new List<Client>();
        TcpClient temp_client_;

      /*  public TCPServer(MainForm form)
        {
            main_form_ = form;
        }*/
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
                        }
                        catch (Exception)
                        {
                            return;
                        }
                        clients_.FindIndex(FindClientByID(1));
                        clients_.Add(new Client(temp_client_));   //, main_form_
                        //connected!
                        // Get a stream object for reading and writing
                        MessageBox.Show("got tcp connection");

                    }
                });
            }
        }

        public void close()
        {
            foreach (Client cam_client in clients_) //shutdown clients connection
            {
                cam_client.close();

            }

            server_.Stop(); //stop listening for new clients
        }

        public List<Client> getClients() { return clients_; }

        static Predicate<Client> FindClientByID(int id)
        {
            return delegate(Client cam_client)
            {
                return cam_client.cam_id == id;
            };
        }
    }
}