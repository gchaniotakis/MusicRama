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
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: User
        public ActionResult Index()
        {
            return View(db.Users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id,Username,Password")] User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           var user = db.Users.Where(u => u.Id == id).ToList();

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Username,Password")] User user)
        {
            if(ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand($"UPDATE Users SET Username = {user.Username} WHERE Id =  {user.Id}");
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("User");
        }

        public ActionResult Delete (int id)
        {
            var users = db.Users.Where(u => u.Id == id).ToList();
            foreach (User user in users)
            {
                db.Users.Remove(user);
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