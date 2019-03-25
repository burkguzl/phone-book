using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelefonRehberi.Core;

namespace TelefonRehberi.Entities
{
    public class Departman : IEntity
    {
        [Key]
        [Display(Name = "Id")]
        public int DepartmanId { get; set; }
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }

        public List<Calisan> Calisanlar { get; set; }
    }
}