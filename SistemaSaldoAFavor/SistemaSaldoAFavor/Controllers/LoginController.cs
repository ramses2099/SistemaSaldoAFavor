using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaSaldoAFavor.Models;
using SistemaSaldoAFavor.Service;

namespace SistemaSaldoAFavor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Dashboard");
            } else {
                return View();
            }
                       
        }

        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAutenticate(User oUser)
        {
            if (ModelState.IsValid) {
                String StUsuario = ServiceUser.GetAutenctication(oUser.UserName, oUser.Pwd);
                if (String.IsNullOrEmpty(StUsuario))
                {
                    ViewBag.Message = "Error, Usuario y Clave Incorrecta!!!";
                    return View("~/Views/Login/index.cshtml");
                }
                else {
                    Session["Usuario"] = StUsuario;
                    return View("~/Views/Dashboard/index.cshtml");
                }
                
            }
            return View("~/Views/Login/index.cshtml");
        }

    }
}