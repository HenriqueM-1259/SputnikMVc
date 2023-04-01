using Microsoft.AspNetCore.Mvc;
using SputnikMVc.Models;
using SputnikMVc.Services;

namespace SputnikMVc.Controllers
{
    public class PlayerMusicaController : Controller
    {
        private readonly MusicaService _musica;
        private readonly ArtistaService _artista;

        public PlayerMusicaController(MusicaService musicaService, ArtistaService artistaService)
        {
            _musica = musicaService;
            _artista = artistaService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> PreencherPlayer([FromQuery]int id)
        {
            
            Musica musica = await this._musica.GetIdMusicaSQL(id);
            
            return new JsonResult(musica);
        }
    }
}
