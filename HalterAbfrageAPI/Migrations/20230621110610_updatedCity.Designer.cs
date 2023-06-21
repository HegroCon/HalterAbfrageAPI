﻿// <auto-generated />
using System;
using HalterAbfrageAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HalterAbfrageAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230621110610_updatedCity")]
    partial class updatedCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HalterAbfrageAPI.Models.Fahrzeug", b =>
                {
                    b.Property<string>("Kennzeichen")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Farbe")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Kategory")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Marke")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Kennzeichen");

                    b.HasIndex("PersonId");

                    b.ToTable("Fahrzeuge");
                });

            modelBuilder.Entity("HalterAbfrageAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("StadtPlz")
                        .IsRequired()
                        .HasColumnType("varchar(5");

                    b.Property<string>("StrasseHausnummer")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("StadtPlz");

                    b.ToTable("Personen");
                });

            modelBuilder.Entity("HalterAbfrageAPI.Models.Stadt", b =>
                {
                    b.Property<string>("Plz")
                        .HasColumnType("varchar(5");

                    b.Property<string>("Bundesland")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.HasKey("Plz");

                    b.ToTable("Stadt");
                });

            modelBuilder.Entity("HalterAbfrageAPI.Models.Fahrzeug", b =>
                {
                    b.HasOne("HalterAbfrageAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HalterAbfrageAPI.Models.Person", b =>
                {
                    b.HasOne("HalterAbfrageAPI.Models.Stadt", "Stadt")
                        .WithMany()
                        .HasForeignKey("StadtPlz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stadt");
                });
#pragma warning restore 612, 618
        }
    }
}
