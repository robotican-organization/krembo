using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//package from krembo to pc
//WKC - wireless krembo communication protocol

/**************************************************************************
 * |--------------------- N BYTES ARRAY ------------------|
 * |       0 (8 BITS FLAGS)        |   1    |   2   |3-27 |
 * |   |   |FB |REB|LB |RIB|BC |BF |   BL   |  BCL% | ID  |
 * |0-1|0-1|0-1|0-1|0-1|0-1|0-1|0-1| 0-100  | 0-100 |0-255|
 * |------------------------------------------------------|
 * ID = 24 bytes of Photon string id in bytes
 *
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full
 * FB = Front Bumper = flag indicates whether bumper was pressed
 * RIB = Right Bumper = flag indicates whether bumper was pressed
 * REB = Rear Bumper = flag indicates whether bumper was pressed
 * RB = Right Bumper = flag indicates whether bumper was pressed
 * LB = Left Bumper = flag indicates whether bumper was pressed
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger
 **************************************************************************/

namespace KremboControl.Network
{
    public class WKCKrembo2PC
    {
        public const int ID_SIZE = 24;
        public const int MSG_SIZE = 3 + ID_SIZE;

        public const int FLAGS_INDX = 0;
            public const int BAT_FULL_BIT = 0;
            public const int BAT_CHARGING_BIT = 1;
            public const int BUMP_RIGHT_BIT = 2;
            public const int BUMP_LEFT_BIT = 3;
            public const int BUMP_REAR_BIT = 4;
            public const int BUMP_FRONT_BIT = 5;
        public const int BAT_LVL_INDX = 1;
        public const int BAT_CHRG_LVL_INDX = 2;
        public const int ID_START_INDX = 3;        

        public String ID { get; private set; }
        public UInt16 BatLvl { get; private set; }
        public UInt16 BatChrgLvl { get; private set; }
        public bool IsBatCharging,
                    IsBatFull,
                    BumpFront,
                    BumpRear,
                    BumpRight,
                    BumpLeft;


        public WKCKrembo2PC() { }
        public WKCKrembo2PC(byte [] wkc_msg)
        {
            toWKC(wkc_msg);
        }

        public void toWKC(byte []  wkc_bytes)
        {
            //get flags values
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
