using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APIFibra.Entities
{
    public class CotaIndice
    {
        public int ID { get; set; }
        public DateTime DataCota { get; set; }
        public float ValorCota{ get; set; }
        public bool CotaOficial { get; set; }
        public float RentabilidadeDia { get; set; }
        public float RentabilidadeMes { get; set; }
        public float RentabilidadeAno { get; set; }
        public float RentabilidadeUltimosMeses { get; set; }
        public DateTime DataFGTSVale { get; set; }
        public float ValorFGTSVale { get; set; }
        public DateTime DataFundoFibraMulticarteira { get; set; }
        public float ValorFundoFibraMulticarteira { get; set; }
        public float PatrimonioLiquidoFibraMulticarteira { get; set; }
        public DateTime DataFundoPremium { get; set; }
        public float ValorFundoPremium { get; set; }
        public float PatrimonioLiquidoFundoPremium { get; set; }
        public DateTime DataPatrimonio { get; set; }
        public float ValorCotaPatrimonio { get; set; }
        public int ValorPatrimonioAtual { get; set; }
        public int ValorPatrimonioMedio { get; set; }
        public float SelicValor { get; set; }
        public float SelicVariacao { get; set; }
        public float TJLPValor { get; set; }
        public float TJLPVariacao { get; set; }
        public float CDB30Valor { get; set; }
        public float CDB30Variacao { get; set; }
        public float IGPMValor { get; set; }
        public float IGPMVariacao { get; set; }
        public string Observacao { get; set; }
        
    }
}