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
            this.sendtest_btn = new System.Windows.Forms.Button();
            this.connected_photons_lstbx = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.krembo_pic = new System.Windows.Forms.PictureBox();
            this.kremboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // bat_chrg_lvl_lbl
            // 
            this.bat_chrg_lvl_lbl.AutoSize = true;
            this.bat_chrg_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_chrg_lvl_lbl.Location = new System.Drawing.Point(287, 456);
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
            this.id_lbl.Location = new System.Drawing.Point(287, 61);
            this.id_lbl.Name = "id_lbl";
            this.id_lbl.Size = new System.Drawing.Size(66, 24);
            this.id_lbl.TabIndex = 6;
            this.id_lbl.Text = "label7";
            // 
            // bat_lvl_lbl
            // 
            this.bat_lvl_lbl.AutoSize = true;
            this.bat_lvl_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bat_lvl_lbl.Location = new System.Drawing.Point(287, 417);
            this.bat_lvl_lbl.Name = "bat_lvl_lbl";
            this.bat_lvl_lbl.Size = new System.Drawing.Size(66, 24);
            this.bat_lvl_lbl.TabIndex = 7;
            this.bat_lvl_lbl.Text = "label8";
            // 
            // sendtest_btn
            // 
            this.sendtest_btn.Location = new System.Drawing.Point(374, 625);
            this.sendtest_btn.Name = "sendtest_btn";
            this.sendtest_btn.Size = new System.Drawing.Size(104, 66);
            this.sendtest_btn.TabIndex = 5;
            this.sendtest_btn.Text = "send test";
            this.sendtest_btn.UseVisualStyleBackColor = true;
            this.sendtest_btn.Click += new System.EventHandler(this.sendtest_btn_Click);
            // 
            // connected_photons_lstbx
            // 
            this.connected_photons_lstbx.FormattingEnabled = true;
            this.connected_photons_lstbx.ItemHeight = 16;
            this.connected_photons_lstbx.Location = new System.Drawing.Point(12, 37);
            this.connected_photons_lstbx.Name = "connected_photons_lstbx";
            this.connected_photons_lstbx.Size = new System.Drawing.Size(228, 468);
            this.connected_photons_lstbx.TabIndex = 14;
            this.connected_photons_lstbx.SelectedIndexChanged += new System.EventHandler(this.connected_photons_lstbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "State:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "X Val:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y Val:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(824, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 182);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kremboToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1287, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // krembo_pic
            // 
            this.krembo_pic.Image = global::KremboControl.Properties.Resources.krembo_scheme;
            this.krembo_pic.InitialImage = null;
            this.krembo_pic.Location = new System.Drawing.Point(272, 37);
            this.krembo_pic.Name = "krembo_pic";
            this.krembo_pic.Size = new System.Drawing.Size(402, 468);
            this.krembo_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.krembo_pic.TabIndex = 9;
            this.krembo_pic.TabStop = false;
            this.krembo_pic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // kremboToolStripMenuItem
            // 
            this.kremboToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flashToolStripMenuItem});
            this.kremboToolStripMenuItem.Name = "kremboToolStripMenuItem";
            this.kremboToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.kremboToolStripMenuItem.Text = "Krembo";
            // 
            // flashToolStripMenuItem
            // 
            this.flashToolStripMenuItem.Name = "flashToolStripMenuItem";
            this.flashToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.flashToolStripMenuItem.Text = "Flash ...";
            this.flashToolStripMenuItem.Click += new System.EventHandler(this.flashToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1287, 826);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.connected_photons_lstbx);
            this.Controls.Add(this.bat_chrg_lvl_lbl);
            this.Controls.Add(this.sendtest_btn);
            this.Controls.Add(this.bat_lvl_lbl);
            this.Controls.Add(this.id_lbl);
            this.Controls.Add(this.krembo_pic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krembo_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label bat_chrg_lvl_lbl;
        private System.Windows.Forms.Label bat_lvl_lbl;
        private System.Windows.Forms.Label id_lbl;
        private System.Windows.Forms.Button sendtest_btn;
        private System.Windows.Forms.PictureBox krembo_pic;
        private System.Windows.Forms.ListBox connected_photons_lstbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kremboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

