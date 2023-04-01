using Microsoft.EntityFrameworkCore;
using SputnikMVc.Context;
using SputnikMVc.Models;

namespace SputnikMVc.Services
{
    public class ArtistaService
    {

        private readonly MySQLContext _context;

        public ArtistaService(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Artista> GetByName(Artista artista)
        {
            return await _context.Artista.Where(x => x.Nome == artista.Nome).FirstOrDefaultAsync();
        }
        
        public async Task<Artista> Create(Artista artista)
        {     
            
            await _context.Artista.AddAsync(artista);
            await _context.SaveChangesAsync();

            artista = await GetByName(artista);

            return artista;
        }

    }
}
