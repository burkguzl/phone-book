using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelefonRehberi.Core;

namespace TelefonRehberi.Entities
{
    public class Calisan:IEntity
    {
        [Key][Display(Name = "Id")]
        public int CalisanId { get; set; }
        [Display(Name = "Departman")]
        public int DepartmanId { get; set; }
        [Display(Name = "Yönetici")]
        public int? YoneticiId { get; set; }
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")][DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        public string Telefon { get; set; }
        

        public Departman Departman { get; set; }

    }
}