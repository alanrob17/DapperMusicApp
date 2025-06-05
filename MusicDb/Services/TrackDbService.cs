using MusicDb.Repositories;
using MusicDb.Services.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Services
{
    public class TrackDbService
    {
        private readonly ITrackRepository _repository;
        private readonly IOutputService _output;

        public TrackDbService(ITrackRepository repository, IOutputService output)
        {
            _repository = repository;
            _output = output;
        }
        public async Task RunAllDatabaseOperations()
        {
            // await GetAllTrackRecordsAsync();
            // await GetAllTracksWithTechnicalDetailsAsync();
            await GetFullListAsync();
        }

        private async Task GetAllTrackRecordsAsync()
        {
            var tracks = await _repository.GetAllTracksAsync();
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Tracks retrieved successfully:");
                foreach (var track in tracks)
                {
                    await _output.WriteLineAsync(track.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found.");
            }
        }

        public async Task GetAllTracksWithTechnicalDetailsAsync()
        {
            var tracks = await _repository.GetAllTracksAsync(includeTechDetails: true);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Tracks with technical details retrieved successfully:");
                
                foreach (var track in tracks)
                {
                        await _output.WriteLineAsync($"{track.Artist} - {track.Recorded} : {track.Album} - {track.Disc} - {track.Number} - {track.Name} ({track.Duration?.ToString(@"mm\:ss") ?? "N/A"})");
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found with technical details.");
            }
        }

        private async Task GetFullListAsync()
        {
            var tracks = await _repository.GetFullListAsync();
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Full list of tracks retrieved successfully:");
                
                foreach (var track in tracks)
                {
                    await _output.WriteLineAsync(track.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found in the full list.");
            }
        }
    }
}
