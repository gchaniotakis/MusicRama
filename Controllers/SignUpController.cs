using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using MusicRama.Models;

namespace MusicRama.Controllers
{
    public class SignUpController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            (bool valid, string field, string error) = db.Users.Add(user, ModelState.IsValid);

            if (!valid)
            {
                ModelState.AddModelError(field, error);
                    return View(user);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}