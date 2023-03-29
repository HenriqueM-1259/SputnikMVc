using Microsoft.EntityFrameworkCore;
using SputnikMVc.Context;
using SputnikMVc.Models;
using SputnikMVc.Models.ViewModel;

namespace SputnikMVc.Services
{
    public class MusicaService
    {
        private readonly MySQLContext _context;
        public MusicaService(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Musica> GetByName(Musica musica)
        {
            return await _context.Musicas.Where(x => x.Name == musica.Name).FirstOrDefaultAsync();
        }

        public async Task<Musica> Create(Musica musica)
        {

            await _context.Musicas.AddAsync(musica);
            await _context.SaveChangesAsync();
            musica = await GetByName(musica);
            return musica;
        }
        public async Task<AlbumMusica> GetByNameAlbumAndMusica(AlbumMusica AlbumMusica)
        {
            return await _context.albumMusicas.Where(x => x.MusicaId == AlbumMusica.MusicaId && x.AlbumId == AlbumMusica.AlbumId).FirstOrDefaultAsync();
        }
        public async Task<AlbumMusica> CreateAlbumAndMusica(AlbumMusica AlbumMusica)
        {

            await _context.albumMusicas.AddAsync(AlbumMusica);
            await _context.SaveChangesAsync();
            AlbumMusica = await GetByNameAlbumAndMusica(AlbumMusica);
            return AlbumMusica;
        }

        public async Task<List<Musica>> GetAllIdAlbum(int id)
        {
            List<AlbumMusica> ListMusicaAlbum = _context.albumMusicas.Where(x => x.AlbumId == id).ToList();
            List<Musica> ListaMusica = new List<Musica>();
            foreach (var album in ListMusicaAlbum)
            {
                ListaMusica.Add(await _context.Musicas.Where(x => x.Id == album.MusicaId).FirstOrDefaultAsync());
            }
            return ListaMusica;
        }

    }
}
