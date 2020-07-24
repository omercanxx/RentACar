using ProjeRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjeRentACar.Controllers
{
    public class AdminController : Controller
    {
        rentACarEntities1 db = new rentACarEntities1();
        // GET: Admin
        public ActionResult login()
        {
            if (User.Identity.Name != "")
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }
        [HttpPost]
        public ActionResult login(Admin admin)
        {
            if (admin.Email != null)
            {
                if (admin.Sifre != null)
                {
                    var bilgi = db.Admin.FirstOrDefault(m => m.Email == admin.Email && m.Sifre == admin.Sifre);
                    if (bilgi != null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(bilgi.id.ToString(), false);
                        //true olursa tekrar girisinde uye girisini sormayacak
                        return RedirectToAction("Index", "Arac");
                    }
                    else
                    {
                        ViewBag.uyari = "Bilgilerinizi kontrol ediniz";
                    }
                }
                else
                {
                    ViewBag.uyari = "Sifrenizi yaziniz";
                }
            }
            else
            {
                ViewBag.uyari = "Email adresini yaziniz";
            }
            return View();
        }

    }
}