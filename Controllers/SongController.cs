using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicRama.Models;


namespace MusicRama.Controllers
{
    public class SongController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Song
        public ActionResult Index()
        {
            return View(db.Songs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Artist,Name,Description,Date")] Song song)
        {
            song.Date = DateTime.Now;
            db.Songs.Add(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = db.Songs.Where(s => s.Id == id).ToList();

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Artist,Name,Description,Date")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand($"UPDATE Songs SET Artist = {song.Artist}, Name = {song.Name}, Description = {song.Description} WHERE Id =  {song.Id}");
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Song");
        }

        public ActionResult Delete(int id)
        {
            var songs = db.Songs.Where(s => s.Id == id).ToList();
            foreach (Song song in songs)
            {
                db.Songs.Remove(song);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}