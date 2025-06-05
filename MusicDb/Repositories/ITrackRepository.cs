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
        Task<IEnumerable<ArtistRecordTrack>> GetFullListAsync();
    }
}
