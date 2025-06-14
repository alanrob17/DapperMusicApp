using Dapper;
using MusicDb.Data;
using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<IEnumerable<Record>> GetArtistRecordsAsync(int artistId)
        {
            string sproc = "up_GetRecordsByArtistId";
            var parameter = new { ArtistId = artistId };
            return await _db.GetDataAsync<Record>(sproc, parameter);
        }

        public async Task<IEnumerable<ArtistRecordReviewDto>> NoRecordReviewsAsync()
        {
            string sproc = "up_GetNoRecordReview";
            return await _db.GetDataAsync<ArtistRecordReviewDto>(sproc, new { });
        }

        public async Task<int> CountDiscsAsync(string show)
        {
            string sproc = "up_CountDiscs";
            var parameter = new DynamicParameters();
            parameter.Add("@Show", show);
            var discs = await _db.GetCountOrIdAsync(sproc, parameter);
            return discs;
        }

        public async Task<int> GetArtistNumberOfRecordsAsync(int artistId)
        {
            string sproc = "up_GetArtistNumberOfRecords";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistId", artistId);
            return await _db.GetCountOrIdAsync(sproc, parameter);
        }

        public async Task<int> GetArtistNumberOfRecordsAsync(string name)
        {
            string sproc = "up_GetArtistNumberOfRecordsByName";
            var parameter = new DynamicParameters();
            parameter.Add("@ArtistName", name);
            return await _db.GetCountOrIdAsync(sproc, parameter);
        }

        public async Task<ArtistRecordDto> GetRecordByNameAsync(string name)
        {
            var sproc = "up_GetRecordByPartialName";
            var parameter = new { Name = name };
            return await _db.GetSingleAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<IEnumerable<ArtistRecordDto>> GetRecordsByNameAsync(string name)
        {
            var sproc = "up_GetRecordByPartialName";
            var parameter = new { Name = name };
            return await _db.GetDataAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<string> GetArtistNameFromRecordAsync(int recordId)
        {
            var sproc = "up_GetArtistNameByRecordId";
            var parameter = new { RecordId = recordId };
            var name = await _db.GetTextAsync(sproc, parameter);
            return name ?? string.Empty;
        }

        public async Task<int> GetRecordNumberByYearAsync(int year)
        {
            var sproc = "up_GetRecordedYearNumber";
            var parameter = new { Year = year };
            return await _db.GetCountOrIdAsync(sproc, parameter);
        }

        public async Task<IEnumerable<ArtistRecordDto>> GetRecordsByRecordedYearAsync(int year)
        {
            var sproc = "up_GetRecordsByYearRecorded";
            var parameter = new { Year = year };
            return await _db.GetDataAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<int> GetNoReviewCountAsync()
        {
            var sproc = "up_GetNoRecordReviewCount";
            return await _db.GetCountOrIdAsync(sproc, new { });
        }

        public async Task<ArtistRecordDto> GetRecordDetailsAsync(int recordId)
        {
            var sproc = "up_getSingleArtistAndRecord";
            var parameter = new { RecordId = recordId };
            return await _db.GetSingleAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<IEnumerable<TotalDiscsDto>> GetTotalArtistDiscsAsync()
        {
            var sproc = "up_GetTotalDiscsForEachArtist";
            return await _db.GetDataAsync<TotalDiscsDto>(sproc, new { });
        }

        public async Task<ArtistRecordDto> GetRecordHtmlAsync(int recordId)
        {
            var sproc = "up_getSingleArtistAndRecord";
            var parameter = new { RecordId = recordId };
            return await _db.GetSingleAsync<ArtistRecordDto>(sproc, parameter);
        }

        public async Task<IEnumerable<Record>> GetRecordListAsync(int artistId)
        {
            var sproc = "up_RecordSelectByArtistId";
            var parameter = new { ArtistId = artistId };
            return await _db.GetDataAsync<Record>(sproc, parameter);
        }

        public async Task<string> GetAlbumLengthAsync(int recordId)
        {
            var sproc = "adm_GetAlbumLength";
            var parameters = new DynamicParameters();
            parameters.Add("@RecordId", recordId);
            return await _db.GetTextAsync(sproc, parameters);
        }

        public async Task<int> AddRecordAsync(Record record)
        {
            return await _db.SaveDataAsync("adm_RecordInsert", record, outputParameterName: "RecordId");
        }

        public async Task<int> UpdateRecordAsync(Record record)
        {
            var sproc = "adm_UpdateRecord";
            return await _db.SaveDataAsync(sproc, record, "Result", DbType.Int32);
        }

        public async Task<bool> DeleteRecordAsync(int recordId)
        {
            var sproc = "up_DeleteRecord";
            var parameter = new { RecordId = recordId };
            var rowsAffected = await _db.DeleteDataAsync(sproc, parameter);
            return rowsAffected > 0;
        }
    }
}
