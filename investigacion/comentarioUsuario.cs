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
//SesionPartido sesionPartido = SesionPartido.GetInstance();
namespace investigacion
{
    public partial class comentarioUsuario : Form
    {
        string rutaVideo = "";
        List<string> listaRutas = new List<string>();

        public comentarioUsuario()
        {
            InitializeComponent();

            List<Button> btnFotoL = new List<Button>();
            List<Button> btnCorreoL = new List<Button>();

            Mongo mongo = new Mongo();
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = mongo.getUsuarios();
            int x = 0;
            int z = 50;
            int y = 12;
            int n = 0;
            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add("\t" + "\t" + "  " + usuario.id + "\n" + "\n");
                Button fotoBtn = new Button();
                fotoBtn.Name = usuario.id.ToString();
                fotoBtn.Click += new EventHandler(mostrarFoto);
                Button correoBtn = new Button();
                correoBtn.Name = usuario.id.ToString();
                correoBtn.Click += new EventHandler(mostrarCorreo);
                fotoBtn.Text = ("Foto");
                correoBtn.Text = ("Correo");
                fotoBtn.SetBounds(x, y * n, 50, 20);
                correoBtn.SetBounds(z, y * n, 50, 20);
                btnCorreoL.Add(correoBtn);
                btnFotoL.Add(fotoBtn);
                n++;
            }
            foreach (Button a in btnFotoL)
            {
                listBox1.Controls.Add(a);
                listBox1.Items.Add("\n");
                Console.WriteLine(x);
                Console.WriteLine(y);

            }
            foreach (Button a in btnCorreoL)
            {
                listBox1.Controls.Add(a);
                listBox1.Items.Add("\n");
                Console.WriteLine(x);
                Console.WriteLine(y);

            }
            Usuario ff = mongo.getUsuario(SesionID.GetInstance().getValue());
            if (ff.rol == "administrador")
            {
                button2.Enabled = true;
                button2.Visible = true;
                button4.Enabled = true;
                button4.Visible = true;
                textBox2.Enabled = true;
                textBox4.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = false;
                button2.Visible = false;
                button4.Enabled = false;
                button4.Visible = false;
            }

        }

        private void mostrarFoto(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Mongo mongo = new Mongo();
            Usuario usuario = mongo.getUsuario(btn.Name);
            List<Comentario> comentario = new List<Comentario>();
            comentario = mongo.getComentariosUruario(btn.Name);
            using (Form form = new Form())
            {
                form.Text = "Información del usuario";
                form.SetBounds(0,0,600,600);
                Label foto = new Label();
                ListBox comen = new ListBox();
                comen.Text = comentario.ToString();
                foto.SetBounds(0, 0, 200, 200);
                foto.Image = usuario.imagen.Image;
                form.Controls.Add(foto);
                comen.SetBounds(0, 200, 400, 400);
                

                foreach (Comentario c in comentario)
                {
                    comen.Items.Add(c.textoComentario);
                    

                }
                form.Controls.Add(comen);

                form.ShowDialog();
            }

        }
        private void mostrarCorreo(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Mongo mongo = new Mongo();
            string correo = mongo.getUsuario(btn.Name).mail;
            MessageBox.Show(correo);
        }
        private void button4_Click(object sender, EventArgs e)
        {
             Mongo mongo = new Mongo();
             
             string resumen = textBox2.Text;
             string idPartido = textBox1.Text;
             //Partido partido = new Partido(eq1, eq2, resumen, idPartido);
             // mongo.insertarPartido(partido, listaRutas);
             mongo.updatePartido(idPartido, resumen, listaRutas);
             listaRutas.Clear();


        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            string seleccion = senderComboBox.SelectedItem.ToString();
            //axWindowsMediaPlayer1.URL = mongo.getPartido("5a1b076d0319cb23fcdddba2").getVideo(0);
            //axWindowsMediaPlayer1.URL = 

        }

        private void button5_Click(object sender, EventArgs e)
        {

            System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Users\camil\source\repos\investigacion\investigacion\bin\Debug\videos");
            
            foreach (FileInfo file in di.GetFiles())
            {
              
                file.Delete();
            }

            Mongo mongo = new Mongo();
            try
            {
                Usuario usuario = mongo.getUsuario(SesionID.GetInstance().getValue());
                string seleccionado = textBox1.Text;
                string eq1 = mongo.getIdentificadorPartido(seleccionado).equipo1;
                string eq2 = mongo.getIdentificadorPartido(seleccionado).equipo2;
                label4.Text = (eq1 + " vs " + eq2);
                string a = mongo.getIdentificadorPartido(seleccionado).resumen;
                Console.WriteLine("soy a " + a);
                textBox2.Text = (a);

            
            

            

            //Label lab = new Label();
            //lab.Text = "hola";
            //groupBox2.Controls.Add(lab);

            //Comentarios//Lista de comentarios
            List<TextBox> comments = new List<TextBox>();
            //Lista de respuestas
            List<TextBox> replys = new List<TextBox>();
            //Lista de labels con las respectivas respuestas
            List<TextBox> reply = new List<TextBox>();
            //Cantidad de elementos insertados en comentarios
            var elemcant = 0;

            //Agrega comentarios

            Partido gg = mongo.getIdentificadorPartido(seleccionado);
            /*Partido gg = new Partido("saprissa ", "heredia", "cartago sigue sin ganar", "2");
            gg.comentarios.Add(new Comentario("1", "2", "Me llamo Parce", "0"));
            gg.comentarios.Add(new Comentario("2", "2", "Me llamo Cami", "0"));
            gg.comentarios.Add(new Comentario("3", "2", "Me llamo Bryan", "0"));
            gg.comentarios[0].respuestas.Add(new Comentario("2", "2", "Hola Parce", "0"));
            gg.comentarios[0].respuestas.Add(new Comentario("2", "2", "Hola Parce", "0"));
            gg.comentarios[1].respuestas.Add(new Comentario("2", "2", "Hola Cami", "0"));
            gg.comentarios[2].respuestas.Add(new Comentario("2", "2", "Hola Bryan", "0"));
            gg.comentarios[2].respuestas.Add(new Comentario("2", "2", "Hola BryanX2", "0"));
            gg.comentarios[2].respuestas.Add(new Comentario("2", "2", "Hola BryanX3", "0"));
            gg.comentarios[2].respuestas.Add(new Comentario("2", "2", "Hola BryanX4 :V", "0"));
            */

            var myPlayList = axWindowsMediaPlayer1.playlistCollection.newPlaylist("pl1");
            string aa = "";
            for (int i = 0; i < gg.videos.Count();i++) {
                aa = gg.getVideo(i);
                myPlayList.appendItem(axWindowsMediaPlayer1.newMedia(gg.getVideo(i)));
            }


            axWindowsMediaPlayer1.currentPlaylist = myPlayList;
            //axWindowsMediaPlayer1.URL = aa;

            for (int i = 0; i < gg.comentarios.Count(); i++)
            {
                //Agrega comentarios principales
                //Posicion correspodiente al comentario
                var posy = 20 + elemcant * 70 - replys.Count() * 20;
                //Texto del comentario
                TextBox newTextBox = new TextBox();
                newTextBox.Enabled = false;
                newTextBox.BackColor = Color.DarkGray;
                newTextBox.SetBounds(50, posy + 15, 350, 20);
                newTextBox.Text = "Comment " + i + ": " + gg.comentarios[i].textoComentario;
                comments.Add(newTextBox);
                groupBox2.Controls.Add(newTextBox);
                //Fecha
                Label fecha = new Label();
                fecha.AutoSize = false;
                fecha.TextAlign = ContentAlignment.MiddleRight;
                fecha.Text = "Date: " + gg.comentarios[i].fechaHora;
                fecha.SetBounds(250, posy, 150, 15);
                fecha.Enabled = false;
                groupBox2.Controls.Add(fecha);
                //Correo del comentario
                TextBox mail = new TextBox();
                mail.AutoSize = false;
                if( usuario.disponible != false)
                {
                    mail.Text = mongo.getUsuario(gg.comentarios[i].idUsuario).mail;
                    mail.Enabled = false;
                    mail.SetBounds(50, posy, 350, 15);
                    groupBox2.Controls.Add(mail);

                }
                else
                {
                    mail.Text = "BORRADO";
                    mail.Enabled = false;
                    mail.SetBounds(50, posy, 350, 15);
                    groupBox2.Controls.Add(mail);
                }
                
                //Agrega repuestas
                for (var j = 0; j < gg.comentarios[i].respuestas.Count(); j++)
                {
                    elemcant += 1;
                    //Posion de la respuesta
                    posy = 20 + elemcant * 70 - replys.Count() * 20;
                    //Texto de la respuesta
                    TextBox replyn = new TextBox();
                    replyn.BackColor = Color.LightGray;
                    replyn.SetBounds(100, posy + 15, 300, 20);
                    replyn.Enabled = false;
                    replyn.Text = "Reply " + j + ": " + gg.comentarios[i].respuestas[j].textoComentario;
                    replys.Add(replyn);
                    groupBox2.Controls.Add(replyn);
                    //Fecha
                    Label fechaRespuesta = new Label();
                    fechaRespuesta.AutoSize = false;
                    fechaRespuesta.TextAlign = ContentAlignment.MiddleRight;
                    fechaRespuesta.Text = "Date: " + gg.comentarios[i].respuestas[j].fechaHora;
                    fechaRespuesta.SetBounds(250, posy, 150, 15);
                    fechaRespuesta.Enabled = false;
                    groupBox2.Controls.Add(fechaRespuesta);
                    //Correo de respuesta
                    TextBox mailReply = new TextBox();
                    mailReply.AutoSize = false;
                    mailReply.Text = mongo.getUsuario(gg.comentarios[i].respuestas[j].idUsuario).mail;
                    mailReply.Enabled = false;
                    mailReply.SetBounds(100, posy, 300, 15);
                    groupBox2.Controls.Add(mailReply);
                }
                elemcant += 1;
            }

            //Cantidad de comentarios principales
            var cant = comments.Count();
            for (int i = 0; i < cant; i++)
            {
                var posy = comments[i].Bounds.Y;
                TextBox newTextBox = new TextBox();
                newTextBox.SetBounds(50, posy + 25, 240, 20);
                newTextBox.Text = "Reply " + i.ToString();
                reply.Add(newTextBox);
                groupBox2.Controls.Add(newTextBox);
            }

            //Boton para comentar
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < cant; i++)
            {
                var posy = reply[i].Bounds.Y;
                Button newButton = new Button();
                newButton.Click += new EventHandler(Action);
                newButton.BackColor = Color.LightSalmon;
                newButton.SetBounds(300, posy, 100, 20);
                newButton.Text = "Responder";
                newButton.Name = i.ToString();
                buttons.Add(newButton);
                groupBox2.Controls.Add(newButton);
            }

            //Accion del boton responder
            void Action(object send, EventArgs f)
            {
                Button b = send as Button;
                Console.WriteLine("asdasdasdasd" + b.Name);
                mongo.insertarComentario(new Comentario(SesionID.GetInstance().getValue().ToString(), gg.id.ToString(), reply[Int32.Parse(b.Name)].Text, gg.comentarios[Int32.Parse(b.Name)].id.ToString()));
                int c = groupBox2.Controls.Count;
                for (int i = c - 1; i >= 0; i--)
                    groupBox2.Controls.Remove(groupBox2.Controls[i]);
                button5_Click(sender, e);


            }
            }
            catch
            {
                MessageBox.Show("debe ingresar un id Partido valido");
            }


        }

        private void comentarioUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string comentario = textBox4.Text;
            Mongo mongo = new Mongo();
            mongo.insertarComentario(new Comentario(SesionID.GetInstance().getValue().ToString(), mongo.getIdentificadorPartido(textBox1.Text).id.ToString(), comentario, "0"));
            button5_Click(sender, e);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
                }
                
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new principal().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}


/*
 * List<Partido> partidos = new List<Partido>();
            partidos = mongo.getPartidos();
            foreach (Partido a in partidos)
            {
                comboBox1.Items.Add(a.equipo1+" vs "+a.equipo2);
            }
            */