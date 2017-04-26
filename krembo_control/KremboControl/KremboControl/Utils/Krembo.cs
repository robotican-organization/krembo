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
        public WKCKrembo2PC krembo_wkc;
        
        public Krembo(WKCKrembo2PC wkc_msg)
        {
            krembo_wkc = wkc_msg;
        }
        public override string ToString()
        {
            return KremboIdDict.Instance.IdToName(krembo_wkc.ID);
        }
    }
}
