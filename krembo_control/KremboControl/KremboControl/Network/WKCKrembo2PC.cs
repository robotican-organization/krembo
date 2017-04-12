using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**************************************************************************
 * |------------------- N BYTES ARRAY -------------
 * |  0  |1 (8 BITS FLAGS) |   2    |      3      |
 * |  ID |   BC   |   BF   |   BL   |    BCL%     |
 * |0-255|  0-1   |  0-1   | 0-100  |   0-100     |
 * |----------------------------------------------|
 * ID = This Krembo ID
 * BC = Battery Charging = flage indicates whether battery is being charged
 * BF = Battery Full = flage indicates whether battery is Full
 * BL = Battery Level %
 * BCL = Battery Charging Level % = current level from charger
 **************************************************************************/

namespace KremboControl.Network
{
    public class WKCKrembo2PC
    {
        public const int MSG_SIZE = 4;

        public const int ID_INDX = 0;
        public const int FLAGS_INDX = 1;
        public const int BAT_LVL_INDX = 2;
        public const int BAT_CHRG_LVL_INDX = 3;

        public UInt16 ID { get; private set; }
        public UInt16 BatLvl { get; private set; }
        public UInt16 BatChrgLvl { get; private set; }

        public WKCKrembo2PC() { }
        public WKCKrembo2PC(byte [] wkc_msg)
        {
            toWKC(wkc_msg);
        }

        public void toWKC(byte []  wkc_bytes)
        {
            ID = wkc_bytes[ID_INDX];
            BatLvl = wkc_bytes[BAT_LVL_INDX];
            BatChrgLvl = wkc_bytes[BAT_CHRG_LVL_INDX];
        }

        public bool getBitInByte(byte data_byte, int bit_indx)
        {
            return Convert.ToBoolean((data_byte >> bit_indx) & 1);
        }
    }
}
