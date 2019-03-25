using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace TelefonRehberi.MvcWebUI.Models.Giris
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter içermelidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}