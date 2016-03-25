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
