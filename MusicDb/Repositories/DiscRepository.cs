using MusicDb.Data;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public class DiscRepository : IDiscRepository
    {
        private readonly IDataAccess _db;

        public DiscRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Disc>> GetAllDiscsAsync()
        {
            var sproc = "up_DiscSelectAll";
            return await _db.GetDataAsync<Disc>(sproc, new { });
        }
    }
}
