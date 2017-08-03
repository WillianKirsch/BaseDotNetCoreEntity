using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Produtos.Persistencia.Contexto;

namespace Produtos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20170802210554_Terceiro")]
    partial class Terceiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Produtos.Entidades.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("Produtos.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<double>("PrecoVenda");

                    b.Property<int>("SubGrupoId");

                    b.HasKey("Id");

                    b.HasIndex("SubGrupoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Produtos.Entidades.SubGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("GrupoId");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("SubGrupos");
                });

            modelBuilder.Entity("Produtos.Entidades.Produto", b =>
                {
                    b.HasOne("Produtos.Entidades.SubGrupo", "SubGrupo")
                        .WithMany()
                        .HasForeignKey("SubGrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Produtos.Entidades.SubGrupo", b =>
                {
                    b.HasOne("Produtos.Entidades.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
