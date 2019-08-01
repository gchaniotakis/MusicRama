using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicRama.Models;

namespace MusicRama.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login (string username,string password,string returnurl)
        {
            UserManager manager = new UserManager();
            var loggedInUser = manager.Login(username,password);

            string decodeurl = null;
            if (!string.IsNullOrEmpty(returnurl))
                decodeurl = Server.UrlDecode(returnurl);

            if(loggedInUser != null)
            {
                Session["user"] = loggedInUser;

                ViewBag.Name = loggedInUser.Username;
                return Redirect(decodeurl ?? "/home/Index");
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}