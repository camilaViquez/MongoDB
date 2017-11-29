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
    public partial class registrar : Form
    {
        string ruta = "";
        public registrar()
        {
            InitializeComponent();
            comboBox1.Items.Insert(0, "usuario");
            comboBox1.Items.Insert(1, "administrador");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)

                        {
                            ruta = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void registrar_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text;
            string contrasena = textBox2.Text;

            //Se encripta la contrasena
            string hashPass = Hash.Encrypt(contrasena);
            
            
            Mongo mongo = new Mongo();
            Console.WriteLine(ruta);
            
            mongo.insertarUsuario(new Usuario(hashPass,correo,true,comboBox1.Text),ruta);
            


        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new principal().Show();
            this.Hide();
        }
    }
}
