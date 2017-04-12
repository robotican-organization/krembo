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
            this.connected_photons_lstbx = new System.Windows.Forms.ListBox();
            this.flash_btn = new System.Windows.Forms.Button();
            this.choose_bin_btn = new System.Windows.Forms.Button();
            this.bin_file_path_txtbx = new System.Windows.Forms.TextBox();
            this.bat_chrg_lvl_lbl = new System.Windows.Forms.Label();
            this.id_lbl = new System.Windows.Forms.Label();
            this.bat_lvl_lbl = new System.Windows.Forms.Label();
            this.sendtest_btn = new System.Windows.Forms.Button();
            this.krembo_pic = new System.Windows.Forms.PictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connected_photons_lstbx
            // 
            this.connected_photons_lstbx.FormattingEnabled = true;
            this.connected_photons_lstbx.ItemHeight = 16;
            this.connected_photons_lstbx.Location = new System.Drawing.Point(12, 13);
            this.connected_photons_lstbx.Name = "connected_photons_lstbx";
            this.connected_photons_lstbx.Size = new System.Drawing.Size(228, 420);
            this.connected_photons_lstbx.TabIndex = 0;
            // 
            // flash_btn
            // 
            this.flash_btn.Location = new System.Drawing.Point(49, 586);
            this.flash_btn.Name = "flash_btn";
            this.flash_btn.Size = new System.Drawing.Size(122, 66);
            this.flash_btn.TabIndex = 1;
            this.flash_btn.Text = "Flash";
            this.flash_btn.UseVisualStyleBackColor = true;
            this.flash_btn.Click += new System.EventHandler(this.flash_btn_Click);
            // 
            // choose_bin_btn
            // 
            this.choose_bin_btn.Location = new System.Drawing.Point(49, 470);
            this.choose_bin_btn.Name = "choose_bin_btn";
            this.choose_bin_btn.Size = new System.Drawing.Size(122, 66);
            this.choose_bin_btn.TabIndex = 2;
            this.choose_bin_btn.Text = "Choose Bin File";
            this.choose_bin_btn.UseVisualStyleBackColor = true;
            this.choose_bin_btn.Click += new System.EventHandler(this.choose_bin_btn_Click);
            // 
            // bin_file_path_txtbx
            // 
            this.bin_file_path_txtbx.Location = new System.Drawing.Point(197, 492);
            this.bin_file_path_txtbx.Name = "bin_file_path_txtbx";
            this.bin_file_path_txtbx.Size = new System.Drawing.Size(273, 22);
            this.bin_file_path_txtbx.TabIndex = 3;
            // 
            // bat_chrg_lvl_lbl
            // 
            this.bat_chrg_lvl_lbl.AutoSize = true;
            this.bat_chrg_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_chrg_lvl_lbl.Location = new System.Drawing.Point(548, 410);
            this.bat_chrg_lvl_lbl.Name = "bat_chrg_lvl_lbl";
            this.bat_chrg_lvl_lbl.Size = new System.Drawing.Size(66, 24);
            this.bat_chrg_lvl_lbl.TabIndex = 8;
            this.bat_chrg_lvl_lbl.Text = "label9";
            // 
            // id_lbl
            // 
            this.id_lbl.AutoSize = true;
            this.id_lbl.BackColor = System.Drawing.Color.Transparent;
            this.id_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_lbl.ForeColor = System.Drawing.Color.Black;
            this.id_lbl.Location = new System.Drawing.Point(701, 13);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(66, 24);
            this.id_lbl.TabIndex = 6;
            this.id_lbl.Text = "label7";
            // 
            // bat_lvl_lbl
            // 
            this.bat_lvl_lbl.AutoSize = true;
            this.bat_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_lvl_lbl.Location = new System.Drawing.Point(548, 368);
            this.bat_lvl_lbl.Name = "bat_lvl_lbl";
            this.bat_lvl_lbl.Size = new System.Drawing.Size(66, 24);
            this.bat_lvl_lbl.TabIndex = 7;
            this.bat_lvl_lbl.Text = "label8";
            // 
            // sendtest_btn
            // 
            this.sendtest_btn.Location = new System.Drawing.Point(570, 549);
            this.sendtest_btn.Name = "sendtest_btn";
            this.sendtest_btn.Size = new System.Drawing.Size(104, 66);
            this.sendtest_btn.TabIndex = 5;
            this.sendtest_btn.Text = "send test";
            this.sendtest_btn.UseVisualStyleBackColor = true;
            this.sendtest_btn.Click += new System.EventHandler(this.sendtest_btn_Click);
            // 
            // krembo_pic
            // 
            this.krembo_pic.Image = global::KremboControl.Properties.Resources.krembo_scheme;
            this.krembo_pic.InitialImage = null;
            this.krembo_pic.Location = new System.Drawing.Point(548, 13);
            this.krembo_pic.Name = "krembo_pic";
            this.krembo_pic.Size = new System.Drawing.Size(380, 423);
            this.krembo_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.krembo_pic.TabIndex = 9;
            this.krembo_pic.TabStop = false;
            this.krembo_pic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 21);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 69);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 21);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Multi";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(257, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 152);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Mode";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 106);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(44, 21);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "All";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 45);
            this.button1.TabIndex = 13;
            this.button1.Text = "Take Control";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 45);
            this.button2.TabIndex = 14;
            this.button2.Text = "Flash";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 686);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bat_chrg_lvl_lbl);
            this.Controls.Add(this.sendtest_btn);
            this.Controls.Add(this.bat_lvl_lbl);
            this.Controls.Add(this.id_lbl);
            this.Controls.Add(this.bin_file_path_txtbx);
            this.Controls.Add(this.choose_bin_btn);
            this.Controls.Add(this.flash_btn);
            this.Controls.Add(this.connected_photons_lstbx);
            this.Controls.Add(this.krembo_pic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox connected_photons_lstbx;
        private System.Windows.Forms.Button flash_btn;
        private System.Windows.Forms.Button choose_bin_btn;
        private System.Windows.Forms.TextBox bin_file_path_txtbx;
        private System.Windows.Forms.Label bat_chrg_lvl_lbl;
        private System.Windows.Forms.Label bat_lvl_lbl;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Button sendtest_btn;
        private System.Windows.Forms.PictureBox krembo_pic;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

