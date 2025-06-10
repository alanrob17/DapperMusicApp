using Dapper;
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
    public class RecordRepository : IRecordRepository
    {
        private readonly IDataAccess _db;

        public RecordRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Record>> GetAllRecordsAsync()
        {
            var sproc = "up_RecordSelectAll";
            return await _db.GetDataAsync<Record>(sproc, new { });
        }

        public async Task<IEnumerable<ArtistRecordDto>> GetAllArtistRecordsAsync()
        {
            var sproc = "up_ArtistRecordSelectAll";
            return await _db.GetDataAsync<ArtistRecordDto>(sproc, new { });
        }

        public async Task<Record> GetRecordByIdAsync(int recordId)
        {
            string sproc = "up_GetRecordById";
            var parameter = new { RecordId = recordId };
            return await _db.GetSingleAsync<Record>(sproc, parameter);
        }

        public async Task<ArtistRecordDto> GetArtistRecordByIdAsync(int recordId)
        {
            string sproc = "up_GetArtistRecordById";
            var parameter = new { RecordId = recordId };
            return await _db.GetSingleAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<int> CountTotalRecordsAsync()
        {
            string sproc = "up_GetTotalNumberOfAllRecords";
            return await _db.GetCountOrIdAsync(sproc, new { });
        }

        public async Task<IEnumerable<Record>> GetRecordsByArtistIdAsync(int artistId)
        {
            string sproc = "up_GetRecordsByArtistId";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", artistId);
            return await _db.GetDataAsync<Record>(sproc, parameter);
        }

        public async Task<TotalTimeDto> GetTotalAlbumTimeAsync()
        {
            string sproc = "adm_CalculateTotalAlbumTime";
            TotalTimeDto? time = await _db.GetSingleAsync<TotalTimeDto>(sproc, new { });

            return time ?? new TotalTimeDto
            {
                TotalSeconds = "0",
                TotalLengthFormatted = "00:00:00:00"
            };
        }

        public async Task<TotalTimeDto?> GetTotalAlbumTimeByArtistIdAsync(int artistId)
        {
            string sproc = "adm_CalculateTotalAlbumTimeByArtistId";
            var parameter = new { ArtistId = artistId };
            TotalTimeDto? time = await _db.GetSingleAsync<TotalTimeDto>(sproc, parameter);

            return time ?? new TotalTimeDto
            {
                TotalSeconds = "0",
                TotalLengthFormatted = "00:00:00:00"
            };
        }

        public async Task<Artist> GetArtistFromRecordArtistIdAsync(int artistId)
        {
            string sproc = "up_GetArtistFromRecordArtistId";
            var parameter = new { ArtistId = artistId };
            Artist artist = await _db.GetSingleAsync<Artist>(sproc, parameter);

            return artist ?? new Artist
            {
                ArtistId = artistId,
                Name = "Unknown Artist"
            };
        }

        public async Task<Artist> GetArtistFromNameAsync(string name)
        {
            string sproc = "up_GetArtistByName";
            var parameter = new { Name = name };
            return await _db.GetSingleAsync<Artist>(sproc, parameter);
        }

    }
}
