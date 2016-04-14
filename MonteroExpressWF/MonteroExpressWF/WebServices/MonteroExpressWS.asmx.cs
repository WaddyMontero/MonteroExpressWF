using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MonteroExpressWF.BLL;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.WebServices
{
    /// <summary>
    /// Summary description for MonteroExpressWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class MonteroExpressWS : System.Web.Services.WebService
    {

        #region TiposDocumentos
        [WebMethod]
        public TipoDocumento ObtenerTipoDocumento(int IdTipoDocumento)
        {
            //return JsonConvert.SerializeObject(ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento)));
            return ManejadorTipoDocumento.ObtenerTipoDocumentoById(IdTipoDocumento);
        }
        [WebMethod]
        public List<TipoDocumento> ObtenerTiposDocumentos() 
        {
            return ManejadorTipoDocumento.ObtenerTiposDocumentos();
        }


        //[WebMethod]
        //public object ObtenerTipoDocumentoJT(int IdTipoDocumento)
        //{
        //    //return JsonConvert.SerializeObject(ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento)));
        //    return new {Result = "OK", Records = ManejadorTipoDocumento.ObtenerTipoDocumentoById(IdTipoDocumento)};
        //}

        #endregion

        #region DireccionesEntidad
        
        [WebMethod]
        public object ObtieneDireccionesByEntidad(int IdEntidad)
        {
            return new { Result = "OK", Records = ManejadorEntidadDirecciones.ObtieneEntidadDireccionesByEntidad(IdEntidad), TotalRecordCount = 0 };
            
        }

        [WebMethod]
        public object InsertaEntidadDireccion(EntidadDireccion record)
        {
            try
            {
                ManejadorEntidadDirecciones.InsertarEntidadDireccion(record);
                return new { Result = "OK", Record = record };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message};
            }

        }
        [WebMethod]
        public object EliminarEntidadDireccion(int IdEntidadDireccion)
        {
            try
            {
                ManejadorEntidadDirecciones.EliminarEntidadDireccion(IdEntidadDireccion);
                return new { Result = "OK" };
            }
            catch(Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
        #endregion

        #region Entidad

        [WebMethod]
        public Entidad BuscarEntidad(string NumDocumento)
        {
            return ManejadorEntidades.BuscarEntidad(NumDocumento);            
        }

        [WebMethod]
        public object ActualizarNombreEntidad(Entidad record)
        {
            ManejadorEntidades.ActualizarNombreEntidad(record);
            return new { Result = "OK", Record = record};
        }

        [WebMethod]
        public object ListarEntidades()
        {
            return new { Result = "OK", Records = ManejadorEntidades.ListarEntidades(), TotalRecordCount = 0 };
        }

        [WebMethod]
        public object InsertarEntidad(Entidad Entidad)
        {
            try
            {
                ManejadorEntidades.InsertarEntidad(Entidad.Nombre, Entidad.IdTipoDocumento, Entidad.NumDocumento);
                return new { Result = "OK", Record = Entidad };
            }
            catch (Exception ex)
            {
                return new { Result = "OK", Message = ex.Message };
            }
        }
        #endregion

        #region UbicacionesGeograficas

        [WebMethod]
        public object ObtenerProvinciasByPais(int IdPais) 
        {
            return ManejadorGeografico.ObtenerProvincias(IdPais).Select(opt => new { Value = opt.IdProvincia, DisplayText = opt.Nombre });
        }
        [WebMethod]
        public object ObtenerCiudadesByProvincia(int IdProvincia) 
        {
            return ManejadorGeografico.ObtenerCiudades(IdProvincia).Select(opt => new {Value = opt.IdCiudad,DisplayText=opt.Nombre});
        }
        //Para uso del JTABLE
        [WebMethod]
        public object ObtenerProvinciasByPaisJT(int IdPais)
        {
            return new { Result = "OK", Options = ManejadorGeografico.ObtenerProvincias(IdPais).Select(opt => new { Value = opt.IdProvincia, DisplayText = opt.Nombre }) };
        }
        [WebMethod]
        public object ObtenerCiudadesByProvinciaJT(int IdProvincia)
        {
            return new { Result = "OK", Options = ManejadorGeografico.ObtenerCiudades(IdProvincia).Select(opt => new { Value = opt.IdCiudad, DisplayText = opt.Nombre }) };
        }


        [WebMethod]
        public object ObtenerPaises()
        {
            return new {Result = "OK", Options = ManejadorGeografico.ObtenerPaises().Select(p => new {Value = p.IdPais, DisplayText= p.Nombre})};
        }

        [WebMethod]
        public static object ListarPaquetes() 
        {
            return new { Result = "OK", Records = new List<PaqueteEnvio>(), TotalRecordCount = 0 };
        }
        #endregion

        #region TamaniosPaquetes

        //Para uso del jtable como options de un dropdown
        [WebMethod]
        public object ObtieneTamaniosPaquetes() 
        {
            return new { Result = "OK", Options = ManejadorTamaniosPaquetes.ObtieneTamaniosPaquetes().Select(tp => new { Value = tp.IdTamanioPaquete, DisplayText = tp.Descripcion }) };
        }
            
        #endregion

        #region Estados

        [WebMethod]
        //Para uso del jtable como options de un dropdown
        public object ObtieneEstadosPaquetes() 
        {
            return new { Result = "OK", Options = ManejadorEstados.ObtieneEstadosPaquetesActivos().Select(e => new { Value = e.IdEstado, DisplayText = e.Descripcion }) };
        }

        #endregion

        #region Envios

        [WebMethod]
        public object ListarEnvios()
        {
            return new { Result = "OK", Records = ManejadorEnvios.ListarEnvios(), TotalRecordCount = 0 };
        }



        #endregion

#region SegurosEnvios

        public object ObtenerSegurosEnvios()
        {
            return new { Result = "OK", Records = ManejadorSegurosEnvios.ObtenerSegurosEnvios(), TotalRecordCount = 0 };
        }

#endregion


        #region Envio

        [WebMethod(EnableSession=true)]
        public object InsertarEnvio(Envio Envio) 
        {
            try
            {
                return ManejadorEnvios.RegistrarEnvio(Envio);                
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }
        #endregion
    }
}
