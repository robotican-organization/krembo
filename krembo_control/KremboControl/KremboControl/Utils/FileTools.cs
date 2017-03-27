using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KremboControl.Utils
{
    class FileTools
    {
        public static string chooseSaveFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Save at";
            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;
            return null;
        }

        public static string chooseFilePath(string file_filter)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = file_filter;//"All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true      
                return choofdlog.FileName;
            }
            else return "";
        }
    }
}
