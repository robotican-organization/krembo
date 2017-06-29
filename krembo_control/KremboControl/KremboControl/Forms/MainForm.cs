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
using System.Net.Sockets;

namespace KremboControl
{
    public partial class MainForm : Form
    {
        BindingList<Krembo> krembos_list_ = new BindingList<Krembo>();
        TCPServer server_;
        bool flash_mode_ = false;

        public MainForm()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(OnKeyPress);
            connected_photons_lstbx.DataSource = krembos_list_;
            
            server_ = new TCPServer();
            server_.subscribeToMsgs(OnNewKremboMsg);
            TryConnect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OnNewKremboMsg(WKCKrembo2PC wkc_msg)
        {
            Invoke((MethodInvoker)delegate
            {
                Krembo updated_krembo = new Krembo(wkc_msg);
                bool exist = false;
                foreach (Krembo krembo in krembos_list_)
                {
                    if (krembo.WkcIn.ID == wkc_msg.ID)
                    {
                        krembos_list_.ElementAt<Krembo>(krembos_list_.IndexOf(krembo)).WkcIn = krembo.WkcIn;
                        exist = true;
                        break;
                    }
                    
                }
                if (!exist)
                    krembos_list_.Add(updated_krembo);

                if (!wkc_msg.Disconnected && 
                    (GetSelectedKrembo().WkcIn.ID == updated_krembo.WkcIn.ID))
                {
                    UpdateGUIData(updated_krembo);
                }
            });
        }
        
        //get selected krembo in list
        private Krembo GetSelectedKrembo()
        {
            return ((Krembo)(connected_photons_lstbx.SelectedItem));
        }


        public void UpdateGUIData(Krembo krembo)
        {
            //read basic data
            if (krembo != null)
            {
               
                //update GUI lables with recent data
                id_lbl.Text = "ID: " + krembo.WkcIn.ID.ToString();
                bat_lvl_lbl.Text = "Bat lvl: " + krembo.WkcIn.BatLvl.ToString() + "%";
                bat_chrg_lvl_lbl.Text = "Chrg lvl: " + krembo.WkcIn.BatChrgLvl.ToString() + "%";

                //read rgba data
                rgba_front_lbl.Text = krembo.WkcIn.RgbaFront.Distance.ToString();
                rgba_front_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaFront.Red,
                                                          krembo.WkcIn.RgbaFront.Green,
                                                          krembo.WkcIn.RgbaFront.Blue);

                rgba_rear_lbl.Text = krembo.WkcIn.RgbaRear.Distance.ToString();
                rgba_rear_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaRear.Red,
                                                          krembo.WkcIn.RgbaRear.Green,
                                                          krembo.WkcIn.RgbaRear.Blue);

                rgba_right_lbl.Text = krembo.WkcIn.RgbaRight.Distance.ToString();
                rgba_right_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaRight.Red,
                                                          krembo.WkcIn.RgbaRight.Green,
                                                          krembo.WkcIn.RgbaRight.Blue);

                rgba_left_lbl.Text = krembo.WkcIn.RgbaLeft.Distance.ToString();
                rgba_left_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaLeft.Red,
                                                          krembo.WkcIn.RgbaLeft.Green,
                                                          krembo.WkcIn.RgbaLeft.Blue);

                rgba_front_right_lbl.Text = krembo.WkcIn.RgbaFrontRight.Distance.ToString();
                rgba_front_right_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaFrontRight.Red,
                                                          krembo.WkcIn.RgbaFrontRight.Green,
                                                          krembo.WkcIn.RgbaFrontRight.Blue);

                rgba_front_left_lbl.Text = krembo.WkcIn.RgbaFrontLeft.Distance.ToString();
                rgba_front_left_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaFrontLeft.Red,
                                                          krembo.WkcIn.RgbaFrontLeft.Green,
                                                          krembo.WkcIn.RgbaFrontLeft.Blue);

                rgba_rear_right_lbl.Text = krembo.WkcIn.RgbaRearRight.Distance.ToString();
                rgba_rear_right_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaRearRight.Red,
                                                          krembo.WkcIn.RgbaRearRight.Green,
                                                          krembo.WkcIn.RgbaRearRight.Blue);

                rgba_rear_left_lbl.Text = krembo.WkcIn.RgbaRearLeft.Distance.ToString();
                rgba_rear_left_lbl.BackColor = Color.FromArgb(krembo.WkcIn.RgbaRearLeft.Red,
                                                          krembo.WkcIn.RgbaRearLeft.Green,
                                                          krembo.WkcIn.RgbaRearLeft.Blue);


                //read bumpers values
                if (krembo.WkcIn.BumpFront)
                    bumper_front_lbl.BackColor = Color.Lime;
                else
                    bumper_front_lbl.BackColor = Color.Red;

                if (krembo.WkcIn.BumpRear)
                    bumper_rear_lbl.BackColor = Color.Lime;
                else
                    bumper_rear_lbl.BackColor = Color.Red;

                if (krembo.WkcIn.BumpRight)
                    bumper_right_lbl.BackColor = Color.Lime;
                else
                    bumper_right_lbl.BackColor = Color.Red;

                if (krembo.WkcIn.BumpLeft)
                    bumper_left_lbl.BackColor = Color.Lime;
                else
                    bumper_left_lbl.BackColor = Color.Red;

                OnSelectedPhoton();
            }
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
            server_.sendToKrembo(GetSelectedKrembo().WkcIn.ID, wkc_msg); //client is chosen by connection socket (no need for id)
        }

        private void SendMsgToSelectedKrembo()
        {
            server_.sendToKrembo(GetSelectedKrembo().WkcIn.ID, 
                                 GetSelectedKrembo().WkcOut); //client is chosen by connection socket (no need for id)
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
                UpdateGUIState();
                UpdateGUIData(GetSelectedKrembo());
            }         
        }

        private void UpdateGUIState()
        {
            //update GUI controls to current krembo state
            base_on_rdbtn.Checked = GetSelectedKrembo().WkcOut.joy_control;
            base_off_rdbtn.Checked = !GetSelectedKrembo().WkcOut.joy_control;
            //TODO: CONTINUE HERE----------------------------------------------------------------------------------------

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
            SendBaseCmd(linear_vel_sbar.Value, angular_vel_sbar.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Natural number b/w -100 and 100</param>
        public void SendBaseCmd(int linear_val, int angular_val)
        {
            GetSelectedKrembo().WkcOut.linear_vel = Krembo.MapBaseToByteVel(-100, 100, linear_val * 10);
            GetSelectedKrembo().WkcOut.angular_vel = Krembo.MapBaseToByteVel(-100, 100, angular_val * 10);
            angular_vel_lbl.Text = (Math.Abs(angular_vel_sbar.Value * 10)).ToString() + " %";
            linear_vel_lbl.Text = (Math.Abs(linear_vel_sbar.Value * 10)).ToString() + " %";
            SendMsgToSelectedKrembo();
        }

        private void angular_vel_sbar_Scroll(object sender, EventArgs e)
        {
            SendBaseCmd(linear_vel_sbar.Value, angular_vel_sbar.Value);
        }

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (base_on_rdbtn.Checked)
            {
                bool valid_key = true;
                switch (e.KeyCode)
                {
                    case Keys.W:
                        if (linear_vel_sbar.Value + 1 <= 10)
                           linear_vel_sbar.Value++;
                        break;
                    case Keys.S:
                        if (linear_vel_sbar.Value - 1 >= -10)
                            linear_vel_sbar.Value--;
                        break;
                    case Keys.D:
                        if (angular_vel_sbar.Value + 1 <= 10)
                            angular_vel_sbar.Value++;
                        break;
                    case Keys.A:
                        if (angular_vel_sbar.Value - 1 >= -10)
                            angular_vel_sbar.Value--;
                        break;
                    case Keys.X:
                        angular_vel_sbar.Value = 0;
                        linear_vel_sbar.Value = 0;
                        break;
                    default:
                        valid_key = false;
                        break;
                }
                if (valid_key)
                    SendBaseCmd(linear_vel_sbar.Value, angular_vel_sbar.Value);
            }
        }

        private void reset_lin_vel_btn_Click(object sender, EventArgs e)
        {
            linear_vel_sbar.Value = 0;
            SendBaseCmd(0, angular_vel_sbar.Value);

           // linear_vel_sbar.Value = 0;
           // linear_vel_lbl.Text = "0 %";
        }

        private void reset_ang_vel_btn_Click(object sender, EventArgs e)
        {
            angular_vel_sbar.Value = 0;
            SendBaseCmd(linear_vel_sbar.Value, 0);
        }

        private void choose_color_btn_Click(object sender, EventArgs e)
        {
            ChooseLedColor();
        }

        private void ChooseLedColor()
        {
            if (color_dialog.ShowDialog() == DialogResult.OK)
            {
                if (color_dialog.Color.R > 0 ||
                    color_dialog.Color.G > 0 ||
                    color_dialog.Color.B > 0)
                {
                    red_lbl.Text = color_dialog.Color.R.ToString();
                    green_lbl.Text = color_dialog.Color.G.ToString();
                    blue_lbl.Text = color_dialog.Color.B.ToString();
                    choose_color_btn.BackColor = color_dialog.Color;

                    GetSelectedKrembo().WkcOut.led_red = ushort.Parse(red_lbl.Text);
                    GetSelectedKrembo().WkcOut.led_green = ushort.Parse(green_lbl.Text);
                    GetSelectedKrembo().WkcOut.led_blue = ushort.Parse(blue_lbl.Text);
                }
                else
                {
                    led_off_rdbtn.Checked = true;
                    led_on_rdbtn.Checked = false;
                }
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
                        id_list.Add(KremboIdDict.Instance.IdToName(krembo.WkcIn.ID));
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
                ChooseLedColor();
                choose_color_btn.Enabled = true;
                GetSelectedKrembo().WkcOut.toggle_led = true;
            }
            else
                GetSelectedKrembo().WkcOut.toggle_led = false;
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
                GetSelectedKrembo().WkcOut.linear_vel = Krembo.MapBaseToByteVel(-100, 100, 0);
                GetSelectedKrembo().WkcOut.angular_vel = Krembo.MapBaseToByteVel(-100, 100, 0);

                GetSelectedKrembo().WkcOut.joy_control = true;
                reset_ang_vel_btn.Enabled = true;
                reset_lin_vel_btn.Enabled = true;
                linear_vel_sbar.Enabled = true;
                angular_vel_sbar.Enabled = true;
            }
            else
            {
                //stop base
                GetSelectedKrembo().WkcOut.joy_control = false;
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
            GetSelectedKrembo().WkcOut.user_msg = msg_txt.Text;
            SendMsgToSelectedKrembo();
            GetSelectedKrembo().WkcOut.user_msg = "";
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
                GetSelectedKrembo().WkcOut.data_req = true;
            }
            else
            {
                GetSelectedKrembo().WkcOut.data_req = false;
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
            GetSelectedKrembo().WkcOut.base_offset = true;
            GetSelectedKrembo().WkcOut.base_left_offset = Krembo.MapBaseToByteVel(-100, 100, (int)base_left_offset_txt.Value);
            GetSelectedKrembo().WkcOut.base_right_offset = Krembo.MapBaseToByteVel(-100, 100, (int)base_right_offset_txt.Value);
            SendMsgToSelectedKrembo();
            GetSelectedKrembo().WkcOut.base_offset = false;
        }

        private void base_grbx_Enter(object sender, EventArgs e)
        {

        }

        private void retry_btn_Click(object sender, EventArgs e)
        {
            TryConnect();
        }

        private void TryConnect()
        {
            string local_ip = GetMyIP();
            if (local_ip != null)
            {
                local_ip_lbl.Text = local_ip;
                local_ip_lbl.ForeColor = Color.Green;
                server_.asyncListenAt(new NetAddr(GetMyIP(), Krembo.PORT));
                retry_btn.Enabled = false;
            }
            else
            {
                local_ip_lbl.Text = "Not Connected";
                local_ip_lbl.ForeColor = Color.Red;
                MsgBxLogger.errorMsg("Internet Connection",
                                     "Internet connection is not available. Please connect and try again.");
            }
        }

        private string GetMyIP()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return null;
            string local_ip = null;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    local_ip = endPoint.Address.ToString();
                }
            }
            catch (SocketException exc)
            {
            }
            return local_ip;
        }

        private void bumps_calib_btn_Click(object sender, EventArgs e)
        {
            GetSelectedKrembo().WkcOut.bumps_calib = true;
            SendMsgToSelectedKrembo();
            GetSelectedKrembo().WkcOut.bumps_calib = false;
        }
    }
}
