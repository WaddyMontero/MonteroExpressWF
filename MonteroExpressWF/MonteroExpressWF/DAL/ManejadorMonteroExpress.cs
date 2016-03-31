using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using Persistencia;

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
        
    }
}