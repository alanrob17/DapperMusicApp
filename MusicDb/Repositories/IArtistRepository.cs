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
        // Define methods for artist repository operations
        //void AddArtist(Artist artist);
        //Artist GetArtistById(int id);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        //void UpdateArtist(Artist artist);
        //void DeleteArtist(int id);
    }
}
