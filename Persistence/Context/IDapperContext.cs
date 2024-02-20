using System.Data;

namespace Persistence.Context
{
    public interface IDapperContext
    {
        Task<T> ExceProcAsync<T>(string prodName, object param, CommandType commandType);
        Task<IEnumerable<T>> GetListAsync<T>(string prodName, object param, CommandType commandType);
    }
}
