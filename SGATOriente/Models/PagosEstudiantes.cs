//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PagosEstudiantes
    {
        public int PagoID { get; set; }
        public Nullable<int> EstudianteID { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
    
        public virtual AgregarNuevosEstudiantes AgregarNuevosEstudiantes { get; set; }
    }
}
