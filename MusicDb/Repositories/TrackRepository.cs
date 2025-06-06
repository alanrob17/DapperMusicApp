using Dapper;
using MusicDb.Data;
using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public Task<IEnumerable<ArtistRecordTrack>> GetArtistListAsync(int artistId)
        {
            var sproc = "up_RecordListByArtist";
            var parameter = new { ArtistId = artistId };
            return _db.GetDataAsync<ArtistRecordTrack>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrack>> GetArtistRecordAsync(int artistId, int recordId)
        {
            var sproc = "up_ArtistRecordTracks";
            var parameters = new DynamicParameters();
            parameters.Add("@ArtistId", artistId);
            parameters.Add("@RecordId", recordId);
            return _db.GetDataAsync<ArtistRecordTrack>(sproc, parameters);
        }

        public async Task<TotalTime> GetTotalAlbumTimeAsync()
        {
            var sproc = "adm_CalculateTotalAlbumTime";
            TotalTime? totalTime = await _db.GetSingleAsync<TotalTime>(sproc, new { });

            return totalTime;
        }
    }
}
