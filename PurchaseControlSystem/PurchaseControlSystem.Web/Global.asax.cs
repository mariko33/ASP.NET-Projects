using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PurchaseControlSystem.Models.EntityModels;
using PurchaseControlSystem.Web.Models.ViewModels;

namespace PurchaseControlSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureMapping();
        }

        private void ConfigureMapping()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<PurchaseOrder, PurchaseOrderVm>();
                expression.CreateMap<CreateOrderVm, PurchaseOrder>();
                expression.CreateMap<PurchaseOrder, EditOrderVm>();

            });
        }
    }
}
