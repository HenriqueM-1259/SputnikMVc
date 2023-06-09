﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SputnikMVc.Context;
using SputnikMVc.Models;
using SputnikMVc.Services;

namespace SputnikMVc.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly ArtistaService _service;
        private readonly MySQLContext _sqlContext;
        public ArtistaController(ArtistaService service, MySQLContext sqlContext)
        {
            _service = service;
            _sqlContext = sqlContext;
        }
        // GET: ArtistaController
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
        public async Task<ActionResult> Create(Artista artista)
        {
            try
            {
                await _service.Create(artista);
                return View("~/Views/Home/Index.cshtml");
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> index()
        {
            List<Artista> artista = await _sqlContext.Artista.OrderBy(x => x.Nome).ToListAsync();
            return View(artista);
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
