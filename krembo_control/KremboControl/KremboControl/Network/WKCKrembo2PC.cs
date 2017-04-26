using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**************************************************************************
 * |------------------------- N BYTES ARRAY -------------------|
 * |0 (8 BITS FLAGS) |   1    |      2      |  3  |  4 - 4+IDL |
 * |   BC   |   BF   |   BL   |    BCL%     | IDL |    ID      |
 * |  0-1   |  0-1   | 0-100  |   0-100     |0-255|  ID bytes  |
 * |-----------------------------------------------------------|
 * IDL = ID size
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
        public const int ID_SIZE = 24;
        public const int MSG_SIZE = 3 + ID_SIZE;

        public const int FLAGS_INDX = 0;
        public const int BAT_LVL_INDX = 1;
        public const int BAT_CHRG_LVL_INDX = 2;
        public const int ID_START_INDX = 3;        

        public String ID { get; private set; }
        public UInt16 BatLvl { get; private set; }
        public UInt16 BatChrgLvl { get; private set; }

        public WKCKrembo2PC() { }
        public WKCKrembo2PC(byte [] wkc_msg)
        {
            toWKC(wkc_msg);
        }

        public void toWKC(byte []  wkc_bytes)
        {
            BatLvl = wkc_bytes[BAT_LVL_INDX];
            BatChrgLvl = wkc_bytes[BAT_CHRG_LVL_INDX];
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
    }
}
