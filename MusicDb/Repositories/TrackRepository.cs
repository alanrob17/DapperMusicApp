using MusicDb.Data;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly IDataAccess _db;

        public TrackRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Track>> GetAllTracksAsync()
        {

            var sproc = "up_TrackSelectAll";
            return await _db.GetDataAsync<Track>(sproc, new { });
        }
    }
}
