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
    }
}
