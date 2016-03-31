using System.Collections.Generic;
using System.Web;

namespace Persistencia
{
    /// <summary>
    /// Clase que gestiona la creacion de conexiones
    /// </summary>
    public class ConexionFactory
    {
        private static Dictionary<string, Conexion> Conexiones
        {
            get
            {
                if (HttpContext.Current.Session["conexiones"] == null)
                {
                    HttpContext.Current.Session.Add("conexiones", new Dictionary<string, Conexion>());
                }
                return HttpContext.Current.Session["conexiones"] as Dictionary<string, Conexion>;
            }
        }

        /// <summary>
        /// Retorna una instancia de <c>Conexion</c>, multiple llamadas a este metodo devuelven la misma instancia de <c>Conexion</c>.
        /// </summary>
        /// <returns></returns>
        public static Conexion GetConexion()
        {
            if (Conexiones.ContainsKey("") == false)
            {
                Conexiones.Add("", new Conexion());
            }
            return Conexiones[""];
        }

        /// <summary>
        /// Retorna una instancia de <c>Conexion</c> utlizando el connectionstring especificado, multiple llamadas a este metodo devuelven la misma instancia de <c>Conexion</c>.
        /// </summary>
        /// <param name="databse">nombre del connectionstring</param>
        /// <returns></returns>
        public static Conexion GetConexion(string databse)
        {
            if (Conexiones.ContainsKey(databse) == false)
            {
                Conexiones.Add(databse, new Conexion(databse));
            }
            return Conexiones[databse];
        }

        /// <summary>
        /// Retorna una nueva instancia de <c>Conexion</c>
        /// </summary>
        /// <returns></returns>
        public static Conexion GetNewConexion()
        {
            return new Conexion();
        }

        /// <summary>
        /// Retorna una nueva instancia de <c>Conexion</c> utlizando el connectionstring especificado
        /// </summary>
        /// <param name="database">nombre del connectionstring</param>
        /// <returns></returns>
        public static Conexion GetNewConexion(string database)
        {
            return new Conexion(database);
        }
    }
}
