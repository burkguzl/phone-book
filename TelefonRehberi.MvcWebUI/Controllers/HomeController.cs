using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Entities;
using TelefonRehberi.MvcWebUI.Models;

namespace TelefonRehberi.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICalisanService _calisanService;
        private IDepartmanService _departmanService;

        public HomeController(ICalisanService calisanService, IDepartmanService departmanService)
        {
            _calisanService = calisanService;
            _departmanService = departmanService;
        }



        public ActionResult Index()
        {
            var calisanlar = _calisanService.GetAll().Select(i => new HomeViewModel()
            {
                CalisanId = i.CalisanId,
                Ad = i.Ad,
                Telefon = i.Telefon
            });

            return View(calisanlar.ToList());
        }


        public ActionResult Detay(int? id)
        {
            var calisan = _calisanService.GetById(id, i => i.Departman);
            var calisanlar = _calisanService.GetAll();

            var model = new HomeDetayViewModel()
            {
                Calisan = calisan,
                Calisanlar = calisanlar
            };

            return View(model);
        }
    }
}