using DesktopWarrior.Models;
using DesktopWarrior.Models.ModelBinders;
using DesktopWarrior.Models.ViewModels.BuildYourRig;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DesktopWarrior
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ModelBinders.Binders.Add(typeof(Byr), new BuildYourRigModelBinder());
            ModelBinders.Binders.Add(typeof(Checkout), new CheckoutModelBinder());
        }
    }
}
