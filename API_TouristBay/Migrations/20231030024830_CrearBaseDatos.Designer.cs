﻿// <auto-generated />
using API_TouristBay.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_TouristBay.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231030024830_CrearBaseDatos")]
    partial class CrearBaseDatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_TouristBay.Models.Pasajeros.Pasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Genero")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pasajero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "default",
                            Genero = false,
                            Nombre = "default"
                        });
                });

            modelBuilder.Entity("API_TouristBay.Models.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aerolinea")
                        .HasColumnType("int");

                    b.Property<bool>("Clase")
                        .HasColumnType("bit");

                    b.Property<int>("Destino")
                        .HasColumnType("int");

                    b.Property<int>("Origen")
                        .HasColumnType("int");

                    b.Property<int>("PlzEconomicas")
                        .HasColumnType("int");

                    b.Property<int>("PlzPreferenciales")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Vuelo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aerolinea = 0,
                            Clase = false,
                            Destino = 0,
                            Origen = 0,
                            PlzEconomicas = 0,
                            PlzPreferenciales = 0,
                            Precio = 0.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
