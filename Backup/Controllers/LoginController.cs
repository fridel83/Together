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

        private CreateAccountViewModel view = new CreateAccountViewModel() ;


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


        public ActionResult AjouterUserInfo()
        {
            TogetherUsersSet user = new TogetherUsersSet();
            return View(user);
        }

        [HttpPost]
        public ActionResult AjouterUserInfo(TogetherUsersSet user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            using (ITogetherDal dal = new TogetherDal() )
            {
                user.actif = false;
                user.password = dal.encodeStringMD5(user.password);
                int IdUser =dal.ajouterUser(user);
                FormsAuthentication.SetAuthCookie(IdUser.ToString(), true);
                return View("enregistrementOK");
            }
        }

     
        public ActionResult AjouterHomeAdresseInfo()
        {
            AdressesSet adresse = new AdressesSet();
            return View(adresse);
        }

        public ActionResult AjouterWorkAdresseInfo()
        {
            AdressesSet adresse = new AdressesSet();
            return View(adresse);
        }

        [HttpPost]
        public ActionResult AjouterHomeAdresseInfo(AdressesSet adresse)
        {
            if (!ModelState.IsValid)
            {
                return View(adresse);
            }
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                int IdUser;
                if (Int32.TryParse(HttpContext.User.Identity.Name, out IdUser))
                {
                    adresse.TogetherUsersSet = dal.obtenirUserByUserId(IdUser); ;
                    AdressesSet_HomeAdress myhome = new AdressesSet_HomeAdress { AdressesSet = adresse };
                    dal.saveHomeAdress(myhome);
                }
            }
            return View("AjouterWorkAdresseInfo");
        }

        [HttpPost]
        public ActionResult AjouterWorkAdresseInfo(AdressesSet adresse)
        {
            if (!ModelState.IsValid)
            {
                return View(adresse);
            }
            using (ITogetherDal dal = new TogetherDal())
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    int IdUser;
                    if (Int32.TryParse(HttpContext.User.Identity.Name, out IdUser))
                    {
                        adresse.TogetherUsersSet = dal.obtenirUserByUserId(IdUser);
                        AdressesSet_WorkAdress mywork = new AdressesSet_WorkAdress { AdressesSet = adresse };
                        dal.saveWorkAdress(mywork);
                    }
                }
            }
            return View("enregistrementOK", "Home");
        }

        // GET: Home/Details/5
        public ActionResult AjouterUser()
        {
            dal = new RoadBetterTogether.Models.TogetherDal();
            TogetherUsersSet user = new TogetherUsersSet();
            TogetherCarsSet car = new TogetherCarsSet();
            AdressesSet home = new AdressesSet();
            AdressesSet work = new AdressesSet();
            List<string> listeMarques = new List<string>
            {
                "bmw",
                "mercedes",
                "audi",
                "peugeot",
                "renault",
                "ford",
                "alpha romeo"
            };
            CreateAccountViewModel vuew = new CreateAccountViewModel();
            vuew.user = user;
            vuew.work = work;
            vuew.home = home;
            //vuew.car = car;
            ViewBag.listmark = new SelectList(listeMarques);
            return View(vuew);
        }

        [HttpPost]
        public ActionResult AjouterUser(CreateAccountViewModel vue)
        {
            using (ITogetherDal dal = new TogetherDal())
            {
                if (!ModelState.IsValid)
                {
                    List<string> listeMarques = new List<string>
                    {
                        "bmw",
                        "mercedes",
                        "audi",
                        "peugeot",
                        "renault",
                        "ford",
                        "alpha romeo"
                    };
                    CreateAccountViewModel vuew = new CreateAccountViewModel();
                    vuew.user = vue.user;
                    vuew.work = vue.work;
                    vuew.home = vue.home;
                    //vuew.car = vue.car;
                    ViewBag.listmark = new SelectList(listeMarques);
                    return View(vuew);
                }
                vue.user.actif = true;
                vue.user.password = dal.encodeStringMD5(vue.user.password);
                int idUser = dal.ajouterUser(vue.user);
                TogetherUsersSet_TogetherDrivers rel = new TogetherUsersSet_TogetherDrivers { TogetherUsersSet = vue.user };
                int idDriver = dal.saveTogetherUsersSet_TogetherDrivers(rel);
                vue.home.TogetherUsersSet = vue.user;
                vue.work.TogetherUsersSet = vue.user;
                AdressesSet_HomeAdress myhome = new AdressesSet_HomeAdress { AdressesSet = vue.home };
                AdressesSet_WorkAdress mywork = new AdressesSet_WorkAdress { AdressesSet = vue.work };
                dal.saveHomeAdress(myhome);
                dal.saveWorkAdress(mywork);
                /*
                if (vue.user.goingMode)
                {
                    rel.TogetherCarsSet.Add(vue.car);
                    dal.saveCar(vue.car);
                }
                */
                return View("enregistrementOK");
            }
        }
    }
}