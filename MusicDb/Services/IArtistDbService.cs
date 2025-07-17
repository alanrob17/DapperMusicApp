using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Services
{
    public interface IArtistDbService
    {
        Task RunAllDatabaseOperations();
    }
}
