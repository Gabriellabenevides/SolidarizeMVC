﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolidarizeMVC.Data;

#nullable disable

namespace Solidarize.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241019025354_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SolidarizeMVC.Models.CampanhaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorObjetivo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("SolidarizeMVC.Models.DoacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampanhaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDoacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoadorId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDoacao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId");

                    b.HasIndex("DoadorId");

                    b.ToTable("Doacoes");
                });

            modelBuilder.Entity("SolidarizeMVC.Models.DoadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doadores");
                });

            modelBuilder.Entity("SolidarizeMVC.Models.DoacaoModel", b =>
                {
                    b.HasOne("SolidarizeMVC.Models.CampanhaModel", "Campanha")
                        .WithMany("Doacoes")
                        .HasForeignKey("CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SolidarizeMVC.Models.DoadorModel", "Doador")
                        .WithMany("Doacoes")
                        .HasForeignKey("DoadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campanha");

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("SolidarizeMVC.Models.CampanhaModel", b =>
                {
                    b.Navigation("Doacoes");
                });

            modelBuilder.Entity("SolidarizeMVC.Models.DoadorModel", b =>
                {
                    b.Navigation("Doacoes");
                });
#pragma warning restore 612, 618
        }
    }
}