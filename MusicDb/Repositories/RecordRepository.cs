using MusicDb.Data;
using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly IDataAccess _db;

        public RecordRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Record>> GetAllRecordsAsync()
        {
            var sproc = "up_RecordSelectAll";
            return await _db.GetDataAsync<Record>(sproc, new { });
        }

        public async Task<IEnumerable<ArtistRecordDto>> GetAllArtistRecordsAsync()
        {
            var sproc = "up_ArtistRecordSelectAll";
            return await _db.GetDataAsync<ArtistRecordDto>(sproc, new { });
        }
    }
}
