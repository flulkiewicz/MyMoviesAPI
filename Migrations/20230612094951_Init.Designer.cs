﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMoviesAPI.Data;

#nullable disable

namespace MyMoviesAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230612094951_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyMoviesAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("ExternalId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Quentin Tarantino",
                            Rate = 9,
                            Title = "Reservoir Dogs",
                            Year = 1992
                        },
                        new
                        {
                            Id = 2,
                            Director = "Quentin Tarantino",
                            Rate = 9,
                            Title = "Django Unchained",
                            Year = 2012
                        },
                        new
                        {
                            Id = 3,
                            Director = "Guy Ritchie",
                            Rate = 7,
                            Title = "Wrath of Man",
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            Director = "Barbara Białowąs",
                            Rate = 1,
                            Title = "365 Dni",
                            Year = 2020
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
