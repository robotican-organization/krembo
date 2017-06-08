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
using KremboControl.Forms;

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
            server_.asyncListenAt(new NetAddr("10.0.0.5", 8000));
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
                        break;
                    }
                    
                }
                krembos_list_.Add(updated_krembo);
                if (connected_photons_lstbx.SelectedItem.Equals(updated_krembo))
                    updateKremboImgLbls(updated_krembo);
                else
                    connected_photons_lstbx.SelectedItem = updated_krembo; 
            });
        }

        public void updateKremboImgLbls(Krembo krembo)
        {
            id_lbl.Text = "ID: " + krembo.krembo_wkc.ID.ToString();
            bat_lvl_lbl.Text = "Bat lvl: " + krembo.krembo_wkc.BatLvl.ToString();
            bat_chrg_lvl_lbl.Text = "Chrg lvl: " + krembo.krembo_wkc.BatChrgLvl.ToString();
        }

    

        private void sendtest_btn_Click(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.data_req = true;
            wkc_msg.toggle_led = false;
            wkc_msg.joy_control = true;
            wkc_msg.user_msg = "hello krembo";
            wkc_msg.linear_vel = Krembo.NEUTRAL_BASE_VEL;
            wkc_msg.angular_vel = Krembo.NEUTRAL_BASE_VEL;
            server_.sendToKrembo(((Krembo)(connected_photons_lstbx.SelectedItem)).krembo_wkc.ID, wkc_msg); //client is chosen by connection socket (no need for id)
        }

        private void SendMsgToSelectedKrembo(WKCPC2Krembo wkc_msg)
        {
            server_.sendToKrembo(((Krembo)(connected_photons_lstbx.SelectedItem)).krembo_wkc.ID, wkc_msg); //client is chosen by connection socket (no need for id)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FlashForm()).Show();
        }

        private void connected_photons_lstbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller_grbx.Enabled = true;
            updateKremboImgLbls((Krembo)connected_photons_lstbx.SelectedItem);
        }

        private void linear_vel_sbar_Scroll(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.FillBaseMsg(Krembo.ConvertToKremboVel(-100, 100, linear_vel_sbar.Value),
                                Krembo.ConvertToKremboVel(-100, 100, angular_vel_sbar.Value));
            SendMsgToSelectedKrembo(wkc_msg);

            linear_vel_lbl.Text = linear_vel_sbar.Value.ToString() + " %";
        }

        private void angular_vel_sbar_Scroll(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.FillBaseMsg(Krembo.ConvertToKremboVel(-100, 100, linear_vel_sbar.Value),
                                Krembo.ConvertToKremboVel(-100, 100, angular_vel_sbar.Value));
            SendMsgToSelectedKrembo(wkc_msg);

            angular_vel_lbl.Text = angular_vel_sbar.Value.ToString() + " %";
        }

        private void reset_lin_vel_btn_Click(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.FillBaseMsg(Krembo.ConvertToKremboVel(-100, 100, 0),
                                Krembo.ConvertToKremboVel(-100, 100, angular_vel_sbar.Value));
            SendMsgToSelectedKrembo(wkc_msg);
            linear_vel_sbar.Value = 0;
            linear_vel_lbl.Text = "0 %";
        }

        private void reset_ang_vel_btn_Click(object sender, EventArgs e)
        {
            WKCPC2Krembo wkc_msg = new WKCPC2Krembo();
            wkc_msg.FillBaseMsg(Krembo.ConvertToKremboVel(-100, 100, linear_vel_sbar.Value),
                                Krembo.ConvertToKremboVel(-100, 100, 0));
            SendMsgToSelectedKrembo(wkc_msg);
            angular_vel_sbar.Value = 0;
            angular_vel_lbl.Text = "0 %";
        }
    }
}
