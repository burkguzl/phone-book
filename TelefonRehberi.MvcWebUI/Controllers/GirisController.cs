using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.MvcWebUI.Models.Giris;
using System.Net.Mail;
using System.Text;

namespace TelefonRehberi.MvcWebUI.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris

        private IAdminService _adminService;

        public GirisController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_adminService.SignUp(model.Username, model.Password))
                {
                    return Redirect(model.ReturnUrl == null ? "/Calisan/Liste" : model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya sifre");
                    return View(model);
                }
            }
            else
            {

                return View(model);
            }

        }

        public ActionResult SifremiUnuttum()
        {
            var model = new LoginSifremiUnuttumViewModel();
            ViewBag.Status = false;
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SifremiUnuttum(LoginSifremiUnuttumViewModel model)
        {

            if (ModelState.IsValid)
            {
                var calisan = _adminService.FindByUsernameAndEmail(model.Username, model.Email);
                if (calisan != null)
                {
                    var body = new StringBuilder();
                    body.AppendLine("Username: " + calisan.Username);
                    body.AppendLine("Email: " + calisan.Email);
                    body.AppendLine("Parola: " + calisan.Password);

                    var mailSender = new MailSender();
                    mailSender.MailGonder(body.ToString());

                    ViewBag.Status = true;
                    return View(model);
                }

                else
                {
                    ViewBag.Status = false;
                    ModelState.AddModelError("", "Bu kullanıcı adı ve email adresine sahip bir hesap bulunamadı.");
                    return View(model);
                }

            }

            ViewBag.Status = false;
            return View(model);
        }

    }
}