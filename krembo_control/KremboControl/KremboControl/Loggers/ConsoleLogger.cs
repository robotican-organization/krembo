using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KremboControl.Utils
{
    static class ConsoleLogger
    {
        public static void write(string name, string msg)
        {
            var curr_time = DateTime.Now.ToString();
            Console.WriteLine("[{0}][{1}]: {2}", curr_time, name, msg);
        }

        public static void write(string name, string msg, bool is_debug_mode)
        {
            if (is_debug_mode)
                write(name, msg);
        }

    }
}
