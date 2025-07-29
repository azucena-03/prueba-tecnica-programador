using Dapper;
using System.Data;
using TrabajadoresPrueba.Models;
using TrabajadoresPrueba.Repositories.Abstract;

namespace TrabajadoresPrueba.Repositories.Implementation
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly IFactoryConnection _factory;

        public TrabajadorService(IFactoryConnection factory)
        {
            _factory = factory;
        }

        public async Task<int> Update(TrabajadorModel trabajador)
        {
            var storeProcedure = "usp_actualiza_trabajador";
            try
            {
                var connection = _factory.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure, new
                { 
                    trabajador.Id,
                    trabajador.TipoDocumento,
                    trabajador.NumeroDocumento,
                    trabajador.Nombres,
                    trabajador.Sexo,
                    trabajador.IdDepartamento,
                    trabajador.IdProvincia,
                    trabajador.IdDistrito
                }, commandType: CommandType.StoredProcedure
                );
                _factory.CloseConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo editar el trabajador", e);
            }
        }

        public async Task<int> Delete(int id)
        {
            var storeProcedure = "usp_elimina_trabajador";
            try
            {
                var connection = _factory.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure, new
                {
                    IdTrabajador = id
                }, commandType: CommandType.StoredProcedure
                );
                _factory.CloseConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo eliminar el trabajador", e);
            }
        }

        public async Task<int> Add(TrabajadorModel trabajador)
        {
            var storeProcedure = "usp_nuevo_trabajador";
            try
            {
                var connection = _factory.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure, new
                {
                    trabajador.TipoDocumento,
                    trabajador.NumeroDocumento,
                    trabajador.Nombres,
                    trabajador.Sexo,
                    trabajador.IdDepartamento,
                    trabajador.IdProvincia,
                    trabajador.IdDistrito
                }, commandType: CommandType.StoredProcedure
                );

                _factory.CloseConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo guardar el nuevo trabajador", e);
            }
        }

        public async Task<IEnumerable<TrabajadorVm>> GetList()
        {
            IEnumerable<TrabajadorVm> trabajadorList = null;
            var storeProcedure = "usp_obtener_trabajadores";
            try
            {
                var connection = _factory.GetConnection();
                trabajadorList = await connection.QueryAsync<TrabajadorVm>(storeProcedure, null, commandType: CommandType.StoredProcedure);

            }
            catch (Exception e)
            {
                throw new Exception("Error en la consulta de datos", e);
            }
            finally
            {
                _factory.CloseConnection();
            }

            return trabajadorList;
        }

        public async Task<TrabajadorModel> GetById(int id)
        {
            var storeProcedure = "usp_obtener_trabajadores_por_id";
            TrabajadorModel trabajador = null;
            try
            {
                var connection = _factory.GetConnection();
                trabajador = await connection.QueryFirstAsync<TrabajadorModel>(storeProcedure, new
                {
                    Id = id,
                }, commandType: CommandType.StoredProcedure
                );

                _factory.CloseConnection();
                return trabajador;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtene el trabajador", e);
            }
        }
    }
}
