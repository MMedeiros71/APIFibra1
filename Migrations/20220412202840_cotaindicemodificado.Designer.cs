// <auto-generated />
using System;
using APIFibra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIFibra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220412202840_cotaindicemodificado")]
    partial class cotaindicemodificado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIFibra.Entities.Administrativo", b =>
                {
                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Nivel")
                        .HasColumnType("tinyint");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UltimoAcesso")
                        .HasColumnType("datetime2");

                    b.HasKey("Usuario");

                    b.ToTable("FibraAdministrativo");
                });

            modelBuilder.Entity("APIFibra.Entities.Ativo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Abertura")
                        .HasColumnType("real");

                    b.Property<float>("Compra")
                        .HasColumnType("real");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fechamento")
                        .HasColumnType("real");

                    b.Property<float>("Maximo")
                        .HasColumnType("real");

                    b.Property<float>("Medio")
                        .HasColumnType("real");

                    b.Property<float>("Minimo")
                        .HasColumnType("real");

                    b.Property<string>("Negocios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeAtivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("QCompra")
                        .HasColumnType("real");

                    b.Property<float>("QVenda")
                        .HasColumnType("real");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Ultimo")
                        .HasColumnType("real");

                    b.Property<float>("Variacao")
                        .HasColumnType("real");

                    b.Property<float>("Venda")
                        .HasColumnType("real");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Data", "NomeAtivo");

                    b.ToTable("FibraAtivo");
                });

            modelBuilder.Entity("APIFibra.Entities.CotaIndice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CDB30Valor")
                        .HasColumnType("real");

                    b.Property<float>("CDB30Variacao")
                        .HasColumnType("real");

                    b.Property<bool>("CotaOficial")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCota")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFGTSVale")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFundoFibraMulticarteira")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFundoPremium")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPatrimonio")
                        .HasColumnType("datetime2");

                    b.Property<float>("IGPMValor")
                        .HasColumnType("real");

                    b.Property<float>("IGPMVariacao")
                        .HasColumnType("real");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PatrimonioLiquidoFibraMulticarteira")
                        .HasColumnType("real");

                    b.Property<float>("PatrimonioLiquidoFundoPremium")
                        .HasColumnType("real");

                    b.Property<float>("RentabilidadeAno")
                        .HasColumnType("real");

                    b.Property<float>("RentabilidadeDia")
                        .HasColumnType("real");

                    b.Property<float>("RentabilidadeMes")
                        .HasColumnType("real");

                    b.Property<float>("RentabilidadeUltimosMeses")
                        .HasColumnType("real");

                    b.Property<float>("SelicValor")
                        .HasColumnType("real");

                    b.Property<float>("SelicVariacao")
                        .HasColumnType("real");

                    b.Property<float>("TJLPValor")
                        .HasColumnType("real");

                    b.Property<float>("TJLPVariacao")
                        .HasColumnType("real");

                    b.Property<float>("ValorCota")
                        .HasColumnType("real");

                    b.Property<float>("ValorCotaPatrimonio")
                        .HasColumnType("real");

                    b.Property<float>("ValorFGTSVale")
                        .HasColumnType("real");

                    b.Property<float>("ValorFundoFibraMulticarteira")
                        .HasColumnType("real");

                    b.Property<float>("ValorFundoPremium")
                        .HasColumnType("real");

                    b.Property<int>("ValorPatrimonioAtual")
                        .HasColumnType("int");

                    b.Property<int>("ValorPatrimonioMedio")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("FibraCotaIndice");
                });

            modelBuilder.Entity("APIFibra.Entities.Noticia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<short>("Grupo")
                        .HasColumnType("smallint");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Data");

                    b.ToTable("FibraNoticias");
                });
#pragma warning restore 612, 618
        }
    }
}
