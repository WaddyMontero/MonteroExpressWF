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
    
    public partial class EstadosEnvio
    {
        public EstadosEnvio()
        {
            this.Envios = new HashSet<Envio>();
        }
    
        public int IdEstadoEnvio { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
    
        public virtual ICollection<Envio> Envios { get; set; }
    }
}
