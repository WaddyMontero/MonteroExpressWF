using System;
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
            con.EjecucionNoRetorno("[dbo].[prc_Insertar_EntidadDireccion]",parametros.ToArray());
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
            con.EjecucionNoRetorno("[dbo].[prc_Insertar_Entidad]", parametros.ToArray());
        }
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


        #endregion

        #region Puertos

        public static List<Puerto> ObtienePuertos() 
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Puertos]",true);
            List<Puerto> lista = null;
            if (dt != null && dt.Rows.Count >0)
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
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_Entidad]", tran, parametros.ToArray());
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
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_EntidadDireccion]", tran, parametros.ToArray());
                    Envio.Remitente.EntidadDirecciones[0].IdEntidadDireccion = int.Parse(command.Parameters["@IdEntidadDireccion"].Value.ToString());
                }
                if (Envio.Destinatario.IdEntidad == 0)
                {
                    parametros.Add(new Parametro("@IdEntidad", 0, DbType.Int32,ParameterDirection.Output));
                    parametros.Add(new Parametro("@Nombre", Envio.Destinatario.Nombre, DbType.String));
                    parametros.Add(new Parametro("@IdTipoDocumento", Envio.Destinatario.IdTipoDocumento, DbType.Int32));
                    parametros.Add(new Parametro("@NumDocumento", Envio.Destinatario.NumDocumento, DbType.String));
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_Entidad]", tran, parametros.ToArray());
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
                    command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_EntidadDireccion]", tran, parametros.ToArray());
                    Envio.Destinatario.EntidadDirecciones[0].IdEntidadDireccion = int.Parse(command.Parameters["@IdEntidadDireccion"].Value.ToString());
                }

                //Insertando el envio
                parametros.Clear();
                parametros.Add(new Parametro("@Fecha", Convert.ToDateTime(Envio.FechaString), DbType.Date));
                parametros.Add(new Parametro("@AlbaranNum", Envio.AlbaranNum, DbType.String));
                parametros.Add(new Parametro("@IdOficina", Envio.IdOficina, DbType.Int32));
                parametros.Add(new Parametro("@IdPuertoOrigen", Envio.IdPuertoOrigen, DbType.Int32));
                parametros.Add(new Parametro("@IdPuertoDestino", Envio.IdPuertoDestino, DbType.Int32));
                parametros.Add(new Parametro("@RecogidoPor", Envio.RecogidoPor, DbType.String));
                parametros.Add(new Parametro("@Ruta", Envio.Ruta, DbType.String));
                parametros.Add(new Parametro("@IdRemitenteDir", Envio.Remitente.EntidadDirecciones[0].IdEntidadDireccion, DbType.Int32));
                parametros.Add(new Parametro("@IdDestinatarioDir", Envio.Destinatario.EntidadDirecciones[0].IdEntidadDireccion, DbType.Int32));
                parametros.Add(new Parametro("@IdSeguroEnvio", Envio.IdSeguro, DbType.Int32));
                parametros.Add(new Parametro("@Valor", Envio.Valor, DbType.Decimal));
                parametros.Add(new Parametro("@IdEstado", Envio.IdEstado, DbType.Int32));
                parametros.Add(new Parametro("@IdEnvio", Envio.IdEnvio, DbType.Int32,ParameterDirection.Output));
                //parametros.Add(new Parametro("@IdUsuario", Usuario.UsuarioActual.IdUsuario, DbType.Int32));
                parametros.Add(new Parametro("@IdUsuario", 2, DbType.Int32));
                command = con.EjecucionNoRetornoWithOutput("[dbo].[prc_Insertar_Envio]", tran, parametros.ToArray());
                Envio.IdEnvio = int.Parse(command.Parameters["@IdEnvio"].Value.ToString());

                
                //Insertando los tipos de contenido
                
                foreach (TipoContenido cont in Envio.TiposContenidos)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("@IdEnvio", Envio.IdEnvio, DbType.Int32));
                    parametros.Add(new Parametro("@IdTipoContenido", cont.IdTipoContenido, DbType.Int32));
                    con.EjecucionNoRetorno("[dbo].[prc_Insertar_TipoContenidoEnvio]", tran, parametros.ToArray());
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
                    con.EjecucionNoRetorno("[dbo].[prc_Insertar_PaqueteEnvio]", tran, parametros.ToArray());
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

        public static List<Envio> ListarEnvios()
        {
            Conexion con = new Conexion("SqlCon");
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Envios]");
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
                        AlbaranNum = dr["NumeroAlbaran"].ToString(),
                        Remitente = new Entidad { IdEntidad = int.Parse(dr["IdEntidadRemitente"].ToString()), Nombre = dr["Remitente"].ToString() },
                        Destinatario = new Entidad { IdEntidad = int.Parse(dr["IdEntidadDestinatario"].ToString()), Nombre = dr["Destinatario"].ToString() },
                        IdSeguro = int.Parse(dr["IdSeguroEnvio"].ToString()),
                        Valor = decimal.Parse(dr["Valor"].ToString()),
                        IdPuertoOrigen = int.Parse(dr["IdPuertoOrigen"].ToString()),
                        IdPuertoDestino = int.Parse(dr["IdPuertoDestino"].ToString()),
                        direccionRemitente = dr["DireccionRemitente"].ToString(),
                        direccionDestinatario = dr["DireccionDestinatario"].ToString(),
                        nombreRemitente = dr["Remitente"].ToString(),
                        nombreDestinatario = dr["Destinatario"].ToString(),
                        nombrePuertoDestino = dr["PuertoDestino"].ToString(),
                        nombrePuertoOrigen = dr["PuertoOrigen"].ToString(),
                        descripcionSeguro = dr["SeguroEnvio"].ToString()
                    });
                }
            }
            return lista;
        }
        #endregion

        #region Oficinas

        public static List<Oficina> ObtenerOficinas() 
        {
            Conexion con = new Conexion("SqlCon");
  
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_Oficinas]",true);
            List<Oficina> lista = null;

            if (dt != null && dt.Rows.Count > 0)
            {

                lista = new List<Oficina>();
                foreach (DataRow row in dt.Rows)

                {
                    lista.Add(new Oficina

                    {
                        IdOficina = int.Parse(row["IdOficina"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Activo = Convert.ToBoolean(row["Activo"].ToString())

                    });
                }
            }
            return lista;
        }
        #endregion
    }
}