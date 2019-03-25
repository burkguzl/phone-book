using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.MvcWebUI.Models.Giris
{
    public class LoginSifremiUnuttumViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girilmesi zorunludur.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Eposta adresi girilmesi zorunludur.")][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}