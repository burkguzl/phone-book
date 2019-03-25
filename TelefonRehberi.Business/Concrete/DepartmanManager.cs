using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        private IDepartmanDal _departmanDal;

        public DepartmanManager(IDepartmanDal departmanDal)
        {
            _departmanDal = departmanDal;
        }

        public void Add(Departman departman)
        {
            _departmanDal.Add(departman);
        }

        public void Delete(int departmanId)
        {
            _departmanDal.Delete(new Departman(){DepartmanId = departmanId});
        }

        public IEnumerable<Departman> GetAll()
        {
            return _departmanDal.GetList();
        }

        public Departman GetById(int? departmanId)
        {
            return _departmanDal.Get(i => i.DepartmanId == departmanId);
        }

        public void Update(Departman departman)
        {
            _departmanDal.Update(departman);
        }
    }
}