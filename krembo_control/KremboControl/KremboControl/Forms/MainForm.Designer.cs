namespace KremboControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bat_chrg_lvl_lbl = new System.Windows.Forms.Label();
            this.id_lbl = new System.Windows.Forms.Label();
            this.bat_lvl_lbl = new System.Windows.Forms.Label();
            this.ping_btn = new System.Windows.Forms.Button();
            this.connected_photons_lstbx = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.controller_grbx = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.blue_lbl = new System.Windows.Forms.Label();
            this.green_lbl = new System.Windows.Forms.Label();
            this.red_lbl = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.choose_color_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.angular_vel_sbar = new System.Windows.Forms.TrackBar();
            this.reset_ang_vel_btn = new System.Windows.Forms.Button();
            this.reset_lin_vel_btn = new System.Windows.Forms.Button();
            this.angular_vel_lbl = new System.Windows.Forms.Label();
            this.linear_vel_sbar = new System.Windows.Forms.TrackBar();
            this.linear_vel_lbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krembo_pic = new System.Windows.Forms.PictureBox();
            this.compass1 = new Simple_HUD.Compass();
            this.color_dialog = new System.Windows.Forms.ColorDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.choose_bin_btn = new System.Windows.Forms.Button();
            this.flash_btn = new System.Windows.Forms.Button();
            this.bin_path_lbl = new System.Windows.Forms.Label();
            this.select_all_btn = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.rgba_north_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.controller_grbx.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angular_vel_sbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linear_vel_sbar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bat_chrg_lvl_lbl
            // 
            this.bat_chrg_lvl_lbl.AutoSize = true;
            this.bat_chrg_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_chrg_lvl_lbl.Location = new System.Drawing.Point(35, 365);
            this.bat_chrg_lvl_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bat_chrg_lvl_lbl.Name = "bat_chrg_lvl_lbl";
            this.bat_chrg_lvl_lbl.Size = new System.Drawing.Size(93, 18);
            this.bat_chrg_lvl_lbl.TabIndex = 8;
            this.bat_chrg_lvl_lbl.Text = "BAT CHRG";
            // 
            // id_lbl
            // 
            this.id_lbl.AutoSize = true;
            this.id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_lbl.ForeColor = System.Drawing.Color.Black;
            this.id_lbl.Location = new System.Drawing.Point(35, 45);
            this.id_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(24, 18);
            this.id_lbl.TabIndex = 6;
            this.id_lbl.Text = "ID";
            // 
            // bat_lvl_lbl
            // 
            this.bat_lvl_lbl.AutoSize = true;
            this.bat_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_lvl_lbl.Location = new System.Drawing.Point(35, 334);
            this.bat_lvl_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bat_lvl_lbl.Name = "bat_lvl_lbl";
            this.bat_lvl_lbl.Size = new System.Drawing.Size(72, 18);
            this.bat_lvl_lbl.TabIndex = 7;
            this.bat_lvl_lbl.Text = "BAT LVL";
            // 
            // ping_btn
            // 
            this.ping_btn.Location = new System.Drawing.Point(14, 378);
            this.ping_btn.Margin = new System.Windows.Forms.Padding(2);
            this.ping_btn.Name = "ping_btn";
            this.ping_btn.Size = new System.Drawing.Size(78, 54);
            this.ping_btn.TabIndex = 5;
            this.ping_btn.Text = "Ping";
            this.ping_btn.UseVisualStyleBackColor = true;
            this.ping_btn.Click += new System.EventHandler(this.sendtest_btn_Click);
            // 
            // connected_photons_lstbx
            // 
            this.connected_photons_lstbx.FormattingEnabled = true;
            this.connected_photons_lstbx.Location = new System.Drawing.Point(14, 24);
            this.connected_photons_lstbx.Margin = new System.Windows.Forms.Padding(2);
            this.connected_photons_lstbx.Name = "connected_photons_lstbx";
            this.connected_photons_lstbx.Size = new System.Drawing.Size(172, 342);
            this.connected_photons_lstbx.TabIndex = 14;
            this.connected_photons_lstbx.SelectedIndexChanged += new System.EventHandler(this.connected_photons_lstbx_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Linear Vel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Angular Vel:";
            // 
            // controller_grbx
            // 
            this.controller_grbx.Controls.Add(this.groupBox4);
            this.controller_grbx.Controls.Add(this.groupBox2);
            this.controller_grbx.Controls.Add(this.groupBox1);
            this.controller_grbx.Controls.Add(this.ping_btn);
            this.controller_grbx.Controls.Add(this.connected_photons_lstbx);
            this.controller_grbx.Location = new System.Drawing.Point(11, 38);
            this.controller_grbx.Margin = new System.Windows.Forms.Padding(2);
            this.controller_grbx.Name = "controller_grbx";
            this.controller_grbx.Padding = new System.Windows.Forms.Padding(2);
            this.controller_grbx.Size = new System.Drawing.Size(801, 474);
            this.controller_grbx.TabIndex = 18;
            this.controller_grbx.TabStop = false;
            this.controller_grbx.Text = "Controller";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.blue_lbl);
            this.groupBox2.Controls.Add(this.green_lbl);
            this.groupBox2.Controls.Add(this.red_lbl);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.choose_color_btn);
            this.groupBox2.Location = new System.Drawing.Point(205, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 114);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Led";
            // 
            // blue_lbl
            // 
            this.blue_lbl.AutoSize = true;
            this.blue_lbl.BackColor = System.Drawing.Color.DodgerBlue;
            this.blue_lbl.Location = new System.Drawing.Point(222, 24);
            this.blue_lbl.MinimumSize = new System.Drawing.Size(30, 20);
            this.blue_lbl.Name = "blue_lbl";
            this.blue_lbl.Size = new System.Drawing.Size(30, 20);
            this.blue_lbl.TabIndex = 9;
            this.blue_lbl.Text = "0";
            this.blue_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // green_lbl
            // 
            this.green_lbl.AutoSize = true;
            this.green_lbl.BackColor = System.Drawing.Color.Lime;
            this.green_lbl.Location = new System.Drawing.Point(182, 24);
            this.green_lbl.MinimumSize = new System.Drawing.Size(30, 20);
            this.green_lbl.Name = "green_lbl";
            this.green_lbl.Size = new System.Drawing.Size(30, 20);
            this.green_lbl.TabIndex = 8;
            this.green_lbl.Text = "0";
            this.green_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // red_lbl
            // 
            this.red_lbl.AutoSize = true;
            this.red_lbl.BackColor = System.Drawing.Color.Red;
            this.red_lbl.Location = new System.Drawing.Point(141, 24);
            this.red_lbl.MinimumSize = new System.Drawing.Size(30, 20);
            this.red_lbl.Name = "red_lbl";
            this.red_lbl.Size = new System.Drawing.Size(30, 20);
            this.red_lbl.TabIndex = 7;
            this.red_lbl.Text = "0";
            this.red_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(24, 23);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Off";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 47);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "On";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Color :";
            // 
            // choose_color_btn
            // 
            this.choose_color_btn.Location = new System.Drawing.Point(103, 76);
            this.choose_color_btn.Name = "choose_color_btn";
            this.choose_color_btn.Size = new System.Drawing.Size(31, 23);
            this.choose_color_btn.TabIndex = 0;
            this.choose_color_btn.Text = "...";
            this.choose_color_btn.UseVisualStyleBackColor = true;
            this.choose_color_btn.Click += new System.EventHandler(this.choose_color_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.angular_vel_sbar);
            this.groupBox1.Controls.Add(this.reset_ang_vel_btn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.reset_lin_vel_btn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.angular_vel_lbl);
            this.groupBox1.Controls.Add(this.linear_vel_sbar);
            this.groupBox1.Controls.Add(this.linear_vel_lbl);
            this.groupBox1.Location = new System.Drawing.Point(205, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 224);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base";
            // 
            // angular_vel_sbar
            // 
            this.angular_vel_sbar.Location = new System.Drawing.Point(24, 152);
            this.angular_vel_sbar.Margin = new System.Windows.Forms.Padding(2);
            this.angular_vel_sbar.Maximum = 100;
            this.angular_vel_sbar.Minimum = -100;
            this.angular_vel_sbar.Name = "angular_vel_sbar";
            this.angular_vel_sbar.Size = new System.Drawing.Size(233, 45);
            this.angular_vel_sbar.TabIndex = 19;
            this.angular_vel_sbar.Scroll += new System.EventHandler(this.angular_vel_sbar_Scroll);
            // 
            // reset_ang_vel_btn
            // 
            this.reset_ang_vel_btn.Location = new System.Drawing.Point(193, 117);
            this.reset_ang_vel_btn.Margin = new System.Windows.Forms.Padding(2);
            this.reset_ang_vel_btn.Name = "reset_ang_vel_btn";
            this.reset_ang_vel_btn.Size = new System.Drawing.Size(56, 19);
            this.reset_ang_vel_btn.TabIndex = 23;
            this.reset_ang_vel_btn.Text = "Reset";
            this.reset_ang_vel_btn.UseVisualStyleBackColor = true;
            this.reset_ang_vel_btn.Click += new System.EventHandler(this.reset_ang_vel_btn_Click);
            // 
            // reset_lin_vel_btn
            // 
            this.reset_lin_vel_btn.Location = new System.Drawing.Point(193, 27);
            this.reset_lin_vel_btn.Margin = new System.Windows.Forms.Padding(2);
            this.reset_lin_vel_btn.Name = "reset_lin_vel_btn";
            this.reset_lin_vel_btn.Size = new System.Drawing.Size(56, 19);
            this.reset_lin_vel_btn.TabIndex = 22;
            this.reset_lin_vel_btn.Text = "Reset";
            this.reset_lin_vel_btn.UseVisualStyleBackColor = true;
            this.reset_lin_vel_btn.Click += new System.EventHandler(this.reset_lin_vel_btn_Click);
            // 
            // angular_vel_lbl
            // 
            this.angular_vel_lbl.AutoSize = true;
            this.angular_vel_lbl.Location = new System.Drawing.Point(90, 117);
            this.angular_vel_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.angular_vel_lbl.Name = "angular_vel_lbl";
            this.angular_vel_lbl.Size = new System.Drawing.Size(24, 13);
            this.angular_vel_lbl.TabIndex = 21;
            this.angular_vel_lbl.Text = "0 %";
            // 
            // linear_vel_sbar
            // 
            this.linear_vel_sbar.Location = new System.Drawing.Point(24, 60);
            this.linear_vel_sbar.Margin = new System.Windows.Forms.Padding(2);
            this.linear_vel_sbar.Maximum = 100;
            this.linear_vel_sbar.Minimum = -100;
            this.linear_vel_sbar.Name = "linear_vel_sbar";
            this.linear_vel_sbar.Size = new System.Drawing.Size(233, 45);
            this.linear_vel_sbar.TabIndex = 18;
            this.linear_vel_sbar.Scroll += new System.EventHandler(this.linear_vel_sbar_Scroll);
            // 
            // linear_vel_lbl
            // 
            this.linear_vel_lbl.AutoSize = true;
            this.linear_vel_lbl.Location = new System.Drawing.Point(83, 29);
            this.linear_vel_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linear_vel_lbl.Name = "linear_vel_lbl";
            this.linear_vel_lbl.Size = new System.Drawing.Size(24, 13);
            this.linear_vel_lbl.TabIndex = 20;
            this.linear_vel_lbl.Text = "0 %";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1426, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // krembo_pic
            // 
            this.krembo_pic.Image = global::KremboControl.Properties.Resources.krembo_scheme;
            this.krembo_pic.InitialImage = null;
            this.krembo_pic.Location = new System.Drawing.Point(16, 25);
            this.krembo_pic.Margin = new System.Windows.Forms.Padding(2);
            this.krembo_pic.Name = "krembo_pic";
            this.krembo_pic.Size = new System.Drawing.Size(302, 380);
            this.krembo_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.krembo_pic.TabIndex = 9;
            this.krembo_pic.TabStop = false;
            this.krembo_pic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // compass1
            // 
            this.compass1.Heading = 0F;
            this.compass1.Location = new System.Drawing.Point(353, 48);
            this.compass1.Name = "compass1";
            this.compass1.Size = new System.Drawing.Size(150, 150);
            this.compass1.TabIndex = 20;
            this.compass1.YawRate = 0F;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.compass1);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.rgba_north_lbl);
            this.groupBox3.Controls.Add(this.id_lbl);
            this.groupBox3.Controls.Add(this.bat_lvl_lbl);
            this.groupBox3.Controls.Add(this.bat_chrg_lvl_lbl);
            this.groupBox3.Controls.Add(this.krembo_pic);
            this.groupBox3.Location = new System.Drawing.Point(827, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 418);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.select_all_btn);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.choose_bin_btn);
            this.groupBox4.Controls.Add(this.flash_btn);
            this.groupBox4.Controls.Add(this.bin_path_lbl);
            this.groupBox4.Location = new System.Drawing.Point(504, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 387);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flash";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // choose_bin_btn
            // 
            this.choose_bin_btn.Location = new System.Drawing.Point(23, 117);
            this.choose_bin_btn.Margin = new System.Windows.Forms.Padding(2);
            this.choose_bin_btn.Name = "choose_bin_btn";
            this.choose_bin_btn.Size = new System.Drawing.Size(61, 54);
            this.choose_bin_btn.TabIndex = 7;
            this.choose_bin_btn.Text = "Choose Bin File";
            this.choose_bin_btn.UseVisualStyleBackColor = true;
            this.choose_bin_btn.Click += new System.EventHandler(this.choose_bin_btn_Click);
            // 
            // flash_btn
            // 
            this.flash_btn.Location = new System.Drawing.Point(23, 190);
            this.flash_btn.Margin = new System.Windows.Forms.Padding(2);
            this.flash_btn.Name = "flash_btn";
            this.flash_btn.Size = new System.Drawing.Size(158, 36);
            this.flash_btn.TabIndex = 6;
            this.flash_btn.Text = "Flash";
            this.flash_btn.UseVisualStyleBackColor = true;
            this.flash_btn.Click += new System.EventHandler(this.flash_btn_Click);
            // 
            // bin_path_lbl
            // 
            this.bin_path_lbl.AutoSize = true;
            this.bin_path_lbl.Location = new System.Drawing.Point(99, 138);
            this.bin_path_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bin_path_lbl.Name = "bin_path_lbl";
            this.bin_path_lbl.Size = new System.Drawing.Size(28, 13);
            this.bin_path_lbl.TabIndex = 8;
            this.bin_path_lbl.Text = "path";
            // 
            // select_all_btn
            // 
            this.select_all_btn.Location = new System.Drawing.Point(49, 301);
            this.select_all_btn.Margin = new System.Windows.Forms.Padding(2);
            this.select_all_btn.Name = "select_all_btn";
            this.select_all_btn.Size = new System.Drawing.Size(171, 31);
            this.select_all_btn.TabIndex = 11;
            this.select_all_btn.Text = "Select All";
            this.select_all_btn.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 42);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 17);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Disabled";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(23, 66);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(64, 17);
            this.radioButton4.TabIndex = 12;
            this.radioButton4.Text = "Enabled";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // rgba_north_lbl
            // 
            this.rgba_north_lbl.AutoSize = true;
            this.rgba_north_lbl.BackColor = System.Drawing.Color.Transparent;
            this.rgba_north_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgba_north_lbl.ForeColor = System.Drawing.Color.Black;
            this.rgba_north_lbl.Location = new System.Drawing.Point(77, 176);
            this.rgba_north_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rgba_north_lbl.MinimumSize = new System.Drawing.Size(35, 0);
            this.rgba_north_lbl.Name = "rgba_north_lbl";
            this.rgba_north_lbl.Size = new System.Drawing.Size(35, 18);
            this.rgba_north_lbl.TabIndex = 21;
            this.rgba_north_lbl.Text = "0";
            this.rgba_north_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(152, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.MinimumSize = new System.Drawing.Size(35, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(224, 175);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.MinimumSize = new System.Drawing.Size(35, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(246, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.MinimumSize = new System.Drawing.Size(35, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(222, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.MinimumSize = new System.Drawing.Size(35, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(150, 53);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.MinimumSize = new System.Drawing.Size(35, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "0";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(77, 78);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.MinimumSize = new System.Drawing.Size(35, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = "0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(51, 126);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.MinimumSize = new System.Drawing.Size(35, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 18);
            this.label13.TabIndex = 28;
            this.label13.Text = "0";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Red;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(505, 105);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.MinimumSize = new System.Drawing.Size(20, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 35);
            this.label15.TabIndex = 32;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(409, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.MinimumSize = new System.Drawing.Size(35, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 31;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Red;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(409, 27);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.MinimumSize = new System.Drawing.Size(35, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 20);
            this.label16.TabIndex = 33;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Red;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(328, 104);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.MinimumSize = new System.Drawing.Size(20, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 35);
            this.label14.TabIndex = 30;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1426, 695);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.controller_grbx);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.controller_grbx.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angular_vel_sbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linear_vel_sbar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label bat_chrg_lvl_lbl;
        private System.Windows.Forms.Label bat_lvl_lbl;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Button ping_btn;
        private System.Windows.Forms.PictureBox krembo_pic;
        private System.Windows.Forms.ListBox connected_photons_lstbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox controller_grbx;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label linear_vel_lbl;
        private System.Windows.Forms.TrackBar angular_vel_sbar;
        private System.Windows.Forms.TrackBar linear_vel_sbar;
        private System.Windows.Forms.Label angular_vel_lbl;
        private System.Windows.Forms.Button reset_ang_vel_btn;
        private System.Windows.Forms.Button reset_lin_vel_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choose_color_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private Simple_HUD.Compass compass1;
        private System.Windows.Forms.ColorDialog color_dialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label blue_lbl;
        private System.Windows.Forms.Label green_lbl;
        private System.Windows.Forms.Label red_lbl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button choose_bin_btn;
        private System.Windows.Forms.Button flash_btn;
        private System.Windows.Forms.Label bin_path_lbl;
        private System.Windows.Forms.Button select_all_btn;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label rgba_north_lbl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
    }
}

