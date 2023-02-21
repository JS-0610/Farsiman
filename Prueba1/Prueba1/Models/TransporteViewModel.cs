using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba1.Models
{
    public class TransporteViewModel
    {
        public int Id { get; set; }
        public int? Unidad { get; set; }

        public string Conductor { get; set; }

    }

    public class TransporteEnlaceModel
    {
        public int Id { get; set; }
        public int? Unidad { get; set; }

        public string Conductor { get; set; }
        public double? Tarifa { get; set; }
        public double? Bono { get; set; }
        public int? Meta { get; set; }

    }

    public class TransportistaViewModel
    {
        public int Id { get; set; }
        public int? Unidad { get; set; }
        public string Conductor { get; set; }
        public int Viajes { get; set; }
        public double? TotalKm { get; set; }
        public double? Tarifa { get; set; }
        public double? MetaP { get; set;}
        public double? Bono { get; set;}
        public double? Total { get; set; }
    }
}