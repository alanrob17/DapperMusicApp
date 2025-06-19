using MusicDb.Dtos;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public interface IDiscRepository
    {
        Task<IEnumerable<Disc>> GetAllDiscsAsync();
        Task<IEnumerable<ArtistRecordDiscDto>> GetAllDiscLengthsAsync();
        Task<Disc> GetDiscByIdAsync(int discId);
        Task<IEnumerable<ArtistRecordDiscDto>> GetLongDiscsAsync();
    }
}
