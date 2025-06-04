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
            await GetAllArtistRecordsAsync();
            // await GetRecordByIdAsync(1076);
            // await CountTotalRecordsAsync();
            // await GetTotalCostAsync();
            // await GetTotalCdCostAsync();
            // await GetRecordsByArtistIdAsync(114);
            // await AddNewRecord();
            // await AddNewRecord(893, "Hip-Hop TipTop", "Rock", 2025, "Wobble Dobble Music", "Aus", "***", 1, "CD", DateTime.Now, 19.99m, "", "This is Charlie's second album.");
            // await DeleteRecordAsync(5294);
            // await UpdateRecordAsync();
            // await UpdateRecordAsync(5291, "Rockin' The Boogie Bass Again", "Rock", 2023, "Wibble Wobble Music", "Aus", "***", 1, "CD", DateTime.Now, 19.99m, "", "This is Charlies's second album.");
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

    }
}
