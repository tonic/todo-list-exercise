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
            
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            container.RegisterType<IListItemRepository, ListItemRepository>(new InjectionConstructor(connectionString));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}