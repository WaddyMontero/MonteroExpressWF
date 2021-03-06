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
    using System.Xml.Serialization;
    
    [XmlRoot(ElementName="Entidade")]
    public partial class Entidade
    {
        public Entidade()
        {
            this.EntidadDirecciones = new HashSet<EntidadDireccione>();
        }
    [XmlAttribute(DataType = "int", AttributeName = "IdEntidad")]
        public int IdEntidad { get; set; }
        [XmlAttribute(DataType = "string", AttributeName = "Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute(DataType = "int", AttributeName = "IdTipoDocumento")]
        public Nullable<int> IdTipoDocumento { get; set; }
        [XmlAttribute(DataType = "string", AttributeName = "NumDocumento")]
        public string NumDocumento { get; set; }
        [XmlAttribute(DataType = "date", AttributeName = "FechaIngreso")]
        public System.DateTime FechaIngreso { get; set; }
        [XmlAttribute(DataType = "boolean", AttributeName = "Activo")]
        public bool Activo { get; set; }

        [XmlElement(Type = typeof(ICollection<EntidadDireccione>), ElementName = "EntidadDirecciones")]
    
        public virtual ICollection<EntidadDireccione> EntidadDirecciones { get; set; }
        [XmlElement(Type = typeof(TiposDocumento), ElementName = "TiposDocumento")]
        public virtual TiposDocumento TiposDocumento { get; set; }
    }
}
