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
    public partial class buscarPartido : Form
    {
        public buscarPartido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                string numeroPartido = textBox1.Text;
                Mongo mongo = new Mongo();
                SesionPartido sesionPartido = SesionPartido.GetInstance();
                sesionPartido.setValue(numeroPartido);
                mongo.getIdentificadorPartido(numeroPartido);
                new comentarioPartido().Show();
                this.Hide();
     
            
            
        }
    }
}
