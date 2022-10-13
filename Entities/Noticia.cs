using System;
using System.Net.Mime;

namespace APIFibra.Entities
{
    public class Noticia
    {
        public int ID { get; set; }
        public short Grupo { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public bool Principal { get; set; }
    }
}