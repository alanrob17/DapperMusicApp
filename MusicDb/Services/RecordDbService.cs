using MusicDb.Models;
using MusicDb.Models.Dtos;
using MusicDb.Repositories;
using MusicDb.Services.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Services
{
    public class RecordDbService
    {
        private readonly IRecordRepository _repository;
        private readonly IOutputService _output;

        public RecordDbService(IRecordRepository repository, IOutputService output)
        {
            _repository = repository;
            _output = output;
        }
        public async Task RunAllDatabaseOperations()
        {
            // await GetAllRecordsAsync();
            // await GetAllArtistRecordsAsync();
            // await GetRecordByIdAsync(1076);
            // await GetArtistRecordByIdAsync(1076);
            // await CountTotalRecordsAsync();
            // await GetRecordsByArtistIdAsync(26);
            // TODO: finish next method
            //await GetTotalAlbumTimeAsync();
            // await GetArtistFromRecordArtistIdAsync(26);
            // await GetTotalTimeByArtistIdAsync(160);
            // await GetArtistFromArtistNameAsync("Neil Young");
            await GetTotalTimeByArtistNameAsync("The Band");

            // TODO: Uncomment and implement the following methods as needed
            // await AddNewRecord();
            // await AddNewRecord(893, "Hip-Hop TipTop", "Rock", 2025, "Wobble Dobble Music", "Aus", "***", 1, "CD", DateTime.Now, 19.99m, "", "This is Charlie's second album.");
            // await UpdateRecordAsync();
            // await UpdateRecordAsync(5291, "Rockin' The Boogie Bass Again", "Rock", 2023, "Wibble Wobble Music", "Aus", "***", 1, "CD", DateTime.Now, 19.99m, "", "This is Charlies's second album.");
            // await DeleteRecordAsync(5294);
            // await GetArtistRecordsAsync(114);
            // await GetNoRecordReviewsAsync();
            // await CountDiscsAsync("All");
            // await GetArtistNumberOfRecordsAsync(114);
            // await GetRecordByNameAsync("Doggo");
            // await GetRecordsByNameAsync("Bringing");
            // await GetArtistNameFromRecordAsync(3232);
            // await GetRecordNumberByYearAsync(1974);
            // await GetTotalNumberOfCDsAsync();
            // await GetNoReviewCountAsync();
            // await GetBoughtDiscCountForYearAsync(2022);
            // await GetTotalCostForYearAsync(2017);
            // await GetTotalNumberOfDiscsAsync();
            // await GetRecordDetailsAsync(3232);
            // await GetTotalArtistCostAsync();
            // await GetTotalArtistDiscsAsync();
            // await GetRecordListbyArtistAsync(114);
            // await GetRecordHtmlAsync(3232);
            // await GetDiscCountForYearAsync(1974);
            // await GetArtistRecordListAsync();
            // await GetTotalNumberOfRecordsAsync();
            // await GetTotalNumberOfBluraysAsync();
            // await GetTotalNumberOfDVDsAsync();
        }

        private async Task GetAllRecordsAsync()
        {
            var records = await _repository.GetAllRecordsAsync();

            if (records != null && records.Any())
            {
                await _output.WriteLineAsync("Records retrieved successfully:");
                foreach (var record in records)
                {
                    await _output.WriteLineAsync($"{record.ToString()}");
                }
            }
            else
            {
                await _output.WriteLineAsync("No records found.");
            }
        }

        private async Task GetAllArtistRecordsAsync()
        {
            var records = await _repository.GetAllArtistRecordsAsync();

            if (records != null && records.Any())
            {
                await _output.WriteLineAsync("Records retrieved successfully:");
                foreach (var record in records)
                {
                    await _output.WriteLineAsync($"{record.ToString()}");
                }
            }
            else
            {
                await _output.WriteLineAsync("No records found.");
            }
        }

        private async Task GetRecordByIdAsync(int recordId)
        {
            var record = await _repository.GetRecordByIdAsync(recordId);

            if (record is not null)
            {
                await _output.WriteLineAsync(record.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"RecordId: {recordId} not found.");
            }
        }

        private async Task GetArtistRecordByIdAsync(int recordId)
        {
            var record = await _repository.GetArtistRecordByIdAsync(recordId);

            if (record is not null)
            {
                await _output.WriteLineAsync(record.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"RecordId: {recordId} not found.");
            }
        }

        private async Task CountTotalRecordsAsync()
        {
            var count = await _repository.CountTotalRecordsAsync();
            await _output.WriteLineAsync($"Total Records: {count}");
        }

        private async Task GetRecordsByArtistIdAsync(int artistId)
        {
            var records = await _repository.GetRecordsByArtistIdAsync(artistId);
            foreach (var record in records)
            {
                await _output.WriteLineAsync(record.ToString());
            }
        }

        private async Task GetTotalAlbumTimeAsync()
        {
            TotalTimeDto time = await _repository.GetTotalAlbumTimeAsync();
            await _output.WriteLineAsync($"Total time for all albums: {time.TotalLengthFormatted}");
        }

        private async Task GetTotalTimeByArtistIdAsync(int artistId)
        {
            TotalTimeDto? time = await _repository.GetTotalAlbumTimeByArtistIdAsync(artistId);

            Artist artist = await _repository.GetArtistFromRecordArtistIdAsync(artistId);

            if (time is not null && artist is not null)
            {
                await _output.WriteLineAsync($"Total Album time for artist: {artist.Name} - {time.TotalLengthFormatted}");
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for artist {artistId}.");
            }
        }

        private async Task GetTotalTimeByArtistNameAsync(string name)
        {
            Artist artist = await _repository.GetArtistFromNameAsync(name);

            if (artist is not null)
            {
                TotalTimeDto? time = await _repository.GetTotalAlbumTimeByArtistIdAsync(artist.ArtistId);

                if (time is not null)
                {
                    await _output.WriteLineAsync($"Total Album time for artist: {artist.Name} - {time.TotalLengthFormatted}");
                }
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for artist {name}.");
            }
        }

        private async Task GetArtistFromArtistNameAsync(string name)
        {
            Artist artist = await _repository.GetArtistFromNameAsync(name);
            if (artist is not null)
            {
                await _output.WriteLineAsync(artist.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"Artist with name '{name}' not found.");
            }
        }

        private async Task GetArtistFromRecordArtistIdAsync(int artistId)
        {
            Artist artist = await _repository.GetArtistFromRecordArtistIdAsync(artistId);

            if (artist is not null)
            {
                await _output.WriteLineAsync($"Artist found: {artist.Name}");
            }
            else
            {
                await _output.WriteErrorAsync($"No artist found for ArtistId: {artistId}.");
            }
        }
    }
}
