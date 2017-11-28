using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigacion
{
    class SesionPartido
    {
        private string value;
        private static SesionPartido instance = null;

        private SesionPartido() {
            value = "";
        }

        public void setValue(string input) {
            value = input;
        }

        public string getValue() {
            return value;
        }

        public static SesionPartido GetInstance()
        {
            if (instance == null)
                instance = new SesionPartido();

            return instance;
        }

        public void destroySesion()
        {
            instance = null;
        }
    }
}
