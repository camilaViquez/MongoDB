using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace investigacion
{
    class Mongo
    {

        public string connectionString { get; set; }
        public string databaseName { get; set; }
        public string collectionName { get; set; }
        private MongoClient mongoClient;
        private MongoServer mongoServer;
        private MongoDatabase dataBase;

        public Mongo()
        {

            connectionString = "mongodb://localhost:27017";
            databaseName = "Campeonato";

            try
            {
                mongoClient = new MongoClient(connectionString);
                mongoServer = mongoClient.GetServer();
                dataBase = mongoServer.GetDatabase(databaseName);
            }
            catch (Exception e)
            {
                throw new Exception("Can not access to db server.", e);
            }
        }

        public Partido insertarPartido(Partido partido,List<string> urlVideo) {

            var tempPartido = new BsonDocument
                {
                    {"equipo1",partido.equipo1 },
                    {"equipo2" ,partido.equipo2},
                    {"resumen" ,partido.resumen},
                    {"identificador",partido.identificador}
                };

            dataBase.GetCollection<Partido>("Partido").Insert(tempPartido);
            string idSTring = tempPartido["_id"].ToString();

            Partido temp = new Partido(partido.equipo1,partido.equipo2,partido.resumen,partido.identificador);
            temp.id = new ObjectId(idSTring);


            for (int i = 0; i < urlVideo.Count(); i++) {
                string idVideo = saveVideo(urlVideo[i]);

                var tempVideo = new BsonDocument
                {
                    { "videoGridFS",idVideo},
                    { "idVideo",idSTring }

                };
                addVideo(tempVideo);
            }

            

            return temp;
        }

        public void updatePartido(string identificador,string resumen,List<string>urlVideo) {

            var coleccion = dataBase.GetCollection<Partido>("Partido");
            var query = Query.EQ("identificador", identificador);

            Partido temp = coleccion.FindOne(query);

            var update = Update.Set("resumen", resumen);
            coleccion.Update(query, update);


            for (int i = 0; i < urlVideo.Count(); i++)
            {
                string idVideo = saveVideo(urlVideo[i]);

                var tempVideo = new BsonDocument
                {
                    { "videoGridFS",idVideo},
                    { "idVideo",temp.id.ToString() }

                };
                addVideo(tempVideo);
            }


        }


        public void insertarPartidoBasico(string equipo1,string equipo2,string identificador) {

            var tempPartido = new BsonDocument
                {
                    {"equipo1",equipo1 },
                    {"equipo2" ,equipo2},
                    {"resumen" ,""},
                    {"identificador",identificador}
                };

            dataBase.GetCollection<Partido>("Partido").Insert(tempPartido);

        }



        public Partido getPartido(string id) {

            var query = Query.EQ("_id", new ObjectId(id));
            MongoCollection<Partido> collection = dataBase.GetCollection<Partido>("Partido");
            Partido tempPartdio = collection.FindOne(query);

            tempPartdio.videos = getVid(id);

            for (int i = 0; i < tempPartdio.videos.Count(); i++) {
                tempPartdio.videos[i].video=getVideo(tempPartdio.videos[i].videoGridFS);
            }

            tempPartdio.comentarios = getRespuestaComentario(id);
            tempPartdio.makeData();
            //tempPartdio.video.video = getVideo(tempPartdio.video.videoGridFS);
            //string a=tempPartdio.video.videoGridFS;
            return tempPartdio;

        }

        public Comentario insertarComentario(Comentario comentario) {

            var tempComentario = new BsonDocument
                {
                    {"idUsuario",comentario.idUsuario },
                    {"idPartido" ,comentario.idPartido},
                    {"textoComentario" ,comentario.textoComentario},
                    {"idReferencia",comentario.idReferencia},
                    {"fechaHora",DateTime.Now }
                };


            dataBase.GetCollection<Comentario>("comentario").Insert(tempComentario);
            string idSTring = tempComentario["_id"].ToString();

            Comentario temp = new Comentario(comentario.idUsuario, comentario.idPartido, comentario.idUsuario,comentario.idReferencia);
            temp.fechaHora = DateTime.Now;
            temp.id = new ObjectId(idSTring);

            return temp;

        }

        public Usuario insertarUsuario(Usuario usuario,string rutaImagen) {

            var tempUsuario = new BsonDocument
                {
                    {"contrasena",usuario.contrasena },
                    {"disponible" ,usuario.disponible},
                    {"mail",usuario.mail },
                    {"rol",usuario.rol }
                };

            dataBase.GetCollection<Usuario>("Usuario").Insert(tempUsuario);
            string idSTring = tempUsuario["_id"].ToString();

            string idImagen = saveImagen(rutaImagen);

            var tempImage = new BsonDocument
                {
                    { "imageGridFS",idImagen},
                    { "idmagen",idSTring }

                };
            addImage(tempImage);

            Usuario temp = new Usuario(usuario.contrasena, usuario.mail, usuario.disponible,usuario.rol);
            temp.id= new ObjectId(idSTring);

            return temp;


        }

        public Usuario getUsuario(string id) {

            var query = Query.EQ("_id", new ObjectId(id));
            MongoCollection<Usuario> collection = dataBase.GetCollection<Usuario>("Usuario");
            Usuario temp = collection.FindOne(query);
            temp.imagen = getImage(id);
            temp.imagen.Image = getImagen(temp.imagen.imageGridFS);
            return temp;


        }

        public Comentario getComentario(string id) {

            var query = Query.EQ("_id", new ObjectId(id));
            MongoCollection<Comentario> collection = dataBase.GetCollection<Comentario>("comentario");
            Comentario temp = collection.FindOne(query);
            temp.respuestas = getRespuestaComentario(temp.id.ToString());
            return temp;

        }

        public Partido getIdentificadorPartido(string identificador)
        {

            var query = Query.EQ("identificador", identificador);
            MongoCollection<Partido> collection = dataBase.GetCollection<Partido>("Partido");
            Partido tempPartdio = collection.FindOne(query);

            tempPartdio.videos = getVid(tempPartdio.id.ToString());

            for (int i = 0; i < tempPartdio.videos.Count(); i++)
            {
                tempPartdio.videos[i].video = getVideo(tempPartdio.videos[i].videoGridFS);
            }
            tempPartdio.comentarios = getComentariosPartido(tempPartdio.id.ToString());
            tempPartdio.makeData();

          
            
           

            return tempPartdio;




        }



        public List<Comentario> getRespuestaComentario(string idReferencia) {

            MongoCollection<Comentario> collection = dataBase.GetCollection<Comentario>("comentario");
            var query = Query.EQ("idReferencia", idReferencia);
            List<Comentario> comentarios = collection.Find(query).ToList();

            return comentarios;
        }

        public List<Comentario> getComentariosUruario(string id)
        {
            MongoCollection<Comentario> collection = dataBase.GetCollection<Comentario>("comentario");
            var query = Query.EQ("idUsuario", id);
            List<Comentario> comentariosUsuario = collection.Find(query).ToList();

            for (int i = 0; i < comentariosUsuario.Count(); i++) {
                comentariosUsuario[i].respuestas = getRespuestaComentario(comentariosUsuario[i].id.ToString());
            }

            return comentariosUsuario;

        }

        public List<Comentario> getComentariosPartido(string idPartido) {

            MongoCollection<Comentario> collection = dataBase.GetCollection<Comentario>("comentario");
            var query = Query.EQ("idPartido", idPartido);
            List<Comentario> comentariosPartido = collection.Find(query).ToList();

            List<Comentario> temp = new List<Comentario>();
            foreach (Comentario c in comentariosPartido) {
                if (c.idReferencia == "0") {
                    temp.Add(c);
                }
            }

            for (int i = 0; i < temp.Count(); i++)
            {
                temp[i].respuestas = getRespuestaComentario(temp[i].id.ToString());
            }

            return temp;
        } 


        public void addImage(BsonDocument imag)
        {
            dataBase.GetCollection<Imagen>("Imagen").Insert(imag);
        }

        public void addVideo(BsonDocument video)
        {
            dataBase.GetCollection<Video>("videos").Insert(video);
        }

        public Imagen getImage(string id)
        {
            var query = Query.EQ("idmagen", id);
            MongoCollection<Imagen> collection = dataBase.GetCollection<Imagen>("Imagen");
            Imagen temp = collection.FindOne(query);

            return temp;
        }



        public List<Video> getVid(string id) {
            var query = Query.EQ("idVideo", id);
            MongoCollection<Video> collection = dataBase.GetCollection<Video>("videos");
            List<Video> temp = collection.Find(query).ToList();
            return temp;
        }

        public Bitmap getImagen(string idImagen)
        {

            var fileID = new ObjectId(idImagen);
            var file = dataBase.GridFS.FindOneById(fileID);
            string temp;

            Bitmap imag;

            using (var fs = file.OpenRead())
            {

                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                var stream = new MemoryStream(bytes);
                temp = "data:Image/png;base64," + Convert.ToBase64String(bytes); ;
                //imagen = "data:Image/png;base64," + Convert.ToBase64String(bytes);
                imag= new Bitmap(stream);
            }

            return imag;

        }

        public string saveImagen(string rutaImagen)
        {

            var fileName = rutaImagen;
            string idImagen;

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = dataBase.GridFS.Upload(fs, fileName);
                var fileId = gridFsInfo.Id;
                idImagen = fileId.ToString();
            }

            return idImagen;

        }

        public List<Partido> getPartidos() {


            

           List<Partido> partidos = dataBase.GetCollection<Partido>("Partido").FindAll().ToList();

            for (int i = 0; i < partidos.Count(); i++) {

                partidos[i].videos = getVid(partidos[i].id.ToString());

                var a = partidos[i].videos.Count();

                for (int j = 0; j < partidos[i].videos.Count(); j++)
                {
                    partidos[i].videos[j].video = getVideo(partidos[i].videos[j].videoGridFS);
                   
                }
                
                partidos[i].comentarios = getRespuestaComentario(partidos[i].id.ToString());

            }

            return partidos;
            

        }

        public List<Usuario> getUsuarios()
        {
            List<Usuario> usuarios = dataBase.GetCollection<Usuario>("Usuario").FindAll().ToList();
            foreach(Usuario usuario in usuarios)
            {
                usuario.imagen = getImage(usuario.id.ToString());//To string porque es object id
                usuario.imagen.Image = getImagen(usuario.imagen.imageGridFS);
            }
            return usuarios;
        }

            public string saveVideo(string rutaVideo) {
            var fileName = rutaVideo;
            string idVideo;

            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = dataBase.GridFS.Upload(fs, fileName);
                var fileId = gridFsInfo.Id;
                idVideo = fileId.ToString();
            }

            return idVideo;

        }

        public byte[] getVideo(string idVideo)
        {

            var fileID = new ObjectId(idVideo);
            var file = dataBase.GridFS.FindOneById(fileID);


            byte[] video;

            using (var fs = file.OpenRead())
            {

                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                var stream = new MemoryStream(bytes);
                //imagen = "data:Image/png;base64," + Convert.ToBase64String(bytes);
                video = bytes;
            }

            return video;

        }

        

        public Usuario getUsuarioPorCorreo(string correo) {

            var query = Query.EQ("mail", correo);
            MongoCollection<Usuario> collection = dataBase.GetCollection<Usuario>("Usuario");

            collection.Validate();
            Usuario temp = collection.FindOne(query);
            try
            {
                temp.imagen = getImage(temp.id.ToString());
                temp.imagen.Image = getImagen(temp.imagen.imageGridFS);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe ingresar un correo valido");
            }
            
            
            
            return temp;

        }





    }
}
