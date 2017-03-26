using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;


namespace KremboControl.Utils
{
    static class MsgBxLogger
    {
        public static void errorMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void warningMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }
        public static void infoMsg(String title, String content)
        {
            MessageBox.Show(content,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }



    }
}
