using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KremboControl.Utils;

namespace KremboControl.Network
{
    class WKCPC2Krembo
    {
        /***************************************************************************************************************
         * |----------------------------------------------N BYTES ARRAY-----------------------------------------------|
         * |          0 (8 BITS FLAGS)             |  1   |  2  |
         * |DATA REQ|TOGGLE LED|                   | ROLL |PITCH|
         * |   0-1  |   0-1    |                   |0-255 |0-255|
         **************************************************************************************************************/
        /*
        public const int MSG_SIZE = 3;
        public const int ID_INDX = 0;
        public const int BAT_LVL_INDX = 1;
        public const int BAT_CHRG_LVL_INDX = 2;
        */
        public static void toBytes(ref byte[] bytes_buff, JoystickControls joy_controls)
        {
            /*
            //header
            fillBuffWithBytes(ref bytes_buff, HEADER, PKG_HEADER_INDX);

            //data
            fillBuffWithBytes(ref bytes_buff, joy_controls.roll_axis, PKG_ROLL_INDX);
            fillBuffWithBytes(ref bytes_buff, joy_controls.pitch_axis, PKG_PITCH_INDX);
            fillBuffWithBytes(ref bytes_buff, joy_controls.yaw_axis, PKG_YAW_INDX);
            fillBuffWithBytes(ref bytes_buff, joy_controls.throttle_axis, PKG_THROTTLE_INDX);
            fillBuffWithBytes(ref bytes_buff, Convert.ToByte(joy_controls.toggle1), PKG_TOGGLE1_INDX);
            fillBuffWithBytes(ref bytes_buff, Convert.ToByte(joy_controls.toggle2), PKG_TOGGLE2_INDX);
            */
          
        }

        /*
        private static void fillBuffWithBytes(ref byte[] buff, UInt16 value, int fill_index)
        {
            //int16 - 2 bytes
            byte[] temp_buff = BitConverter.GetBytes(value);
            buff[fill_index] = temp_buff[0];
            buff[fill_index + 1] = temp_buff[1];
        }

        private static void fillBuffWithBytes(ref byte[] buff, byte value, int fill_index)
        {
            //bool is only 1 byte
            byte[] temp_buff = BitConverter.GetBytes(value);
            buff[fill_index] = temp_buff[0];
        }*/
    }
}
