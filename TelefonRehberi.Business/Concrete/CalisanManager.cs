using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Concrete
{
    public class CalisanManager : ICalisanService
    {
        private ICalisanDal _calisanDal;
        

        public CalisanManager(ICalisanDal calisanDal)
        {
            _calisanDal = calisanDal;
        }

        public void Add(Calisan calisan)
        {
            _calisanDal.Add(calisan);
        }

        public void Delete(int calisanId)
        {
            _calisanDal.Delete(new Calisan(){CalisanId = calisanId});
        }

        public IEnumerable<Calisan> GetAll()
        {
            return _calisanDal.GetList();
        }

        public IEnumerable<Calisan> GetAll(params Expression<Func<Calisan, object>>[] includes)
        {
            return _calisanDal.GetList(null, includes);
        }

        public IEnumerable<Calisan> GetByDepartman(int departmanId)
        {
            return _calisanDal.GetList(i => i.DepartmanId == departmanId);
        }

        public Calisan GetById(int? calisanId)
        {
            return _calisanDal.Get(i => i.CalisanId == calisanId);
        }

        public Calisan GetById(int? calisanId, params Expression<Func<Calisan, object>>[] includes)
        {
            return _calisanDal.Get(i => i.CalisanId == calisanId, includes);
        }

        public Calisan GetByYoneticiId(int? yoneticiId)
        {
            return _calisanDal.Get(i => i.CalisanId == yoneticiId);
        }

        public void Update(Calisan calisan)
        {
            _calisanDal.Update(calisan);
        }

      }
}