using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MusicDb.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Data
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SqlConnectionFactory> _logger;

        public SqlConnectionFactory(IConfiguration configuration, ILogger<SqlConnectionFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("MusicDB");
            // _logger.LogInformation("Using connection string: {ConnectionString}", connectionString);
            return new SqlConnection(connectionString);
        }
    }
}
