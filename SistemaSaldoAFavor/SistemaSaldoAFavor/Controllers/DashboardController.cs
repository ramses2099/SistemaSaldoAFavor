using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaSaldoAFavor.Service;
using SistemaSaldoAFavor.Models;

namespace SistemaSaldoAFavor.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        //
        [HttpPost]
        public ActionResult LoadData()
        {
            
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


            //column search
            var recibo = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            var fecha = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            var rnc = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            var cliente = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();

            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            
            // Getting all Customer data    
            var customerData = ServiceSaldoAFavor.GetAll();
                      

            //Search recibo   
            if (!string.IsNullOrEmpty(recibo))
            {
               customerData = customerData.Where(m => m.Recibo.Contains(recibo.ToUpper())).ToList();
            }            
            //Search fecha   
            if (!string.IsNullOrEmpty(fecha))
            {
                customerData = customerData.Where(m => m.Fecha.Contains(fecha.ToUpper())).ToList();
            }
            //Search rnc   
            if (!string.IsNullOrEmpty(rnc))
            {
                customerData = customerData.Where(m => m.RNC.Contains(rnc)).ToList();
            }
            //Search cliente   
            if (!string.IsNullOrEmpty(cliente))
            {
                customerData = customerData.Where(m => m.Cliente.Contains(cliente)).ToList();
            }
            //
            
            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m => m.Cliente.Contains(searchValue)).ToList();
            }
            //
            

            //total number of rows count     
            recordsTotal = customerData.Count();
            //Paging     
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
          


        }
        //
    }
}