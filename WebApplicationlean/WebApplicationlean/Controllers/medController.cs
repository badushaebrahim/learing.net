using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationlean.DAL;
using WebApplicationlean.Models;

namespace WebApplicationlean.Controllers
{
    public class medController : Controller
    {

        DAlofmedecine medDaL = new DAlofmedecine();
        // GET: med
        public ActionResult Index()
        {
            var medlist = medDaL.GetMedecines();
            return View(medlist);
        }

        // GET: med/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: med/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: med/Create
        [HttpPost]
        public ActionResult Create(modelofmedecine med)
        {
            bool Isinserted =false;
            try
            {
                if (ModelState.IsValid)
                {
                    Isinserted = medDaL.Insertmeds(med);
                    if (Isinserted)
                    {
                        TempData["SuccessMessage"] = "saved data";
                    }
                    else
                    {
                        TempData["ErroMessage"] = "fail";
                    }
                }
                


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }

        // GET: med/Edit/5
        public ActionResult Edit(int id)
        {
            var meditem = medDaL.GetMedecinesbyID(id).FirstOrDefault();
            return View(meditem);
        }

        // POST: med/Edit/5
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

        // GET: med/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: med/Delete/5
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
