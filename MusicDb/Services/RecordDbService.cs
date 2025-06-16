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
            // await UpdateRecordAsync(3278, 413, "Bass Extroadinaire!", "James' Greatest Hits", "Rock", 2024, 2, "G:\\Music\\Library\\James Robson\\2024 - Bass Extroadinaire!\\cover.jpg", "This is James' first album.", "G:\\Music\\Library\\James Robson\\2024 - Bass Extroadinaire!", "0:2:20:10");
            // await DeleteRecordAsync(3278);
            // await GetArtistRecordsAsync(26);
            // await GetNoRecordReviewsAsync();
            // await CountDiscsAsync("Blues");
            // await GetArtistNumberOfRecordsAsync(26);
            // await GetArtistNumberOfRecordsAsync("Bob Dylan");
            // await GetRecordByNameAsync("Blonde");
            // await GetRecordsByNameAsync("Bringing");
            // await GetArtistNameFromRecordAsync(1373);
            // await GetRecordNumberByYearAsync(1974);
            // await GetRecordListByYearAsync(1974);
            // await GetNoReviewCountAsync();
            // await GetRecordDetailsAsync(3232);
            // await GetTotalArtistDiscsAsync();
            // await GetRecordHtmlAsync(3232);
            // await GetRecordListAsync(26);
            // await GetAlbumLengthAsync(306);
            await GetAlbumDetailsAndLengthAsync(306);
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

        private async Task GetArtistRecordsAsync(int artistId)
        {

            var records = await _repository.GetArtistRecordsAsync(artistId);
            foreach (var record in records)
            {
                await _output.WriteLineAsync(record.ToString());
            }
        }

        private async Task GetNoRecordReviewsAsync()
        {
            var records = await _repository.NoRecordReviewsAsync();
            foreach (var record in records)
            {
                await _output.WriteLineAsync($"ArtistId: {record.ArtistId} - Artist: {record.ArtistName} - Record Id: {record.RecordId}: {record.Recorded} - {record.RecordName}");
            }
        }

        private async Task CountDiscsAsync(string show)
        {
            var discs = await _repository.CountDiscsAsync(show);
            await _output.WriteLineAsync($"{show}: Total Discs: {discs}");
        }

        private async Task GetArtistNumberOfRecordsAsync(int artistId)
        {
            var records = await _repository.GetArtistNumberOfRecordsAsync(artistId);
            if (records > 0)
            {
                await _output.WriteLineAsync($"ArtistId: {artistId} - Number of Records: {records}");
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for ArtistId: {artistId}");
            }
        }

        private async Task GetArtistNumberOfRecordsAsync(string name)
        {
            int records = await _repository.GetArtistNumberOfRecordsAsync(name);
            if (records > 0)
            {
                await _output.WriteLineAsync($"Artist: {name} - Number of Records: {records}");
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for Artist: {name}");
            }
        }

        private async Task GetRecordByNameAsync(string name)
        {
            var record = await _repository.GetRecordByNameAsync(name);
            if (record is not null)
            {
                await _output.WriteLineAsync(record.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"Record: {name} not found.");
            }
        }

        private async Task GetRecordsByNameAsync(string name)
        {
            var records = await _repository.GetRecordsByNameAsync(name);
            if (records is not null)
            {
                foreach (var record in records)
                {
                        await _output.WriteLineAsync(record.ToString());
                }
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for name: {name}");
            }
        }

        private async Task GetArtistNameFromRecordAsync(int recordId)
        {
            var artistName = await _repository.GetArtistNameFromRecordAsync(recordId);
            if (!string.IsNullOrEmpty(artistName))
            {
                await _output.WriteLineAsync($"Artist Name: {artistName}");
            }
            else
            {
                await _output.WriteErrorAsync($"No artist found for record ID: {recordId}");
            }
        }

        private async Task GetRecordListByYearAsync(int year)
        {
            var records = await _repository.GetRecordsByRecordedYearAsync(year);
            if (records is not null)
            {
                foreach (var record in records)
                {
                    await _output.WriteLineAsync(record.ToString());
                }
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for Year recorded: {year}");
            }
        }

        private async Task GetTotalArtistDiscsAsync()
        {
            var totals = await _repository.GetTotalArtistDiscsAsync();
            foreach (var total in totals)
            {
                await _output.WriteLineAsync($"ArtistId: {total.ArtistId}, Artist: {total.Name} - Total Discs: {total.TotalDiscs}");
            }
        }

        private async Task GetRecordNumberByYearAsync(int year)
        {
            var records = await _repository.GetRecordNumberByYearAsync(year);
            if (records > 0)
            {
                await _output.WriteLineAsync($"Total records for year {year}: {records}");
            }
            else
            {
                await _output.WriteErrorAsync($"No records found for year: {year}");
            }
        }

        private async Task GetNoReviewCountAsync()
        {
            var count = await _repository.GetNoReviewCountAsync();
            if (count > 0)
            {
                await _output.WriteLineAsync($"Total number of records with no reviews: {count}");
            }
            else
            {
                await _output.WriteErrorAsync("No records found with no reviews.");
            }
        }

        private async Task GetRecordDetailsAsync(int recordId)
        {

            var record = await _repository.GetRecordDetailsAsync(recordId);
            if (record is not null)
            {
                await _output.WriteLineAsync(record.ToString());
            }
            else
            {
                await _output.WriteErrorAsync($"Record with ID {recordId} not found.");
            }
        }

        private async Task GetRecordHtmlAsync(int recordId)
        {
            ArtistRecordDto record = await _repository.GetRecordHtmlAsync(recordId);
            if (record is not null)
            {
                string recordHtml = RecordHtml(record);
                await _output.WriteLineAsync(recordHtml);
            }
            else
            {
                await _output.WriteErrorAsync($"Record with ID {recordId} not found.");
            }
        }

        private async Task GetRecordListAsync(int artistId)
        {
            var records = (IEnumerable<Record>)await _repository.GetRecordListAsync(artistId);

            var recordDictionary = new Dictionary<int, string>
            {
                { 0, "Select a Record" }
            };

            foreach (var record in records)
            {
                recordDictionary.Add(record.RecordId, $"{record.Recorded} - {record.Name}");
            }

            await _output.WriteLineAsync("Record List:");
            foreach (var kvp in recordDictionary)
            {
                await _output.WriteLineAsync($"{kvp.Key}: {kvp.Value}");
            }
        }

        private async Task GetAlbumLengthAsync(int recordId)
        {
            string albumLength = await _repository.GetAlbumLengthAsync(recordId);
            if (albumLength != null)
            {
                await _output.WriteLineAsync($"Album length: {albumLength}");
            }
            else
            {
                await _output.WriteLineAsync("No album length found.");
            }
        }

        private async Task GetAlbumDetailsAndLengthAsync(int recordId)
        {
            ArtistRecordDto album = await _repository.GetAlbumDetailsAsync(recordId);
            if (album != null)
            {
                await _output.WriteLineAsync($"Album length: {album.ToString()}");
            }
            else
            {
                await _output.WriteLineAsync("No album found.");
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

        private async Task UpdateRecordAsync(int recordId, int artistId, string name, string subTitle, string field, int recorded, int discs, string coverName, string review, string folder, string length)
        {
            var record = new Record
            {
                RecordId = recordId,
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
            };

            var rowsAffected = await _repository.UpdateRecordAsync(record);
            if (rowsAffected > 0)
            {
                await _output.WriteLineAsync($"Record Id: {recordId} updated successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to update record with Id: {recordId}.");
            }
        }

        private async Task DeleteRecordAsync(int recordId)
        {
            var result = await _repository.DeleteRecordAsync(recordId);
            if (result)
            {
                await _output.WriteLineAsync($"Record with ID {recordId} deleted successfully.");
            }
            else
            {
                await _output.WriteErrorAsync($"Failed to delete record with ID {recordId}.");
            }
        }

        private string RecordHtml(ArtistRecordDto record)
        {
            var recordHtml = $@"
                <h1>{record.Name}</h1>
                <h2>Artist: {record.ArtistName}</h2>
                <p>ArtistId: {record.ArtistId}</p>
                <p>RecordId: {record.RecordId}</p>
                <p>Field: {record.Field}</p>
                <p>Recorded: {record.Recorded}</p>
                <p>Discs: {record.Discs}</p>
                <p>Review: {record.Review}</p>
                <p>Album length: {record.Length}</p>";
            return recordHtml;
        }
    }
}
