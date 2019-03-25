using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Entities;

namespace TelefonRehberi.MvcWebUI.Models
{
    public class CalisanViewModel
    {
        public IEnumerable<Calisan> Calisanlar { get; set; }
        
    }
}