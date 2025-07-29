using Dapper;
using System.Data;
using TrabajadoresPrueba.Models;
using TrabajadoresPrueba.Repositories.Abstract;

namespace TrabajadoresPrueba.Repositories.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly IFactoryConnection _factory;

        public LocationService(IFactoryConnection factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<DepartamentoModel>> DepartamentoList()
        {
            IEnumerable<DepartamentoModel> departamentoList = null;
            var storeProcedure = "usp_obtener_departamentos";
            try
            {
                var connection = _factory.GetConnection();
                departamentoList = await connection.QueryAsync<DepartamentoModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factory.CloseConnection();
            }

            return departamentoList;
        }

        public async Task<IEnumerable<DistritoModel>> DistritoList()
        {
            IEnumerable<DistritoModel> distritoList = null;
            var storeProcedure = "usp_obtener_distritos";
            try
            {
                var connection = _factory.GetConnection();
                distritoList = await connection.QueryAsync<DistritoModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factory.CloseConnection();
            }

            return distritoList;
        }

        public async Task<IEnumerable<ProvinciaModel>> ProvinciaList()
        {
            IEnumerable<ProvinciaModel> provinciaList = null;
            var storeProcedure = "usp_obtener_provincias";
            try
            {
                var connection = _factory.GetConnection();
                provinciaList = await connection.QueryAsync<ProvinciaModel>(storeProcedure, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factory.CloseConnection();
            }

            return provinciaList;
        }
    }
}
