using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationlean.DAL;
using WebApplicationlean.Models;

namespace WebApplicationlean.Controllers
{
    public class HomeController : Controller
    {
        DAlofmedecine medDaL = new DAlofmedecine();
        public ActionResult Home()
        {
            return View();
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
           

            try
            {
                if (ModelState.IsValid)
                {
                    var res = medDaL.Userlogin(usr);

                  /*  if (res[0].Role.ToString()== "fail")
                    {
                        TempData["SuccessMessage"] = res;
                        Session["userid"] = res[0].uid.ToString();

                    }
                    else*/ if (res[0].Role.ToString() == "Pharmasist")
                    {
                        //TempData["SuccessMessage"] = res;
                        Session["userid"] = res[0].uid.ToString();
                        return RedirectToAction("Index", "med");
                    }
                    else if (res[0].Role.ToString() == "Admin")
                    {
                        TempData["SuccessMessage"] = res;
                        Session["userid"] = res[0].uid.ToString();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        TempData["ErroMessage"] = "Invalid Email/Password";
                        return View();

                    }
                }
                else
                {
                    TempData["ErroMessage"] = "Invalid Data error";
                    return View();



                }
                return RedirectToAction("Index", "med");

            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message+"modelerror";
                return RedirectToAction("Index");
            }
           
        }


        public ActionResult Register()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            return RedirectToAction("Home");
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

                    return View();
                }
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Login");
            }

        }
    }
}