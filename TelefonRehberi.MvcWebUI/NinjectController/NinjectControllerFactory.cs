using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using TelefonRehberi.Business.Abstract;
using TelefonRehberi.Business.Concrete;
using TelefonRehberi.DataAccess.Abstract;
using TelefonRehberi.DataAccess.Concrete.EntityFramework;
using TelefonRehberi.Entities;

namespace TelefonRehberi.MvcWebUI.NinjectController
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel= new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ICalisanService>()
                .To<CalisanManager>()
                .WithConstructorArgument("calisanDal", new EfCalisanDal());

            ninjectKernel.Bind<IDepartmanService>()
                .To<DepartmanManager>()
                .WithConstructorArgument("departmanDal", new EfDepartmanDal());

            ninjectKernel.Bind<IAdminService>().To<AdminManager>()
                .WithConstructorArgument("adminDal", new EfAdminDal());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controlerType)
        {
            return controlerType == null ? null : (IController) ninjectKernel.Get(controlerType);
        }
    }
}