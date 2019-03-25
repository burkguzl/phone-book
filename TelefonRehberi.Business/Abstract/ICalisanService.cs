using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Abstract
{
    public interface ICalisanService
    {
        IEnumerable<Calisan> GetAll();
        IEnumerable<Calisan> GetAll(params Expression<Func<Calisan, object>>[] includes);
        IEnumerable<Calisan> GetByDepartman(int departmanId);
        Calisan GetByYoneticiId(int? yoneticiId);
        Calisan GetById(int? calisanId, params Expression<Func<Calisan, object>>[] includes);
        Calisan GetById(int? calisanId);
        void Add(Calisan calisan);
        void Delete(int calisanId);
        void Update(Calisan calisan);

    }
}
