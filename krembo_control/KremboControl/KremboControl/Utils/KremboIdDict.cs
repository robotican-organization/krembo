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
