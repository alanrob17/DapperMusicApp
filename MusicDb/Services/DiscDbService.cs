using MusicDb.Repositories;
using MusicDb.Services.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Services
{
    public class DiscDbService
    {
        private readonly IDiscRepository _repository;
        private readonly IOutputService _output;

        public DiscDbService(IDiscRepository repository, IOutputService output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task RunAllDatabaseOperations()
        {
            // await GetAllDiscsAsync();
            await GetAllDiscLengthsAsync();
        }

        private async Task GetAllDiscsAsync()
        {
            var discs = await _repository.GetAllDiscsAsync();
            if (discs != null && discs.Any())
            {
                await _output.WriteLineAsync("Discs retrieved successfully:");
                foreach (var disc in discs)
                {
                    await _output.WriteLineAsync(disc.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No discs found.");
            }
        }

        private async Task GetAllDiscLengthsAsync()
        {
            var discs = await _repository.GetAllDiscLengthsAsync();
            if (discs != null && discs.Any())
            {
                await _output.WriteLineAsync("Discs retrieved successfully:");
                foreach (var disc in discs)
                {
                    await _output.WriteLineAsync(disc.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No discs found.");
            }
        }
    }
}