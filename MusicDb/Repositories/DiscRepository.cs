using MusicDb.Data;
using MusicDb.Models;
using MusicDb.Models.Dtos;
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

        public async Task<IEnumerable<ArtistRecordDisc>> GetAllDiscLengthsAsync()
        {
            var sproc = "up_GetAllDiscLengths";
            return await _db.GetDataAsync<ArtistRecordDisc>(sproc, new { });
        }
    }
}
