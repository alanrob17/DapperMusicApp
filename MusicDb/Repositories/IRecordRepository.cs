using MusicDb.Models;
using MusicDb.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllRecordsAsync();
        Task<IEnumerable<ArtistRecord>> GetAllArtistRecordsAsync();
    }
}
