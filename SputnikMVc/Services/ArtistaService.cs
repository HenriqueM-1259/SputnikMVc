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


        public async Task<string> Create(Artista artista)
        {
            Artista art = await _context.Artista.FindAsync(artista.Nome);
            if (art != null)
            {
                return "Artista ja foi criado";
            }
            await _context.Artista.AddAsync(artista);

            return artista.ToString();
        }

    }
}
