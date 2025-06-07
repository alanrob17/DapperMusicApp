using MusicDb.Data;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<bool> AddArtistAsync(Artist artist)
        {
            var sproc = "adm_ArtistInsert";

            var affected = await _db.SaveDataAsync(sproc, artist, "Result", DbType.Int32);
            return affected > 0;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            var sproc = "up_ArtistSelectAll";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsWithBriefBioAsync()
        {
            var sproc = "adm_ArtistSelectBriefBio";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {   
            var sproc = "up_GetArtistById";
            var parameter = new { ArtistId = artistId };
            return await _db.GetSingleAsync<Artist>(sproc, parameter);
        }

        public async Task<IEnumerable<Artist>> GetArtistListAsync()
        {
            var sproc = "up_ArtistSelectAll";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<int> CountArtistsAsync()
        {
            var sproc = "up_GetArtistCount";
            return await _db.GetCountOrIdAsync(sproc, new { });
        }
    }
}
