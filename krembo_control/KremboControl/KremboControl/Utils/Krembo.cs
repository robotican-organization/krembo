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
        public const int PORT = 8000;
        public const int MOVE_LEFT_KEY = 37;
        public const int MOVE_RIGHT_KEY = 39;
        public const int MOVE_FORWARD_KEY = 38;
        public const int MOVE_BACKWARD_KEY = 40;
        public WKCKrembo2PC WkcIn;
        public WKCPC2Krembo WkcOut = new WKCPC2Krembo();
        
        public Krembo(WKCKrembo2PC wkc_msg)
        {
            WkcIn = wkc_msg;
        }
        public override string ToString()
        {
            return KremboIdDict.Instance.IdToName(WkcIn.ID);
        }

        public static ushort MapBaseToByteVel(float min, float max, float val)
        {
            return (ushort)((val - min) / (max - min) * (MAX_BASE_VEL - MIN_BASE_VEL) + MIN_BASE_VEL);
        }
    }
}
