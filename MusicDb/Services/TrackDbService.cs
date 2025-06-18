using MusicDb.Models;
using MusicDb.Models.Dtos;
using MusicDb.Repositories;
using MusicDb.Services.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            // await GetHighQualityTracksAsync();
            await GetHighQualityAlbumsAsync();
            // await GetBriefListAsync();
            // await GetBriefListByYearAsync(1970);
            // await GetArtistListAsync();
            // await GetArtistRecordAsync();
            // await GetTotalAlbumTimeAsync();
            // await GetAllSingleTrackRecordsAsync();
            // await GetArtistGuestTrackListAsync("Bob Dylan");
            // await GetTrackListingAsync(189);
            // await GetAllTrackRecordsAsync(233);
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

        private async Task GetHighQualityTracksAsync()
        {
            IEnumerable<ArtistRecordTrackDto> tracks = await _repository.GetHighQualityTracksAsync();
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("High quality tracks retrieved successfully:");

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

        private async Task GetAllSingleTrackRecordsAsync()
        {
            IEnumerable<ArtistRecordTrackDto> tracks = await _repository.GetAllSingleTracksAsync();
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Single track records retrieved successfully:");
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


        private async Task GetArtistGuestTrackListAsync(string name)
        {
            IEnumerable<ArtistRecordTrackDto> tracks = await _repository.GetArtistGuestTracksAsync(name);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Single track records retrieved successfully:");
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

        private async Task GetTrackListingAsync(int discId)
        {
            IEnumerable<Track> tracks = await _repository.GetTrackListingAsync(discId);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Single track records retrieved successfully:");
                foreach (var track in tracks)
                {
                    string number = track.Number.ToString().PadLeft(2, '0');

                    await _output.WriteLineAsync($"{track.Artist} - {track.Recorded} : {track.Album} - {number} - {track.Name} ({track.Duration?.ToString(@"mm\:ss") ?? "N/A"})");
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found.");
            }
        }

        private async Task GetAllTrackRecordsAsync(int recordId)
        {
            IEnumerable<ArtistRecordTrackDto> tracks = await _repository.GetRecordTrackListingAsync(recordId);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Track records retrieved successfully:");
                var count = 1;
                foreach (var track in tracks)
                {
                    if (track.DiscNumber > count)
                    {
                        count++;
                        await _output.WriteLineAsync($"\n");
                    }
                    string number = track.Number.ToString().PadLeft(2, '0');

                    if (track.Discs == 1)
                    {
                        await _output.WriteLineAsync($"{track.ArtistName} - {track.Recorded} : {track.RecordName} - {number} - {track.FullTrackName} ({track.Duration?.ToString(@"mm\:ss") ?? "N/A"})");
                    }
                    else if (track.Discs > 1 && track.Discs < 10)
                    {
                        await _output.WriteLineAsync($"{track.ArtistName} - {track.Recorded} : Disc {track.DiscNumber} - {track.RecordName} - {number} - {track.FullTrackName} ({track.Duration?.ToString(@"mm\:ss") ?? "N/A"})");
                    } 
                    else
                    {                         
                        string disc = track.DiscNumber.ToString().PadLeft(2, '0');
                        await _output.WriteLineAsync($"{track.ArtistName} - {track.Recorded} : Disc {disc} - {track.RecordName} - {number} - {track.FullTrackName} ({track.Duration?.ToString(@"mm\:ss") ?? "N/A"})");
                    }
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found.");
            }
        }

        private async Task GetBriefListAsync()
        {
            IEnumerable<Track> tracks = await _repository.GetBriefListAsync();
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Single track records retrieved successfully:");
                foreach (var track in tracks)
                {
                    string number = track.Number.ToString().PadLeft(2, '0');
                    await _output.WriteLineAsync($"{track.Artist} - {track.Recorded} : {track.Album} - {track.Field} - {number} - {track.Name} ({track.Length?.ToString() ?? "N/A"})");
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found.");
            }
        }

        private async Task GetBriefListByYearAsync(int year)
        {
            IEnumerable<Track> tracks = await _repository.GetBriefListByYearAsync(year);
            if (tracks != null && tracks.Any())
            {
                await _output.WriteLineAsync("Single track records retrieved successfully:");
                foreach (var track in tracks)
                {
                    string number = track.Number.ToString().PadLeft(2, '0');
                    await _output.WriteLineAsync($"{track.Artist} - {track.Recorded} : {track.Album} - {track.Field} - {number} - {track.Name} ({track.Length?.ToString() ?? "N/A"})");
                }
            }
            else
            {
                await _output.WriteLineAsync("No tracks found.");
            }
        }

        private async Task GetHighQualityAlbumsAsync()
        {
            IEnumerable<ArtistRecordDto> records = await _repository.GetHighQualityAlbumsAsync();
            if (records != null && records.Any())
            {
                await _output.WriteLineAsync("High quality albums retrieved successfully:");

                foreach (var record in records)
                {
                    await _output.WriteLineAsync(record.ToString());
                }
            }
            else
            {
                await _output.WriteLineAsync("No high quality Albums found in the list.");
            }
        }
    }
}
