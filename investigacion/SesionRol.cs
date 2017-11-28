using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigacion
{
    class SesionRol
    {
        private string value;
        private static SesionRol instance = null;

        private SesionRol() {
            value = "";
        }

        public void setValue(string input)
        {
            value = input;
        }

        public string getValue()
        {
            return value;
        }

        public static SesionRol GetInstance()
        {
            if (instance == null)
                instance = new SesionRol();

            return instance;
        }

        public void destroySesion()
        {
            instance = null;
        }
    }
}
