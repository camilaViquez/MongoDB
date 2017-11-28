using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;

namespace investigacion { 

    [BsonIgnoreExtraElements]
    class Imagen
    {
        public ObjectId imagId { get; set; }
        public string imageGridFS { get; set; }
        public string idmagen { get; set; }
        public Bitmap Image { get; set; }
}
}
