using Prueba1.Filter;
using System.Web;
using System.Web.Mvc;

namespace Prueba1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession());
        }
    }
}
