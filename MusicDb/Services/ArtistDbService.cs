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
            // await AddArtistAsync();
            // await AddArtistWithoutFirstNameAsync();
            // await AddArtistFromFieldsAsync();
            // await UpdateArtistAsync();
            // await UpdateArtistAsync(411, "Charles", "Robson", "Charles Robson", "Charles is a Jazz music star.", @"G:\Music\Library\Charles Robson", 0);
            // await DeleteArtistAsync(411);
            // await DeleteArtistAsync("Andrew Robson");
            // await CheckForArtistNameAsync("James Robson");
            // await GetArtistByFirstLastNameAsync("Bob", "Dylan");
            // await GetArtistByNameAsync("Jackson Browne");
            // await GetArtistIdByNameAsync("Bruce", "Cockburn");
            // await GetArtistIdFromRecordAsync(123);
            // await GetNoBiographyCountAsync();
            // await GetArtistsWithNoBioAsync();
            // await GetBiographyAsync(26);
            // await GetBiographyFromRecordIdAsync(123);
            // await GetArtistNameFromRecordIdAsync(123);
            // await ShowArtistAsync(26);
            await GetArtistNameAsync(26);
        }

        private async Task AddArtistWithoutFirstNameAsync()
        {
            var result = await _repository.AddArtistWithoutFirstNameAsync();
            if (result)
            {
                await _output.WriteLineAsync("Artist added successfully without first name.");
            }
            else
            {
                await _output.WriteLineAsync("Failed to add artist without first name.");
            }
        }

        private async Task AddArtistAsync()
        {
            var artist = new Artist
            {
                FirstName = string.Empty,
                LastName = "The Aeroplanes",
                Name = "The Aeroplanes",
                Biography = string.Empty,
                Folder = "G:\\Music\\Library\\The Aeroplanes",
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

        private async Task AddArtistFromFieldsAsync()
        {
            var firstName = "Arnold";
            var lastName = "Robson";
            var name = "Arnold Robson";
            var biography = "Arnold is a Hip-Hop star.";
            var folder = @"G:\Music\Library\Arnold Robson";
            var recordArtistId = 0;

            var result = await _repository.AddArtistAsync(firstName, lastName, name, biography, folder, recordArtistId);

            if (result)
            {
                await _output.WriteLineAsync($"Artist {firstName} {lastName} added successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to add artist {firstName} {lastName}.");
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

        private async Task CheckForArtistNameAsync(string name)
        {
            var result = await _repository.CheckForArtistNameAsync(name);
            if (result)
            {
                await _output.WriteLineAsync($"Artist {name} exists in the database.");
            }
            else
            {
                await _output.WriteErrorAsync($"Artist {name} does not exist in the database.");
            }
        }

        private async Task GetArtistByNameAsync(string name)
        {
            var artist = await _repository.GetArtistByNameAsync(name);
            if (artist is not null)
            {
                await _output.WriteLineAsync(artist.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"Artist with name {name} not found.");
            }
        }

        private async Task GetArtistByFirstLastNameAsync(string firstName, string lastName)
        {
            var artist = await _repository.GetArtistByFirstLastNameAsync(firstName, lastName);
            if (artist is not null)
            {
                await _output.WriteLineAsync(artist.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"Artist with name {firstName} {lastName} not found.");
            }
        }

        private async Task GetArtistIdByNameAsync(string firstName, string lastName)
        {
            var artistId = await _repository.GetArtistIdAsync(firstName, lastName);
            if (artistId > 0)
            {
                await _output.WriteLineAsync($"ArtistId: {artistId} found for {firstName} {lastName}");
            }
            else
            {
                await _output.WriteErrorAsync($"ArtistId not found for {firstName} {lastName}");
            }
        }

        private async Task GetArtistIdFromRecordAsync(int recordId)
        {
            var artistId = await _repository.GetArtistIdFromRecordAsync(recordId);
            if (artistId > 0)
            {
                await _output.WriteLineAsync($"ArtistId: {artistId} found for RecordId: {recordId}");
            }
            else
            {
                await _output.WriteErrorAsync($"ArtistId not found for RecordId: {recordId}");
            }
        }

        private async Task GetNoBiographyCountAsync()
        {
            int count = await _repository.GetNoBiographyCountAsync();
            await _output.WriteLineAsync($"Total Artists with no biography: {count}");
        }

        private async Task GetArtistsWithNoBioAsync()
        {
            var artists = await _repository.GetArtistsWithNoBioAsync();

            await _output.WriteLineAsync($"Artists with no biography: {artists.Count()}");

            foreach (var artist in artists)
            {
                await _output.WriteLineAsync(artist.ToString());
            }
        }

        private async Task GetBiographyAsync(int artistId)
        {
            var artist = await _repository.GetBiographyAsync(artistId);
            if (artist is not null)
            {
                var biography = ToHtml(artist);
                await _output.WriteLineAsync(biography);
            }
            else
            {
                await _output.WriteErrorAsync($"ArtistId: {artistId} not found.");
            }
        }

        private async Task GetBiographyFromRecordIdAsync(int recordId)
        {
            var biography = await _repository.GetBiographyFromRecordIdAsync(recordId);
            if (!string.IsNullOrEmpty(biography))
            {
                await _output.WriteLineAsync($"Biography: {biography}");
            }
            else
            {
                await _output.WriteErrorAsync($"No biography found for RecordId: {recordId}");
            }
        }

        private async Task GetArtistNameFromRecordIdAsync(int recordId)
        {
            var artistName = await _repository.GetArtistNameByRecordIdAsync(recordId);
            if (!string.IsNullOrEmpty(artistName))
            {
                await _output.WriteLineAsync($"Artist Name: {artistName}");
            }
            else
            {
                await _output.WriteErrorAsync($"No artist found for RecordId: {recordId}");
            }
        }

        private async Task ShowArtistAsync(int artistId)
        {
            var artist = await _repository.ShowArtistAsync(artistId);
            if (artist is not null)
            {
                var artistHtml = ToHtml(artist);
                await _output.WriteLineAsync(artistHtml);
            }
            else
            {
                await _output.WriteErrorAsync($"ArtistId: {artistId} not found.");
            }
        }

        private async Task GetArtistNameAsync(int artistId)
        {
            var artistName = await _repository.GetArtistNameAsync(artistId);
            if (!string.IsNullOrEmpty(artistName))
            {
                await _output.WriteLineAsync($"Artist Name: {artistName}");
            }
            else
            {
                await _output.WriteErrorAsync($"No artist found for ArtistId: {artistId}");
            }
        }

        private async Task UpdateArtistAsync()
        {
            var artistId = 414;
            var firstName = "Ethan J";
            var lastName = "Robson";
            var name = "Ethan J Robson";
            var biography = "Ethan J is a Dub music star.";
            var folder = "G:\\Music\\Library\\Ethan J Robson";
            var recordArtistId = 0;

            var updated = await _repository.UpdateArtistAsync(artistId, firstName, lastName, name, biography, folder, recordArtistId);
            if (updated > 0)
            {
                await _output.WriteLineAsync($"Artist {name} updated successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to update artist {name}.");
            }
        }

        private async Task UpdateArtistAsync(int artistId, string firstName, string lastName, string name, string biography, string folder, int recordArtistId)
        {
            var artist = new Artist
            {
                ArtistId = artistId,
                FirstName = firstName,
                LastName = lastName,
                Name = name,
                Biography = biography,
                Folder = folder,
                RecordArtistId = recordArtistId
            };
            int updated = await _repository.UpdateArtistAsync(artist);
            if (updated > 0)
            {
                await _output.WriteLineAsync($"Artist {artist.Name} updated successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to update artist {artist.Name}.");
            }
        }

        private async Task DeleteArtistAsync(int artistId)
        {
            var deleted = await _repository.DeleteArtistAsync(artistId);

            if (deleted)
            {
                await _output.WriteLineAsync($"Successfully deleted artist (ID: {artistId})");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to delete artist (ID: {artistId})");
            }
        }

        private async Task DeleteArtistAsync(string name)
        {
            bool deleted = await _repository.DeleteArtistAsync(name);

            if (deleted)
            {
                await _output.WriteLineAsync($"Successfully deleted artist: {name}");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to delete artist: {name}");
            }
        }

        private string ToHtml(Artist artist)
        {
            var artistDetails = new StringBuilder();

            artistDetails.Append($"<p><strong>ArtistId: </strong>{artist.ArtistId}</p>\n");

            if (!string.IsNullOrEmpty(artist.FirstName))
            {
                artistDetails.Append($"<p><strong>First Name: </strong>{artist.FirstName}</p>\n");
            }

            artistDetails.Append($"<p><strong>Last Name: </strong>{artist.LastName}</p>\n");

            if (!string.IsNullOrEmpty(artist.Name))
            {
                artistDetails.Append($"<p><strong>Name: </strong>{artist.Name}</p>\n");
            }

            if (!string.IsNullOrEmpty(artist.Folder))
            {
                artistDetails.Append($"<p><strong>Folder: </strong>{artist.Folder}</p>\n");
            }

            if (artist.RecordArtistId > 0)
            {
                artistDetails.Append($"<p><strong>Record Artist Id: </strong>{artist.RecordArtistId}</p>\n");
            }

            if (!string.IsNullOrEmpty(artist.Biography))
            {
                artistDetails.Append($"<p><strong>Biography: </strong></p>\n<div>\n{artist.Biography}\n</div>\n");
            }

            return artistDetails.ToString();
        }
    }
}
