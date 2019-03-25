using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using TelefonRehberi.Entities;

namespace TelefonRehberi.MvcWebUI.Models
{
    public class HomeDetayViewModel
    {
        public Calisan Calisan { get; set; }
        public IEnumerable<Calisan> Calisanlar { get; set; }
        
    }
}