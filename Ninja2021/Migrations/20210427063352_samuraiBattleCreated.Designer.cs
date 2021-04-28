﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ninja2021.Models;

namespace Ninja2021.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210427063352_samuraiBattleCreated")]
    partial class samuraiBattleCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ninja2021.Models.Battle", b =>
                {
                    b.Property<int>("battleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("battleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("Ninja2021.Models.Samurai", b =>
                {
                    b.Property<int>("samuraiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("battlesFought")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("samuraiId");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("Ninja2021.Models.SamuraisInBattle", b =>
                {
                    b.Property<int>("samuraiId")
                        .HasColumnType("int");

                    b.Property<int>("battleId")
                        .HasColumnType("int");

                    b.HasKey("samuraiId", "battleId");

                    b.HasIndex("battleId");

                    b.ToTable("SamuraisInBattle");
                });

            modelBuilder.Entity("Ninja2021.Models.SamuraisInBattle", b =>
                {
                    b.HasOne("Ninja2021.Models.Battle", "battle")
                        .WithMany("samuraiBattles")
                        .HasForeignKey("battleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ninja2021.Models.Samurai", "samurai")
                        .WithMany("samuraiBattles")
                        .HasForeignKey("samuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}