using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ToDoList.DataAccess;
using ToDoList.Framework.Interfaces.DataAccess;
using System.Configuration;

namespace ToDoList.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // TODO move this
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            container.RegisterType<IListItemRepository, ListItemRepository>(new InjectionConstructor(connectionString));

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}