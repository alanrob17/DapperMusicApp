using MusicDb.Dtos;
using MusicDb.Models;
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
            // await GetAllDiscLengthsAsync();
            // await GetDiscAsync(249);
            // await GetLongDiscsAsync();
            await GetDiscsWithSingleTrackAsync();
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

        private async Task GetDiscAsync(int discId)
        {
            
            var disc = await _repository.GetDiscByIdAsync(discId); // Assuming GetDiscByIdAsync is implemented in IDiscRepository
            if (disc != null)
            {
                await _output.WriteLineAsync($"Disc retrieved successfully: \n{disc.ToString()}");
            }
            else
            {
                await _output.WriteLineAsync("No disc found with the specified ID.");
            }
        }

        private async Task GetLongDiscsAsync()
        {
            var discs = await _repository.GetLongDiscsAsync();
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

        private async Task GetDiscsWithSingleTrackAsync()
        {
            var discs = await _repository.GetSingleTrackDiscsAsync();
            if (discs != null && discs.Any())
            {
                await _output.WriteLineAsync("Discs with a single track retrieved successfully:");
                foreach (var disc in discs)
                {
                    await _output.WriteLineAsync(disc.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No discs with a single track found.");
            }
        }
    }
}