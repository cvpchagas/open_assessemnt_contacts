using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Infra.Repositories.Json
{
    public class BaseConnectionJson : IDisposable
    {
        private string _connection;

        public BaseConnectionJson(string conn)
        {
            _connection = new string(conn);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        public IEnumerable<T> ReadData<T>(string queryString, DynamicParameters parametros)
        {
            return _connection.Query<T>(queryString, parametros);
        }


        public bool InsertUpdate(string queryString, DynamicParameters parametros)
        {
            _connection.ExecuteScalar(queryString, parametros);

            return true;
        }

        public bool Delete(string queryString, DynamicParameters parametros)
        {

            _connection.ExecuteScalar(queryString, parametros);

            return true;
        }

        public bool InsertUpdateTransaction(string queryString, DynamicParameters parametros)
        {
            var transaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                _connection.Execute(queryString, parametros, transaction);
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public OracleConnection ExecuteTrasactionLote()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}
