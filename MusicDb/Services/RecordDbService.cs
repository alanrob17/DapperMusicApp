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
            // await GetTotalAlbumTimeAsync();
            // await GetArtistFromRecordArtistIdAsync(26);
            // await GetTotalTimeByArtistIdAsync(160);
            // await GetArtistFromArtistNameAsync("Neil Young");
            // await GetTotalTimeByArtistNameAsync("Yes");
            // await AddNewRecord();
            // await AddNewRecord(413, "Double Bass Extroadinaire!", "Continuing Best of James Robson", "Rock", 2025, 3, "G:\\Music\\Library\\James Robson\\2025 - Double Bass Extroadinaire!\\cover.jpg", "This is James' second album.", "G:\\Music\\Library\\James Robson\\2025 - Double Bass Extroadinaire!", "0:2:25:26");
            // await UpdateRecordAsync();
            // TODO: Uncomment and implement the following method
            // await UpdateRecordAsync(5291, "Rockin' The Boogie Bass Again", "Rock", 2023, "Wibble Wobble Music", "Aus", "***", 1, "CD", DateTime.Now, 19.99m, "", "This is Charlies's second album.");

            // TODO: Uncomment and implement the following methods as needed
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

        private async Task AddNewRecord()
        {
            var recordId = await _repository.AddRecordAsync(new Record
            {
                ArtistId = 413,
                Name = "Bass Extroadinaire!",
                SubTitle = "The Best of James Robson",
                Field = "Rock",
                Recorded = 2024,
                Discs = 2,
                CoverName = "G:\\Music\\Library\\James Robson\\2024 - Bass Extroadinaire!\\cover.jpg",
                Review = "This is James' first album.",
                Folder = "G:\\Music\\Library\\James Robson",
                Length = "0:1:00:00"
            });

            if (recordId > 0)
            {
                await _output.WriteLineAsync($"Record with Id: {recordId} added successfully");
            }
            else
            {
                await _output.WriteErrorAsync("Failed to add record!");
            }
        }

            // ArtistId, Name, SubTitle, Field, Recorded, Discs, CoverName, Review, Folder, Length
        private async Task AddNewRecord(int artistId, string name, string subTitle, string field, int recorded, int discs, string coverName, string review, string folder, string length)
        {
            var recordId = await _repository.AddRecordAsync(new Record
            {
                ArtistId = artistId,
                Name = name,
                SubTitle = subTitle,
                Field = field,
                Recorded = recorded,
                Discs = discs,
                CoverName = coverName,
                Review = review,
                Folder = folder,
                Length = length
            });

            if (recordId > 0)
            {
                await _output.WriteLineAsync($"Record added successfully with RecordId: {recordId}");
            }
            else
            {
                await _output.WriteErrorAsync("Failed to add record.");
            }
        }

        private async Task UpdateRecordAsync()
        {
            var record = new Record
            {
                RecordId = 3278,
                ArtistId = 413,
                Name = "Jazz Rock Bass Extroadinaire!",
                SubTitle = "James Robson's Greatest Hits",
                Field = "Jazz",
                Recorded = 2025,
                Discs = 2,
                CoverName = "G:\\Music\\Library\\James Robson\\2024 - Jazz Rock Bass Extroadinaire!\\cover.jpg",
                Review = "This is James' first album.",
                Folder = "G:\\Music\\Library\\James Robson\\2024 - Jazz Rock Bass Extroadinaire!",
                Length = "0:2:20:10"
            };

            var rowsAffected = await _repository.UpdateRecordAsync(record);
            if (rowsAffected > 0)
            {
                await _output.WriteLineAsync($"Record with ID {record.RecordId} updated successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to update record with ID {record.RecordId}.");
            }
        }
    }
}
