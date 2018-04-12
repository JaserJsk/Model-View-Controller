using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo.Ajax
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Här har vi definierat att /Home är standard
            // Men, den letar även efter Controller och Action
            // Det betyder att om man skriver /Gallery
            // Så kommer man in i GalleryController.Index()
            // ASP.NET kommer alltså internt att göra: 
            //     var controller = new GalleryController()
            //     return controller.Index();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
