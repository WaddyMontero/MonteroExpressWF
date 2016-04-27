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
        public object ListarEnvios(int jtStartIndex,int jtPageSize,string Nombre,string Fecha,string Albaran)
        {
            return new { Result = "OK", Records = ManejadorEnvios.ListarEnvios(jtStartIndex, jtPageSize, Nombre, Fecha, Albaran), TotalRecordCount = ManejadorEnvios.TotalEnvios(Nombre, Fecha, Albaran) };
        }

        [WebMethod(EnableSession = true)]
        public object InsertarEnvio(Envio Envio)
        {
            try
            {
                if (Envio.Remitente.NumDocumento != Envio.Destinatario.NumDocumento)
                {
                    return ManejadorEnvios.RegistrarEnvio(Envio);
                }
                else
                {
                    return new { Result = "ERROR", Message = "El número de documento del Remitente y el Destinatario deben ser diferentes." };
                }
                
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }


        #endregion

        #region SegurosEnvios
        [WebMethod]
        public object ObtenerSegurosEnvios()
        {
            return new { Result = "OK", Records = ManejadorSegurosEnvios.ObtenerSegurosEnvios(0), TotalRecordCount = 0 };
        }

        [WebMethod]
        public object InsertaSeguroEnvio(SeguroEnvio record)
        {
            ManejadorSegurosEnvios.InsertaSeguroEnvio(record);
            return new { Result = "OK", Record = record };
        }

        [WebMethod]
        public object ActualizaSeguroEnvio(SeguroEnvio record)
        {
            ManejadorSegurosEnvios.ActualizaSeguroEnvio(record);
            return new { Result = "OK", Record= record};
        }


        #endregion

        #region TiposContenidos
        [WebMethod]
        public object ObtenerTiposContenidos()
        {
            return new { Result = "OK", Records = ManejadorTiposContenidos.ObtenerTiposContenidos(0), TotalRecordCount = 0 };
        }

        [WebMethod]
        public object InsertaTipoContenido(TipoContenido record)
        {
            ManejadorTiposContenidos.InsertaTipoContenido(record);
            return new { Result = "OK", Record = record };
        }

        [WebMethod]
        public object ActualizaTipoContenido(TipoContenido record)
        {
            ManejadorTiposContenidos.ActualizaTipoContenido(record);
            return new { Result = "OK", Record = record };
        }


        #endregion

        #region Oficinas
        [WebMethod]
        public object ObtenerOficinas()
        {
            return new { Result = "OK", Records = ManejadorOficinas.ObtenerOficinas(0), TotalRecordCount = 0 };
        }

        [WebMethod]
        public object InsertaOficinas(Oficina record)
        {
            ManejadorOficinas.InsertaOficinas(record);
            return new { Result = "OK", Record = record };
        }

        [WebMethod]
        public object ActualizaOficinas(Oficina record)
        {
            ManejadorOficinas.ActualizaOficinas(record);
            return new { Result = "OK", Record = record };
        }


        #endregion

        #region Puertos
        [WebMethod]
        public object ObtenerPuertos()
        {
            return new { Result = "OK", Records = ManejadorPuertos.ObtienePuertos(0), TotalRecordCount = 0 };
        }

        [WebMethod]
        public object InsertaPuertos(Puerto record)
        {
            ManejadorPuertos.InsertaPuertos(record);
            return new { Result = "OK", Record = record };
        }

        [WebMethod]
        public object ActualizaPuertos(Puerto record)
        {
            ManejadorPuertos.ActualizaPuertos(record);
            return new { Result = "OK", Record = record };
        }


        #endregion

        #region PaquetesEnvios
        [WebMethod]
        public object ObtenerPaquetesPorEnvio(int idEnvio)
        {
            return new { Result = "OK", Records = ManejadorPaquetesEnvios.ObtenerPaquetesPorEnvio(idEnvio), TotalRecordCount = 0 };
        }


        #endregion

        #region Graficas

        [WebMethod]
        public List<KeyValuePair<int,string>> TotalEnviosPorMes()
        {
            return ManejadorGraficas.TotalEnviosPorMes();

        }

        [WebMethod]
        public List<KeyValuePair<string, string>> Top5Envios()
        {
            return ManejadorGraficas.Top5Envios();
        }

        [WebMethod]
        public List<KeyValuePair<string, string>> Top5Recepciones()
        {
            return ManejadorGraficas.Top5Recepciones();
        }


        #endregion
    }
}
