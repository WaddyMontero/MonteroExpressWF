using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia;
using System.Data;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorEntidadDirecciones
    {

        public static ObtenerEntidadDirecciones(string NumDocumento)
        {
            Conexion con = new Conexion("SqlCon");
            Parametro param = new Parametro("@NumDocumento",NumDocumento,DbType.String);
            DataTable dt = con.GetDataTable("[dbo].[prc_Obtiene_DireccionesEntidad]","",param);
            List<EntidadDireccion> lista;
            if (dt!= null && dt.Rows.Count > 0)
	        {
                lista = new List<EntidadDireccion>();
		        foreach (DataRow row in dt.Rows)
	            {
		            lista.Add(new EntidadDireccion{
                        IdEntidad = int.Parse(row["IdEntidad"].ToString()),
                        Telefono1 = row["Telefono1"].ToString(),
                        Telefono2 = row["Telefono2"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaIngreso = Convert.ToDateTime(row["FechaIngreso"].ToString()),
                        Ciudad = new Ciudad(int.Parse(row["IdCiudad"].ToString()),row["IdCiudad"].ToString(),new Provincia(Convert.ToInt32(row["IdProvincia"].ToString()),row["Provincia"].ToString())) 
                        
                    });
	            }
	        }
        }
    }
}