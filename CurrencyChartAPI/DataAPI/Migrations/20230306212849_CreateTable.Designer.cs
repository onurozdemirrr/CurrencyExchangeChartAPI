﻿// <auto-generated />
using DataAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAPI.Migrations
{
    [DbContext(typeof(TCMBContext))]
    [Migration("20230306212849_CreateTable")]
    partial class CreateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAPI.ResponseDataKur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Birim")
                        .HasColumnType("int");

                    b.Property<decimal>("DovizAlis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DovizCinsi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DovizKodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DovizSatis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EfektifAlis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EfektifSatis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tarih")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResponseDataKurs");
                });
#pragma warning restore 612, 618
        }
    }
}
