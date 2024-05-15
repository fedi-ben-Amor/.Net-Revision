using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
   
    public class ChonsonController : Controller
    {
        private readonly IServiceChanson iServiceChanson;
        private readonly IServiceArtiste iServiceArtiste;
        public ChonsonController(IServiceChanson iServiceChanson, IServiceArtiste iServiceArtiste)
        {
            this.iServiceChanson = iServiceChanson;
            this.iServiceArtiste = iServiceArtiste;
        }

        // GET: ChonsonController
        public ActionResult Index(string Titre)
        {
            if (!string.IsNullOrEmpty(Titre))
            {
                List<Chanson> chansons = iServiceChanson.GetChansonByTitre(Titre);
                return View(chansons);
            }
            else
            {
                List<Chanson> chansons = iServiceChanson.GetAll().OrderBy(f => f.VuesYoutube).ToList();
                return View(chansons);
            }
        }


        // GET: ChonsonController/Details/5
        public ActionResult Details(int id)
        {
            var chanson = iServiceChanson.GetById((int)id);
            if (chanson == null)
            {
                return NotFound();
            }
            return View(chanson);
        }


        // GET: ChonsonController/Create
        public ActionResult Create()
        {

            ViewBag.StyleMusical = new SelectList(Enum.GetNames(typeof(StyleMusical)));
            var artistes = iServiceArtiste.GetAll()
                                           .Select(a => new
                                           {
                                               ArtisteId = a.ArtisteId,
                                               NomComplet = a.nom + " " + a.prenom
                                           })
                                           .ToList();

            ViewBag.ArtisteFk = new SelectList(artistes, "ArtisteId", "NomComplet");
            return View();
        }

        // POST: ChonsonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chanson chanson)
        {
            try
            {
                iServiceChanson.Add(chanson);
                iServiceChanson.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChonsonController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chanson = iServiceChanson.GetById((int)id);
            if (chanson == null)
            {
                return NotFound();
            }
            ViewBag.StyleMusical = new SelectList(Enum.GetNames(typeof(StyleMusical)));
            var artistes = iServiceArtiste.GetAll()
                                    .Select(a => new
                                    {
                                        ArtisteId = a.ArtisteId,
                                        NomComplet = a.nom + " " + a.prenom
                                    })
                                    .ToList();

            ViewBag.ArtisteFk = new SelectList(artistes, "ArtisteId", "NomComplet");
            return View(chanson);
        }

        // POST: ChonsonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chanson chanson)
        {
            try
            {
                iServiceChanson.Update(chanson);
                iServiceChanson.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    

        // GET: ChonsonController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var chanson = iServiceChanson.GetById((int)id);
            if (chanson == null)
            {
                return NotFound();
            }

            return View(chanson);
        }

        // POST: ChonsonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var chanson = iServiceChanson.GetById((int)id);
                iServiceChanson.Delete(chanson);
                iServiceChanson.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
