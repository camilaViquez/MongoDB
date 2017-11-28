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
    public partial class Form1 : Form

    {
        
        Mongo mongo = new Mongo();
        

        public void a()
        {
            
            //mongo.insertarComentario(new Comentario("1", "2", "muy malo,me aburre", "0"));
            //mongo.insertarUsuario(new Usuario("123","bryan10919t@hotmail.com", true,"usuario"), "C:\\Users\\camil\\Desktop\\investigacion\\genji-cosplay.jpg");
            //mongo.insertarPartido(new Partido("Barcelona", "cartago","es obvio cual fue el resultado!!", 1),"C:\\Users\\camil\\Desktop\\investigacion\\30_Segundos_Con_Messi(youtube.com).mp4");
           List<string> a = new List<string>();
            a.Add("C:\\Users\\camil\\Desktop\\investigacion\\La vida Lionel Messi en 30 segundos.mp4");
            a.Add("C:\\Users\\camil\\Desktop\\investigacion\\30_Segundos_Con_Messi(youtube.com).mp4");
            mongo.insertarPartido(new Partido("equipo de Bryan2.0", "equipo de Parce1.0", "es obvio cual fue el resultado!!", "123"),a);
            
        }
        public Form1()
        {
            //InitializeComponent();
            new principal().Show();
            this.Hide();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(932, 522);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //a();
            prueba();
            new Partido("a","2","awd","ad").makeData();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void prueba() {
            //mongo.insertarPartido(new Partido("liga ", "cartago", "la liga es muy buena", 1));
            //mongo.insertarPartido(new Partido("saprissa ", "heredia", "cartago sigue sin ganar", 2));
            // mongo.insertarComentario(new Comentario("5a18b9990319cb1cd02cc6dd", "5a1993480319cb4dd08cd5dc", "uyyyyy prro que buena la liga :v", "0"));
            //   mongo.insertarComentario(new Comentario("5a18d8dd0319cb50bcf7512e", "5a1993480319cb4dd08cd5dd", "si mae , la liga es muy buena", "5a1995ad0319cb3840bc6b9e"));
            //mongo.insertarComentario(new Comentario("5a18d8dd0319cb50bcf7512e", "5a1993480319cb4dd08cd5dd", "comdmnaqnx", "5a1995ad0319cb3840bc6b9e"));
            // mongo.insertarComentario(new Comentario("5a18d8dd0319cb50bcf7512e", "5a1993480319cb4dd08cd5dd", "aoihjfa", "5a1995ad0319cb3840bc6b9e"));
            // mongo.insertarComentario(new Comentario("5a18d8dd0319cb50bcf7512e", "5a1993480319cb4dd08cd5dd", "auiusbhdyas", "5a1995ad0319cb3840bc6b9e"));

            /* Comentario c = mongo.getComentario("5a1995ad0319cb3840bc6b9e");
              Console.WriteLine(c.textoComentario + "\n");
              Console.WriteLine("comentarios de ese comentario" + "\n");
              for (int i = 0; i < c.respuestas.Count; i++) {
                  Console.WriteLine(c.respuestas[i].textoComentario+"\n");
              }
              */

            mongo.insertarComentario(new Comentario("5a1b2ec00319cb5700309b0f", "5a1b41c60319cb4f78685970", "uyyyyy prro que buena la liga :v", "0"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new principal().Show();

            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
