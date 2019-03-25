using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Entities;

namespace TelefonRehberi.MvcWebUI.Models
{
    public class CalisanKayitViewModel
    {
        public Calisan Calisan { get; set; }
        public IEnumerable<Departman> Departmanlar { get; set; }
        public IEnumerable<Calisan> Calisanlar { get; set; }
    }
}