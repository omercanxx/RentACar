using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeRentACar.Controllers
{
    [_AdminController]
    public class OyunController : Controller
    {
        // GET: Oyun
        public ActionResult TasKagitMakas()
        {
            return View();
        }
        public ActionResult xox()
        {
            return View();
        }
    }
}