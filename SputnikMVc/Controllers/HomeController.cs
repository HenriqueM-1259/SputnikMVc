using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikMVc.Context;
using SputnikMVc.Models;
using System.Diagnostics;

namespace SputnikMVc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MySQLContext _sqlContext;
        public HomeController(ILogger<HomeController> logger, MySQLContext mySQLContext)
        {
            _logger = logger;
            _sqlContext = mySQLContext;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }
        public async Task<IActionResult> ListarArtista()
        {
            List<Artista> artista = await _sqlContext.Artista.OrderBy(x => x.Nome).ToListAsync();
            return PartialView("ListarArtista", artista);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}