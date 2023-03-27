using Microsoft.EntityFrameworkCore;
using SputnikMVc.Context;
using SputnikMVc.Models;

namespace SputnikMVc.Services
{
    public class AlbumService
    {

        private readonly MySQLContext _context;

        public AlbumService(MySQLContext context)
        {
            _context = context;
        }


        public async Task<Album> Create(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();


            return await _context.Albums.Where(x => x.Title == album.Title).FirstAsync();
        }
        public async Task<Album> GetByName(Album album)
        {
            return await _context.Albums.Where(x => x.Title == album.Title).FirstOrDefaultAsync();
        }

    }
}
