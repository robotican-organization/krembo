
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using KremboControl.Utils;

namespace KremboControl.Network
{
    public class KremboClient
    {
        const bool DEBUG_MODE = true;
        TcpClient client_;
        TCPServer server_;
        NetworkStream net_stream_;
        byte[] bytes_in_;
        int num_of_bytes_rcved_;
        Task listen_task_ = new Task(() => { });
        public int cam_id, human_cam_id;
        public string human_cam_type, human_cam_state;
        public char cam_type, cam_content;
        public bool alive = true;

        public KremboClient(TcpClient client, TCPServer server)
        {
            client_ = client;
            server_ = server;
            bytes_in_ = new byte[WKCMsg.MSG_SIZE];
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
                        server_.onClientRcvdCallBack(bytes_in_);
                    }
                }
                catch (Exception)
                {

                }
            });
        }



            
        public void send(/*CamMessage.CamAction cam_action*/)
        {
           /* MessageBox.Show(IsConnected(client_).ToString());
            byte[] msg_buff = new byte[CamMessage.msgSize];
            msg_buff[(int)CamMessage.MsgIndx.ID] = (byte)cam_id;
            msg_buff[(int)CamMessage.MsgIndx.TYPE] = (byte)cam_type;
            msg_buff[(int)CamMessage.MsgIndx.CONTENT] = (byte)cam_action;
            msg_buff[(int)CamMessage.MsgIndx.CHECKSUM] = (byte)CamMessage.calcChecksum(System.Text.Encoding.UTF8.GetString(msg_buff).ToCharArray());
            net_stream_.Write(msg_buff, 0, msg_buff.Length); */
        }

        public void close()
        {
            client_.Close();
        }

        private void handleNewMsg(/*CamMessage cam_msg*/)
        {
            /*
            if (known_client_ && cam_id != cam_msg.id)
                return; //error. existing camera trying to change its id/faulty message
            //real msg values
            cam_id = cam_msg.id;
            cam_content = cam_msg.content;
            cam_type = cam_msg.type;

            //human read msg values for lables use
            human_cam_id = cam_msg.id;
            //determine cam type
            switch (cam_msg.type)
            {
                case (char)CamMessage.CamType.COMPLEX:
                    human_cam_type = "Complex";
                    break;
                case (char)CamMessage.CamType.SIMPLE:
                    human_cam_type = "Simple";
                    break;
                default:
                    human_cam_type = "Error";
                    break;
            }
            //determine cam state
            switch (cam_msg.content)
            {
                case (char)CamMessage.CamState.INITIAL_ID:
                    known_client_ = true;
                    main_form_.Invoke((MethodInvoker)delegate
                    {
                        main_form_.updateCamsConLog(human_cam_id, human_cam_type, true);
                    });
                    return;
                case (char)CamMessage.CamState.NOT_RECORDING:
                    human_cam_state = "Nuetral";
                    break;
                case (char)CamMessage.CamState.RECORDING:
                    human_cam_state = "Recording";
                    break;
                default:
                    human_cam_state = "Error";
                    break;
            }

            main_form_.Invoke((MethodInvoker)delegate
            {
                //main_form_.updateCamsLog(human_cam_id, human_cam_type, human_cam_state);
                main_form_.updateCamsStateLog(human_cam_id, human_cam_type, human_cam_state);
            });
            */
        }
    }
}
