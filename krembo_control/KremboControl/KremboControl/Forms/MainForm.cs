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

        BindingList<Krembo> krembos_list_ = new BindingList<Krembo>();
        TCPServer server_;


        public Form1()
        {
            //this.WindowState = FormWindowState.Maximized; //enable this for full screen
            InitializeComponent();

            connected_photons_lstbx.DataSource = krembos_list_;
            
            server_ = new TCPServer();
            server_.subscribeToMsgs(onClientNewMsgCB);
            server_.asyncListenAt(new NetAddr("10.0.0.11", 8000));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ParticleCLI.getOnlinePhotons();
        }

        private void onClientNewMsgCB(WKCKrembo2PC wkc_msg)
        {
            Invoke((MethodInvoker)delegate
            {
                Krembo updated_krembo = new Krembo(wkc_msg);
                foreach (Krembo krembo in krembos_list_)
                {
                    if (krembo.krembo_wkc.ID == wkc_msg.ID)
                    {
                        //remove existing krembo (make place for updated one)
                        krembos_list_.Remove(krembo);
                    }
                    break;
                }
                krembos_list_.Add(updated_krembo);
                if (connected_photons_lstbx.SelectedItem.Equals(updated_krembo))
                {
                    id_lbl.Text = "ID: " + updated_krembo.krembo_wkc.ID.ToString();
                    bat_lvl_lbl.Text = "Bat lvl: " + updated_krembo.krembo_wkc.BatLvl.ToString();
                    bat_chrg_lvl_lbl.Text = "Chrg lvl: " + updated_krembo.krembo_wkc.BatChrgLvl.ToString();
                }
                
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

        private void sendtest_btn_Click(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.data_req = true;
            wkc_msg.toggle_led = false;
            wkc_msg.joy_control = true;
            wkc_msg.user_msg = "hello krembo";
            wkc_msg.joy_x = Krembo.NEUTRAL_BASE_VEL;
            wkc_msg.joy_y = Krembo.NEUTRAL_BASE_VEL;
            server_.sendToClient(((Krembo)(connected_photons_lstbx.SelectedItem)).krembo_wkc.ID, wkc_msg); //client is chosen by connection socket (no need for id)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
