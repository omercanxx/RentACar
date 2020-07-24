using ProjeRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeRentACar.Controllers
{
    public class kategorilerController : Controller
    {
        rentACarEntities1 db = new rentACarEntities1();

        public ActionResult Index()
        {
            var model = db.Sehir.ToList();
            return View(model);
        }
        public ActionResult ilce(int id)
        { 
            var model = db.Sehir.Where(m => m.sehir_id == id).ToList();
            ViewBag.sehirID = id;
            return View(model);

        } 
    }
}