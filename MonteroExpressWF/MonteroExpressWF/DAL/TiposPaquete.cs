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
    
    public partial class TiposPaquete
    {
        public TiposPaquete()
        {
            this.PaquetesEnvios = new HashSet<PaquetesEnvio>();
        }
    
        public int IdTipoPaquete { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual ICollection<PaquetesEnvio> PaquetesEnvios { get; set; }
    }
}
