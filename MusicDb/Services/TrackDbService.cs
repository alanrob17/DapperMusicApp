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
            // await GetFullListAsync();
            // await GetArtistListAsync();
            // await GetArtistRecordAsync();
            await GetTotalAlbumTimeAsync();
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

        private async Task GetArtistListAsync()
        {
            var artistId = 26;
            var tracks = await _repository.GetArtistListAsync(artistId);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Full list of Artist tracks:");

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

        private async Task GetArtistRecordAsync()
        {
            var artistId = 26;
            var recordId = 175;
            var tracks = await _repository.GetArtistRecordAsync(artistId, recordId);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Full list of an Artist and their Album:");

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

        private async Task GetTotalAlbumTimeAsync()
        {
            var totalTime = await _repository.GetTotalAlbumTimeAsync();
            if (totalTime != null)
            {
                await _output.WriteLineAsync($"Total time for all albums: {totalTime.TotalLengthFormatted}");
            }
        }
    }
}
