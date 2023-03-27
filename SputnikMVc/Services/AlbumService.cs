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


        public async Task Create(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

    }
}
