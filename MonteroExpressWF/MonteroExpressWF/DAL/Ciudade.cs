//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonteroExpressWF.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudade
    {
        public Ciudade()
        {
            this.EntidadDirecciones = new HashSet<EntidadDireccione>();
        }
    
        public int IdCiudad { get; set; }
        public Nullable<int> IdProvincia { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<EntidadDireccione> EntidadDirecciones { get; set; }
    }
}
