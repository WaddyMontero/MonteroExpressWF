using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorEnvios
    {
        public static List<Envio> ListarEnvios(int PageIndex, int PageSize, string Nombre, string Fecha, string Albaran, string Estado)
        {
            return ManejadorMonteroExpress.ListarEnvios(PageIndex,PageSize,Nombre,Fecha,Albaran, Estado);
        }
        public static Envio ObtenerEnvio(int IdEnvio)
        {
            return ManejadorMonteroExpress.ObtenerEnvio(IdEnvio);
        }
        public static object RegistrarEnvio(Envio Envio) 
        {
            return ManejadorMonteroExpress.RegistrarEnvio(Envio);
        }

        public static int TotalEnvios(string Nombre, string Fecha, string Albaran)
        {
            return ManejadorMonteroExpress.TotalEnvios(Nombre, Fecha, Albaran);
        }

        public static void ActualizaEstadosEnvios(Int32 IdEnvio,Int16 IdEstado, int IdUsuario)
        {
            ManejadorMonteroExpress.ActualizaEstadosEnvios(IdEnvio,IdEstado, IdUsuario);
        }

        public static Envio ObtenerEnvioByAlbaran(string AlbaranNum)
        {
            return ManejadorMonteroExpress.ObtenerEnvioByAlbaran(AlbaranNum);
        }
    }
}