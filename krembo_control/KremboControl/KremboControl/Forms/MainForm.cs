using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KremboControl.Utils;
using KremboControl.Network;
using System.Net;

namespace KremboControl
{
    public partial class Form1 : Form
    {


        TCPServer server_;


        public Form1()
        {
            //this.WindowState = FormWindowState.Maximized; //enable this for full screen
            InitializeComponent();
            server_ = new TCPServer();
            server_.subscribe(onClientNewMsgCB);
            server_.asyncListenAt(new NetAddr("10.0.0.13", 8000));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ParticleCLI.getOnlinePhotons();
        }

        private void onClientNewMsgCB(WKCMsg wkc_msg)
        {
            Invoke((MethodInvoker)delegate
            {
                connected_photons_lstbx.Items.Add(wkc_msg.ID);
            });
            
        }
    }
}
