using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Persistencia
{
    /// <summary>
    /// Clase que representa una conexion a base de datos
    /// </summary>
    public class Conexion : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Database _db;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDbConnection _con;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _recordCount;
        
        /// <summary>
        /// Propiedad que almacena la Cantidad Total de Records que devuelve la tabla
        /// </summary>
        public int RecordCount 
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        /// <summary>
        /// Crea una conexion con el conexion string por defecto
        /// </summary>
        public Conexion()
        {
            _db = DatabaseFactory.CreateDatabase();

            _con = _db.CreateConnection();
        }

        /// <summary>
        /// Crea una conexion con el conexion especificado
        /// </summary>
        /// <param name="Database">nombre del connectionstring a seleccionar</param>
        public Conexion(String Database)
        {
            _db = DatabaseFactory.CreateDatabase(Database);
            _con = _db.CreateConnection();
        }

        /// <summary>
        /// Ejecuta la sentencia sql y retorna un <c>DataTable</c> con los resultados
        /// </summary>
        /// <param name="sql">sentencia sql a ejecutar</param>
        /// <returns><code>DataTable</code> con los resultados</returns>
        public DataTable GetDataTable(string sql)
        {

            try
            {
                DataTable dt = null;
                DbCommand dbCommand = _db.GetSqlStringCommand(sql);
                DataSet dataSet = _db.ExecuteDataSet(dbCommand);
                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0];
                }
                return dt;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }


        /// <summary>
        /// Ejecuta la sentencia sql o el stored procedure y retorna un <c>DataTable</c> con los resultados
        /// </summary>
        /// <param name="sql">sentencia sql o nombre del procedure</param>
        /// <param name="esProcedure">indica si <c>sql</c> es el nombre de un stored procedure</param>
        /// <returns><c>DataTable</c> con los resultados</returns>
        public DataTable GetDataTable(string sql, bool esProcedure)
        {
            return GetDataTable(sql, "tabla", esProcedure);
        }


        /// <summary>
        /// Ejecuta la sentencia sql o el procedure y retorna un <c>DataTable</c>, de nombre <paramref name="nombreTable"/>, con los resultados
        /// </summary>
        /// <param name="sql">sentencia sql o nombre del procedure</param>
        /// <param name="esProcedure">indica si <c>sql</c> es el nombre de un stored procedure</param>
        /// <param name="nombreTable">Nombre de la tabla generada</param>
        /// <returns><c>DataTable</c> con los resultados</returns>
        public DataTable GetDataTable(string sql, string nombreTable, bool esProcedure)
        {
            if (esProcedure)
            {
                DbTransaction tran = null;
                return GetDataTable(sql, nombreTable, tran);
            }

            try
            {
                DataTable dt = null;
                DbCommand dbCommand = _db.GetSqlStringCommand(sql);
                DataSet dataSet = _db.ExecuteDataSet(dbCommand);
                nombreTable = string.IsNullOrEmpty(nombreTable) ? "tabla" : nombreTable;
                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0];
                    dt.TableName = nombreTable;
                }
                return dt;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }


        /// <summary>
        /// Ejecuta el stored procedure especificado por <paramref name="nombreProcedure"/> y retorna <c>DataTable</c> de nombre <paramref name="nombreTabla"/> enviando los parametros especficados en 
        /// <paramref name="parametros"/>
        /// </summary>
        /// <param name="nombreProcedure">Nombre del stored procedure a ejecutar</param>
        /// <param name="nombreTabla">Nombre que se asignara al <c>DataTable</c></param>
        /// <param name="parametros">Conjunto de parametros que se enviara al stored procedure</param>
        /// <returns><c>DataTable</c> con los resultados del stored procedure</returns>
        public DataTable GetDataTable(string nombreProcedure, string nombreTabla, params Parametro[] parametros)
        {
            return GetDataTable(nombreProcedure, nombreTabla, null, parametros);
        }

        /// <summary>
        /// Ejecuta el stored procedure especificado por <paramref name="nombreProcedure"/>, dentro de la transaccion especificada por <paramref name="tran"/> y 
        /// retorna <c>DataTable</c> de nombre <paramref name="nombreTabla"/> enviando los parametros especficados en <paramref name="parametros"/>
        /// </summary>
        /// <param name="nombreProcedure">Nombre del stored procedure a ejecutar</param>
        /// <param name="nombreTabla">Nombre que se asignara al <c>DataTable</c></param>
        /// <param name="tran">Transaccion en la que se ejecutara el stored procedure</param>
        /// <param name="parametros">Conjunto de parametros que se enviara al stored procedure</param>
        /// <returns><c>DataTable</c> con los resultados del stored procedure</returns>
        public DataTable GetDataTable(string nombreProcedure, string nombreTabla, DbTransaction tran, params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);

            this.SetParametros(dbCommand, _db, parametros);

            DataTable dt = null;
            nombreTabla = string.IsNullOrEmpty(nombreTabla) ? "tabla" : nombreTabla;
            try
            {
                DataSet dataset = null;
                if (tran == null)
                {
                    dataset = _db.ExecuteDataSet(dbCommand);
                }
                else
                {
                    dataset = _db.ExecuteDataSet(dbCommand, tran);
                }
                if (dataset.Tables.Count > 0)
                {
                    dt = dataset.Tables[0];
                    dt.TableName = nombreTabla;
                }
                return dt;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        /*
        public DataTable GetDataTable(string nombreProcedure, string nombreTable)
        {
            DbTransaction tran = null;
            return GetDataTable(nombreProcedure, nombreTable, tran);
        }*/

        /// <summary>
        /// Ejecuta el stored procedures especificado sin devolver valor alguno. 
        /// </summary>
        /// <param name="nombreProcedure">Nombre del stored procedure a ejecutar</param>
        /// <returns></returns>
        public bool EjecucionNoRetorno(string nombreProcedure)
        {
            DbTransaction tran = null;
            return this.EjecucionNoRetorno(nombreProcedure, tran);
        }

        /// <summary>
        /// Ejecuta el stored procedures especificado sin devolver valor alguno y enviando las parametros especificados en <paramref name="parametros"/>. 
        /// </summary>
        /// <param name="nombreProcedure">Nombre del stored procedure a ejecutar</param>
        /// /// <param name="parametros">Parametros que recibirá el stored procedure a ejecutar</param>
        /// <returns></returns>
        public bool EjecucionNoRetorno(string nombreProcedure, params Parametro[] parametros)
        {
            return this.EjecucionNoRetorno(nombreProcedure, null, parametros);
        }

        /// <summary>
        /// Ejecuta el stored procedures especificado sin devolver valor alguno, dentro de la transaccion especificada por <paramref name="tran"/> 
        /// y enviando las parametros especificados en <paramref name="parametros"/>. 
        /// </summary>
        /// <param name="nombreProcedure">Nombre del stored procedure a ejecutar</param>
        /// <param name="tran">Transacción</param>
        /// <param name="parametros">Parametros del procedimiento</param>
        /// <returns></returns>
        public bool EjecucionNoRetorno(string nombreProcedure, DbTransaction tran, params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);
            
            SetParametros(dbCommand, _db, parametros);

            try
            {
                if (tran == null)
                {
                    _db.ExecuteNonQuery(dbCommand);
                }
                else
                {
                    _db.ExecuteNonQuery(dbCommand, tran);
                }
                return true;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta el Comando con NoRetorno pero devuelve un <c>DbCommand</c> en vez de un bool para poder manejar los valores retornados.
        /// </summary>
        /// <param name="nombreProcedure">El nombre del StoredProcedure a ser utilizados</param>
        /// <param name="parametros">La lista de parametros Output/Input requeridos por este StoredProcedure</param>
        /// <returns></returns>
        public DbCommand EjecucionNoRetornoWithOutput(string nombreProcedure, params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);
            
            SetParametros(dbCommand, _db, parametros);

            try
            {
                _db.ExecuteNonQuery(dbCommand);
                return dbCommand;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta el el stored procedure y devuelve un <c>IDataReader</c>
        /// </summary>
        /// <param name="nombreProcedure">nombre del stored procedure</param>
        /// <returns><c>IDataReader</c> con los resultados</returns>
        public IDataReader Ejecucion(string nombreProcedure)
        {
            return this.Ejecucion(nombreProcedure, false);
        }

        /// <summary>
        /// Ejecuta el el stored procedure y devuelve un <c>IDataReader</c> enviando los parametros en <paramref name="parametros"/>
        /// </summary>
        /// <param name="nombreProcedure">nombre del stored procedure</param>
        /// <param name="parametros">Conjunto de parametros que se enviara al stored procedure</param>
        /// <returns><c>IDataReader</c> con los resultados</returns>
        public IDataReader Ejecucion(string nombreProcedure,params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);
            
            SetParametros(dbCommand, _db, parametros);
            try
            {
                IDataReader retorno = null;
                retorno = _db.ExecuteReader(dbCommand);
                return retorno;
            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta la sentencia sql o el stored procedure y devuelve un <c>IDataReader</c>
        /// </summary>
        /// <param name="Valor">sentencia sql o nombre del stored procedure</param>
        /// <param name="esProcedure">indica si es un stored procedure</param>
        /// <returns><c>IDataReader</c></returns>
        public IDataReader Ejecucion(string Valor, bool esProcedure)
        {
            try
            {
                DbCommand dbCommand = null;
                if (esProcedure)
                {
                    dbCommand = _db.GetStoredProcCommand(Valor);
                }
                else
                {
                    dbCommand = _db.GetSqlStringCommand(Valor);
                }

                IDataReader retorno = _db.ExecuteReader(dbCommand);
                return retorno;

            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que realiza la paginacion en SQL pasando como parametro:
        /// </summary>
        /// <param name="index">Indice de la pagina que se desea consultar</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <param name="nombreProcedure">Nombre del Stored Procedure</param>
        /// <returns></returns>
        public IDataReader GetDataPaging(int index, int pageSize, string nombreProcedure)
        {
            Parametro[] parametros = new Parametro[2];
            parametros[0] = new Parametro("@PageIndex", index, DbType.Int32);
            parametros[1] = new Parametro("@PageSize", pageSize, DbType.Int32);
            //p[2] = new Parametro("@RecordCount", 0, DbType.Int32, ParameterDirection.Output);

            return this.EjecucionPaging(nombreProcedure, parametros);

        }

        /// <summary>
        /// Metodo que realiza la paginacion en SQL pasando como parametro:
        /// </summary>
        /// <param name="index">Indice de la pagina que se desea consultar</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <param name="nombreProcedure">Nombre del Stored Procedure</param>
        /// <param name="parametrosBusqueda">Otros parametros para el stored procedure</param>
        /// <returns></returns>
        public DataTable GetDataPaging(int index, int pageSize, string nombreProcedure, params Parametro[] parametrosBusqueda)
        {
            //int i; //Contador para recorrer el arreglo de parametros
            //Variable entera que contiene la suma de la cantidad de parametros en el arreglo mas el parametro index y pagesize 
            //* para fijar el tamano a otro arreglo creado para que ser asignado al arreglo de Parametros en la Clase Conexion.
            

            List<Parametro> parametros = new List<Parametro>();

            parametros.Add(new Parametro("@PageIndex", index, DbType.Int32));
            parametros.Add(new Parametro("@PageSize", pageSize, DbType.Int32));

            if (parametros != null)
            {
                parametros.AddRange(parametrosBusqueda);

            }

            return this.EjecucionPaging(nombreProcedure, "tabla", parametros.ToArray());
        }

        /// <summary>
        /// Metodo que inicia la transaccion
        /// </summary>
        /// <returns>una instancia de <c>DbTransaction</c> que representa la transaccion abierta</returns>
        public DbTransaction BeginTransaction()
        {
            if (_con.State != ConnectionState.Open)
            {
                _con.Open();
            }
            return _con.BeginTransaction() as DbTransaction;
        }

        /// <summary>
        /// Cierra la conexion.
        /// </summary>
        public void CierreConexion()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }
 
        private void SetParametros(DbCommand comando, Database db, params Parametro[] parametros)
        {
            if (parametros != null)
            {
                for (int i = 0; i < parametros.Length; i++)
                {
                    if (parametros[i].Direccion == ParameterDirection.Output)
                    {
                        db.AddOutParameter(comando, parametros[i].Nombre, parametros[i].Tipo, int.MaxValue);
                    }
                    else
                    {
                        db.AddInParameter(comando, parametros[i].Nombre, parametros[i].Tipo, parametros[i].Valor);
                    }
                }

            }
        }
        
        private void CreateErrorLog(string message, int code)
        {
            CreateErrorLog(new Exception(string.Format("MESSAGE:{0}\nERROR_CODE:{1}", message, code)));
        }
        
        private void CreateErrorLog(Exception ex)
        {
            //Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        }

        private DataTable EjecucionPaging(string nombreProcedure, string nombreTabla, params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);

            SetParametros(dbCommand, _db, parametros);
            try
            {
                DataTable dt = _db.ExecuteDataSet(dbCommand).Tables[0]; // Retorna el Total de Record de la tabla en cuestion

                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns.Contains("Total"))
                    {
                        this.RecordCount = Convert.ToInt32(dt.Rows[0]["Total"]);
                    }
                }

                DataSet dataset = _db.ExecuteDataSet(dbCommand);
                if (dataset.Tables.Count > 0)
                {
                    dt = dataset.Tables[0];
                    dt.TableName = nombreTabla;
                }

                return dt;

            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        private IDataReader EjecucionPaging(string nombreProcedure, params Parametro[] parametros)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand(nombreProcedure);

            SetParametros(dbCommand, _db, parametros);
            try
            {
                DataTable dt = _db.ExecuteDataSet(dbCommand).Tables[0]; // Retorna el Total de Record de la tabla en cuestion
                IDataReader retorno = null;

                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns.Contains("Total"))
                    {
                        this.RecordCount = Convert.ToInt32(dt.Rows[0]["Total"]);
                    }
                }

                retorno = _db.ExecuteReader(dbCommand);
                return retorno;

            }
            catch (SqlException ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
            catch (Exception ex)
            {
                CreateErrorLog(ex);
                throw ex;
            }
        }

        #region IDisposable Members
        /// <summary>
        /// Destruye 
        /// </summary>
        public void Dispose()
        {

        }

        #endregion
    }
}