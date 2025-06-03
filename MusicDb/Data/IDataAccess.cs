using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Data
{
    public interface IDataAccess
    {

        //Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedureName);
        //Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedureName, object parameters);
        //Task<T?> GetSingleAsync<T>(string storedProcedureName, object parameters) where T : class;
        //Task<int> ExecuteAsync(string storedProcedureName, object parameters);
        //Task<int> ExecuteAsync(string storedProcedureName);
        Task<IEnumerable<T>> GetDataAsync<T>(string sproc, object value);
    }
}
