﻿// <auto-generated />
using System;
using JeBalance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("JeBalance.Infrastructure.Models.DenonciationSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Delit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Horodatage")
                        .HasColumnType("TEXT");

                    b.Property<int>("InformateurId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaysEvasion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReponseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuspectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InformateurId");

                    b.HasIndex("ReponseId")
                        .IsUnique();

                    b.HasIndex("SuspectId");

                    b.ToTable("Denonciations");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.Models.PersonneSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NombreAvertissement")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypePersonne")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.Models.ReponseSQLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DenonciationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Retribution")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reponses");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.Models.DenonciationSQLite", b =>
                {
                    b.HasOne("JeBalance.Infrastructure.Models.PersonneSQLite", "Informateur")
                        .WithMany()
                        .HasForeignKey("InformateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JeBalance.Infrastructure.Models.ReponseSQLite", "Reponse")
                        .WithOne("DenonciationSQLite")
                        .HasForeignKey("JeBalance.Infrastructure.Models.DenonciationSQLite", "ReponseId");

                    b.HasOne("JeBalance.Infrastructure.Models.PersonneSQLite", "Suspect")
                        .WithMany()
                        .HasForeignKey("SuspectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Informateur");

                    b.Navigation("Reponse");

                    b.Navigation("Suspect");
                });

            modelBuilder.Entity("JeBalance.Infrastructure.Models.ReponseSQLite", b =>
                {
                    b.Navigation("DenonciationSQLite");
                });
#pragma warning restore 612, 618
        }
    }
}
