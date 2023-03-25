using Microsoft.EntityFrameworkCore;
using SputnikMVc.Models;
using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Context
{
    public class MySQLContext:DbContext 
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Artista> Artista { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasMany(a => a.Musicas).WithOne(m => m.Album).HasForeignKey(m => m.Id);

            modelBuilder.Entity<Album>()
           .HasOne(a => a.Artista)
           .WithMany(ar => ar.MusicaLista)
           .HasForeignKey(a => a.ArtistaId);

            modelBuilder.Entity<PlaylistMusica>().HasKey(pm => new {pm.PlaylistId,pm.MusicaId});

            modelBuilder.Entity<PlaylistMusica>().HasOne(p => p.Playlist)
                .WithMany(p => p.PlaylistMusica)
                .HasForeignKey(pm => pm.PlaylistId);

            modelBuilder.Entity<PlaylistMusica>().HasOne(pm =>pm.Musica)
                .WithMany(m => m.PlaylistMusica)
                .HasForeignKey(pm => pm.MusicaId);



        }
    }
}
