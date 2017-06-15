using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KremboControl.Network;

namespace KremboControl.Utils
{
    public class Krembo
    {
        public const int MAX_BASE_VEL = 255;
        public const int NEUTRAL_BASE_VEL = 127;
        public const int MIN_BASE_VEL = 0;
        public WKCKrembo2PC WKC;
        
        public Krembo(WKCKrembo2PC wkc_msg)
        {
            WKC = wkc_msg;
        }
        public override string ToString()
        {
            return KremboIdDict.Instance.IdToName(WKC.ID);
        }

        public static ushort ConvertToKremboVel(int min, int max, int val)
        {
            int old_range = (max - min);
            int new_range = (MAX_BASE_VEL - MIN_BASE_VEL);
            return (ushort)((((val - min) * new_range) / old_range) + MIN_BASE_VEL);
        }
    }
}
