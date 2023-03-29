using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SputnikMVc.Models;
using SputnikMVc.Services;

namespace SputnikMVc.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumService _service;

        public AlbumController(AlbumService service)
        {
            _service = service;
        }
        // GET: ArtistaController
        public async Task<ActionResult> Index([FromQuery]int idArtista)
        {
            List<Album> album = await _service.GetAllIdArtista(idArtista);
            return View(album);
        }

        // GET: ArtistaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Album album)
        {
            try
            {
                await _service.Create(album);
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
