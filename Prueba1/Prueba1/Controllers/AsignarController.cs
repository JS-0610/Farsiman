using Prueba1.Models;
using Prueba1.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Prueba1.Controllers
{
    public class AsignarController : Controller
    {
        // GET: Asignar
        public ActionResult Index()
        {
            List<EditColaboradorViewModel> lst1 = null;
            using (FarsimanEntities db = new FarsimanEntities())
            {
                lst1 = (from d in db.tbColaborador
                       select new EditColaboradorViewModel
                       {
                           Id = d.colaborador_id,
                           Nombre = d.nombre,
                           Recorrido = d.recorrido,
                           SucursalId= d.sucursal_id,
                       }).ToList();
            }
            
            List<SucursalViewModel> lst2 = null;
            using (FarsimanEntities db = new FarsimanEntities())
            {
                lst2 = (from d in db.tbSucursal
                        orderby d.nombre
                        select new SucursalViewModel
                        {
                            Id = d.sucursal_id,
                            Nombre = d.nombre
                        }).ToList();
            }

            ViewBag.Colaboradores = lst1;
            ViewBag.Sucursal = lst2;
            return View();
        }

        public ActionResult Edit(int idC, int idS, double recorrido)
        {
            
            using(FarsimanEntities db = new FarsimanEntities())
            {
                var oColaborador = db.tbColaborador.Find(idC);
                oColaborador.sucursal_id = idS;
                oColaborador.recorrido = recorrido;

                db.Entry(oColaborador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}