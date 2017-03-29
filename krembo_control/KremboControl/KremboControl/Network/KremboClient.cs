
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
        const string NAME_PREFIX = "Krembo"; //the prefix before id. i.e for Krembo1 prefix is Krembo TODO: move to settings?
        TcpClient client_;
        TCPServer server_;
        NetworkStream net_stream_;
        byte[] bytes_in_;
        int num_of_bytes_rcved_;
        Task listen_task_ = new Task(() => { });
        public bool alive = true;
        public UInt16 id;

        public KremboClient(TcpClient client, UInt16 client_id, TCPServer server)
        {
            id = client_id;
            client_ = client;
            server_ = server;
            bytes_in_ = new byte[WKCKrembo2PC.MSG_SIZE];
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

        public void send(WKCPC2Krembo wkc_msg)
        {
            byte[] buff = new byte[WKCPC2Krembo.PC2KREMBO_MSG_SIZE];
            wkc_msg.toBytes(ref buff);
            net_stream_.Write(buff, 0, buff.Length);

            //send user msg (Krembo expecting to get it after WKC msg)
            byte[] user_msg_buff = Encoding.ASCII.GetBytes(wkc_msg.user_msg);
            net_stream_.Write(user_msg_buff, 0, user_msg_buff.Length);
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
