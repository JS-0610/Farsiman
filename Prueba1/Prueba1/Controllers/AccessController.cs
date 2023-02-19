using Prueba1.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba1.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string user, string password)
        {
            try
            {
                using(FarsimanEntities db = new FarsimanEntities())
                {
                    var lst = from d in db.tbUsuarios
                              where d.username == user && d.pass == password
                              select d;
                    if(lst.Count() > 0)
                    {
                        tbUsuarios oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    } else
                    {
                        return Content("Usuario Invalido");
                    }
                }
            }
            catch (Exception e)
            {

                return Content("Ocurrio un error: " + e.Message);
            }
        }
    }
}