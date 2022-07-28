using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationlean.DAL;
using WebApplicationlean.Models;

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

        public ActionResult deletuser(int id) {

            var data = medDaL.Getusersbyid(id).FirstOrDefault();
            return View(data);
        
        }
        [HttpPost]
        public ActionResult deletuser(int id , Userregmodel1 mod)
        {
            bool Isdeleted = false;
            try
            {
               // String na = mod.Name.ToString();


                    Isdeleted = medDaL.deleteuserbyid(id);
                    if (Isdeleted)
                    {
                        TempData["SuccessMessage"] = "Delete Success";
                    }
                    else
                    {
                        TempData["ErroMessage"] = "Delete fail";
                    }


                    return RedirectToAction("Medecines");
               
                 
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
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
        public ActionResult MedecineCreate()
        {
            return View();
        }
        // POST: med/Create
        [HttpPost]
        public ActionResult MedecineCreate(modelofmedecine med)
        {
            bool Isinserted = false;
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
                else
                {
                    TempData["ErroMessage"] = "model error";
                }



                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }


        public ActionResult MedecineDelete(int id)
        {
            var data = medDaL.GetMedecinesbyID(id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult MedecineDelete(int id,modelofmedecine mr)
        {
            bool Isdeleted = false;
            try
            {

                Isdeleted = medDaL.Deletemeds(id);
                if (Isdeleted)
                {
                    TempData["SuccessMessage"] = "Delete Success";
                }
                else
                {
                    TempData["ErroMessage"] = "Delete fail";
                }


                return RedirectToAction("Medecines");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult MedecineEdit (int id)
        {
            var data = medDaL.GetMedecinesbyID(id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult MedecineEdit(modelofmedecine med)
        {

            bool Isinserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Isinserted = medDaL.Updatemeds(med);
                    if (Isinserted)
                    {
                        TempData["SuccessMessage"] = "saved data";
                    }
                    else
                    {
                        TempData["ErroMessage"] = "fail";
                    }
                }



                return RedirectToAction("Medecine");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }

    }
}