﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KremboControl.Utils;



/***************************************************************************************************************
* |----------------------------------------------N BYTES ARRAY-------------------------------------------------|
* Index |    0 (8 BITS FLAGS)   |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |
* Data  | | |BC |BO |JC |DR |TL | JX  | JY  |  MS |  LR |  LG |  LB | BRO | BLO |
* Values|   |0-1|0-1|0-1|0-1|0-1|0-255|0-255|0-255|0-255|0-255|0-255|0-255|0-255|
* -------------------------------------------------------------------------------------------------------------|
* Flags:
* JC = JOY CONTROL = indicates whether master request to control base with joystick
* DR = DATA REQUEST = master asks for sensors/Krembo state data
* TL = TOGGLE LED = master asks to turn on/off led
* BO = BASE OFFSET = indicates whether to set wheels speed offset (calibration)
* BC = BUMPERS CALIBRATION MODE
* 
* JX = JOY X = joystick x value
* JY = JOY Y = joystick y value
* MS = MESSAGE SIZE = user message size
* LR = LED RED
* LG = LEG GREEN
* LB = LED BLUE
* BRO = BASE RIGHT OFFSET 
* BLO = BASE LEFT OFFSET 
**************************************************************************************************************/


namespace KremboControl.Network
{
    public class WKCPC2Krembo
    {
        public const int PC2KREMBO_MSG_SIZE = 9;

        public const int FLAGS_INDX = 0;
                    public const int DATA_REQ_BIT = 0;
                    public const int TOGGLE_LED_BIT = 1;
                    public const int JOY_CTRL_BIT = 2;
                    public const int BASE_OFFSET_BIT = 3;
                    public const int BUMPS_CALIB_BIT = 4;

        public const int JOY_X_INDX = 1;
        public const int JOY_Y_INDX = 2;
        public const int USER_MSG_SIZE_INDX = 3;
        public const int LED_RED_INDX = 4;
        public const int LED_GREEN_INDX = 5;
        public const int LED_BLUE_INDX = 6;
        public const int BASE_RIGHT_OFFSET = 7;
        public const int BASE_LEFT_OFFSET = 8;

        public ushort linear_vel = Krembo.NEUTRAL_BYTE_VEL,
                      angular_vel = Krembo.NEUTRAL_BYTE_VEL,
                      led_red,
                      led_green,
                      led_blue,
                      base_right_offset,
                      base_left_offset;

        public bool data_req = true, //default is to send data right away
                    toggle_led,
                    joy_control,
                    base_offset,
                    bumps_calib;

        public string user_msg = "";

        public byte[] toBytes()
        {
            byte[] user_msg_buff = Encoding.ASCII.GetBytes(user_msg);
            byte[] buff = new byte[PC2KREMBO_MSG_SIZE + user_msg_buff.Length];

            byte flags_byte = 0;
            setBitInByte(ref flags_byte, Convert.ToByte(data_req), DATA_REQ_BIT);
            setBitInByte(ref flags_byte, Convert.ToByte(toggle_led), TOGGLE_LED_BIT);
            setBitInByte(ref flags_byte, Convert.ToByte(joy_control), JOY_CTRL_BIT);
            setBitInByte(ref flags_byte, Convert.ToByte(base_offset), BASE_OFFSET_BIT);
            setBitInByte(ref flags_byte, Convert.ToByte(bumps_calib), BUMPS_CALIB_BIT);
            buff[FLAGS_INDX] = flags_byte;

            buff[JOY_X_INDX] = (byte)linear_vel;
            buff[JOY_Y_INDX] = (byte)angular_vel;
            buff[LED_RED_INDX] = (byte)led_red;
            buff[LED_BLUE_INDX] = (byte)led_blue;
            buff[LED_GREEN_INDX] = (byte)led_green;

            buff[BASE_RIGHT_OFFSET] = (byte)base_right_offset;
            buff[BASE_LEFT_OFFSET] = (byte)base_left_offset;


            buff[USER_MSG_SIZE_INDX] = (byte)user_msg.Length;

            for (int i=PC2KREMBO_MSG_SIZE;
                 i < buff.Length;
                 i++)
            {
                buff[i] = user_msg_buff[i-PC2KREMBO_MSG_SIZE];
            }
            return buff;
        }

        void setBitInByte(ref byte data_byte, byte bit_val, byte bit_indx)
        {
            data_byte ^= (byte)((-bit_val ^ data_byte) & (1 << bit_indx));
        }

    }
}
