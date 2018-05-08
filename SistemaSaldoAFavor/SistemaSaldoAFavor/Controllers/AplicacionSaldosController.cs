using SistemaSaldoAFavor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaSaldoAFavor.Controllers
{
    public class AplicacionSaldosController : Controller
    {
        // GET: AplicacionSaldos
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicarSaldo(SaldosAFavor oSaldoAFavor)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}