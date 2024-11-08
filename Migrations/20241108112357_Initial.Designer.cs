﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Allatmenhely_API.Migrations
{
    [DbContext(typeof(AnimalContext))]
    [Migration("20241108112357_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Allatmenhely_API.Entities.Allatok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CareTaker")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GondozokId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HealthStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdopted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrokbefogadasokId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GondozokId");

                    b.HasIndex("OrokbefogadasokId");

                    b.ToTable("Allatoks");
                });

            modelBuilder.Entity("Allatmenhely_API.Entities.Gondozok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Gondozoks");
                });

            modelBuilder.Entity("Allatmenhely_API.Entities.Orokbefogadasok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdopterContactInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdopterName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AdoptionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Orokbefogadasoks");
                });

            modelBuilder.Entity("Allatmenhely_API.Entities.Allatok", b =>
                {
                    b.HasOne("Allatmenhely_API.Entities.Gondozok", "Gondozok")
                        .WithMany()
                        .HasForeignKey("GondozokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Allatmenhely_API.Entities.Orokbefogadasok", "Orokbefogadasok")
                        .WithMany()
                        .HasForeignKey("OrokbefogadasokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gondozok");

                    b.Navigation("Orokbefogadasok");
                });
#pragma warning restore 612, 618
        }
    }
}
