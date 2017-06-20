using KremboControl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//package from krembo to pc
//WKC - wireless krembo communication protocol

/**************************************************************************
 * |----------------------------------------- N BYTES ARRAY ----------------------------------------------|
 * |       0 (8 BITS FLAGS)        |   1    |   2   | 3-6 |7-10 |11-14|15-18|19-21|22-25|26-29|30-33|34-58|
 * |   |   |FB |REB|LB |RIB|BC |BF |   BL   |  BCL% |RGBF |RGBRE|RGBRI|RGBL |RGBFR|RGBFL|RGBRR|RGBRL| ID  |
 * |0-1|0-1|0-1|0-1|0-1|0-1|0-1|0-1| 0-100  | 0-100 |0-255|0-255|0-255|0-255|0-255|0-255|0-255|0-255|0-255|
 * |------------------------------------------------------------------------------------------------------|

 ************FLAGS**********
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full

 ************BUMPERS FLAGS**********
 * Each bumper flag indicates whether bumper was pressed
 * FB = Front Bumper
 * RIB = Right Bumper
 * REB = Rear Bumper
 * RB = Right Bumper
 * LB = Left Bumper

 ************RGBA SENSORS**********
 * Each Rgba sensor is represented with 4 bytes (1 for proximity and 3 for rgb)
 * RGBF - front rgba
 * RGBRE - rear rgba
 * RGBRI - right rgba
 * RGBL - left rgba
 * RGBFR - front right rgba
 * RGBFL - front left rgba
 * RGBRR - rear right rgba
 * RGBRL - rear left rgba

 ************BATTERY DATA**********
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger

 * ID = 24 bytes of Photon string id in bytes
 **************************************************************************/

namespace KremboControl.Network
{
    public class WKCKrembo2PC
    {

        //flags indexes
        public const int FLAGS_INDX = 0;
        public const int BAT_FULL_BIT = 0;
        public const int BAT_CHARGING_BIT = 1;
        public const int BUMP_RIGHT_BIT = 2;
        public const int BUMP_LEFT_BIT = 3;
        public const int BUMP_REAR_BIT = 4;
        public const int BUMP_FRONT_BIT = 5;

        //battery indexes
        public const int BAT_LVL_INDX = 1;
        public const int BAT_CHRG_LVL_INDX = 2;

        //rgba offset indexes
        public const int RGBA_PROX_OFFSET = 0;
        public const int RGBA_RED_OFFSET = 1;
        public const int RGBA_GREEN_OFFSET = 2;
        public const int RGBA_BLUE_OFFSET = 3;

        //rgba start indexes
        public const int RGBA_FRONT_START_INDX = 3;
        public const int RGBA_REAR_START_INDX = 7;
        public const int RGBA_RIGHT_START_INDX = 11;
        public const int RGBA_LEFT_START_INDX = 15;
        public const int RGBA_FRONT_RIGHT_START_INDX = 19;
        public const int RGBA_FRONT_LEFT_START_INDX = 22;
        public const int RGBA_REAR_RIGHT_START_INDX = 26;
        public const int RGBA_REAR_LEFT_START_INDX = 30;

        //id indexes
        public const int ID_START_INDX = 34;
        public const int ID_SIZE = 24; //size of photon hardware id

        public const int MSG_SIZE = 34 + ID_SIZE; //size bytes arr

        public bool Disconnected = false; //if this is set to true by tcp server, message is used to notify that photon has disconnected
        public String ID;
        public UInt16 BatLvl { get; private set; }
        public UInt16 BatChrgLvl { get; private set; }
        public bool IsBatCharging,
                    IsBatFull,
                    BumpFront,
                    BumpRear,
                    BumpRight,
                    BumpLeft;

        public RGBARes RgbaFront = new RGBARes(),
                       RgbaRear = new RGBARes(),
                       RgbaRight = new RGBARes(),
                       RgbaLeft = new RGBARes(),
                       RgbaFrontRight = new RGBARes(),
                       RgbaFrontLeft = new RGBARes(),
                       RgbaRearRight = new RGBARes(),
                       RgbaRearLeft = new RGBARes();
                        


        public WKCKrembo2PC() { }
        public WKCKrembo2PC(byte [] wkc_msg)
        {
            toWKC(wkc_msg);
        }

        public void toWKC(byte []  wkc_bytes)
        {
            //get battery flags



            //get rgba values
            RgbaFront.Distance = wkc_bytes[RGBA_FRONT_START_INDX + RGBA_PROX_OFFSET];
            RgbaFront.Red = wkc_bytes[RGBA_FRONT_START_INDX + RGBA_RED_OFFSET];
            RgbaFront.Green = wkc_bytes[RGBA_FRONT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaFront.Blue = wkc_bytes[RGBA_FRONT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaRear.Distance = wkc_bytes[RGBA_REAR_START_INDX + RGBA_PROX_OFFSET];
            RgbaRear.Red = wkc_bytes[RGBA_REAR_START_INDX + RGBA_RED_OFFSET];
            RgbaRear.Green = wkc_bytes[RGBA_REAR_START_INDX + RGBA_GREEN_OFFSET];
            RgbaRear.Blue = wkc_bytes[RGBA_REAR_START_INDX + RGBA_BLUE_OFFSET];

            RgbaRight.Distance = wkc_bytes[RGBA_RIGHT_START_INDX + RGBA_PROX_OFFSET];
            RgbaRight.Red = wkc_bytes[RGBA_RIGHT_START_INDX + RGBA_RED_OFFSET];
            RgbaRight.Green = wkc_bytes[RGBA_RIGHT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaRight.Blue = wkc_bytes[RGBA_RIGHT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaLeft.Distance = wkc_bytes[RGBA_LEFT_START_INDX + RGBA_PROX_OFFSET];
            RgbaLeft.Red = wkc_bytes[RGBA_LEFT_START_INDX + RGBA_RED_OFFSET];
            RgbaLeft.Green = wkc_bytes[RGBA_LEFT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaLeft.Blue = wkc_bytes[RGBA_LEFT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaFrontRight.Distance = wkc_bytes[RGBA_FRONT_RIGHT_START_INDX + RGBA_PROX_OFFSET];
            RgbaFrontRight.Red = wkc_bytes[RGBA_FRONT_RIGHT_START_INDX + RGBA_RED_OFFSET];
            RgbaFrontRight.Green = wkc_bytes[RGBA_FRONT_RIGHT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaFrontRight.Blue = wkc_bytes[RGBA_FRONT_RIGHT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaFrontLeft.Distance = wkc_bytes[RGBA_FRONT_LEFT_START_INDX + RGBA_PROX_OFFSET];
            RgbaFrontLeft.Red = wkc_bytes[RGBA_FRONT_LEFT_START_INDX + RGBA_RED_OFFSET];
            RgbaFrontLeft.Green = wkc_bytes[RGBA_FRONT_LEFT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaFrontLeft.Blue = wkc_bytes[RGBA_FRONT_LEFT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaRearRight.Distance = wkc_bytes[RGBA_REAR_RIGHT_START_INDX + RGBA_PROX_OFFSET];
            RgbaRearRight.Red = wkc_bytes[RGBA_REAR_RIGHT_START_INDX + RGBA_RED_OFFSET];
            RgbaRearRight.Green = wkc_bytes[RGBA_REAR_RIGHT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaRearRight.Blue = wkc_bytes[RGBA_REAR_RIGHT_START_INDX + RGBA_BLUE_OFFSET];

            RgbaRearLeft.Distance = wkc_bytes[RGBA_REAR_LEFT_START_INDX + RGBA_PROX_OFFSET];
            RgbaRearLeft.Red = wkc_bytes[RGBA_REAR_LEFT_START_INDX + RGBA_RED_OFFSET];
            RgbaRearLeft.Green = wkc_bytes[RGBA_REAR_LEFT_START_INDX + RGBA_GREEN_OFFSET];
            RgbaRearLeft.Blue = wkc_bytes[RGBA_REAR_LEFT_START_INDX + RGBA_BLUE_OFFSET];


            //get bumper flags
            BumpRight = GetBitInByte(wkc_bytes[FLAGS_INDX], BUMP_RIGHT_BIT);
            BumpLeft = GetBitInByte(wkc_bytes[FLAGS_INDX], BUMP_LEFT_BIT);
            BumpFront = GetBitInByte(wkc_bytes[FLAGS_INDX], BUMP_FRONT_BIT);
            BumpRear = GetBitInByte(wkc_bytes[FLAGS_INDX], BUMP_REAR_BIT);


            BatLvl = wkc_bytes[BAT_LVL_INDX];
            BatChrgLvl = wkc_bytes[BAT_CHRG_LVL_INDX];

            //get user msg
            byte [] id_bytes = new byte[ID_SIZE];
            for (int i=0; i < ID_SIZE; i++)
            {
                id_bytes[i] = wkc_bytes[i + ID_START_INDX];
            }
            ID = Encoding.Default.GetString(id_bytes);
        }

        public bool getBitInByte(byte data_byte, int bit_indx)
        {
            return Convert.ToBoolean((data_byte >> bit_indx) & 1);
        }

        bool GetBitInByte(byte data_byte, byte bit_indx)
        {
            return Convert.ToBoolean((data_byte >> bit_indx) & 1); 
        }
    }
}
