using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Entities;
using TelefonRehberi.MvcWebUI.Models;
using TelefonRehberi.MvcWebUI.Models.Giris;

namespace TelefonRehberi.MvcWebUI.Controllers
{
    [LoginControl]
    public class DepartmanController : Controller
    {
        // GET: Departman
        private ICalisanService _calisanService;
        private IDepartmanService _departmanService;

        public DepartmanController(ICalisanService calisanService, IDepartmanService departmanService)
        {
            _calisanService = calisanService;
            _departmanService = departmanService;
        }

        public ActionResult Liste()
        {
            var model = new DepartmanViewModel
            {
                Departmanlar = _departmanService.GetAll()
            };
            return View(model);
        }

        public ActionResult Duzenle(int? id)
        {
            var departman = _departmanService.GetById(id);

            var model = new DepartmanDuzenleViewModel
            {
                Departman = departman
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(DepartmanDuzenleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _departmanService.Update(model.Departman);
                TempData.Add("message", String.Format("Departman Id {0} olan kaydınız güncellendi!", model.Departman.DepartmanId));
                return RedirectToAction("Liste");
            }

            else
            {
                ModelState.AddModelError("", "Güncelleme başarısız.");

                return View(model);
            }


        }



        public ActionResult Sil(int? id)
        {

            var calisanlar = _calisanService.GetAll();
            var silinecekDepartman = _departmanService.GetById(id);
            foreach (var calisan in calisanlar)
            {
                if (calisan.DepartmanId == id)
                {
                    TempData.Add("message", String.Format("İçerisinde çalışan barındıran departman silinemez!"));
                    return RedirectToAction("Liste");
                }
            }

            TempData.Add("message", String.Format("{0} numaralı Id ye sahip, {1} isimli departman silinmiştir!", silinecekDepartman.DepartmanId, silinecekDepartman.Ad));
            _departmanService.Delete(silinecekDepartman.DepartmanId);
            return RedirectToAction("Liste");
        }

        public ActionResult Kayit()
        {
            var model = new DepartmanKayitViewModel
            {
                Departman = new Departman()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(DepartmanKayitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _departmanService.Add(model.Departman);
                TempData.Add("message", String.Format("{0} adlı departman kaydınız eklenmiştir.", model.Departman.Ad));
                return RedirectToAction("Liste");
            }
            else
            {
                ModelState.AddModelError("", "Departman kaydınız oluşturulamadı!");

                return View(model);
            }


        }
    }
}