using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        //public Nullable<int> IdProvincia { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }

        public  Provincia Provincia { get; set; }

        //public Ciudad(int IdCiudad,string Nombre,Provincia provincia)
        //{
        //    IdCiudad = this.IdCiudad;
        //    Nombre = this.Nombre;
        //    provincia = this.Provincia;
        //}
    }
}