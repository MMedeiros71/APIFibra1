using System;

namespace APIFibra.Entities
{
    public class Administrativo
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public  byte Nivel { get; set; }
        public DateTime? UltimoAcesso { get; set; }
    }
}