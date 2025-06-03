using System.Data;

namespace MusicDb.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}