using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccess.Concrete
{
    public class SeedData:DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            
            List<Departman> departmanlar = new List<Departman>()
            {
                new Departman(){Ad = "Bilgi İşlem", Aciklama = "Bilgi işlem departmanı"},
                new Departman(){Ad = "Programlama", Aciklama = "Programlama departmanı"},
                new Departman(){Ad = "İnsan Kaynakları", Aciklama = "İnsan kaynakları departmanı"},
                new Departman(){Ad = "Muhasebe ve Finans", Aciklama = "Muhasebe ve finans departmanı"},
                new Departman(){Ad = "Masaüstü Yazılımlar", Aciklama = "Masaüstü yazılımlar departmanı"},
                new Departman(){Ad = "Web Yazılımlar", Aciklama = "Web yazılımlar departmanı"},

            };

            foreach (var departman in departmanlar)
            {
                context.Departmanlar.Add(departman);
            }

            context.SaveChanges();

            List<Calisan> calisanlar = new List<Calisan>()
            {
                new Calisan(){Ad = "Burak",Soyad = "Güzel", DepartmanId = 6, Telefon = "05555555555"},
                new Calisan(){Ad = "Ahmet",Soyad = "Selim", DepartmanId = 5, Telefon = "0588255555", YoneticiId = 1},
                new Calisan(){Ad = "Murat",Soyad = "Yaşayan", DepartmanId = 5, Telefon = "05543255555", YoneticiId = 1},
                new Calisan(){Ad = "Ali",Soyad = "Yücesoy", DepartmanId = 4, Telefon = "05555554325"},
                new Calisan(){Ad = "Fevzi",Soyad = "Yurt", DepartmanId = 1, Telefon = "05555325555", YoneticiId = 4},
                new Calisan(){Ad = "Sinem",Soyad = "Ulusoy", DepartmanId = 6, Telefon = "05321555555", YoneticiId = 1},
                new Calisan(){Ad = "Merve",Soyad = "Gök", DepartmanId = 6, Telefon = "05555555435", YoneticiId = 4},
                new Calisan(){Ad = "Selim",Soyad = "Saymaz", DepartmanId = 6, Telefon = "05555554335", YoneticiId = 10},
                new Calisan(){Ad = "Burak",Soyad = "Başaranoğlu", DepartmanId = 3, Telefon = "05543224555"},
                new Calisan(){Ad = "Aslı",Soyad = "Tekinalp", DepartmanId = 2, Telefon = "05555544355", YoneticiId = 1},

            };

            foreach (var calisan in calisanlar)
            {
                context.Calisanlar.Add(calisan);
            }

            context.SaveChanges();

            Admin admin = new Admin
            {
                Username = "admin",
                Password = "123456",
                Email = "burakguzel@outlook.com"
            };

            context.Admin.Add(admin);

            context.SaveChanges();


            base.Seed(context);
        }
    }
}