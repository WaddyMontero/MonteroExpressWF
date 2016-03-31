using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Persistencia
{
    /// <summary>
    /// Representa un parametro de un stored procedure.
    /// </summary>
    [Serializable]
    public class Parametro
    {
        private string _nombre;

        [NonSerialized]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object _valor;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DbType _tipo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Int32 _size;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private System.Data.ParameterDirection _direccion;


        /// <summary>
        /// Retorna el nombre del parametro.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("El nombre del parametro no puede estar vacio");
                }
                this._nombre = value;
            }
        }

        /// <summary>
        /// Retorna el valor del parametro.
        /// </summary>
        public object Valor
        {
            get
            {
                return this._valor;
            }
            set
            {
                this._valor = value;
            }
        }

        /// <summary>
        /// Retorna el tipo de datos del parametro.
        /// </summary>
        public DbType Tipo
        {
            get
            {
                return this._tipo;
            }
            set
            {
                this._tipo = value;
            }
        }
        /// <summary>
        /// Retorna el tamaño del parametro
        /// </summary>
        public Int32 Size
        {
            get { return this._size; }
            set { this._size = value; }
        }
        
        /// <summary>
        /// Retorna la direccion del parametro.
        /// </summary>
        public System.Data.ParameterDirection Direccion
        {
            get
            {
                return this._direccion;
            }
            set
            {
                this._direccion = value;
            }
        }

        /// <summary>
        /// Crea una instancia de la clase con el nombre especificado.
        /// </summary>
        /// <param name="nombre"></param>
        public Parametro(string nombre)
        {
            this.Nombre = nombre;
        }
        
        /// <summary>
        /// Crea una instancia de la clase con el nombre, valor y tipo especificados.
        /// </summary>
        /// <param name="nombre">Nombre del parametro.</param>
        /// <param name="valor">Valor del parametro.</param>
        /// <param name="tipo">Tipo de datos del elemento.</param>
        public Parametro(string nombre, object valor, DbType tipo)
        {
            this.Nombre = nombre;
            this.Valor = valor;
            this.Tipo = tipo;
        }

        /// <summary>
        /// Crea una instancia de la clase con el nombre, valor, tipo y dirección especificados.
        /// </summary>
        /// <param name="nombre">Nombre del parametro.</param>
        /// <param name="valor">Valor del parametro.</param>
        /// <param name="tipo">Tipo de datos del elemento.</param>
        /// <param name="direccion">Especifica la direccion del parametro.</param>
        public Parametro(string nombre, object valor, DbType tipo, ParameterDirection direccion)
            : this(nombre, valor, tipo)
        {
            this.Direccion = direccion;
        }

        /// <summary>
        /// Crea una instancia de la clase con el nombre, valor y tipo especificados.
        /// </summary>
        /// <param name="nombre">Nombre del parametro.</param>
        /// <param name="valor">Valor del parametro.</param>
        /// <param name="tipo">Tipo de datos del elemento.</param>
        /// /// <param name="direccion">Direccion del parametro.</param>
        /// <param name="size">Tamaño del elemento</param>
        public Parametro(string nombre, object valor, DbType tipo, ParameterDirection direccion, Int32 size)
            : this(nombre, valor, tipo, direccion)
        {
            this.Size = size;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public static explicit operator System.Data.Common.DbParameter(Parametro parametro)
        {
            if (parametro == null)
            {
                return null;
            }
            else
            {
                DbCommand nCommand = new System.Data.SqlClient.SqlCommand();
                DbParameter nParameter = nCommand.CreateParameter();

                nParameter.ParameterName = parametro.Nombre;
                nParameter.Value = parametro.Valor;
                nParameter.DbType = parametro.Tipo;
                nParameter.Direction = parametro.Direccion;
                if (parametro.Size > 0)
                {
                    nParameter.Size = parametro.Size;
                }
                return nParameter;
            }

        }
    }
}
