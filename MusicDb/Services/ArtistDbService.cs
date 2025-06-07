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
    public class ArtistDbService
    {
        private readonly IArtistRepository _repository;
        private readonly IOutputService _output;
                
        public ArtistDbService(IArtistRepository repository, IOutputService output)
        {
            _repository = repository;
            _output = output;
        }

        public async Task RunAllDatabaseOperations()
        {
            // await GetAllArtistsAsync();
            // await GetAllArtistsWithBriefBioAsync();
            // await GetArtistListAsync();
            // await DisplayAllArtistsAsync();
            // await GetArtistByIdAsync(26);
            // await CountArtistsAsync();
            await AddArtistAsync();

            // TODO: Create these methods.
            // await AddArtistWithoutFirstNameAsync();
            // await AddArtistFromFieldsAsync();
            // await CheckForArtistNameAsync("Charley Robson");
            // await DeleteArtistAsync(892);
            // await DeleteArtistAsync("Andrew Robson");
            // await GetArtistByFirstLastNameAsync("Bob", "Dylan");
            // await GetArtistByNameAsync("Bob Dylan");
            // await GetArtistIdByNameAsync("Bob", "Dylan");
            // await GetArtistIdFromRecordAsync(5249);
            // await GetArtistsWithNoBioAsync();
            // await GetBiographyAsync(114);
            // await GetNoBiographyCountAsync();
            // await UpdateArtistAsync(861, "Charles", "Robson", "Charles Robson", "Charles is a Jazz music star.");
            // await UpdateArtistAsync();
            // await GetBiographyFromRecordIdAsync(5249);
            // await GetArtistNameFromRecordIdAsync(5249);
            // await ShowArtistAsync(114);
            // await GetArtistNameAsync(114);
        }

        private async Task AddArtistAsync()
        {
            var artist = new Artist
            {
                FirstName = "Andrew",
                LastName = "Robson",
                Name = "Andrew Robson",
                Biography = "Andrew is a Hip-Hop star.",
                Folder = "G:\\Music\\Library\\Andrew Robson",
                RecordArtistId = 0
            };
            var result = await _repository.AddArtistAsync(artist);
            if (result)
            {
                await _output.WriteLineAsync("Artist added successfully.");
            }
            else
            {
                await _output.WriteLineAsync("Failed to add artist.");
            }
        }

        private async Task GetArtistByIdAsync(int artistId)
        {
            var artist = await _repository.GetArtistByIdAsync(artistId);

            if (artist != null)
            {
                await _output.WriteLineAsync(artist.ToString());
            }
            else
            {
                await _output.WriteLineAsync($"Artist with Id {artistId} not found.");
            }
        }

        private async Task GetAllArtistsAsync()
        {
            var artists = await _repository.GetAllArtistsAsync();
            foreach (var artist in artists)
            {
                var biography = string.Empty;
                if (artist.Biography != null && artist.Biography.Length > 60)
                {
                    biography = artist.Biography.Substring(0, 60);
                }

                await _output.WriteLineAsync($"Id: {artist.ArtistId}, Name: {artist.Name} - {biography}");
            }
        }

        private async Task GetAllArtistsWithBriefBioAsync()
        {
            var artists = await _repository.GetAllArtistsWithBriefBioAsync();
            foreach (var artist in artists)
            {
                await _output.WriteLineAsync($"Id: {artist.ArtistId}, Name: {artist.Name} - {artist.Biography}");
            }
        }

        private async Task GetArtistListAsync()
        {
            var artists = (IEnumerable<Artist>)await _repository.GetArtistListAsync();
            artists = artists.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();

            var artistDictionary = new Dictionary<int, string>
            {
                { 0, "Select an artist" }
            };

            foreach (var artist in artists)
            {
                if (string.IsNullOrEmpty(artist.FirstName))
                {
                    artistDictionary.Add(artist.ArtistId, artist.LastName);
                }
                else
                {
                    artistDictionary.Add(artist.ArtistId, $"{artist.LastName}, {artist.FirstName}");
                }
            }

            await _output.WriteLineAsync("Artist List:");
            foreach (var kvp in artistDictionary)
            {
                await _output.WriteLineAsync($"{kvp.Key}: {kvp.Value}");
            }
        }

        private async Task DisplayAllArtistsAsync()
        {
            var artists = await _repository.GetArtistListAsync();
            foreach (var artist in artists)
            {
                await _output.WriteLineAsync($"Id: {artist.ArtistId}, Name: {artist.Name}");
            }
        }

        private async Task CountArtistsAsync()
        {
            var count = await _repository.CountArtistsAsync();
            await _output.WriteLineAsync($"Total number of artists: {count}");
        }
    }
}
