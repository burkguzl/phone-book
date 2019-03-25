using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Core.DataAccess.EntityFramework;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal:EfEntityRepositoryBase<Admin,DatabaseContext>,IAdminDal
    {

    }
}