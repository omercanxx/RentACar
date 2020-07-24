using ProjeRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ProjeRentACar.Controllers
{
    [_AdminController]
    public class AracController : Controller
    {
        rentACarEntities1 db = new rentACarEntities1();
        // GET: Arac
        public ActionResult Index()
        {
            var model = db.Arac.ToList();
            return View(model);
        }
        public ActionResult aracEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult aracEkle(Arac arac, HttpPostedFileBase dosya)
        {
            ViewBag.uyari = "";
            if ((arac.Plaka != null) && (arac.Marka != null))
            {
                var eskiPlaka = db.Arac.FirstOrDefault(m => m.Plaka == arac.Plaka);
                arac.img = "";
                if (eskiPlaka == null)
                {
                    if(dosya != null)
                    {
                        String uzanti = dosya.FileName;
                        uzanti = uzanti.Substring(uzanti.LastIndexOf("."));

                        var dosyaTanim = Path.GetFileName(dosya.FileName);
                        var klasor = Path.Combine(Server.MapPath("~/images"), dosyaTanim);
                        dosya.SaveAs(klasor);
                        arac.img = "~/images/" + dosya.FileName;
                    }
                    arac.Durum = "Aktif";
                    db.Arac.Add(arac);
                    db.SaveChanges();
                    Session["uyari"] = "Degisiklikler kaydedildi";
                }
                else
                {
                    Session["uyari"] = "Girdiğiniz plaka mevcut";
                }
            }
            else
            {
                Session["uyari"] = "Alanlar boş";
            }
            
            return RedirectToAction("Arac","Arac");
        }
        public ActionResult Arac()
        {
            List<object> drm = new List<object>();

            drm.Add(new SelectListItem { Text = "Aktif", Value = "Aktif" });
            drm.Add(new SelectListItem { Text = "Pasif", Value = "Pasif" });

            ViewBag.durumlar = drm;

            List<object> vites = new List<object>();

            vites.Add(new SelectListItem { Text = "Düz", Value = "Düz" });
            vites.Add(new SelectListItem { Text = "Otomatik", Value = "Otomatik" });

            ViewBag.vites = vites;

            List<object> yakit = new List<object>();
            yakit.Add(new SelectListItem { Text = "Benzin", Value = "Benzin" });
            yakit.Add(new SelectListItem { Text = "Dizel", Value = "Dizel"});
            yakit.Add(new SelectListItem { Text = "LPG", Value = "LPG" });
            yakit.Add(new SelectListItem { Text = "Hibrit", Value = "Hibrit" });

            ViewBag.yakit = yakit;
            var model = db.Arac.ToList();
            return View(model);
        }


        [HttpPost]
        public JsonResult guncelle(Arac arac)
        {
            var degisim = db.Arac.Find(arac.id);

            degisim.Marka = arac.Marka;
            degisim.Plaka = arac.Plaka;
            degisim.Yıl = arac.Yıl;
            if(arac.Yakıt_tipi != null)
            {
                degisim.Yakıt_tipi = arac.Yakıt_tipi;
            }
            if(arac.Vites != null)
            {
                degisim.Vites = arac.Vites;
            }
            if (arac.Durum != null)
            {
                degisim.Durum = arac.Durum;
            }
            db.SaveChanges();
            return Json("Degistirme islemi tamamlandi", JsonRequestBehavior.AllowGet);
        }
        public JsonResult sil(int id)
        {
            var silinecekData = db.Arac.Find(id);

            db.Arac.Remove(silinecekData);

            db.SaveChanges();

            return Json("Silme işlemi tamamlandı.", JsonRequestBehavior.AllowGet);
        }
        public JsonResult fotoDegistir(int id)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase dosya = Request.Files[i];

                int dosyaMB = dosya.ContentLength;
                string dosyaTanim = dosya.FileName;
                string mimeTip = dosya.ContentType;

                dosya.SaveAs(Server.MapPath("~/images/") + dosyaTanim);

                var degisim = db.Arac.Find(id);
                degisim.img = "~/images/" + dosyaTanim;
                db.SaveChanges();
            }

            return Json("Ok", JsonRequestBehavior.AllowGet);

        }
    }
}