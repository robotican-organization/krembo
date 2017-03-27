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
using System.IO;

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

        private void onClientNewMsgCB(WKCKrembo2PC wkc_msg)
        {
            Invoke((MethodInvoker)delegate
            {
                connected_photons_lstbx.Items.Add("Krembo" + wkc_msg.ID);
            });
            
        }

        private void choose_bin_btn_Click(object sender, EventArgs e)
        {
            string bin_file_path = FileTools.chooseFilePath("Binary Files (*.bin)|*.bin");
            bin_file_path_txtbx.Text = bin_file_path;
            flash_btn.Enabled = true;
        }

        private void flash_btn_Click(object sender, EventArgs e)
        {
            if (File.Exists(bin_file_path_txtbx.Text))
            {
                flash_btn.Enabled = false;

                //TODO: do flash work - flash selected photons

                flash_btn.Enabled = true;
            }
            else
            {
                MsgBxLogger.errorMsg("Flash Error",
                                    "Bin file at: " + bin_file_path_txtbx.Text + " doesn't exist");
                bin_file_path_txtbx.Text = "";
                flash_btn.Enabled = false;
            }
               

        }
    }
}
