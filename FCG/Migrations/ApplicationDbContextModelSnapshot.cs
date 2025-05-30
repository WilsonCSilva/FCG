﻿// <auto-generated />
using System;
using FCG.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FCG.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FCG.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("date")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("date")
                        .HasColumnOrder(6);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnOrder(4);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnOrder(2);

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnOrder(5);

                    b.Property<string>("Produtora")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("FCG.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime")
                        .HasColumnOrder(1);

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("FCG.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("date")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnOrder(6);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(3);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnOrder(5);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnOrder(2);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(4);

                    b.Property<byte>("TipoUsuario")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(7);

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("FCG.Models.Pedido", b =>
                {
                    b.HasOne("FCG.Models.Game", "Game")
                        .WithMany("Pedidos")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FCG.Models.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FCG.Models.Game", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("FCG.Models.Usuario", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
