using RoadBetterTogether.Models;
using RoadBetterTogether.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Security.Cryptography;
using System;
using System.Text;


namespace RoadBetterTogether.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private RoadBetterTogether.Models.ITogetherDal dal;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        


        // GET: Home/Details/5
        [AllowAnonymous]
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

        [AllowAnonymous]
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
                TogetherUsersSet_TogetherDrivers rel = new TogetherUsersSet_TogetherDrivers { TogetherUsersSet = vue.user  };
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

        

        

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
