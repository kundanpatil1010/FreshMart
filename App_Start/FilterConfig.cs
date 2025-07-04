using System.Web;
using System.Web.Mvc;

namespace ASP.NET_GROCERY_WEB_APP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
