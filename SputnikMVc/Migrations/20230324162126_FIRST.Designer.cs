﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SputnikMVc.Context;

#nullable disable

namespace SputnikMVc.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20230324162126_FIRST")]
    partial class FIRST
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SputnikMVc.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("SputnikMVc.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("nome")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artista");
                });

            modelBuilder.Entity("SputnikMVc.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PathMusica")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("SputnikMVc.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("SputnikMVc.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Passworld")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SputnikMVc.Models.ViewModel.PlaylistMusica", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("MusicaId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "MusicaId");

                    b.HasIndex("MusicaId");

                    b.ToTable("PlaylistMusica");
                });

            modelBuilder.Entity("SputnikMVc.Models.Album", b =>
                {
                    b.HasOne("SputnikMVc.Models.Artista", "Artista")
                        .WithMany("MusicaLista")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("SputnikMVc.Models.Musica", b =>
                {
                    b.HasOne("SputnikMVc.Models.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("SputnikMVc.Models.ViewModel.PlaylistMusica", b =>
                {
                    b.HasOne("SputnikMVc.Models.Musica", "Musica")
                        .WithMany("PlaylistMusica")
                        .HasForeignKey("MusicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SputnikMVc.Models.Playlist", "Playlist")
                        .WithMany("PlaylistMusica")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musica");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("SputnikMVc.Models.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("SputnikMVc.Models.Artista", b =>
                {
                    b.Navigation("MusicaLista");
                });

            modelBuilder.Entity("SputnikMVc.Models.Musica", b =>
                {
                    b.Navigation("PlaylistMusica");
                });

            modelBuilder.Entity("SputnikMVc.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistMusica");
                });
#pragma warning restore 612, 618
        }
    }
}
