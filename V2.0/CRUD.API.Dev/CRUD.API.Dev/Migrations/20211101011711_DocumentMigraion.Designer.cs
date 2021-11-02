﻿// <auto-generated />
using System;
using CRUD.API.Dev.RessourceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace CRUD.API.Dev.Migrations
{
    [DbContext(typeof(DBRessourceContext))]
    [Migration("20211101011711_DocumentMigraion")]
    partial class DocumentMigraion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUD.API.Dev.Models.Ressource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("DocPath")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Doctype")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Number")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Ressources");
                });
#pragma warning restore 612, 618
        }
    }
}
