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

        public async Task<IEnumerable<ArtistRecordDiscDto>> GetAllDiscLengthsAsync()
        {
            var sproc = "up_GetAllDiscLengths";
            return await _db.GetDataAsync<ArtistRecordDiscDto>(sproc, new { });
        }

        public async Task<Disc> GetDiscByIdAsync(int discId)
        {
            var sproc = "adm_getDisc";
            var disc = await _db.GetSingleAsync<Disc>(sproc, new { DiscId = discId });
            return disc ?? throw new KeyNotFoundException($"Disc with ID {discId} not found.");
        }

        public Task<IEnumerable<ArtistRecordDiscDto>> GetLongDiscsAsync()
        {
            var sproc = "adm_GetLongDiscs";
            return _db.GetDataAsync<ArtistRecordDiscDto>(sproc, new { });
        }
    }
}
