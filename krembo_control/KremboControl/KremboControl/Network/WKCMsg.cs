using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KremboControl.Network
{
    public class WKCMsg
    {
        public const int MSG_SIZE = 1;
        public const int ID_INDX = 0;
        public UInt16 ID { get; private set; }

        public WKCMsg() { }
        public WKCMsg(byte [] wkc_msg)
        {
            toWKC(wkc_msg);
        }

        public void toWKC(byte []  wkc_bytes)
        {
            ID = wkc_bytes[ID_INDX];
        }

        public byte [] toBytes()
        {
            byte[] bytes_msg = new byte[MSG_SIZE];

            bytes_msg[ID_INDX] = (byte)ID;

            return bytes_msg;
        }
       
    }
}
