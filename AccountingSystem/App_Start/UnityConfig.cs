using AccountingSystem.Contexts;
using AccountingSystem.Contexts.Interfaces;
using AccountingSystem.Repositories;
using AccountingSystem.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AccountingSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IDbContext, DbContext>();
            container.RegisterType<IClientRepository, ClientRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}