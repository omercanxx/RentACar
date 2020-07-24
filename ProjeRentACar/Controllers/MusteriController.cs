using ProjeRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeRentACar.Controllers
{
    [_AdminController]
    public class MusteriController : Controller
    {
        // GET: Musteri
        rentACarEntities1 db = new rentACarEntities1();
        // GET: Arac
        public ActionResult Index()
        {

            var model = db.Musteri.ToList();
            return View(model);
        }
        public ActionResult musteriEkle()
        {
            var sListe = db.Sehir.ToList();
            ViewBag.sehir = sListe;
            ViewBag.maxYil = DateTime.Now.Year;
            Int32 sehirid = sListe[0].sehir_id;
            ViewBag.ilce = db.ilce.Where(m => m.sehir_id == sehirid).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult musteriEkle(Musteri musteri)
        {
            ViewBag.uyari = "";
            if ((musteri.Ad_Soyad != null))
            {       
                    db.Musteri.Add(musteri);
                    db.SaveChanges();
                    Session["uyari"] = "Degisiklikler kaydedildi";
            }
            else
            {
                Session["uyari"] = "Alanlar boş";
            }
            return RedirectToAction("Musteri", "Musteri");
        }
        public ActionResult Musteri()
        {
            var model = db.Musteri.ToList();
            return View(model);
        }


        [HttpPost]
        public JsonResult guncelle(Musteri musteri)
        {
            var degisim = db.Musteri.Find(musteri.id);

            degisim.Ad_Soyad = musteri.Ad_Soyad;
            degisim.Email = musteri.Email;
            degisim.Dogum_Yili = musteri.Dogum_Yili;
            degisim.Telefon = musteri.Telefon;

            db.SaveChanges();
            return Json("Degistirme islemi tamamlandi", JsonRequestBehavior.AllowGet);
        }
        public JsonResult sil(int id)
        {
            var silinecekData = db.Musteri.Find(id);

            db.Musteri.Remove(silinecekData);

            db.SaveChanges();

            return Json("Silme işlemi tamamlandı.", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ilceler(int id)
        {
            var iListe = db.ilce.Where(m => m.sehir_id == id).ToList();
            return Json(iListe, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ilceList(int id)
        {

            List<ilce> ilceList = db.ilce.Where(x => x.sehir_id == id).OrderBy(x => x.ilce_adi).ToList();
            List<SelectListItem> itemList = (from i in ilceList
                                             select new SelectListItem
                                             {
                                                 Value = i.ilce_id.ToString(),
                                                 Text = i.ilce_adi

                                             }).ToList();
            return Json(itemList, JsonRequestBehavior.AllowGet);
                                            
        }
    }
}