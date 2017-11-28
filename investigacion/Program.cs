using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace investigacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new principal());
            string pass = "1";

            Console.WriteLine("la weona encriptada: " + Hash.Encrypt(pass));
            Console.WriteLine("la weona: " + Hash.Decrypt(Hash.Encrypt(pass)));
        }
    }
}
