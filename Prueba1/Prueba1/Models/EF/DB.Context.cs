﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FarsimanEntities : DbContext
    {
        public FarsimanEntities()
            : base("name=FarsimanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbSucursal> tbSucursal { get; set; }
        public virtual DbSet<tbViajes> tbViajes { get; set; }
        public virtual DbSet<tbColaborador> tbColaborador { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }
        public virtual DbSet<tbTransporte> tbTransporte { get; set; }
    }
}
