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
        public const int MAX_BYTE_VEL = 255;
        public const int NEUTRAL_BYTE_VEL = 127;
        public const int MIN_BYTE_VEL = 0;
        public const int MAX_BASE_VEL = 100;
        public const int MIN_BASE_VEL = -100;
        public const int PORT = 8000;
        public WKCKrembo2PC WkcIn;
        public WKCPC2Krembo WkcOut = new WKCPC2Krembo();
        
        public Krembo(WKCKrembo2PC wkc_msg)
        {
            WkcIn = wkc_msg;
        }
        public override string ToString()
        {
            return MyName();
        }

        public string MyName()
        {
            return KremboIdDict.Instance.IdToName(WkcIn.ID);
        }

        public static ushort MapBaseToByteVel(float val)
        {
            return (ushort)((float)(val - MIN_BASE_VEL) / (float)(MAX_BASE_VEL - MIN_BASE_VEL) * 
                           (float)(MAX_BYTE_VEL - MIN_BYTE_VEL) + MIN_BYTE_VEL);
        }

        public static float MapByteToBaseVel(ushort val)
        {
            float a = (float)(val - MIN_BYTE_VEL) / (float)(MAX_BYTE_VEL - MIN_BYTE_VEL) *
                   (float)(MAX_BASE_VEL - MIN_BASE_VEL) + MIN_BASE_VEL;
            return a;
        }
    }
}
