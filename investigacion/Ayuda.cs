using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace investigacion
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
            cargarManual();
        }

        private void cargarManual()
        {
            PDF.src = @"C:\Users\camil\source\repos\investigacion\manual_de_usuario_resumen_de_los_partidos.pdf";
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
