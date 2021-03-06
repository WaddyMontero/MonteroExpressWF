﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
            DataTable dt = con.GetDataTable("prc_Obtiene_TiposDocumentos",true);
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
            return ObtenerTiposDocumentos(1).Single(td => td.IdTipoDocumento == IdTipoDocumento);
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

        #region EntidadDirecciones
        public static List<EntidadDireccion> ObtieneEntidadDireccionesByEntidad(int IdEntidad)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdEntidad", IdEntidad, DbType.Int32);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_EntidadesDireccionesByEntidad]", "", param);
            List<EntidadDireccion> entidadDirecciones = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                entidadDirecciones = new List<EntidadDireccion>();
                foreach (DataRow dr in dt.Rows)
                {
                    entidadDirecciones.Add(
                        new EntidadDireccion
                        {
                            IdEntidad = IdEntidad,
                            IdEntidadDireccion = int.Parse(dr["IdEntidadDireccion"].ToString()),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono1 = dr["Telefono1"].ToString(),
                            Telefono2 = dr["Telefono2"].ToString(),
                            IdCiudad = int.Parse(dr["IdCiudad"].ToString()),
                            PorDefecto = Convert.ToBoolean(dr["PorDefecto"].ToString())
                        });
                }
            }
            return entidadDirecciones;
        }

        public static void InsertarEntidadDireccion(EntidadDireccion entidadDireccion) 
        {
            Conexion con = new Conexion("SqlCon");
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@IdEntidad", entidadDireccion.IdEntidad, DbType.Int32));
            parametros.Add(new Parametro("@Direccion", entidadDireccion.Direccion, DbType.String));
            parametros.Add(new Parametro("@IdCiudad", entidadDireccion.IdCiudad, DbType.Int32));
            parametros.Add(new Parametro("@Telefono1", entidadDireccion.Telefono1, DbType.String));
            parametros.Add(new Parametro("@Telefono2", entidadDireccion.Telefono2, DbType.String));
            parametros.Add(new Parametro("@PorDefecto", entidadDireccion.PorDefecto, DbType.Boolean));
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_EntidadDireccion]",parametros.ToArray());
        }

        public static void EliminarEntidadDireccion(int IdEntidadDireccion)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdEntidadDireccion",IdEntidadDireccion,DbType.Int32);
            con.EjecucionNoRetorno("[dbo].[prc_Elimina_EntidadDirecciones]", param);
        }
        public static List<EntidadDireccion> ObtenerEntidadDirecciones(string NumDocumento)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@NumDocumento", NumDocumento, DbType.String);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_DireccionesEntidad]", "", param);
            List<EntidadDireccion> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<EntidadDireccion>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new EntidadDireccion
                    {
                        IdEntidad = int.Parse(row["IdEntidad"].ToString()),
                        Telefono1 = row["Telefono1"].ToString(),
                        Telefono2 = row["Telefono2"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())//,
                        //Ciudad = new Ciudad(int.Parse(row["IdCiudad"].ToString()),row["IdCiudad"].ToString(),new Provincia(Convert.ToInt32(row["IdProvincia"].ToString()),row["Nombre"].ToString(),row["Provincia"].ToString())) 

                    });
                }
            }
            return lista;
        }



        #endregion

        #region Entidad


        public static List<Entidad> ListarEntidades()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Entidades]");
            List<Entidad> lista = null;
            if (dt!=null && dt.Rows.Count > 0)
            {
                lista = new List<Entidad>();
                foreach(DataRow dr in dt.Rows)
                {
                    lista.Add(new Entidad
                    {
                        IdEntidad = int.Parse(dr["IdEntidad"].ToString()),
                        Nombre = dr["Nombre"].ToString(),
                        NumDocumento = dr["NumDocumento"].ToString(),
                        FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        public static void ActualizarNombreEntidad(Entidad Entidad)
        {
            Conexion con = new Conexion("SqlCon");
            Entidad.Nombre = Entidad.Nombre.Replace("+", " ");
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@NuevoNombre", Entidad.Nombre, DbType.String));
            parametros.Add(new Parametro("@IdEntidad", Entidad.IdEntidad, DbType.Int32));
            con.EjecucionNoRetorno("[dbo].[prc_Actualiza_EntidadNombre]",parametros.ToArray());
        }
        public static void InsertarEntidad(string nombreEntidad, int tipoDocumento, string numDocumento)
        {
            Conexion con = new Conexion("SqlCon");
            List<Parametro> parametros = new List<Parametro>();
            nombreEntidad = nombreEntidad.Replace("+", " ");
            parametros.Add(new Parametro("@Nombre", nombreEntidad, DbType.String));
            parametros.Add(new Parametro("@IdTipoDocumento", tipoDocumento, DbType.String));
            parametros.Add(new Parametro("@NumDocumento", numDocumento, DbType.String));
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_Entidad]", parametros.ToArray());
        }
        public static Entidad BuscarEntidad(string NumDocumento) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@NumDocumento",NumDocumento,DbType.String);
            DataTable dt = con.GetDataTable("[dbo].[prc_Busca_Entidad]","",param);
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
                    if (nodoDirecciones != null && nodoDirecciones.HasChildNodes)
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
        public static List<TipoContenido> ObtenerTiposContenidos(int Activo) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@Activo", Activo, DbType.Int16);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_TiposContenidos]","", param);
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

        public static void ActualizaTipoContenido(TipoContenido TipoContenido)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdTipoContenido", TipoContenido.IdTipoContenido, DbType.Int16);
            con.EjecucionNoRetorno("[dbo].[prc_Actualiza_TiposContenidos]", param);
        }

        public static void InsertaTipoContenido(TipoContenido TipoContenido)
        {
            Conexion con = new Conexion("SqlCon");
            TipoContenido.Descripcion = TipoContenido.Descripcion.Replace("+", " ");
            Parametro param = new Parametro("@NuevoTipoContenido", TipoContenido.Descripcion, DbType.String);
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_TiposContenidos]", param);
        }

        #endregion

        #region SegurosEnvios

        public static List<SeguroEnvio> ObtenerSegurosEnvios(int Activo) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@Activo", Activo, DbType.Int16);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_SegurosEnvios]", "",param);
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

        public static void ActualizaSeguroEnvio(SeguroEnvio SeguroEnvio)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdSeguroEnvio", SeguroEnvio.IdSeguroEnvio, DbType.Int16);
            con.EjecucionNoRetorno("[dbo].[prc_Actualiza_SegurosEnvios]", param);
        }

        public static void InsertaSeguroEnvio(SeguroEnvio SeguroEnvio)
        {
            Conexion con = new Conexion("SqlCon");
            SeguroEnvio.Descripcion = SeguroEnvio.Descripcion.Replace("+", " ");
            Parametro param = new Parametro("@NuevoSeguro", SeguroEnvio.Descripcion, DbType.String);
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_SegurosEnvios]", param);
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

        public static List<Estado> ObtieneEstadosEnvios(int IdTipoEstado)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdTipoEstado", IdTipoEstado, DbType.Int32);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_EstadosByTipo]", "", param);
            List<Estado> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Estado>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Estado
                    {
                        IdEstado = int.Parse(row["IdEstado"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        public static void ActualizaEstadosEnvios(Int32 IdEnvio, Int16 IdEstado, int IdUsuario)
        {
            Conexion con = new Conexion("SqlCon");
            DbTransaction tran = con.BeginTransaction();
            try
            {
                List<Parametro> Parametros = new List<Parametro>();
                Parametros.Add(new Parametro("@IdEnvio", IdEnvio, DbType.Int32));
                Parametros.Add(new Parametro("@IdEstado", IdEstado, DbType.Int16));
                Parametros.Add(new Parametro("@IdUsuario", IdUsuario, DbType.Int16));
                con.EjecucionNoRetorno("[dbo].[prc_Actualiza_EstadoEnvio]", Parametros.ToArray());
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
        }

        #endregion

        #region Puertos

        public static List<Puerto> ObtienePuertos(int Activo) 
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@Activo", Activo, DbType.Int16);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Puertos]","",param);
            List<Puerto> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Puerto>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Puerto { 
                        IdPuerto = int.Parse(row["IdPuerto"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        Abrev = row["Abrev"].ToString(),
                        Activo  = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        IdUsuario = int.Parse(row["IdUsuario"].ToString())
                    });
                }
                
            }
            return lista;
        }

        public static void ActualizaPuerto(Puerto Puerto)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdPuerto", Puerto.IdPuerto, DbType.Int16);
            con.EjecucionNoRetorno("[dbo].[prc_Actualiza_Puertos]", param);
        }

        public static void InsertaPuerto(Puerto Puerto)
        {
            Conexion con = new Conexion("SqlCon");
            Puerto.Nombre = Puerto.Nombre.Replace("+", " ");
            Parametro param = new Parametro("@NuevoPuerto", Puerto.Nombre, DbType.String);
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_Puertos]", param);
        }


        #endregion

        #region Envios
            
        public static object RegistrarEnvio(Envio Envio)
        {
            Conexion con = new Conexion("SqlCon");
            DbTransaction tran = con.BeginTransaction();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                DbCommand command;
                if (Envio.Remitente.IdEntidad == 0)
                {
                    parametros.Add(new Parametro("@IdEntidad",0,DbType.Int32,ParameterDirection.Output));
                    parametros.Add(new Parametro("@Nombre", Envio.Remitente.Nombre, DbType.String));
                    parametros.Add(new Parametro("@IdTipoDocumento", Envio.Remitente.IdTipoDocumento, DbType.Int32));
                    parametros.Add(new Parametro("@NumDocumento", Envio.Remitente.NumDocumento, DbType.String));
                    parametros.Add(new Parametro("@Actividad", Envio.Remitente.Actividad, DbType.String));
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Inserta_Entidad]", tran, parametros.ToArray());
                    Envio.Remitente.IdEntidad = int.Parse(command.Parameters["@IdEntidad"].Value.ToString());
                }
                if(Envio.Remitente.EntidadDirecciones[0].IdEntidadDireccion == 0)
                {
                    parametros.Clear();
                    //Inserta la dirección del remitente
                    parametros.Add(new Parametro("@IdEntidad", Envio.Remitente.IdEntidad, DbType.Int32));
                    parametros.Add(new Parametro("@Direccion", Envio.Remitente.EntidadDirecciones[0].Direccion, DbType.String));
                    parametros.Add(new Parametro("@IdCiudad", Envio.Remitente.EntidadDirecciones[0].IdCiudad, DbType.Int32));
                    parametros.Add(new Parametro("@Telefono1", Envio.Remitente.EntidadDirecciones[0].Telefono1, DbType.String));
                    parametros.Add(new Parametro("@Telefono2", Envio.Remitente.EntidadDirecciones[0].Telefono2, DbType.String));
                    parametros.Add(new Parametro("@PorDefecto", Envio.Remitente.EntidadDirecciones[0].PorDefecto, DbType.Boolean));                    
                    parametros.Add(new Parametro("@IdEntidadDireccion", 0, DbType.Int32,ParameterDirection.Output));
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Inserta_EntidadDireccion]", tran, parametros.ToArray());
                    Envio.Remitente.EntidadDirecciones[0].IdEntidadDireccion = int.Parse(command.Parameters["@IdEntidadDireccion"].Value.ToString());
                }
                if (Envio.Destinatario.IdEntidad == 0)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("@IdEntidad", 0, DbType.Int32,ParameterDirection.Output));
                    parametros.Add(new Parametro("@Nombre", Envio.Destinatario.Nombre, DbType.String));
                    parametros.Add(new Parametro("@IdTipoDocumento", Envio.Destinatario.IdTipoDocumento, DbType.Int32));
                    parametros.Add(new Parametro("@NumDocumento", Envio.Destinatario.NumDocumento, DbType.String));
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Inserta_Entidad]", tran, parametros.ToArray());
                    Envio.Destinatario.IdEntidad = int.Parse(command.Parameters["@IdEntidad"].Value.ToString());
                
                }
                if (Envio.Destinatario.EntidadDirecciones[0].IdEntidadDireccion == 0)
                {
                    parametros.Clear();
                    //Inserta la dirección del destinatario
                    parametros.Add(new Parametro("@IdEntidad", Envio.Destinatario.IdEntidad, DbType.Int32));
                    parametros.Add(new Parametro("@Direccion", Envio.Destinatario.EntidadDirecciones[0].Direccion, DbType.String));
                    parametros.Add(new Parametro("@IdCiudad", Envio.Destinatario.EntidadDirecciones[0].IdCiudad, DbType.Int32));
                    parametros.Add(new Parametro("@Telefono1", Envio.Destinatario.EntidadDirecciones[0].Telefono1, DbType.String));
                    parametros.Add(new Parametro("@Telefono2", Envio.Destinatario.EntidadDirecciones[0].Telefono2, DbType.String));
                    parametros.Add(new Parametro("@PorDefecto", Envio.Destinatario.EntidadDirecciones[0].PorDefecto, DbType.Boolean));
                    parametros.Add(new Parametro("@IdEntidadDireccion", 0, DbType.Int32, ParameterDirection.Output));
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Inserta_EntidadDireccion]", tran, parametros.ToArray());
                    Envio.Destinatario.EntidadDirecciones[0].IdEntidadDireccion = int.Parse(command.Parameters["@IdEntidadDireccion"].Value.ToString());
                }

                //Insertando el envio
                parametros.Clear();
                parametros.Add(new Parametro("@Fecha", Convert.ToDateTime(Envio.FechaString), DbType.Date));
                parametros.Add(new Parametro("@AlbaranNum", Envio.AlbaranNum, DbType.String));
                parametros.Add(new Parametro("@IdCiudad", Envio.IdCiudad, DbType.Int32));
                parametros.Add(new Parametro("@IdPuertoOrigen", Envio.IdPuertoOrigen, DbType.Int32));
                parametros.Add(new Parametro("@IdPuertoDestino", Envio.IdPuertoDestino, DbType.Int32));
                parametros.Add(new Parametro("@RecogidoPor", Envio.RecogidoPor, DbType.String));
                parametros.Add(new Parametro("@Ruta", Envio.Ruta, DbType.String));
                parametros.Add(new Parametro("@IdRemitenteDir", Envio.Remitente.EntidadDirecciones[0].IdEntidadDireccion, DbType.Int32));
                parametros.Add(new Parametro("@IdDestinatarioDir", Envio.Destinatario.EntidadDirecciones[0].IdEntidadDireccion, DbType.Int32));
                parametros.Add(new Parametro("@IdSeguroEnvio", Envio.IdSeguro, DbType.Int32));
                //parametros.Add(new Parametro("@Valor", Envio.Valor, DbType.Decimal));
                parametros.Add(new Parametro("@Valor", Envio.Valor, DbType.String));
                parametros.Add(new Parametro("@IdEstado", 1, DbType.Int32));
                parametros.Add(new Parametro("@IdEnvio", Envio.IdEnvio, DbType.Int32,ParameterDirection.Output));
                //parametros.Add(new Parametro("@IdUsuario", Usuario.UsuarioActual.IdUsuario, DbType.Int32));
                parametros.Add(new Parametro("@IdUsuario", Usuario.UsuarioActual.IdUsuario, DbType.Int32));
                command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_Envio]", tran, parametros.ToArray());
                Envio.IdEnvio = int.Parse(command.Parameters["@IdEnvio"].Value.ToString());

                
                //Insertando los tipos de contenido
                
                foreach (TipoContenido cont in Envio.TiposContenidos)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("@IdEnvio", Envio.IdEnvio, DbType.Int32));
                    parametros.Add(new Parametro("@IdTipoContenido", cont.IdTipoContenido, DbType.Int32));
                    con.EjecucionNoRetorno("[dbo].[prc_Inserta_TipoContenidoEnvio]", tran, parametros.ToArray());
                }
                //Inserta los paquetes del envio
                foreach (PaqueteEnvio paq in Envio.PaquetesEnvios)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("@IdEnvio", Envio.IdEnvio, DbType.Int32));
                    parametros.Add(new Parametro("@Cantidad", paq.Cantidad, DbType.Int32));
                    parametros.Add(new Parametro("@IdTamanioPaquete", paq.IdTamanioPaquete, DbType.Int32));
                    parametros.Add(new Parametro("@Descripcion", paq.Descripcion, DbType.String));
                    parametros.Add(new Parametro("@IdEstado", paq.IdEstado, DbType.Int32));
                    parametros.Add(new Parametro("@Peso", paq.Peso, DbType.Decimal));
                    con.EjecucionNoRetorno("[dbo].[prc_Inserta_PaqueteEnvio]", tran, parametros.ToArray());
                }

                tran.Commit();
                return new { Result = "OK", Title="Registrar Envio", Message = "El envio se ha registrado satisfactoriamente.",IdEnvio = Envio.IdEnvio};
                
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return new { Result = "ERROR", Message = ex.Message,Title="Error" };
            }
        }

        public static Envio ObtenerEnvio(int IdEnvio) 
        {
            Conexion con = new Conexion("SqlCon");

            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_EnvioById]","Envios",new Parametro("@IdEnvio",IdEnvio,DbType.Int32));
            Envio envio = null;
            if (dt!= null && dt.Rows.Count > 0)
            {
                string data = dt.Rows[0][0].ToString();
                if (data != "")
                {
                    envio = new Envio();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(data);
                    XmlNode nodoEnvio = xmlDocument.FirstChild;
                    envio.IdEnvio = IdEnvio;
                    envio.Fecha = Convert.ToDateTime(nodoEnvio.Attributes["Fecha"].Value.ToString());
                    envio.IdCiudad = int.Parse(nodoEnvio.Attributes["IdCiudad"].Value.ToString());
                    envio.Ciudad = nodoEnvio.Attributes["Ciudad"].Value.ToString();
                    envio.IdProvincia = int.Parse(nodoEnvio.Attributes["IdProvincia"].Value.ToString());
                    envio.Provincia = nodoEnvio.Attributes["Provincia"].Value.ToString();
                    //envio.Oficina = new Oficina { 
                    //    IdOficina = int.Parse(nodoEnvio.Attributes["IdOficina"].Value.ToString()),
                    //    Nombre = nodoEnvio.Attributes["NombreOficina"].Value.ToString()
                    //};                
                    envio.AlbaranNum = nodoEnvio.Attributes["AlbaranNum"].Value.ToString();
                    envio.IdSeguro = int.Parse(nodoEnvio.Attributes["IdSeguroEnvio"].Value.ToString());
                    envio.SeguroEnvio = new SeguroEnvio
                    {
                        IdSeguroEnvio = int.Parse(nodoEnvio.Attributes["IdSeguroEnvio"].Value.ToString()),
                        Descripcion = nodoEnvio.Attributes["DescripcionSeguro"].Value.ToString()
                    };
                    //envio.Valor = Convert.ToDecimal(nodoEnvio.Attributes["Valor"].Value.ToString());
                    envio.Valor = nodoEnvio.Attributes["Valor"].Value.ToString();
                    envio.FechaIngreso = Convert.ToDateTime(nodoEnvio.Attributes["FechaIngreso"].Value.ToString());
                    envio.IdPuertoOrigen = int.Parse(nodoEnvio.Attributes["IdPuertoOrigen"].Value.ToString());
                    envio.IdPuertoDestino = int.Parse(nodoEnvio.Attributes["IdPuertoDestino"].Value.ToString());
                    envio.nombrePuertoOrigen = nodoEnvio.Attributes["PuertoOrigen"].Value.ToString();
                    envio.nombrePuertoDestino = nodoEnvio.Attributes["PuertoDestino"].Value.ToString();
                    envio.NumeroEnvio = (nodoEnvio.Attributes["NumeroEnvio"] != null) ? nodoEnvio.Attributes["NumeroEnvio"].Value.ToString() : "";

                    //Remitente
                    XmlNode nodoEntidad = nodoEnvio.SelectSingleNode("Remitente");
                    if (nodoEntidad != null)
                    {
                        envio.Remitente = new Entidad
                        {
                            IdEntidad = int.Parse(nodoEntidad.Attributes["IdEntidad"].Value.ToString()),
                            Nombre = nodoEntidad.Attributes["Nombre"].Value.ToString(),
                            IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                            Actividad = (nodoEntidad.Attributes["Actividad"] != null) ? nodoEntidad.Attributes["Actividad"].Value.ToString() : "",
                            TiposDocumento = new TipoDocumento
                            {
                                IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                                Descripcion = nodoEntidad.Attributes["DescripcionTipoDocumento"].Value.ToString()
                            },
                            NumDocumento = nodoEntidad.Attributes["NumDocumento"].Value.ToString(),
                            EntidadDirecciones = new List<EntidadDireccion>()

                        };
                        envio.Remitente.EntidadDirecciones.Add(
                            new EntidadDireccion
                            {
                                IdEntidadDireccion = int.Parse(nodoEntidad.Attributes["IdEntidadDireccion"].Value.ToString()),
                                Direccion = nodoEntidad.Attributes["Direccion"].Value.ToString(),
                                Telefono1 = nodoEntidad.Attributes["Telefono1"].Value.ToString(),
                                Telefono2 = (nodoEntidad.Attributes["Telefono2"] != null) ? nodoEntidad.Attributes["Telefono2"].Value.ToString() : "",
                                Ciudad = new Ciudad
                                {
                                    IdCiudad = int.Parse(nodoEntidad.Attributes["IdCiudad"].Value.ToString()),
                                    Nombre = nodoEntidad.Attributes["NombreCiudad"].Value.ToString(),
                                    Provincia = new Provincia
                                    {
                                        IdProvincia = int.Parse(nodoEntidad.Attributes["IdProvincia"].Value.ToString()),
                                        Nombre = nodoEntidad.Attributes["NombreProvincia"].Value.ToString(),
                                        Pais = new Pais
                                        {
                                            IdPais = int.Parse(nodoEntidad.Attributes["IdPais"].Value.ToString()),
                                            Nombre = nodoEntidad.Attributes["NombrePais"].Value.ToString()
                                        }

                                    }
                                }
                            }
                        );
                    }
                    //Destinatario
                    nodoEntidad = nodoEnvio.SelectSingleNode("Destinatario");
                    if (nodoEntidad != null)
                    {
                        envio.Destinatario = new Entidad
                        {
                            IdEntidad = int.Parse(nodoEntidad.Attributes["IdEntidad"].Value.ToString()),
                            Nombre = nodoEntidad.Attributes["Nombre"].Value.ToString(),
                            IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                            TiposDocumento = new TipoDocumento
                            {
                                IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                                Descripcion = nodoEntidad.Attributes["DescripcionTipoDocumento"].Value.ToString()
                            },
                            NumDocumento = nodoEntidad.Attributes["NumDocumento"].Value.ToString(),
                            EntidadDirecciones = new List<EntidadDireccion>(),

                        };
                        envio.Destinatario.EntidadDirecciones.Add(
                            new EntidadDireccion
                            {
                                IdEntidadDireccion = int.Parse(nodoEntidad.Attributes["IdEntidadDireccion"].Value.ToString()),
                                Direccion = nodoEntidad.Attributes["Direccion"].Value.ToString(),
                                Telefono1 = nodoEntidad.Attributes["Telefono1"].Value.ToString(),
                                Telefono2 = (nodoEntidad.Attributes["Telefono2"] != null) ? nodoEntidad.Attributes["Telefono2"].Value.ToString() : "",
                                Ciudad = new Ciudad
                                {
                                    IdCiudad = int.Parse(nodoEntidad.Attributes["IdCiudad"].Value.ToString()),
                                    Nombre = nodoEntidad.Attributes["NombreCiudad"].Value.ToString(),
                                    Provincia = new Provincia
                                    {
                                        IdProvincia = int.Parse(nodoEntidad.Attributes["IdProvincia"].Value.ToString()),
                                        Nombre = nodoEntidad.Attributes["NombreProvincia"].Value.ToString(),
                                        Pais = new Pais
                                        {
                                            IdPais = int.Parse(nodoEntidad.Attributes["IdPais"].Value.ToString()),
                                            Nombre = nodoEntidad.Attributes["NombrePais"].Value.ToString()
                                        }
                                    }
                                }
                            }
                        );
                    }
                    //Tipos de contenidos del envio
                    XmlNode nodoTiposContenidos = nodoEnvio.SelectSingleNode("TiposContenidos");
                    if (nodoTiposContenidos != null && nodoTiposContenidos.HasChildNodes)
                    {
                        envio.TiposContenidos = new List<TipoContenido>();
                        foreach (XmlNode hijo in nodoTiposContenidos.ChildNodes)
                        {
                            envio.TiposContenidos.Add(new TipoContenido
                            {
                                IdTipoContenido = int.Parse(hijo.Attributes["IdTipoContenido"].Value.ToString()),
                                Descripcion = hijo.Attributes["DescripcionTipoContenido"].Value.ToString(),
                            });
                        }
                    }
                    //Paquetes del envio
                    XmlNode nodoPaquetes = nodoEnvio.SelectSingleNode("PaquetesEnvio");
                    if (nodoPaquetes != null && nodoPaquetes.HasChildNodes)
                    {
                        envio.PaquetesEnvios = new List<PaqueteEnvio>();
                        foreach (XmlNode hijo in nodoPaquetes.ChildNodes)
                        {
                            envio.PaquetesEnvios.Add(new PaqueteEnvio
                            {
                                IdPaqueteEnvio = int.Parse(hijo.Attributes["IdPaqueteEnvio"].Value.ToString()),
                                Cantidad = int.Parse(hijo.Attributes["Cantidad"].Value.ToString()),
                                IdTamanioPaquete = int.Parse(hijo.Attributes["IdTamanioPaquete"].Value.ToString()),
                                TamanioPaquete = new TamanioPaquete
                                {
                                    IdTamanioPaquete = int.Parse(hijo.Attributes["IdTamanioPaquete"].Value.ToString()),
                                    Descripcion = hijo.Attributes["DescripcionTamanoPaquete"].Value.ToString()
                                },
                                Descripcion = hijo.Attributes["DescripcionPaquete"].Value.ToString(),
                                Estado = new Estado
                                {
                                    IdEstado = int.Parse(hijo.Attributes["IdEstado"].Value.ToString()),
                                    Descripcion = hijo.Attributes["EstadoPaquete"].Value.ToString()

                                },
                                Peso = Convert.ToDecimal(hijo.Attributes["Peso"].Value.ToString())
                            });
                        }
                    } 
                }
        }
            return envio;

        }

        public static Envio ObtenerEnvioByAlbaran(string AlbaranNum)
        {
            Conexion con = new Conexion("SqlCon");

            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_EnvioByAlbaran]", "Envios", new Parametro("@AlbaranNum", AlbaranNum, DbType.String));
            Envio envio = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                string data = dt.Rows[0][0].ToString();
                if (data != "")
                {
                    envio = new Envio();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(data);
                    XmlNode nodoEnvio = xmlDocument.FirstChild;
                    envio.IdEnvio = int.Parse(nodoEnvio.Attributes["IdEnvio"].Value.ToString());
                    envio.Fecha = Convert.ToDateTime(nodoEnvio.Attributes["Fecha"].Value.ToString());
                    envio.IdCiudad = int.Parse(nodoEnvio.Attributes["IdCiudad"].Value.ToString());
                    envio.Ciudad = nodoEnvio.Attributes["Ciudad"].Value.ToString();
                    envio.IdProvincia = int.Parse(nodoEnvio.Attributes["IdProvincia"].Value.ToString());
                    envio.Provincia = nodoEnvio.Attributes["Provincia"].Value.ToString();
                    //envio.Oficina = new Oficina { 
                    //    IdOficina = int.Parse(nodoEnvio.Attributes["IdOficina"].Value.ToString()),
                    //    Nombre = nodoEnvio.Attributes["NombreOficina"].Value.ToString()
                    //};                
                    envio.AlbaranNum = AlbaranNum.ToString();
                    envio.IdSeguro = int.Parse(nodoEnvio.Attributes["IdSeguroEnvio"].Value.ToString());
                    envio.SeguroEnvio = new SeguroEnvio
                    {
                        IdSeguroEnvio = int.Parse(nodoEnvio.Attributes["IdSeguroEnvio"].Value.ToString()),
                        Descripcion = nodoEnvio.Attributes["DescripcionSeguro"].Value.ToString()
                    };
                    //envio.Valor = Convert.ToDecimal(nodoEnvio.Attributes["Valor"].Value.ToString());
                    envio.Valor = nodoEnvio.Attributes["Valor"].Value.ToString();
                    envio.FechaIngreso = Convert.ToDateTime(nodoEnvio.Attributes["FechaIngreso"].Value.ToString());
                    envio.IdPuertoOrigen = int.Parse(nodoEnvio.Attributes["IdPuertoOrigen"].Value.ToString());
                    envio.IdPuertoDestino = int.Parse(nodoEnvio.Attributes["IdPuertoDestino"].Value.ToString());
                    envio.nombrePuertoOrigen = nodoEnvio.Attributes["PuertoOrigen"].Value.ToString();
                    envio.nombrePuertoDestino = nodoEnvio.Attributes["PuertoDestino"].Value.ToString();
                    envio.NumeroEnvio = (nodoEnvio.Attributes["NumeroEnvio"] != null) ? nodoEnvio.Attributes["NumeroEnvio"].Value.ToString() : "";
                    XmlNode nodoEstadoEnvio = nodoEnvio.SelectSingleNode("EstadoEnvio");
                    envio.IdEstado = int.Parse(nodoEstadoEnvio.Attributes["IdEstado"].Value.ToString());
                    //Remitente
                    XmlNode nodoEntidad = nodoEnvio.SelectSingleNode("Remitente");
                    if (nodoEntidad != null)
                    {
                        envio.Remitente = new Entidad
                        {
                            IdEntidad = int.Parse(nodoEntidad.Attributes["IdEntidad"].Value.ToString()),
                            Nombre = nodoEntidad.Attributes["Nombre"].Value.ToString(),
                            IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                            Actividad = (nodoEntidad.Attributes["Actividad"] != null) ? nodoEntidad.Attributes["Actividad"].Value.ToString() : "",
                            TiposDocumento = new TipoDocumento
                            {
                                IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                                Descripcion = nodoEntidad.Attributes["DescripcionTipoDocumento"].Value.ToString()
                            },
                            NumDocumento = nodoEntidad.Attributes["NumDocumento"].Value.ToString(),
                            EntidadDirecciones = new List<EntidadDireccion>()

                        };
                        envio.Remitente.EntidadDirecciones.Add(
                            new EntidadDireccion
                            {
                                IdEntidadDireccion = int.Parse(nodoEntidad.Attributes["IdEntidadDireccion"].Value.ToString()),
                                Direccion = nodoEntidad.Attributes["Direccion"].Value.ToString(),
                                Telefono1 = nodoEntidad.Attributes["Telefono1"].Value.ToString(),
                                Telefono2 = (nodoEntidad.Attributes["Telefono2"] != null) ? nodoEntidad.Attributes["Telefono2"].Value.ToString() : "",
                                Ciudad = new Ciudad
                                {
                                    IdCiudad = int.Parse(nodoEntidad.Attributes["IdCiudad"].Value.ToString()),
                                    Nombre = nodoEntidad.Attributes["NombreCiudad"].Value.ToString(),
                                    Provincia = new Provincia
                                    {
                                        IdProvincia = int.Parse(nodoEntidad.Attributes["IdProvincia"].Value.ToString()),
                                        Nombre = nodoEntidad.Attributes["NombreProvincia"].Value.ToString(),
                                        Pais = new Pais
                                        {
                                            IdPais = int.Parse(nodoEntidad.Attributes["IdPais"].Value.ToString()),
                                            Nombre = nodoEntidad.Attributes["NombrePais"].Value.ToString()
                                        }

                                    }
                                }
                            }
                        );
                    }
                    //Destinatario
                    nodoEntidad = nodoEnvio.SelectSingleNode("Destinatario");
                    if (nodoEntidad != null)
                    {
                        envio.Destinatario = new Entidad
                        {
                            IdEntidad = int.Parse(nodoEntidad.Attributes["IdEntidad"].Value.ToString()),
                            Nombre = nodoEntidad.Attributes["Nombre"].Value.ToString(),
                            IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                            TiposDocumento = new TipoDocumento
                            {
                                IdTipoDocumento = int.Parse(nodoEntidad.Attributes["IdTipoDocumento"].Value.ToString()),
                                Descripcion = nodoEntidad.Attributes["DescripcionTipoDocumento"].Value.ToString()
                            },
                            NumDocumento = nodoEntidad.Attributes["NumDocumento"].Value.ToString(),
                            EntidadDirecciones = new List<EntidadDireccion>(),

                        };
                        envio.Destinatario.EntidadDirecciones.Add(
                            new EntidadDireccion
                            {
                                IdEntidadDireccion = int.Parse(nodoEntidad.Attributes["IdEntidadDireccion"].Value.ToString()),
                                Direccion = nodoEntidad.Attributes["Direccion"].Value.ToString(),
                                Telefono1 = nodoEntidad.Attributes["Telefono1"].Value.ToString(),
                                Telefono2 = (nodoEntidad.Attributes["Telefono2"] != null) ? nodoEntidad.Attributes["Telefono2"].Value.ToString() : "",
                                Ciudad = new Ciudad
                                {
                                    IdCiudad = int.Parse(nodoEntidad.Attributes["IdCiudad"].Value.ToString()),
                                    Nombre = nodoEntidad.Attributes["NombreCiudad"].Value.ToString(),
                                    Provincia = new Provincia
                                    {
                                        IdProvincia = int.Parse(nodoEntidad.Attributes["IdProvincia"].Value.ToString()),
                                        Nombre = nodoEntidad.Attributes["NombreProvincia"].Value.ToString(),
                                        Pais = new Pais
                                        {
                                            IdPais = int.Parse(nodoEntidad.Attributes["IdPais"].Value.ToString()),
                                            Nombre = nodoEntidad.Attributes["NombrePais"].Value.ToString()
                                        }
                                    }
                                }
                            }
                        );
                    }
                    //Tipos de contenidos del envio
                    XmlNode nodoTiposContenidos = nodoEnvio.SelectSingleNode("TiposContenidos");
                    if (nodoTiposContenidos != null && nodoTiposContenidos.HasChildNodes)
                    {
                        envio.TiposContenidos = new List<TipoContenido>();
                        foreach (XmlNode hijo in nodoTiposContenidos.ChildNodes)
                        {
                            envio.TiposContenidos.Add(new TipoContenido
                            {
                                IdTipoContenido = int.Parse(hijo.Attributes["IdTipoContenido"].Value.ToString()),
                                Descripcion = hijo.Attributes["DescripcionTipoContenido"].Value.ToString(),
                            });
                        }
                    }
                    //Paquetes del envio
                    XmlNode nodoPaquetes = nodoEnvio.SelectSingleNode("PaquetesEnvio");
                    if (nodoPaquetes != null && nodoPaquetes.HasChildNodes)
                    {
                        envio.PaquetesEnvios = new List<PaqueteEnvio>();
                        foreach (XmlNode hijo in nodoPaquetes.ChildNodes)
                        {
                            envio.PaquetesEnvios.Add(new PaqueteEnvio
                            {
                                IdPaqueteEnvio = int.Parse(hijo.Attributes["IdPaqueteEnvio"].Value.ToString()),
                                Cantidad = int.Parse(hijo.Attributes["Cantidad"].Value.ToString()),
                                IdTamanioPaquete = int.Parse(hijo.Attributes["IdTamanioPaquete"].Value.ToString()),
                                TamanioPaquete = new TamanioPaquete
                                {
                                    IdTamanioPaquete = int.Parse(hijo.Attributes["IdTamanioPaquete"].Value.ToString()),
                                    Descripcion = hijo.Attributes["DescripcionTamanoPaquete"].Value.ToString()
                                },
                                Descripcion = hijo.Attributes["DescripcionPaquete"].Value.ToString(),
                                Estado = new Estado
                                {
                                    IdEstado = int.Parse(hijo.Attributes["IdEstado"].Value.ToString()),
                                    Descripcion = hijo.Attributes["EstadoPaquete"].Value.ToString()

                                },
                                Peso = Convert.ToDecimal(hijo.Attributes["Peso"].Value.ToString())
                            });
                        }
                    }
                }
            }
            return envio;

        }

        public static int TotalEnvios(string Nombre, string Fecha, string Albaran)
        {
            Conexion con = new Conexion("SqlCon");
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@Nombre", Nombre, DbType.String));
            parametros.Add(new Parametro("@Fecha", Fecha, DbType.String));
            parametros.Add(new Parametro("@Albaran", Albaran, DbType.String));
            DataTable dt = con.GetDataTable("[dbo].[prc_ObtieneTotalEnvios]","", parametros.ToArray());
            int Total = int.Parse(dt.Rows[0]["TotalEnvios"].ToString());

            return Total;
        }
        public static List<Envio> ListarEnvios(int PageIndex,int PageSize,string Nombre,string Fecha,string Albaran, string Estado)
        {
            Conexion con = new Conexion("SqlCon");
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@PageIndex",PageIndex,DbType.Int32));
            parametros.Add(new Parametro("@PageSize", PageSize, DbType.Int32));
            parametros.Add(new Parametro("@Nombre", Nombre, DbType.String));
            parametros.Add(new Parametro("@Fecha", Fecha, DbType.String));
            parametros.Add(new Parametro("@Albaran", Albaran, DbType.String));
            parametros.Add(new Parametro("@Estado", Estado, DbType.String));
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Envios]","",parametros.ToArray());
            List<Envio> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<Envio>();
                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(new Envio
                    {
                        IdEnvio = int.Parse(dr["IdEnvio"].ToString()),
                        NumeroEnvio = dr["NumeroEnvio"].ToString(),
                        Fecha = Convert.ToDateTime(dr["FechaEnvio"].ToString()),
                        IdCiudad = int.Parse(dr["IdCiudad"].ToString()),
                        Ciudad = dr["Ciudad"].ToString(),
                        IdProvincia = int.Parse(dr["IdProvincia"].ToString()),
                        Provincia = dr["Provincia"].ToString(),
                        AlbaranNum = dr["NumeroAlbaran"].ToString(),
                        Remitente = new Entidad { IdEntidad = int.Parse(dr["IdEntidadRemitente"].ToString()), Nombre = dr["Remitente"].ToString() },
                        Destinatario = new Entidad { IdEntidad = int.Parse(dr["IdEntidadDestinatario"].ToString()), Nombre = dr["Destinatario"].ToString() },
                        IdSeguro = int.Parse(dr["IdSeguroEnvio"].ToString()),
                        Valor = dr["Valor"].ToString(),
                        IdPuertoOrigen = int.Parse(dr["IdPuertoOrigen"].ToString()),
                        IdPuertoDestino = int.Parse(dr["IdPuertoDestino"].ToString()),
                        direccionRemitente = dr["DireccionRemitente"].ToString(),
                        direccionDestinatario = dr["DireccionDestinatario"].ToString(),
                        nombreRemitente = dr["Remitente"].ToString(),
                        nombreDestinatario = dr["Destinatario"].ToString(),
                        nombrePuertoDestino = dr["PuertoDestino"].ToString(),
                        nombrePuertoOrigen = dr["PuertoOrigen"].ToString(),
                        descripcionSeguro = dr["SeguroEnvio"].ToString(),
                        estadoEnvio = dr["EstadoEnvio"].ToString()
                    });
                }
            }
            return lista;
        }
        #endregion

        //#region Oficinas

        //public static List<Oficina> ObtenerOficinas(int Activo) 
        //{
        //    Conexion con = new Conexion("SqlCon");
        //    Parametro param = new Parametro("@Activo", Activo, DbType.Int16);
        //    DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Oficinas]","", param);
        //    List<Oficina> lista = null;

        //    if (dt != null && dt.Rows.Count > 0)
        //    {

        //        lista = new List<Oficina>();
        //        foreach (DataRow row in dt.Rows)

        //        {
        //            lista.Add(new Oficina

        //            {
        //                IdOficina = int.Parse(row["IdOficina"].ToString()),
        //                Nombre = row["Nombre"].ToString(),
        //                FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
        //                Activo = Convert.ToBoolean(row["Activo"].ToString())

        //            });
        //        }
        //    }
        //    return lista;
        //}

        //public static void ActualizaOficina(Oficina Oficina)
        //{
        //    Conexion con = new Conexion("SqlCon");
        //    Parametro param = new Parametro("@IdOficina", Oficina.IdOficina, DbType.Int16);
        //    con.EjecucionNoRetorno("[dbo].[prc_Actualiza_Oficinas]", param);
        //}

        //public static void InsertaOficina(Oficina Oficina)
        //{
        //    Conexion con = new Conexion("SqlCon");
        //    Oficina.Nombre = Oficina.Nombre.Replace("+", " ");
        //    Parametro param = new Parametro("@NombreOficina", Oficina.Nombre, DbType.String);
        //    con.EjecucionNoRetorno("[dbo].[prc_Inserta_Oficinas]", param);
        //}


        //#endregion

        #region PaquetesEnvios

        public static List<PaqueteEnvio> ObtenerPaquetesPorEnvio(int IdEnvio)
        {
            Conexion conexion = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdEnvio", IdEnvio, DbType.Int32);
            DataTable dt = conexion.GetDataTable("[dbo].[prc_Obtiene_PaqueteEnviosByEnvio]","",param);
            List<PaqueteEnvio> lista = null;
            if (dt!=null && dt.Rows.Count > 0)
            {
                lista = new List<PaqueteEnvio>();
                foreach (DataRow dr in dt.Rows)
                {
                   lista .Add(new PaqueteEnvio{
                        IdEnvio = IdEnvio,
                        IdPaqueteEnvio = int.Parse(dr["IdPaqueteEnvio"].ToString()),
                        Descripcion = dr["DescripcionPaquete"].ToString(),
                        Cantidad = int.Parse(dr["Cantidad"].ToString()),
                        IdEstado = int.Parse(dr["IdEstado"].ToString()),
                        EstadoPaquete = dr["EstadoPaquete"].ToString(),
                        IdTamanioPaquete = int.Parse(dr["IdTamanioPaquete"].ToString()),
                        TamanoPaquete = dr["TamanoPaquete"].ToString(),
                        Peso = decimal.Parse(dr["Peso"].ToString()),
                        ValorEnvio = dr["ValorEnvio"].ToString()
                    });
                }
                
                }

            return lista;
            }
        #endregion

        #region Usuarios

        public static Usuario AutenticarUsuario(string Usuario, string Contrasena)
        {
            Conexion con = new Conexion("SqlCon");
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();            
            byte[] contr = encoding.GetBytes(Contrasena);
            List<Parametro> param = new List<Parametro>();
            param.Add(new Parametro("@Usuario",Usuario,DbType.String));
            param.Add(new Parametro("@Contrasena", contr, DbType.Binary));
            DataTable dt = con.GetDataTable("[dbo].[prc_AutenticarUsuario]","", param.ToArray());
            Usuario usuario = null;
            if (dt != null && dt.Rows.Count> 0)
            {
                usuario = new Usuario();
                usuario.IdUsuario = int.Parse(dt.Rows[0]["IdUsuario"].ToString());
                usuario.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                usuario.CambiarContrasena = Convert.ToBoolean(dt.Rows[0]["CambiarContrasena"].ToString());
                usuario.Habilitado = Convert.ToBoolean(dt.Rows[0]["Habilitado"].ToString());
                usuario.Rol = new Rol { IdRol = int.Parse(dt.Rows[0]["IdRol"].ToString()) };
            }
            return usuario;
        }

        #endregion

        #region Graficas

        public static List<KeyValuePair<int, string>> TotalEnviosPorMes() 
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("prc_ObtieneVentasPorMes",true);
            List<KeyValuePair<int, string>> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<KeyValuePair<int, string>>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new KeyValuePair<int, string>(int.Parse(row["IdMes"].ToString()), row["Envios"].ToString()));
                }
            }
            return lista;
        
        }

        public static List<KeyValuePair<string, string>> Top5Envios()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("select * from View_Top5Envios", false);
            List<KeyValuePair<string, string>> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<KeyValuePair<string, string>>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new KeyValuePair<string, string>(row["Remitente"].ToString(), row["CantidadEnvios"].ToString()));
                }
            }
            return lista;

        }
        public static List<KeyValuePair<string, string>> Top5Recepciones()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("select * from View_Top5Recepciones", false);
            List<KeyValuePair<string, string>> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<KeyValuePair<string, string>>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new KeyValuePair<string, string>(row["Destinatario"].ToString(), row["CantidadRecepciones"].ToString()));
                }
            }
            return lista;

        }

        #endregion

        #region TiposDocumentos

        public static List<TipoDocumento> ObtenerTiposDocumentos(int Activo)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@Activo", Activo, DbType.Int16);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_TiposDocumentos]", "", param);
            List<TipoDocumento> lista = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                lista = new List<TipoDocumento>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new TipoDocumento
                    {
                        IdTipoDocumento = int.Parse(row["IdTipoDocumento"].ToString()),
                        Descripcion = row["Descripcion"].ToString(),
                        Mascara = row["Mascara"].ToString(),
                        Activo = Convert.ToBoolean(row["Activo"].ToString()),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString())
                    });
                }
            }
            return lista;
        }

        public static void ActualizaTipoDocumento(TipoDocumento TipoDocumento)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@IdTipoDocumento", TipoDocumento.IdTipoDocumento, DbType.Int16);
            con.EjecucionNoRetorno("[dbo].[prc_Actualiza_TiposDocumentos]", param);
        }

        public static void InsertaTipoDocumento(TipoDocumento TipoDocumento)
        {
            Conexion con = new Conexion("SqlCon");
            TipoDocumento.Descripcion = TipoDocumento.Descripcion.Replace("+", " ");
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@NuevoTipoDocumento", TipoDocumento.Descripcion, DbType.String));
            parametros.Add(new Parametro("@Mascara", TipoDocumento.Mascara, DbType.String));
            con.EjecucionNoRetorno("[dbo].[prc_Inserta_TipoDocumento]", parametros.ToArray());
        }
        #endregion
    }
}