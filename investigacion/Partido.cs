using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.IO;

namespace investigacion
{
    [BsonIgnoreExtraElements]
    class Partido
    {

        
        public ObjectId id { get; set; }

        public string identificador { get; set; }
        public string equipo1 { get; set; }
        public string equipo2 { get; set; }
        public List<Comentario> comentarios { get; set; }
        public List<Video> videos { get; set; }
        public string resumen { get; set; }


        public Partido(string equipo1, string equipo2, string resumen,string identificador) {
            this.equipo1 = equipo1;
            this.equipo2 = equipo2;
            this.resumen = resumen;
            this.identificador = identificador;
            //this.comentarios = new List<Comentario>();
        }


        public void makeData() {
            System.IO.DirectoryInfo di = new DirectoryInfo(@"C:\Users\camil\source\repos\investigacion\investigacion\bin\Debug\videos");
            int entro = 0;
            foreach (FileInfo file in di.GetFiles())
            {
                entro = 1;
                //file.Delete();
            }
            if (entro == 0) { 
                for (int i = 0; i < videos.Count(); i++) {
                    string text = @"C:\Users\camil\source\repos\investigacion\investigacion\bin\Debug\videos\" + i + ".txt";
                        string a = "";
                    File.WriteAllBytes(text, videos[i].video);
                }
            }


        }

        public string getVideo(int pos) {

            return @"C:\Users\camil\source\repos\investigacion\investigacion\bin\Debug\videos\" + pos + ".txt";
        }

    }
}
