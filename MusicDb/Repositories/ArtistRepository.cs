using MusicDb.Data;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDataAccess _db;

        public ArtistRepository(IDataAccess db)
        {
            _db = db;
        }

        //public Task AddArtist(Artist artist)
        //{
        //    // Code to add artist to the database
        //}

        //public Artist GetArtistById(int id)
        //{
        //    // Code to retrieve artist by ID from the database
        //    return new Artist(); // Placeholder return
        //}

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            var sproc = "up_ArtistSelectAll";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }
        
        //public void UpdateArtist(Artist artist)
        //{
        //    // Code to update artist in the database
        //}
        //public void DeleteArtist(int id)
        //{
        //    // Code to delete artist from the database
        //}
    }
}
