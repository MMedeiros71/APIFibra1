using System.ComponentModel.DataAnnotations.Schema;
using APIFibra.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFibra.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<CotaIndice> CotasIndices { get; set; }
        public DbSet<Cota> Cotas { get; set; }
        
        public DbSet<Recadastro> Recadastros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Administrativo>(e =>
            {
                e.ToTable("FibraAdministrativo");
                e.HasKey(p => p.Usuario);
                e.Property(p => p.Senha).IsRequired();
                e.Property(p => p.Nivel).IsRequired();
            });
            
            modelBuilder.Entity<Noticia>(e =>
            {
                e.ToTable("FibraNoticias");
                e.HasKey(p => p.ID);
                e.Property(p => p.Data).IsRequired();
                e.Property(p => p.Grupo).IsRequired();
                e.Property(p => p.Titulo).IsRequired();
                e.Property(p => p.Comentario).IsRequired();
                e.Property(p => p.Principal).IsRequired();
                e.HasIndex(p => p.Data);
            });
            
            modelBuilder.Entity<Ativo>(e =>
            {
                e.ToTable("FibraAtivo");
                e.HasIndex(p => new
                {
                    p.Data,
                    p.NomeAtivo
                });
                e.HasKey(p => p.ID);
                e.Property(p => p.Data).IsRequired();
                e.Property(p => p.NomeAtivo).IsRequired();
                e.Property(p => p.Ultimo).IsRequired();
                e.Property(p => p.Minimo).IsRequired();
                e.Property(p => p.Maximo).IsRequired();
                e.Property(p => p.Variacao).IsRequired();
                e.Property(p => p.Medio).IsRequired();
                e.Property(p => p.Abertura).IsRequired();
                e.Property(p => p.Fechamento).IsRequired();
                e.Property(p => p.Negocios).IsRequired();
                e.Property(p => p.Quantidade).IsRequired();
                e.Property(p => p.Volume).IsRequired();
                e.Property(p => p.Compra).IsRequired();
                e.Property(p => p.Venda).IsRequired();
                e.Property(p => p.QCompra).IsRequired();
                e.Property(p => p.QVenda).IsRequired();
            });
            
            modelBuilder.Entity<CotaIndice>(e =>
            {
                e.ToTable("FibraCotaIndice");
                e.HasKey(p => p.ID);
                
                e.Property(p => p.DataCota).IsRequired();
                e.Property(p => p.ValorCota).IsRequired();
                e.Property(p => p.CotaOficial).IsRequired();
                e.Property(p => p.RentabilidadeDia).IsRequired();
                e.Property(p => p.RentabilidadeMes).IsRequired();
                e.Property(p => p.RentabilidadeAno).IsRequired();
                e.Property(p => p.RentabilidadeUltimosMeses).IsRequired();
                e.Property(p => p.DataFGTSVale).IsRequired();
                e.Property(p => p.ValorFGTSVale).IsRequired();
                e.Property(p => p.DataFundoFibraMulticarteira).IsRequired();
                e.Property(p => p.ValorFundoFibraMulticarteira).IsRequired();
                e.Property(p => p.PatrimonioLiquidoFibraMulticarteira).IsRequired();
                e.Property(p => p.DataFundoPremium).IsRequired();
                e.Property(p => p.ValorFundoPremium).IsRequired();
                e.Property(p => p.PatrimonioLiquidoFundoPremium).IsRequired();
                e.Property(p => p.DataPatrimonio).IsRequired();
                e.Property(p => p.ValorCotaPatrimonio).IsRequired();
                e.Property(p => p.ValorPatrimonioAtual).IsRequired();
                e.Property(p => p.ValorPatrimonioMedio).IsRequired();
                e.Property(p => p.SelicValor).IsRequired();
                e.Property(p => p.SelicVariacao).IsRequired();
                e.Property(p => p.TJLPValor).IsRequired();
                e.Property(p => p.TJLPVariacao).IsRequired();
                e.Property(p => p.CDB30Valor).IsRequired();
                e.Property(p => p.CDB30Variacao).IsRequired();
                e.Property(p => p.IGPMValor).IsRequired();
                e.Property(p => p.IGPMVariacao).IsRequired();

            });
            
            modelBuilder.Entity<Cota>(e =>
            {
                e.ToTable("FibraCotas");
                e.HasKey(p => p.Numcotista);
                e.Property(p => p.Numcotista).ValueGeneratedNever();
                e.Property(p => p.Nome).IsRequired();
                e.Property(p => p.CPF).IsRequired();
                e.Property(p => p.NumeroCotas).IsRequired();
                e.Property(p => p.NumeroCotas).HasDefaultValue(0.00);
            });
            
            modelBuilder.Entity<Recadastro>(e =>
            {
                e.ToTable("FibraRecadastro");
                e.HasKey(p => p.Numcotista);
                e.Property(p => p.Numcotista).ValueGeneratedNever();
                e.Property(p => p.Nome).IsRequired();
                e.Property(p => p.AutorizadoInicio).IsRequired(false);
                e.Property(p => p.AutorizadoFim).IsRequired(false);
                e.Property(p => p.PoliticoInicio).IsRequired(false);
                e.Property(p => p.PoliticoFim).IsRequired(false);
                e.Property(p => p.PerfilData).IsRequired(false);
                e.Property(p => p.RemuneracaoMensal).IsRequired(false);
                e.Property(p => p.OutrasRendas).IsRequired(false);
                e.Property(p => p.Patrimonio).IsRequired(false);
            });
        }
    }
}