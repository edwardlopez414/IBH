using System.Web.Mvc;

namespace CAPAADMIN.Areas.CAPAUSER
{
    public class CAPAUSERAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CAPAUSER";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CAPAUSER_default",
                "CAPAUSER/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}