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
            this.state_grbx = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.state_grbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // connected_photons_lstbx
            // 
            this.connected_photons_lstbx.FormattingEnabled = true;
            this.connected_photons_lstbx.ItemHeight = 16;
            this.connected_photons_lstbx.Location = new System.Drawing.Point(683, 80);
            this.connected_photons_lstbx.Name = "connected_photons_lstbx";
            this.connected_photons_lstbx.Size = new System.Drawing.Size(228, 292);
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
            // state_grbx
            // 
            this.state_grbx.Controls.Add(this.label12);
            this.state_grbx.Controls.Add(this.label11);
            this.state_grbx.Controls.Add(this.label10);
            this.state_grbx.Controls.Add(this.label9);
            this.state_grbx.Controls.Add(this.label8);
            this.state_grbx.Controls.Add(this.label7);
            this.state_grbx.Controls.Add(this.label6);
            this.state_grbx.Controls.Add(this.label5);
            this.state_grbx.Controls.Add(this.label4);
            this.state_grbx.Controls.Add(this.label3);
            this.state_grbx.Controls.Add(this.label2);
            this.state_grbx.Controls.Add(this.label1);
            this.state_grbx.Location = new System.Drawing.Point(49, 80);
            this.state_grbx.Name = "state_grbx";
            this.state_grbx.Size = new System.Drawing.Size(297, 262);
            this.state_grbx.TabIndex = 4;
            this.state_grbx.TabStop = false;
            this.state_grbx.Text = "Krembo State";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Battery level:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Charging:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(117, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(117, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(117, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "label12";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 686);
            this.Controls.Add(this.state_grbx);
            this.Controls.Add(this.bin_file_path_txtbx);
            this.Controls.Add(this.choose_bin_btn);
            this.Controls.Add(this.flash_btn);
            this.Controls.Add(this.connected_photons_lstbx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.state_grbx.ResumeLayout(false);
            this.state_grbx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox connected_photons_lstbx;
        private System.Windows.Forms.Button flash_btn;
        private System.Windows.Forms.Button choose_bin_btn;
        private System.Windows.Forms.TextBox bin_file_path_txtbx;
        private System.Windows.Forms.GroupBox state_grbx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

