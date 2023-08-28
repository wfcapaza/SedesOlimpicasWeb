using DataAccess;
using BusinessLogic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SedesOlimpicas
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IDAUsuario, DAUsuario>();
            container.RegisterType<IDASede, DASede>();
            container.RegisterType<IDAComplejo, DAComplejo>();
            container.RegisterType<IDAComisario, DAComisario>();
            container.RegisterType<IDAEvento, DAEvento>();

            container.RegisterType<IBLUsuario, BLUsuario>();
            container.RegisterType<IBLSede, BLSede>();
            container.RegisterType<IBLComplejo, BLComplejo>();
            container.RegisterType<IBLComisario, BLComisario>();
            container.RegisterType<IBLEvento, BLEvento>();
        }
    }
}