using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Repositories.Abstract
{
    public interface ITrabajadorService
    {
        Task<IEnumerable<TrabajadorVm>> GetList(string genero);
        Task<TrabajadorModel> GetById(int id);
        Task<int> Add(TrabajadorModel trabajador);
        Task<int> Update(TrabajadorModel trabajador);
        Task<int> Delete(int id);
    }
}
