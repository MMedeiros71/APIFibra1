using System;
using System.ComponentModel;

namespace APIFibra.Entities
{
    public class Ativo
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string NomeAtivo { get; set; }
        public float Ultimo { get; set; }
        
        [DefaultValue(0.00)]
        public float Minimo { get; set; }
        [DefaultValue(0.00)]
        public float Maximo { get; set; }
        public float Variacao { get; set; }
        [DefaultValue(0.00)]
        public float Medio { get; set; }
        [DefaultValue(0.00)]
        public float Abertura { get; set; }
        [DefaultValue(0.00)]
        public float Fechamento { get; set; }
        [DefaultValue("0.00")]
        public string Negocios { get; set; }
        [DefaultValue("0.00")]
        public string Quantidade { get; set; }
        [DefaultValue("N/A")]
        public string Volume { get; set; }
        [DefaultValue(0.00)]
        public float Compra { get; set; }
        [DefaultValue(0.00)]
        public float Venda { get; set; }
        [DefaultValue(0.00)]
        public float QCompra { get; set; }
        [DefaultValue(0.00)]
        public float QVenda { get; set; }
    }
}