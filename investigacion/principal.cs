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
    }
}
