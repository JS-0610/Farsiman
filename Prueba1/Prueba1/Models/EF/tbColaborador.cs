//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba1.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbColaborador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbColaborador()
        {
            this.tbViajes = new HashSet<tbViajes>();
        }
    
        public int colaborador_id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> sucursal_id { get; set; }
        public Nullable<double> recorrido { get; set; }
    
        public virtual tbSucursal tbSucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbViajes> tbViajes { get; set; }
    }
}
