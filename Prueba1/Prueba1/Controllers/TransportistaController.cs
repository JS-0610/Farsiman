using Prueba1.Models.EF;
using Prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba1.Controllers
{
    public class TransportistaController : Controller
    {
        // GET: Transportista
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

        public ActionResult Edit(int idT, double tarifa, double bono, int meta) 
        {
            try
            {
                using (FarsimanEntities db = new FarsimanEntities())
                {
                    var oTrans = db.tbTransporte.Find(idT);
                    oTrans.bono = bono;
                    oTrans.meta = meta;
                    oTrans.tarifa = tarifa;

                    db.Entry(oTrans).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Reporte()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult GetReporte(DateTime fechai)
        {
            List<TransportistaViewModel> lstTransportista = new List<TransportistaViewModel>();
            List<TransporteEnlaceModel> lstTransporte = null;
            List<ViajesTransporteModel> lstViaje = null;
            DateTime oPrimerDiaDelMes = new DateTime(fechai.Year, fechai.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            using (FarsimanEntities db = new FarsimanEntities())
            {
                lstTransporte = (from d in db.tbTransporte
                        orderby d.trasnporte_id
                        select new TransporteEnlaceModel
                        {
                            Id = d.trasnporte_id,
                            Conductor = d.conductor,
                            Unidad = d.unidad,
                            Tarifa = d.tarifa,
                            Bono = d.bono,
                            Meta= d.meta
                        }).ToList();
                
                lstViaje = (from d in db.tbViajes
                            join t in db.tbTransporte on d.transporte_id equals t.trasnporte_id
                            where d.fecha >= oPrimerDiaDelMes && d.fecha <= oUltimoDiaDelMes
                            select new ViajesTransporteModel
                                {
                                    transporte_id = t.trasnporte_id,
                                    Recorrido = d.recorrido,
                                    Pago = d.pago
                                }).ToList();
                
                foreach (var oTrans in lstTransporte)
                {
                    TransportistaViewModel model = new TransportistaViewModel();
                    model.Id = oTrans.Id;
                    model.Conductor = oTrans.Conductor;
                    model.Unidad = oTrans.Unidad;
                    model.Tarifa = oTrans.Tarifa;
                    
                    int contador = 0;
                    double? recorridos = 0;
                    foreach (var travel in lstViaje)
                    {
                        if(travel.transporte_id == oTrans.Id)
                        {
                            recorridos += travel.Recorrido;
                            model.TotalKm += travel.Recorrido;
                            contador++;
                        }   
                        
                    }
                    model.TotalKm = recorridos;
                    model.Viajes = contador;
                    double? meta=oTrans.Meta;
                    model.MetaP = (contador/meta)*100;
                    if (model.MetaP >= 120)
                    {
                        double? bono = oTrans.Bono;
                        model.Bono = bono * 1.2;

                    }
                    else if (model.MetaP >= 100)
                    {
                        double? bono = oTrans.Bono;
                        model.Bono = bono;

                    }
                    else if (model.MetaP >= 90)
                    {
                        double? bono = oTrans.Bono;
                        model.Bono = bono * 0.5;

                    }
                    else {
                        model.Bono = 0;
                    }
                    model.Total = (model.TotalKm * oTrans.Tarifa)+ model.Bono;
                    lstTransportista.Add(model);
                }


            }

            return Json(lstTransportista);
        }

        public ActionResult Detalle(int id, DateTime fechai)
        {
            DateTime oPrimerDiaDelMes = new DateTime(fechai.Year, fechai.Month, 1);
            DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddMonths(1).AddDays(-1);
            List<ViajesViewModel> lst = null;
            using (FarsimanEntities db = new FarsimanEntities())
            {
                lst = (from d in db.tbViajes
                       join c in db.tbColaborador on d.colaborador_id equals c.colaborador_id
                       where d.transporte_id == id && d.fecha >= oPrimerDiaDelMes && d.fecha <= oUltimoDiaDelMes
                       select new ViajesViewModel
                       {
                           Id = d.viaje_id,
                           Colaborador = c.nombre,
                           Fecha = d.fecha.ToString(),
                           Recorrido = d.recorrido,
                           Pago = d.pago
                       }).ToList();
            }
            return View(lst);
        }
    }
}