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
    
    public partial class Provincia
    {
        public Provincia()
        {
            this.Ciudades = new HashSet<Ciudade>();
        }
    
        public int IdProvincia { get; set; }
        public Nullable<int> IdPais { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Ciudade> Ciudades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
