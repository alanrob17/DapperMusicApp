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
            await GetAllArtistsWithBriefBioAsync();

            // TODO: Create these methods.
            // await DisplayAllArtistsAsync();
            // await GetArtistByIdAsync(114);
            // await CountArtistsAsync();
            // await GetArtistListAsync();
            // await AddArtistAsync();
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
    }
}
