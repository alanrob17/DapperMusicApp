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
        Task<bool> AddArtistAsync(string firstName, string lastName, string name, string biography, string folder, int recordArtistId);
        Task<bool> AddArtistWithoutFirstNameAsync();
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<IEnumerable<Artist>> GetAllArtistsWithBriefBioAsync();
        Task<Artist> GetArtistByIdAsync(int artistId);
        Task<IEnumerable<Artist>> GetArtistListAsync();
        Task<int> CountArtistsAsync();
        Task<bool> CheckForArtistNameAsync(string name);
        Task<Artist?> GetArtistByFirstLastNameAsync(string firstName, string lastName);
        Task<Artist?> GetArtistByNameAsync(string name);
        Task<int> GetArtistIdAsync(string firstName, string lastName);
        Task<int> UpdateArtistAsync(Artist artist);
        Task<int> UpdateArtistAsync(int artistId, string firstName, string lastName, string name, string biography, string folder, int recordArtistId);
        Task<bool> DeleteArtistAsync(int artistId);
        Task<bool> DeleteArtistAsync(string name);
    }
}
