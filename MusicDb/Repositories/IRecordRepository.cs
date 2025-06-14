using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllRecordsAsync();
        Task<IEnumerable<ArtistRecordDto>> GetAllArtistRecordsAsync();
        Task<Record> GetRecordByIdAsync(int recordId);
        Task<ArtistRecordDto> GetArtistRecordByIdAsync(int recordId);
        Task<int> CountTotalRecordsAsync();
        Task<IEnumerable<Record>> GetRecordsByArtistIdAsync(int artistId);
        Task<TotalTimeDto> GetTotalAlbumTimeAsync();
        Task<Artist> GetArtistFromRecordArtistIdAsync(int artistId);
        Task<TotalTimeDto?> GetTotalAlbumTimeByArtistIdAsync(int artistId);
        Task<Artist> GetArtistFromNameAsync(string name);
        Task<IEnumerable<Record>> GetArtistRecordsAsync(int artistId);
        Task<IEnumerable<ArtistRecordReviewDto>> NoRecordReviewsAsync();
        Task<int> CountDiscsAsync(string show);
        Task<int> GetArtistNumberOfRecordsAsync(int artistId);
        Task<int> GetArtistNumberOfRecordsAsync(string name);
        Task<ArtistRecordDto> GetRecordByNameAsync(string name);
        Task<IEnumerable<ArtistRecordDto>> GetRecordsByNameAsync(string name);
        Task<string> GetArtistNameFromRecordAsync(int recordId);
        Task<int> GetRecordNumberByYearAsync(int year);
        Task<IEnumerable<ArtistRecordDto>> GetRecordsByRecordedYearAsync(int year);
        Task<int> GetNoReviewCountAsync();
        Task<ArtistRecordDto> GetRecordDetailsAsync(int recordId);
        Task<IEnumerable<TotalDiscsDto>> GetTotalArtistDiscsAsync();
        Task<ArtistRecordDto> GetRecordHtmlAsync(int recordId);
        Task<IEnumerable<Record>> GetRecordListAsync(int artistId);
        Task<string> GetAlbumLengthAsync(int recordId);
        Task<int> AddRecordAsync(Record record);
        Task<int> UpdateRecordAsync(Record record);
        Task<bool> DeleteRecordAsync(int recordId);
    }
}
