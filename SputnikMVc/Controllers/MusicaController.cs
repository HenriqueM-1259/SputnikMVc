using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SputnikMVc.Models;
using SputnikMVc.Models.ViewModel;
using SputnikMVc.Services;

namespace SputnikMVc.Controllers
{
    public class MusicaController : Controller
    {
        private readonly MusicaService _service;

        public MusicaController(MusicaService service)
        {
            _service = service;
        }
        
        public async Task<ActionResult> ListaMusica([FromQuery]int idAlbum)
        {
            List<Musica> Musica = await _service.GetAllIdAlbum(idAlbum);
            return View(Musica);
        }   
    }
}
