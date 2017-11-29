using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace investigacion
{
    public partial class comentarioPartido : Form
    {
        string rutaVideo = "";
        List<string> listaRutas = new List<string>();
        public comentarioPartido()
        {
            InitializeComponent();
            Mongo mongo = new Mongo();
            label4.Text = mongo.getIdentificadorPartido(SesionPartido.GetInstance().getValue()).equipo1;
            label5.Text = mongo.getIdentificadorPartido(SesionPartido.GetInstance().getValue()).equipo2;


        }

        private void comentarioPartido_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string comentario = textBox1.Text;
            

            Console.WriteLine("istance "+SesionPartido.GetInstance().getValue());

            Mongo mongo = new Mongo();

            //Comentario gg = new Comentario();

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mongo mongo = new Mongo();
            
            Stream myStream = null;
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = "c:\\";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;


            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog2.OpenFile()) != null)
                    {
                        using (myStream)

                        {
                            rutaVideo = openFileDialog2.FileName;
                            listaRutas.Add(rutaVideo);
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
		     MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string a in listaRutas)
            {
                listBox1.Items.Add(a);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
