using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllTracksAsync();
        Task<IEnumerable<Track>> GetAllTracksAsync(bool includeTechDetails = true);
        Task<IEnumerable<ArtistRecordTrackDto>> GetFullListAsync();
        Task<IEnumerable<ArtistRecordTrackDto>> GetArtistListAsync(int artistId);
        Task<IEnumerable<ArtistRecordTrackDto>> GetArtistRecordAsync(int artistId, int recordId);
        Task<TotalTimeDto> GetTotalAlbumTimeAsync();
        Task<IEnumerable<ArtistRecordTrackDto>> GetAllSingleTracksAsync();
        Task<IEnumerable<ArtistRecordTrackDto>> GetArtistGuestTracksAsync(string name);
        Task<IEnumerable<Track>> GetTrackListingAsync(int discId);
        Task<IEnumerable<ArtistRecordTrackDto>> GetRecordTrackListingAsync(int recordId);
    }
}
