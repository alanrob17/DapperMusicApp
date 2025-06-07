using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public interface IArtistRepository
    {
        Task<bool> AddArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<IEnumerable<Artist>> GetAllArtistsWithBriefBioAsync();
        Task<Artist> GetArtistByIdAsync(int artistId);
        Task<IEnumerable<Artist>> GetArtistListAsync();
        Task<int> CountArtistsAsync();
    }
}
