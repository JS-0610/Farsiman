using Prueba1.Models;
using Prueba1.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba1.Controllers
{
    public class ReporterController : Controller
    {
        // GET: Reporter
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
            ViewBag.Transporte = lst1;
            return View();
        }
        [HttpPost]
        public ActionResult GetData(int id,DateTime fechai, DateTime fechaf )
        {
            
            List<ViajesViewModel> lst = null;
            using (FarsimanEntities db = new FarsimanEntities())
            {
                lst = (from d in db.tbViajes
                        join c in db.tbColaborador on d.colaborador_id equals c.colaborador_id
                       where d.transporte_id == id && d.fecha >= fechai && d.fecha <=fechaf
                        select new ViajesViewModel
                        {
                            Id = d.viaje_id,
                            Colaborador = c.nombre,
                            Fecha = d.fecha.ToString(),
                            Recorrido = d.recorrido,
                            Pago = d.pago
                        }).ToList();
            }
            var echo = Json(lst);
            return echo;
        }


    }
}