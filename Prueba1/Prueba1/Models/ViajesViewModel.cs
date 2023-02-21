using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization.Configuration;

namespace Prueba1.Models
{
    public class ViajesViewModel
    {
        public int Id { get; set; }
        public string Colaborador { get; set; }
        public string Fecha { get;set; }
        public double? Recorrido { get;set; }
        public double? Pago { get;set; }


    }

    public class ViajesTransporteModel
    {
        public int? transporte_id { get; set; }
        public double? Recorrido { get; set; }
        public double? Pago { get; set; }
    }
}