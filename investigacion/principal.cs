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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mongo m = new Mongo();
            m.insertarPartidoBasico("Panama", "USA", "306");
            m.insertarPartidoBasico("Australia", "Inglaterra", "307");
            m.insertarPartidoBasico("Italia", "Costa Rica", "308");
            m.insertarPartidoBasico("Nicaragua", "Colombia", "401");
            m.insertarPartidoBasico("Honduras", "Ecuador", "402");
            m.insertarPartidoBasico("Argentina", "Brasil", "403");
            m.insertarPartidoBasico("Chile", "Peru", "506");
            m.insertarPartidoBasico("Francia", "Alemania", "507");
            m.insertarPartidoBasico("Polonia", "Mexico", "508");

            new registrar().Show();
            this.Hide();
        }

        private void btnIngreasr_Click(object sender, EventArgs e)
        {
            new ingresar().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Ayuda().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Borrar().Show();
        }
    }
}
