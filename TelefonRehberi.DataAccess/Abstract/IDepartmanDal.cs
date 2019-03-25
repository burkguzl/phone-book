using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberi.Core;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccess.Abstract
{
    public interface IDepartmanDal:IEntityRepository<Departman>
    {
        //custom operations
    }
}