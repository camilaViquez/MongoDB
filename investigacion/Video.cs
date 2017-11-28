using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace investigacion
{
    [BsonIgnoreExtraElements]
    class Video
    {
        WindowsMediaPlayer a = new WindowsMediaPlayer();
        public ObjectId id { get; set; }
       
        public string videoGridFS { get; set; }
        public string idVideo { get; set; }
        public byte[] video { get; set; }
        
        

    }
}
