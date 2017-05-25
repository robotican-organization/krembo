using KremboControl.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KremboControl.Forms
{
    public partial class FlashForm : Form
    {
        public FlashForm()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {

        }

        private void connected_photons_lstbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FlashForm_Load(object sender, EventArgs e)
        {

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
                flash_btn.Enabled = false;

                //TODO: do flash work - flash selected photons

                flash_btn.Enabled = true;
            }
            else
            {
                MsgBxLogger.errorMsg("Flash Error",
                                    "Bin file at: " + bin_path_lbl.Text + " doesn't exist");
                bin_path_lbl.Text = "";
                flash_btn.Enabled = false;
            }
        }
    }
}
