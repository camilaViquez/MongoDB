using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace investigacion
{
    [BsonIgnoreExtraElements]
    class Comentario
    {
        public ObjectId id { get; set; }
        public string idUsuario { get; set; }
        public string idPartido { get; set; }
        public string textoComentario{ get; set; }
        public string idReferencia { get; set; }

        public List<Comentario> respuestas { set; get; }
        public DateTime fechaHora { get; set; }

        public Comentario(string idUsuario, string idPartido, string textoComentario,string idReferencia) {
            this.idUsuario = idUsuario;
            this.idPartido = idPartido;
            this.textoComentario = textoComentario;
            this.idReferencia = idReferencia;
            //this.respuestas = new List<Comentario>();
            //this.fechaHora = DateTime.Now;
        }

    }
}
