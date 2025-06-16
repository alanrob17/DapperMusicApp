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

        public Task<IEnumerable<ArtistRecordTrackDto>> GetFullListAsync()
        {
            var sproc = "up_CompleteRecordList";
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistListAsync(int artistId)
        {
            var sproc = "up_RecordListByArtist";
            var parameter = new { ArtistId = artistId };
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistRecordAsync(int artistId, int recordId)
        {
            var sproc = "up_ArtistRecordTracks";
            var parameters = new DynamicParameters();
            parameters.Add("@ArtistId", artistId);
            parameters.Add("@RecordId", recordId);
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, parameters);
        }

        public async Task<TotalTimeDto> GetTotalAlbumTimeAsync()
        {
            var sproc = "adm_CalculateTotalAlbumTime";
            TotalTimeDto? totalTime = await _db.GetSingleAsync<TotalTimeDto>(sproc, new { });

            return totalTime ?? new TotalTimeDto() { };
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetAllSingleTracksAsync()
        {
            var sproc = "adm_GetAlbumsWithOneTrack";
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, new { });
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetArtistGuestTracksAsync(string name)
        {
            var sproc = "adm_GetArtistGuestTracks";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistName", name);
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, parameter);
        }

        public Task<IEnumerable<Track>> GetTrackListingAsync(int discId)
        {
            var sproc = "adm_SelectTracksFromDisc";
            var parameter = new { DiscId = discId };
            return _db.GetDataAsync<Track>(sproc, parameter);
        }

        public Task<IEnumerable<ArtistRecordTrackDto>> GetRecordTrackListingAsync(int recordId)
        {
            var sproc = "adm_SelectTracksFromRecord";
            var parameter = new { RecordId = recordId };
            return _db.GetDataAsync<ArtistRecordTrackDto>(sproc, parameter);
        }
    }
}
