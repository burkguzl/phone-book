using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelefonRehberi.Core;

namespace TelefonRehberi.Entities
{
    public class Admin:IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")][MinLength(6,ErrorMessage = "Şifreniz en az 6 karekter içermelidir.")][DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}