﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatikaDev.Models;

namespace PatikaDev.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsistanEgitim", b =>
                {
                    b.Property<int>("AsistanlarId")
                        .HasColumnType("int");

                    b.Property<int>("EgitimlerId")
                        .HasColumnType("int");

                    b.HasKey("AsistanlarId", "EgitimlerId");

                    b.HasIndex("EgitimlerId");

                    b.ToTable("AsistanEgitim");
                });

            modelBuilder.Entity("EgitimKatilimci", b =>
                {
                    b.Property<int>("EgitimlerId")
                        .HasColumnType("int");

                    b.Property<int>("KatilimcilarId")
                        .HasColumnType("int");

                    b.HasKey("EgitimlerId", "KatilimcilarId");

                    b.HasIndex("KatilimcilarId");

                    b.ToTable("EgitimKatilimci");
                });

            modelBuilder.Entity("PatikaDev.Models.Asistan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Asistanlar");
                });

            modelBuilder.Entity("PatikaDev.Models.Egitim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("BasariNotu")
                        .HasColumnType("tinyint");

                    b.Property<string>("EgitimAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EgitmenId")
                        .HasColumnType("int");

                    b.Property<short>("Kontejan")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("EgitmenId")
                        .IsUnique();

                    b.ToTable("Egitimler");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimOgrencileri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EgitimId")
                        .HasColumnType("int");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EgitimId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("EgitimOgrencileri");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimTarihleri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("EgitimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EgitimId")
                        .IsUnique();

                    b.ToTable("EgitimTarihleri");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimYoklamalari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EgitimOgrencileriId")
                        .HasColumnType("int");

                    b.Property<bool>("Katilim")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EgitimOgrencileriId");

                    b.ToTable("EgitimYoklamalari");
                });

            modelBuilder.Entity("PatikaDev.Models.Egitmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("PatikaDev.Models.Katilimci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Katilimcilar");
                });

            modelBuilder.Entity("PatikaDev.Models.NotTablosu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EgitimOgrencileriId")
                        .HasColumnType("int");

                    b.Property<byte>("OgrenciNotu")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("EgitimOgrencileriId");

                    b.ToTable("NotTablosu");
                });

            modelBuilder.Entity("PatikaDev.Models.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("AsistanEgitim", b =>
                {
                    b.HasOne("PatikaDev.Models.Asistan", null)
                        .WithMany()
                        .HasForeignKey("AsistanlarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatikaDev.Models.Egitim", null)
                        .WithMany()
                        .HasForeignKey("EgitimlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EgitimKatilimci", b =>
                {
                    b.HasOne("PatikaDev.Models.Egitim", null)
                        .WithMany()
                        .HasForeignKey("EgitimlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatikaDev.Models.Katilimci", null)
                        .WithMany()
                        .HasForeignKey("KatilimcilarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatikaDev.Models.Egitim", b =>
                {
                    b.HasOne("PatikaDev.Models.Egitmen", "Egitmen")
                        .WithOne("Egitim")
                        .HasForeignKey("PatikaDev.Models.Egitim", "EgitmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egitmen");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimOgrencileri", b =>
                {
                    b.HasOne("PatikaDev.Models.Egitim", "Egitim")
                        .WithMany()
                        .HasForeignKey("EgitimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatikaDev.Models.Ogrenci", "Ogrenci")
                        .WithMany()
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egitim");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimTarihleri", b =>
                {
                    b.HasOne("PatikaDev.Models.Egitim", "Egitim")
                        .WithOne("EgitimTarihi")
                        .HasForeignKey("PatikaDev.Models.EgitimTarihleri", "EgitimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egitim");
                });

            modelBuilder.Entity("PatikaDev.Models.EgitimYoklamalari", b =>
                {
                    b.HasOne("PatikaDev.Models.EgitimOgrencileri", "EgitimOgrencileri")
                        .WithMany()
                        .HasForeignKey("EgitimOgrencileriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EgitimOgrencileri");
                });

            modelBuilder.Entity("PatikaDev.Models.NotTablosu", b =>
                {
                    b.HasOne("PatikaDev.Models.EgitimOgrencileri", "EgitimOgrencileri")
                        .WithMany()
                        .HasForeignKey("EgitimOgrencileriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EgitimOgrencileri");
                });

            modelBuilder.Entity("PatikaDev.Models.Egitim", b =>
                {
                    b.Navigation("EgitimTarihi");
                });

            modelBuilder.Entity("PatikaDev.Models.Egitmen", b =>
                {
                    b.Navigation("Egitim");
                });
#pragma warning restore 612, 618
        }
    }
}