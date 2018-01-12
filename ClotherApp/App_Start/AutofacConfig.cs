using Autofac;
using Autofac.Integration.Mvc;
using ClothApp;
using ClothApp.Services;
using ClothApp.Services.Interfaces;
using System.Web.Mvc;

namespace ClotherApp.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ClothService>().As<IClothService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}