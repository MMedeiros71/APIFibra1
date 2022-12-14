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
    [Migration("20220402193402_Ativo")]
    partial class Ativo
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
