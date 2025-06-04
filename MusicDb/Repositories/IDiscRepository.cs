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
    }
}
