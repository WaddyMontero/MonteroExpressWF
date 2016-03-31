using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Persistencia
{
    /// <summary>
    /// Encargada de crear los parametros, esta factoria infiere el tipo de base de datos acorde a una correspondencia predefinida.
    /// Al utilizar esta clase siempre se debe encerrar el bloque de codigo en un try..catch en caso de que no exista la correspondencia 
    /// entre el tipo de la variable y el tipo de base de datos.
    /// </summary>
    public class ParametroFactory
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static Dictionary<Type, DbType> _typeMapping; 
        
        /// <summary>
        /// Crea un parametro con el nombre y valor especificado
        /// </summary>
        /// <param name="nombre">Nombre del parametro</param>
        /// <param name="valor">Valor del parametro</param>
        /// <returns><code>Parametro</code> con el nombre y valor especificado</returns>
        public static Parametro Crear(string nombre, object valor)
        {
            if (nombre[0] != '@')
            {
                nombre = string.Format("@{0}", nombre);
            }
            
            return new Parametro(nombre,valor,TypeMapping[valor.GetType()]);
        }

        /// <summary>
        /// Crea una lista de parametros utilizando los datos del dictionario enviado, donde la llave del dictionario es el nombre del parametro y el valor del dictionario es el valor del parametro.
        /// </summary>
        /// <param name="nombresValores">Dictionario con los datos de los parametros</param>
        /// <returns></returns>
        public static List<Parametro> CrearMany(Dictionary<string, object> nombresValores)
        {
            List<Parametro> parametros = new List<Parametro>();
            foreach (KeyValuePair<string, object> nombreValor in nombresValores)
            {
                parametros.Add(Crear(nombreValor.Key, nombreValor.Value));
            }
            return parametros;
        }

        private static Dictionary<Type, DbType> TypeMapping
        {
            get
            {
                if (_typeMapping == null)
                {
                    _typeMapping = new Dictionary<Type, DbType>();
                    _typeMapping.Add(typeof(string), DbType.String);
                    _typeMapping.Add(typeof(char), DbType.String);
                    _typeMapping.Add(typeof(int), DbType.Int32);
                    _typeMapping.Add(typeof(int?), DbType.Int32);
                    _typeMapping.Add(typeof(double), DbType.Double);
                    _typeMapping.Add(typeof(decimal), DbType.Double);
                    _typeMapping.Add(typeof(bool), DbType.Boolean);
                    _typeMapping.Add(typeof(byte), DbType.Int16);
                    _typeMapping.Add(typeof(DateTime), DbType.DateTime);                    
                    _typeMapping.Add(typeof(DBNull), DbType.Int32);
                    _typeMapping.Add(typeof(Nullable), DbType.String);
                }
               
                return _typeMapping;
            }
        }
    }
}
