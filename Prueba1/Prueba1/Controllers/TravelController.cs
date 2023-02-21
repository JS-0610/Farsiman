using Prueba1.Models;
using Prueba1.Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Prueba1.Controllers
{
    public class TravelController : Controller
    {
        // GET: Travel
        public ActionResult Index()
        {
            List<TransporteViewModel> lst1 = null;                 
            using (FarsimanEntities db = new FarsimanEntities())   
            {
                lst1 = (from d in db.tbTransporte
                       orderby d.unidad
                       select new TransporteViewModel             
                       {                                         
                           Id = d.trasnporte_id,             
                           Conductor = d.conductor,
                           Unidad = d.unidad
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

            ViewBag.Transporte = lst1;
            ViewBag.Sucursal = lst2;
            
            return View();
        }

        
        public ActionResult GetColaboradores(int id)
        {
            List<ColaboradorViewModel> lst = null;
            using (FarsimanEntities db = new FarsimanEntities())
            {
                lst = (from d in db.tbColaborador
                       where d.sucursal_id == id
                       orderby d.nombre
                       select new ColaboradorViewModel
                       {
                           Id = d.colaborador_id,
                           Nombre = d.nombre,
                           Recorrido = d.recorrido
                       }).ToList();
            }
            var echo = Json(lst);
            return echo;
        }
        
        public ActionResult SetViaje(int idTransporte, int valoresCheck, int recorrido)
        {
            try
            {
                
                using (FarsimanEntities db = new FarsimanEntities())
                {
                    var oTrans = db.tbTransporte.Find(idTransporte);
                    tbViajes oViaje = new tbViajes();
                    oViaje.transporte_id = idTransporte;
                    oViaje.colaborador_id = valoresCheck;
                    oViaje.fecha = DateTime.Now.Date;
                    oViaje.recorrido = recorrido;
                    oViaje.pago = recorrido * oTrans.tarifa;

                    db.tbViajes.Add(oViaje);            
                    db.SaveChanges();                 
                }
                
            } catch(Exception ex)
            {
                return Content("Ocurrio un error " + ex.Message);
            }
            return Content("1");
        }
    }
}