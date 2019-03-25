using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin FindByUsernameAndEmail(string username, string email)
        {
            return _adminDal.Get(i => i.Username == username && i.Email == email);
        }

        public bool SignUp(string username, string password)
        {
            Admin admin = _adminDal.Get(i => i.Username==username);
            if (admin!=null)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    HttpContext.Current.Session["AdminId"] = admin.AdminId.ToString();
                    return true;
                }
            }
           
            return false;
        }
    }
}