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
using System.Diagnostics;

namespace KremboControl
{
    public partial class MainForm : Form
    {
        WKCPC2Krembo wkc_msg_ = new WKCPC2Krembo();
        //List<Krembo> krembos_list_ = new List<Krembo>();
        BindingList<Krembo> krembos_list_ = new BindingList<Krembo>();
        TCPServer server_;
        bool flash_mode_ = false;

        public MainForm()
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
                bool exist = false;
                foreach (Krembo krembo in krembos_list_)
                {
                    if (krembo.WKC.ID == wkc_msg.ID)
                    {
                        //remove existing krembo (make place for updated one)
                        //krembos_list_.Remove(krembo);
                        krembos_list_.ElementAt<Krembo>(krembos_list_.IndexOf(krembo)).WKC = krembo.WKC;

                        //krembos_list_.Insert(krembos_list_.IndexOf(krembo), updated_krembo);
                        //existed_krembo = krembo;
                        //if (connected_photons_lstbx.SelectedItem.Equals(krembo))
                        //    updateKremboData(updated_krembo);
                        exist = true;
                        break;
                    }
                    
                }
                if (!exist)
                    krembos_list_.Add(updated_krembo);
                if (!wkc_msg.Disconnected)
                {
                    //krembos_list_.Add(updated_krembo);
                    updateKremboData(updated_krembo);
                }
            });
        }

        public void updateKremboData(Krembo krembo)
        {
            //read basic data
            id_lbl.Text = "ID: " + krembo.WKC.ID.ToString();
            bat_lvl_lbl.Text = "Bat lvl: " + krembo.WKC.BatLvl.ToString();
            bat_chrg_lvl_lbl.Text = "Chrg lvl: " + krembo.WKC.BatChrgLvl.ToString();

            //read rgba data
            rgba_front_lbl.Text = krembo.WKC.RgbaFront.Distance.ToString();
            rgba_front_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaFront.Red,
                                                      krembo.WKC.RgbaFront.Green,
                                                      krembo.WKC.RgbaFront.Blue);

            rgba_rear_lbl.Text = krembo.WKC.RgbaRear.Distance.ToString();
            rgba_rear_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaRear.Red,
                                                      krembo.WKC.RgbaRear.Green,
                                                      krembo.WKC.RgbaRear.Blue);

            rgba_right_lbl.Text = krembo.WKC.RgbaRight.Distance.ToString();
            rgba_right_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaRight.Red,
                                                      krembo.WKC.RgbaRight.Green,
                                                      krembo.WKC.RgbaRight.Blue);

            rgba_left_lbl.Text = krembo.WKC.RgbaLeft.Distance.ToString();
            rgba_left_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaLeft.Red,
                                                      krembo.WKC.RgbaLeft.Green,
                                                      krembo.WKC.RgbaLeft.Blue);

            rgba_front_right_lbl.Text = krembo.WKC.RgbaFrontRight.Distance.ToString();
            rgba_front_right_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaFrontRight.Red,
                                                      krembo.WKC.RgbaFrontRight.Green,
                                                      krembo.WKC.RgbaFrontRight.Blue);

            rgba_front_left_lbl.Text = krembo.WKC.RgbaFrontLeft.Distance.ToString();
            rgba_front_left_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaFrontLeft.Red,
                                                      krembo.WKC.RgbaFrontLeft.Green,
                                                      krembo.WKC.RgbaFrontLeft.Blue);

            rgba_rear_right_lbl.Text = krembo.WKC.RgbaRearRight.Distance.ToString();
            rgba_rear_right_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaRearRight.Red,
                                                      krembo.WKC.RgbaRearRight.Green,
                                                      krembo.WKC.RgbaRearRight.Blue);

            rgba_rear_left_lbl.Text = krembo.WKC.RgbaRearLeft.Distance.ToString();
            rgba_rear_left_lbl.BackColor = Color.FromArgb(krembo.WKC.RgbaRearLeft.Red,
                                                      krembo.WKC.RgbaRearLeft.Green,
                                                      krembo.WKC.RgbaRearLeft.Blue);


            //read bumpers values
            if (krembo.WKC.BumpFront)
                bumper_front_lbl.BackColor = Color.Lime;
            else
                bumper_front_lbl.BackColor = Color.Red;

            if (krembo.WKC.BumpRear)
                bumper_rear_lbl.BackColor = Color.Lime;
            else
                bumper_rear_lbl.BackColor = Color.Red;

            if (krembo.WKC.BumpRight)
                bumper_right_lbl.BackColor = Color.Lime;
            else
                bumper_right_lbl.BackColor = Color.Red;

            if (krembo.WKC.BumpLeft)
                bumper_left_lbl.BackColor = Color.Lime;
            else
                bumper_left_lbl.BackColor = Color.Red;

            OnSelectedPhoton();

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
            server_.sendToKrembo(((Krembo)(connected_photons_lstbx.SelectedItem)).WKC.ID, wkc_msg); //client is chosen by connection socket (no need for id)
        }

        private void SendMsgToSelectedKrembo()
        {
            server_.sendToKrembo(((Krembo)(connected_photons_lstbx.SelectedItem)).WKC.ID, wkc_msg_); //client is chosen by connection socket (no need for id)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void connected_photons_lstbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!flash_mode_)
            {
                updateKremboData((Krembo)connected_photons_lstbx.SelectedItem);
            }         
        }

        public void OnSelectedPhoton()
        {
            led_on_rdbtn.Enabled = true;
            flash_on_rdbtn.Enabled = true;
            base_on_rdbtn.Enabled = true;
            ping_btn.Enabled = true;
        }

        private void linear_vel_sbar_Scroll(object sender, EventArgs e)
        {
            wkc_msg_.linear_vel = Krembo.MapBaseToByteVel(-100, 100, linear_vel_sbar.Value * 10);
            wkc_msg_.angular_vel = Krembo.MapBaseToByteVel(-100, 100, angular_vel_sbar.Value * 10);
            SendMsgToSelectedKrembo();

            linear_vel_lbl.Text = (Math.Abs(linear_vel_sbar.Value * 10)).ToString() + " %";
        }

        private void angular_vel_sbar_Scroll(object sender, EventArgs e)
        {
            wkc_msg_.linear_vel = Krembo.MapBaseToByteVel(-100, 100, linear_vel_sbar.Value * 10);
            wkc_msg_.angular_vel = Krembo.MapBaseToByteVel(-100, 100, angular_vel_sbar.Value * 10);
            SendMsgToSelectedKrembo();

            angular_vel_lbl.Text = (Math.Abs(angular_vel_sbar.Value * 10)).ToString() + " %";
        }

        private void reset_lin_vel_btn_Click(object sender, EventArgs e)
        {
            wkc_msg_.linear_vel = Krembo.MapBaseToByteVel(-100, 100, 0);
            wkc_msg_.angular_vel = Krembo.MapBaseToByteVel(-100, 100, angular_vel_sbar.Value * 10);
            SendMsgToSelectedKrembo();

            linear_vel_sbar.Value = 0;
            linear_vel_lbl.Text = "0 %";
        }

        private void reset_ang_vel_btn_Click(object sender, EventArgs e)
        {
            wkc_msg_.linear_vel = Krembo.MapBaseToByteVel(-100, 100, linear_vel_sbar.Value);
            wkc_msg_.angular_vel = Krembo.MapBaseToByteVel(-100, 100, 0);
            SendMsgToSelectedKrembo();

            angular_vel_sbar.Value = 0;
            angular_vel_lbl.Text = "0 %";
        }

        private void choose_color_btn_Click(object sender, EventArgs e)
        {
            if (color_dialog.ShowDialog() == DialogResult.OK)
            {
                red_lbl.Text = color_dialog.Color.R.ToString();
                green_lbl.Text = color_dialog.Color.G.ToString();
                blue_lbl.Text = color_dialog.Color.B.ToString();
                choose_color_btn.BackColor = color_dialog.Color;

                wkc_msg_.led_red = ushort.Parse(red_lbl.Text);
                wkc_msg_.led_green = ushort.Parse(green_lbl.Text);
                wkc_msg_.led_blue = ushort.Parse(blue_lbl.Text);
                SendMsgToSelectedKrembo();
            }
        }

        private void choose_bin_btn_Click(object sender, EventArgs e)
        {
            string bin_file_path = FileTools.chooseFilePath("Binary Files (*.bin)|*.bin");
            bin_path_lbl.Text = bin_file_path;
            flash_btn.Enabled = true;
        }

        private void flash_btn_Click(object sender, EventArgs e)
        {
            if (File.Exists(bin_path_lbl.Text))
            {
                if (connected_photons_lstbx.SelectedItems.Count > 0)
                {
                    flash_btn.Enabled = false;
                    flash_status_lbl.Text = "Flashing...";
                    flash_status_lbl.BackColor = Color.DarkOrange;
                    //TODO: do flash work - flash selected photons
                    var id_list = new List<string>();
                    foreach (Krembo krembo in krembos_list_)
                        id_list.Add(KremboIdDict.Instance.IdToName(krembo.WKC.ID));
                    Parallel.ForEach(id_list, id =>
                    {
                        ParticleCLI.flashPhoton(id, bin_path_lbl.Text);
                    });
                    flash_status_lbl.Text = "Done...";
                    flash_status_lbl.BackColor = Color.Lime;
                    flash_btn.Enabled = true;
                }
                else
                    MsgBxLogger.errorMsg("Flash Error",
                                    "Please select krembos from the list before flashing");
            }
            else
            {
                MsgBxLogger.errorMsg("Flash Error",
                                    "Bin file at: " + bin_path_lbl.Text + " doesn't exist");
                bin_path_lbl.Text = "N/A";
            }



            
        }

      

        private void led_on_btn_CheckedChanged(object sender, EventArgs e)
        {
            if(led_on_rdbtn.Checked)
            {
                wkc_msg_.toggle_led = true;
                wkc_msg_.led_red = ushort.Parse(red_lbl.Text);
                wkc_msg_.led_green = ushort.Parse(green_lbl.Text);
                wkc_msg_.led_blue = ushort.Parse(blue_lbl.Text);
                choose_color_btn.Enabled = true;
            }
            else
            {
                // wkc_msg_.led_red = 0;
                // wkc_msg_.led_green = 0;
                // wkc_msg_.led_blue = 0;
                // SendMsgToSelectedKrembo();
                wkc_msg_.toggle_led = false;
            }
            SendMsgToSelectedKrembo();
        }

        private void base_off_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
     
        }

        private void base_on_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if(base_on_rdbtn.Checked)
            {
                //enable gui commands
                wkc_msg_.linear_vel = Krembo.MapBaseToByteVel(-100, 100, 0);
                wkc_msg_.angular_vel = Krembo.MapBaseToByteVel(-100, 100, 0);
                wkc_msg_.joy_control = true;

                reset_ang_vel_btn.Enabled = true;
                reset_lin_vel_btn.Enabled = true;
                linear_vel_sbar.Enabled = true;
                angular_vel_sbar.Enabled = true;
            }
            else
            {
                //stop base
                wkc_msg_.joy_control = false;
                reset_ang_vel_btn.Enabled = false;
                reset_lin_vel_btn.Enabled = false;
                linear_vel_sbar.Enabled = false;
                angular_vel_sbar.Enabled = false;
                angular_vel_sbar.Value = 0;
                linear_vel_sbar.Value = 0;
            }
            SendMsgToSelectedKrembo();
        }

        private void flash_on_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (flash_on_rdbtn.Checked)
            {
                flash_mode_ = true;
                flash_btn.Enabled = true;
                choose_bin_btn.Enabled = true;
                select_all_btn.Enabled = true;
                led_grbx.Enabled = false;
                base_grbx.Enabled = false;
                ping_btn.Enabled = false;
                connected_photons_lstbx.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                flash_mode_ = false;
                flash_btn.Enabled = false;
                choose_bin_btn.Enabled = false;
                select_all_btn.Enabled = false;
                led_grbx.Enabled = true;
                base_grbx.Enabled = true;
                ping_btn.Enabled = true;
                connected_photons_lstbx.SelectionMode = SelectionMode.One;
            }
            
        }

        private void flash_off_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void send_txt_btn_Click(object sender, EventArgs e)
        {
            wkc_msg_.user_msg = msg_txt.Text;
            SendMsgToSelectedKrembo();
            wkc_msg_.user_msg = "";
        }

        private void led_off_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void led_grbx_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void data_on_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (data_on_rdbtn.Checked)
            { 
                wkc_msg_.data_req = true;
            }
            else
            {
                wkc_msg_.data_req = false;
                bumper_front_lbl.BackColor = Color.DarkOrange;
                bumper_rear_lbl.BackColor = Color.DarkOrange;
                bumper_right_lbl.BackColor = Color.DarkOrange;
                bumper_left_lbl.BackColor = Color.DarkOrange;
            }
            SendMsgToSelectedKrembo();
        }

        private void data_off_rdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bin_path_lbl_Click(object sender, EventArgs e)
        {

        }

        private void select_all_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < connected_photons_lstbx.Items.Count; i++)
            {
                connected_photons_lstbx.SetSelected(i, true);
            }
            
        }

        private void set_base_calib_btn_Click(object sender, EventArgs e)
        {
            wkc_msg_.base_offset = true;
            wkc_msg_.base_left_offset = Krembo.MapBaseToByteVel(-100, 100, (int)base_left_offset_txt.Value);
            wkc_msg_.base_right_offset = Krembo.MapBaseToByteVel(-100, 100, (int)base_right_offset_txt.Value);
            wkc_msg_.linear_vel += wkc_msg_.base_left_offset;
            wkc_msg_.angular_vel += wkc_msg_.base_right_offset;
            SendMsgToSelectedKrembo();
            wkc_msg_.base_offset = false;
        }

        private void base_grbx_Enter(object sender, EventArgs e)
        {

        }
    }
}
