﻿using SputnikMVc.Context;
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


        public async Task Create(Artista artista)
        {
            
            await _context.Artista.AddAsync(artista);
            await _context.SaveChangesAsync();
           
        }

    }
}
