using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TrabajadoresPrueba.Persistence;
using TrabajadoresPrueba.Repositories.Abstract;

namespace TrabajadoresPrueba.Repositories.Implementation
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection _connection;
        private readonly IOptions<ConnectionConfiguration> _configuracion;
        public FactoryConnection(IOptions<ConnectionConfiguration> configuracion)
        {
            _configuracion = configuracion;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_configuracion.Value.DefaultConnection);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}
