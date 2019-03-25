using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccess.Concrete
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("databaseConnection")
        {
            //seeddata
            Database.SetInitializer(new SeedData());
        }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}