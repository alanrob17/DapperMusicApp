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
    public class TrackRepository : ITrackRepository
    {
        private readonly IDataAccess _db;

        public TrackRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {

            var sproc = "up_TrackSelectAll";
            return await _db.GetDataAsync<Track>(sproc, new { });
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync(bool includeTechDetails = true)
        {
            var sproc = "up_CompleteTrackSelectAll";
            return await _db.GetDataAsync<Track>(sproc, new { IncludeTechnicalDetails = includeTechDetails ? 1 : 0 });
        }

        public Task<IEnumerable<ArtistRecordTrack>> GetFullListAsync()
        {
            var sproc = "up_CompleteRecordList";
            return _db.GetDataAsync<ArtistRecordTrack>(sproc, new { });
        }
    }
}
