﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGATOriente.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SGATOrienteDBEntities : DbContext
    {
        public SGATOrienteDBEntities()
            : base("name=SGATOrienteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgregarNuevosEstudiantes> AgregarNuevosEstudiantes { get; set; }
        public virtual DbSet<ImagenesCarrusel> ImagenesCarrusel { get; set; }
        public virtual DbSet<ImagenFondo> ImagenFondo { get; set; }
        public virtual DbSet<ModificarAlumnos> ModificarAlumnos { get; set; }
        public virtual DbSet<Notificaciones> Notificaciones { get; set; }
        public virtual DbSet<PagosEstudiantes> PagosEstudiantes { get; set; }
        public virtual DbSet<ProgresoEstudiantes> ProgresoEstudiantes { get; set; }
        public virtual DbSet<RecursosEducacionales> RecursosEducacionales { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
    }
}
