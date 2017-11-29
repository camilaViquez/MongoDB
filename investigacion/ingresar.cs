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
    public partial class ingresar : Form
    {
        public ingresar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rol;
            string correo = textBox1.Text;
            string contrasena = textBox2.Text;
            Mongo mongo = new Mongo();
            Usuario gg = mongo.getUsuarioPorCorreo(correo);
            if (Hash.Decrypt(gg.contrasena) == contrasena) {
                rol = gg.rol;
                //new buscarPartido().Show(); este es para crear resumen seguro desaparece
                
                SesionID.GetInstance().setValue(gg.id.ToString());

                new comentarioUsuario().Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new principal().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
