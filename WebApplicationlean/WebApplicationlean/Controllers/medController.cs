using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplicationlean.DAL;
using WebApplicationlean.Models;

namespace WebApplicationlean.Controllers
{
    public class medController : Controller
    {

        DAlofmedecine medDaL = new DAlofmedecine();


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            return RedirectToAction("Login");
        }
        // POST: med/Create
        [HttpPost]
        public ActionResult Register(Userregmodel1 usr)
        {
            bool Isinserted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    Isinserted = medDaL.Rgisternewuer(usr);
                    if (Isinserted)
                    {
                        TempData["SuccessMessage"] = "register complete";
                       
                    }
                }
                else
                {
                    TempData["ErroMessage"] = "model fail in register";
                 

                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Login");
            }
           
        }
        //login view
        public ActionResult Login()
        {
            return View();
        }
        //login request
        [HttpPost]
        public ActionResult Login(userloginmodel usr)
        {
            String res;

            try
            {
                if (ModelState.IsValid)
                {
                     res = medDaL.Userlogin(usr);
                      if (res != "F")
                      {
                        TempData["SuccessMessage"] = res;
                        Session["userid"] = res;
                        
                    }
                    else
                    {
                        TempData["ErroMessage"] = "not model ";
                        return View();

                    }
                }
                else
                {
                    TempData["ErroMessage"] = "model fail in register";
                    return View();



                }
                return RedirectToAction("Index");
               
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


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
                else
                {
                    TempData["ErroMessage"] = "model error";
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
        public ActionResult Edit(modelofmedecine med)
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



                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }

        // GET: med/Delete/5
        public ActionResult Delete(int id)
        {
            var meditem = medDaL.GetMedecinesbyID(id).FirstOrDefault();
            return View(meditem);
        }

        // POST: med/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,modelofmedecine med)
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
           



                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return View();
            }
        }
    }
}
