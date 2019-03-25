using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.Business.Abstract
{
    public interface IAdminService
    {
        bool SignUp(string username, string password);
        Admin FindByUsernameAndEmail(string username, string email);

    }
}
