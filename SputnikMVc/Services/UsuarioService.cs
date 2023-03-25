using SputnikMVc.Context;

namespace SputnikMVc.Services
{
    public class UsuarioService
    {
        private readonly MySQLContext _context;

        public UsuarioService(MySQLContext context)
        {
            _context = context;
        }


    }
}
