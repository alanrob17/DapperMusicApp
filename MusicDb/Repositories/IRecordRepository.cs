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
        Task<int> AddRecordAsync(Record record);
        Task<int> UpdateRecordAsync(Record record);
    }
}
