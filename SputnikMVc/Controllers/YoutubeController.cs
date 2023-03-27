using Microsoft.AspNetCore.Mvc;
using SputnikMVc.Models;
using SputnikMVc.Services;
using YoutubeExplode.Videos;

namespace SputnikMVc.Controllers
{
    public class YoutubeController : Controller
    {

        private readonly YoutubeService youtubeService;

        public YoutubeController(YoutubeService youtubeService)
        {
            this.youtubeService = youtubeService;
        }

        // GET: ArtistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Url)
        {
            try
            {
                await youtubeService.DownloadMusicaYoutube(Url);
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View();
            }
        }
    }
}
