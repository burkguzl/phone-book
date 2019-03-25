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
    public class CalisanController : Controller
    {
        private ICalisanService _calisanService;
        private IDepartmanService _departmanService;

        public CalisanController(ICalisanService calisanService, IDepartmanService departmanService)
        {
            _calisanService = calisanService;
            _departmanService = departmanService;
        }

        public ActionResult Liste()
        {
            var calisanlar = _calisanService.GetAll(i => i.Departman);
            var model = new CalisanViewModel()
            {
                Calisanlar = calisanlar
            };

            return View(model);
        }

        public ActionResult Duzenle(int? id)
        {
            var calisan = _calisanService.GetById(id);

            var model = new CalisanDuzenleViewModel
            {
                Calisan = calisan,
                Calisanlar = _calisanService.GetAll(),
                Departmanlar = _departmanService.GetAll()

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(CalisanDuzenleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _calisanService.Update(model.Calisan);
                TempData.Add("message", String.Format("Calisan Id {0} olan kaydınız güncellendi!", model.Calisan.CalisanId));
                return RedirectToAction("Liste");
            }

            else
            {
                ModelState.AddModelError("", "Güncelleme başarısız.");
                model.Calisanlar = _calisanService.GetAll();
                model.Departmanlar = _departmanService.GetAll();
                return View(model);
            }


        }


        public ActionResult Sil(int? id)
        {
            var calisanlar = _calisanService.GetAll();
            var silinecekCalisan = _calisanService.GetById(id);
            foreach (var calisan in calisanlar)
            {
                if (calisan.YoneticiId == id)
                {
                    TempData.Add("message", String.Format("Yönetici olan çalışan kayıtları silinemez!"));
                    return RedirectToAction("Liste");
                }
            }

            TempData.Add("message", String.Format("{0} numaralı Id ye sahip, {1} isimli üyeniz silinmiştir!", silinecekCalisan.CalisanId, silinecekCalisan.Ad));
            _calisanService.Delete(silinecekCalisan.CalisanId);
            return RedirectToAction("Liste");
        }

        public ActionResult Kayit()
        {
            var model = new CalisanKayitViewModel
            {
                Calisanlar = _calisanService.GetAll(),
                Departmanlar = _departmanService.GetAll(),
                Calisan = new Calisan()

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(CalisanKayitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _calisanService.Add(model.Calisan);
                TempData.Add("message", String.Format("{0} adlı çalışan kaydınız eklenmiştir.", model.Calisan.Ad));
                return RedirectToAction("Liste");
            }
            else
            {
                ModelState.AddModelError("", "Çalışan kaydınız oluşturulamadı!");
                model.Calisanlar = _calisanService.GetAll();
                model.Departmanlar = _departmanService.GetAll();
                return View(model);
            }


        }


    }
}