using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Abstract
{
    public interface IDepartmanService
    {
        void Add(Departman departman);
        void Delete(int departmanId);
        void Update(Departman departman);
        IEnumerable<Departman> GetAll();
        Departman GetById(int? departmanId);


    }
}
