using System.Data;

namespace TrabajadoresPrueba.Repositories.Abstract
{
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetConnection();
    }
}
