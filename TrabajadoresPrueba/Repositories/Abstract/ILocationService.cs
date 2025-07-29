using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Repositories.Abstract
{
    public interface ILocationService
    {
        Task<IEnumerable<DepartamentoModel>> DepartamentoList();
        Task<IEnumerable<ProvinciaModel>> ProvinciaList();
        Task<IEnumerable<DistritoModel>> DistritoList();
    }
}
