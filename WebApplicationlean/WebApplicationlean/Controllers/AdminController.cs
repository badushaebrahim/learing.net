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
            var data = medDaL.GetMedecines();
            return View(data);
        }

        public ActionResult medecines()
        {
            var data = medDaL.GetMedecines();
            return View(data);
        }


        public ActionResult inventory()
        {
            return View();
        }

        public ActionResult supplier()
        {
            var data = medDaL.Getsupply();
            return View(data);
        }



    }
}