using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KremboControl.Network;

namespace KremboControl.Utils
{
    class Krembo
    {
        public WKCKrembo2PC krembo_wkc;

        public Krembo(WKCKrembo2PC wkc_msg)
        {
            krembo_wkc = wkc_msg;
        }
        public override string ToString()
        {
            return String.Format("Krembo{0}", krembo_wkc.ID);
        }
    }
}
