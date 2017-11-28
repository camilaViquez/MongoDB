using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;

namespace investigacion
{
    [BsonIgnoreExtraElements]
    class Usuario
    {
        public ObjectId id { get; set; }
        public string contrasena { get; set; }
        public string mail { get; set; }
        public Imagen imagen { get; set; }
        public string rol { get; set; }
        public Bitmap imag { get; set; }
        public bool disponible { get; set; }

        public Usuario(string contrasena,string mail,bool disponible,string rol) {

            this.contrasena = contrasena;
            this.mail = mail;
            this.disponible = disponible;
            this.rol = rol;

        }

    }
}
