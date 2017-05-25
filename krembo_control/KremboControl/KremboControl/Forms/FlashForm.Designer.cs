namespace KremboControl.Forms
{
    partial class FlashForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bin_path_lbl = new System.Windows.Forms.Label();
            this.choose_bin_btn = new System.Windows.Forms.Button();
            this.flash_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.connected_photons_lstbx = new System.Windows.Forms.ListBox();
            this.select_all_btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // bin_path_lbl
            // 
            this.bin_path_lbl.AutoSize = true;
            this.bin_path_lbl.Location = new System.Drawing.Point(402, 37);
            this.bin_path_lbl.Name = "bin_path_lbl";
            this.bin_path_lbl.Size = new System.Drawing.Size(36, 17);
            this.bin_path_lbl.TabIndex = 3;
            this.bin_path_lbl.Text = "path";
            // 
            // choose_bin_btn
            // 
            this.choose_bin_btn.Location = new System.Drawing.Point(258, 12);
            this.choose_bin_btn.Name = "choose_bin_btn";
            this.choose_bin_btn.Size = new System.Drawing.Size(116, 66);
            this.choose_bin_btn.TabIndex = 2;
            this.choose_bin_btn.Text = "Choose Bin File";
            this.choose_bin_btn.UseVisualStyleBackColor = true;
            this.choose_bin_btn.Click += new System.EventHandler(this.choose_bin_btn_Click);
            // 
            // flash_btn
            // 
            this.flash_btn.Location = new System.Drawing.Point(258, 102);
            this.flash_btn.Name = "flash_btn";
            this.flash_btn.Size = new System.Drawing.Size(321, 56);
            this.flash_btn.TabIndex = 1;
            this.flash_btn.Text = "Flash";
            this.flash_btn.UseVisualStyleBackColor = true;
            this.flash_btn.Click += new System.EventHandler(this.flash_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(480, 481);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(129, 56);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // connected_photons_lstbx
            // 
            this.connected_photons_lstbx.FormattingEnabled = true;
            this.connected_photons_lstbx.ItemHeight = 16;
            this.connected_photons_lstbx.Location = new System.Drawing.Point(15, 12);
            this.connected_photons_lstbx.Name = "connected_photons_lstbx";
            this.connected_photons_lstbx.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.connected_photons_lstbx.Size = new System.Drawing.Size(228, 468);
            this.connected_photons_lstbx.TabIndex = 7;
            this.connected_photons_lstbx.SelectedIndexChanged += new System.EventHandler(this.connected_photons_lstbx_SelectedIndexChanged);
            // 
            // select_all_btn
            // 
            this.select_all_btn.Location = new System.Drawing.Point(15, 499);
            this.select_all_btn.Name = "select_all_btn";
            this.select_all_btn.Size = new System.Drawing.Size(228, 38);
            this.select_all_btn.TabIndex = 8;
            this.select_all_btn.Text = "Select All";
            this.select_all_btn.UseVisualStyleBackColor = true;
            // 
            // FlashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 549);
            this.Controls.Add(this.select_all_btn);
            this.Controls.Add(this.connected_photons_lstbx);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choose_bin_btn);
            this.Controls.Add(this.flash_btn);
            this.Controls.Add(this.bin_path_lbl);
            this.Name = "FlashForm";
            this.Text = "FlashForm";
            this.Load += new System.EventHandler(this.FlashForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bin_path_lbl;
        private System.Windows.Forms.Button choose_bin_btn;
        private System.Windows.Forms.Button flash_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ListBox connected_photons_lstbx;
        private System.Windows.Forms.Button select_all_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}