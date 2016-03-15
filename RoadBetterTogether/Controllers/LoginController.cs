using RoadBetterTogether.Models;
using RoadBetterTogether.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RoadBetterTogether.Controllers
{
    public class LoginController : Controller
    {
        private ITogetherDal dal;
        // GET: Login

        public ActionResult Login()
        {
            UserAutenticate aut = new UserAutenticate();
            return View(aut);
        }

        [HttpPost]
        public ActionResult Login(UserAutenticate aut, string returnUrl)
        {
            string login = aut.login;
            string mdp = aut.mdp;
            if (!ModelState.IsValid)
            {
                UserAutenticate monuser = new UserAutenticate();
                return View(monuser);
            }
            using (ITogetherDal dal = new TogetherDal())
            {
                TogetherUsersSet user = dal.autentifier(login, mdp);
                ViewBag.user = user;
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        Redirect(returnUrl);
                    return View("User");
                }
                else
                {
                    ModelState.AddModelError("login", "Login et/ou mot de passe incorrect");
                    ModelState.AddModelError("mdp", "Login et/ou mot de passe incorrect");
                }
                return View();
            }
        }
    }
}