using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba1.Controllers;
using Prueba1.Models;
using Prueba1.Models.EF;

namespace Prueba1.Filter
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (tbUsuarios)HttpContext.Current.Session["User"];             

            if (oUser == null)                                                  
            {
                if (filterContext.Controller is AccessController == false)      
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Travel/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}