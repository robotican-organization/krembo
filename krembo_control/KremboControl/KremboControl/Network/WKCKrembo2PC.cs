using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/***********************
 * |------------------- N BYTES ARRAY
 * |  0  |   1    |      2      |3 (8 BITS FLAGS) |
 * |  ID |BAT LVL%|BAT CHRG LVL%|BAT CHRG|BAT FULL|
 * |0-255| 0-255  |   0-255     |    0-1 |   0-1  |
 **********************/

namespace KremboControl.Network
{
    public class WKCKrembo2PC
    {
        public const int MSG_SIZE = 3;
        public const int ID_INDX = 0;
        public const int BAT_LVL_INDX = 1;
        public const int BAT_CHRG_LVL_INDX = 2;

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
    }
}
