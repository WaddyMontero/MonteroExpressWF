using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using Persistencia;
using System.Xml;

namespace MonteroExpressWF.DAL
{
    public class ManejadorMonteroExpress
    {
        
        #region TipoDocumento
        public static List<TipoDocumento> ObtenerTiposDocumentos()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("prc_Obtener_TiposDocumentos",true);
            List<TipoDocumento> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<TipoDocumento>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipoDocumento { 
                        IdTipoDocumento = int.Parse(row["IdTipoDocumento"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        Mascara = row["Mascara"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Activo = Convert.ToBoolean(row["Activo"].ToString())
                    });
                }
            }

            return lista;
        }
        public static TipoDocumento ObtenerTipoDocumentoById(int IdTipoDocumento)
        {
            return ObtenerTiposDocumentos().Single(td => td.IdTipoDocumento == IdTipoDocumento);
        }
        #endregion

        #region DatosGeográficos

        public static List<Pais> ObtenerPaises()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Paises]", true);
            List<Pais> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Pais>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Pais
                    {
                        IdPais = int.Parse(row["IdPais"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        public static List<Provincia> ObtenerProvincias(int IdPais)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdPais", IdPais, DbType.Int32);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Provincias]", "", param);
            List<Provincia> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Provincia>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Provincia
                    {
                        IdProvincia = int.Parse(row["IdProvincia"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Pais = new Pais{ IdPais = int.Parse(row["IdPais"].ToString())}
                    });
                }
            }
            return lista;
        }

        public static List<Ciudad> ObtenerCiudades(int IdProvincia)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdProvincia", IdProvincia, DbType.Int32);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Ciudades]", "", param);
            List<Ciudad> lista = new List<Ciudad>();
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Ciudad>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Ciudad
                    {
                        IdCiudad = int.Parse(row["IdCiudad"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Provincia = new Provincia { IdProvincia = int.Parse(row["IdProvincia"].ToString()) } 
                    });
                }
            }
            return lista;
        }

        #endregion
        #region Entidad

        public static Entidad BuscarEntidad(string NumDocumento) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@NumDocumento",NumDocumento,DbType.String);
            DataTable dt = con.GetDataTable("[dbo].[prc_Buscar_Entidad]","",param);
            Entidad entidad = null;
            if (dt!= null && dt.Rows.Count > 0)
            {
                string data = dt.Rows[0][0].ToString();
                if (data != "")
                {
                    entidad = new Entidad();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(data);
                    XmlNode nodoEntidad = xmlDocument.FirstChild.SelectSingleNode("Entidad");
                    entidad.IdEntidad = int.Parse(nodoEntidad.Attributes["IdEntidad"].Value.ToString());
                    entidad.Nombre = nodoEntidad.Attributes["Nombre"].Value.ToString();
                    entidad.IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString());
                    entidad.NumDocumento = nodoEntidad.Attributes["NumDocumento"].Value.ToString();
                    entidad.FechaIngreso = Convert.ToDateTime(nodoEntidad.Attributes["FechaIngreso"].Value.ToString());
                    entidad.Activo = Convert.ToBoolean(int.Parse(nodoEntidad.Attributes["Activo"].Value.ToString()));
                    XmlNode nodoDirecciones = nodoEntidad.SelectSingleNode("EntidadDirecciones");
                    if (nodoDirecciones.HasChildNodes)
                    {
                        entidad.EntidadDirecciones = new List<EntidadDireccion>();
                        foreach (XmlNode direccion in nodoDirecciones.ChildNodes)
                        {
                            entidad.EntidadDirecciones.Add(new EntidadDireccion
                            {
                                Ciudad = new Ciudad
                                {
                                    IdCiudad = int.Parse(direccion.Attributes["IdCiudad"].Value.ToString()),
                                    Nombre = direccion.Attributes["Ciudad"].Value.ToString(),
                                    Provincia = new Provincia
                                    {
                                        IdProvincia = int.Parse(direccion.Attributes["IdProvincia"].Value.ToString()),
                                        Nombre = direccion.Attributes["Provincia"].Value.ToString(),
                                        Pais = new Pais
                                        {
                                            IdPais = int.Parse(direccion.Attributes["IdPais"].Value.ToString()),
                                            Nombre = direccion.Attributes["Pais"].Value.ToString()
                                        }
                                    }
                                },
                                Direccion = direccion.Attributes["Direccion"].Value.ToString(),
                                FechaIngreso = Convert.ToDateTime(direccion.Attributes["FechaIngreso"].Value.ToString()),
                                IdEntidadDireccion = int.Parse(direccion.Attributes["IdEntidadDireccion"].Value.ToString()),
                                PorDefecto = Convert.ToBoolean(int.Parse(direccion.Attributes["PorDefecto"].Value.ToString())),
                                Telefono1 = direccion.Attributes["Telefono1"].Value.ToString(),
                                Telefono2 = (direccion.Attributes.GetNamedItem("Telefono2") != null)?direccion.Attributes["Telefono2"].Value.ToString():"",
                                Activo = Convert.ToBoolean(int.Parse(direccion.Attributes["Activo"].Value.ToString()))
                            });
                        }
                    }
                }
            }
            return entidad;
        }
        #endregion

        #region TiposContenidos
        public static List<TipoContenido> ObtenerTiposContenidos() 
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_TiposContenidos]",true);
            List<TipoContenido> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<TipoContenido>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipoContenido { 
                        IdTipoContenido = int.Parse(row["IdTipoContenido"].ToString()),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        #endregion
        #region SegurosEnvios

        public static List<SeguroEnvio> ObtenerSegurosEnvios() 
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_SegurosEnvios]", true);
            List<SeguroEnvio> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<SeguroEnvio>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new SeguroEnvio
                    {
                        IdSeguroEnvio = int.Parse(row["IdSeguroEnvio"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }
        #endregion

        #region TamaniosPaquetes

        public static List<TamanioPaquete> ObtieneTamaniosPaquetes() 
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_TamaniosPaquetes]",true);
            List<TamanioPaquete> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<TamanioPaquete>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TamanioPaquete
                    {
                        IdTamanioPaquete = int.Parse(row["IdTamanioPaquete"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Activo = Convert.ToBoolean(row["Activo"].ToString())
                    });
                }
            }
            return lista;
        }

        #endregion

        #region Estados

        public static List<Estado> ObtieneEstadosPaquetes(int IdTipoEstado) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdTipoEstado",IdTipoEstado,DbType.Int32);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_EstadosByTipo]","",param);
            List<Estado> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Estado>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Estado { 
                         IdEstado = int.Parse(row["IdEstado"].ToString()),
                         Descripcion = row["Descripcion"].ToString(),
                         Activo = Convert.ToBoolean(row["Activo"].ToString()),
                         FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        #endregion
    }
}