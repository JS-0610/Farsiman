using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba1.Models
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double? Recorrido { get; set; }

    }

    public class EditColaboradorViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double? Recorrido { get; set; }
        public int? SucursalId { get; set; }

    }
}