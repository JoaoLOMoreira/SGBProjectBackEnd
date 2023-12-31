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
    [Migration("20220831233708_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SgbProject.Model.Boi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Genitor")
                        .HasColumnType("bit");

                    b.Property<string>("IdMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesNascimento")
                        .HasColumnType("int");

                    b.Property<int>("QtdCria")
                        .HasColumnType("int");

                    b.Property<string>("Raça")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaCria")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bois");
                });

            modelBuilder.Entity("SgbProject.Model.Vaca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("QtdCria")
                        .HasColumnType("int");

                    b.Property<string>("Raça")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaCria")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Vacas");
                });
#pragma warning restore 612, 618
        }
    }
}
