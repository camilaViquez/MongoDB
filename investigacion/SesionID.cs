using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace investigacion
{
    class SesionID
    {
        private String value;
        private static SesionID instance = null;

        private SesionID() {
            value = "";
        }

        public void setValue(String input)
        {
            value = input;
        }

        public String getValue()
        {
            return value;
        }
        public static SesionID GetInstance()
        {
            if (instance == null)
                instance = new SesionID();

            return instance;
        }

        public void destroySesion() {
            instance = null;
        }
    }
}
