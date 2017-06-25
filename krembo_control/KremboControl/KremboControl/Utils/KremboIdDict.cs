using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KremboControl.Utils
{
    public sealed class KremboIdDict
    {
    
        private static KremboIdDict instance = null;
        private static readonly object padlock = new object();
        private Dictionary<string, string> id_dict = new Dictionary<string, string>();

        private KremboIdDict()
        {
            loadIdDict();
        }

        public static KremboIdDict Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new KremboIdDict();
                    }
                    return instance;
                }
            }
        }
    

        private void loadIdDict()
        {
            id_dict.Add("5c003a000a51353531343431", "Krembo1");
            id_dict.Add("310031000851353531343431", "krembo2");
            id_dict.Add("470052001451353432393433", "Krembo3");
            id_dict.Add("3a0041000747323232383439", "Krembo4");
            id_dict.Add("3a0037000d51353532343635", "Krembo5");
            id_dict.Add("260029000b51353432383931", "Krembo6");
            id_dict.Add("540038000d51353432383931", "Krembo7");
            id_dict.Add("50002f000e51353532343635", "Krembo8");
            id_dict.Add("1f0034000d51353432383931", "Krembo9");
            id_dict.Add("43001f001051353532343635", "Krembo10");
            id_dict.Add("400059000f51353532343635", "Krembo11");
        }

        public string IdToName(string id)
        {
            string name;
            if (!id_dict.TryGetValue(id, out name))
                return "null";  // the key isn't in the dictionary.
            return name;
        }

    }
}
