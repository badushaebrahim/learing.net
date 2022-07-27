using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationlean.DAL;

namespace WebApplicationlean.Controllers
{
    public class AdminController : Controller
    {
        DAlofmedecine medDaL = new DAlofmedecine();
        // GET: Admin
        public ActionResult Index()
        {
            var data = medDaL.Getusersall();
            return View(data);
        }



        public ActionResult inventory()
        {
            var data = medDaL.GetInventoryAll();
            return View(data);
        }

        public ActionResult supplier()
        {
            var data = medDaL.Getsupply();
            return View(data);
        }

        public ActionResult Medecines()
        {
            var data = medDaL.GetMedecines();
            return View(data);
        }
        public ActionResult MedecineDelete(int id)
        {
            var data = medDaL.GetMedecinesbyID(id);
            return View(data);
        }

    }
}