using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia;
using System.Data;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;
namespace MonteroExpressWF.BLL
{
    public class ManejadorEntidadDirecciones
    {
        public static List<EntidadDireccion> ObtieneEntidadDireccionesByEntidad(int IdEntidad)
        {
           return ManejadorMonteroExpress.ObtieneEntidadDireccionesByEntidad(IdEntidad);
        }
        public static List<EntidadDireccion>  ObtenerEntidadDirecciones(string NumDocumento)
        {
            return ManejadorMonteroExpress.ObtenerEntidadDirecciones(NumDocumento);
        }
        public static void InsertarEntidadDireccion(EntidadDireccion entidadDireccion) 
        {
            ManejadorMonteroExpress.InsertarEntidadDireccion(entidadDireccion);
        }

        public static void EliminarEntidadDireccion(int IdEntidadDireccion)
        {
            ManejadorMonteroExpress.EliminarEntidadDireccion(IdEntidadDireccion);
        }
    }
}