﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SgbProject.Data;

#nullable disable

namespace SgbProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220904005142_adicionando tabela baixa")]
    partial class adicionandotabelabaixa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SgbProject.Model.Baixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataBaixa")
                        .HasColumnType("datetime2");

                    b.Property<string>("obs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Baixas");
                });

            modelBuilder.Entity("SgbProject.Model.Bovino", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<bool>("Genitora")
                        .HasColumnType("bit");

                    b.Property<string>("IdMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Pasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdCria")
                        .HasColumnType("int");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaCria")
                        .HasColumnType("datetime2");

                    b.Property<string>("obs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bovinos");
                });

            modelBuilder.Entity("SgbProject.Model.Vacina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Doenca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdBonivo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("anoFabrcacao")
                        .HasColumnType("int");

                    b.Property<int>("anoVenciomento")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataVacinacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("mesFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("mesVencimento")
                        .HasColumnType("int");

                    b.Property<string>("nLote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacinas");
                });
#pragma warning restore 612, 618
        }
    }
}
