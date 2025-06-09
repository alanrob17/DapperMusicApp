﻿using Dapper;
using MusicDb.Data;
using MusicDb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDataAccess _db;

        public ArtistRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddArtistAsync(Artist artist)
        {
            var sproc = "adm_ArtistInsert";

            var affected = await _db.SaveDataAsync(sproc, artist, "Result", DbType.Int32);
            return affected > 0;
        }

        public async Task<bool> AddArtistAsync(string firstName, string lastName, string name, string biography, string folder, int recordArtistId)
        {
            var artist = new Artist
            {
                FirstName = firstName,
                LastName = lastName,
                Name = name,
                Biography = biography,
                Folder = folder,
                RecordArtistId = recordArtistId
            };

            var sproc = "adm_ArtistInsert";
            var affected = await _db.SaveDataAsync("adm_ArtistInsert", artist, "Result", DbType.Int32);
            return affected > 0;
        }

        public async Task<bool> AddArtistWithoutFirstNameAsync()
        {
            var sproc = "adm_ArtistInsert";
            var artist = new Artist
            {
                FirstName = string.Empty,
                LastName = "The Wombats",
                Name = "The Wombats",
                Biography = "The Wombats are a Jazz Rock band.",
                Folder = "G:\\Music\\Library\\The Wombats",
                RecordArtistId = 0
            };

            var affected = await _db.SaveDataAsync(sproc, artist, "Result", DbType.Int32);
            return affected > 0;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            var sproc = "up_ArtistSelectAll";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsWithBriefBioAsync()
        {
            var sproc = "adm_ArtistSelectBriefBio";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {   
            var sproc = "up_GetArtistById";
            var parameter = new { ArtistId = artistId };
            return await _db.GetSingleAsync<Artist>(sproc, parameter);
        }

        public async Task<IEnumerable<Artist>> GetArtistListAsync()
        {
            var sproc = "up_ArtistSelectAll";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<int> CountArtistsAsync()
        {
            var sproc = "up_GetArtistCount";
            return await _db.GetCountOrIdAsync(sproc, new { });
        }

        public async Task<bool> CheckForArtistNameAsync(string name)
        {
            string sproc = "up_CheckArtistExists";
            var parameter = new { Name = name };
            return await _db.GetCountOrIdAsync(sproc, parameter) > 0;
        }

        public async Task<Artist?> GetArtistByFirstLastNameAsync(string firstName, string lastName)
        {
            string sproc = "up_ArtistByFirstLastName";
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", firstName);
            parameters.Add("@LastName", lastName);
            return await _db.GetSingleAsync<Artist>(sproc, parameters);
        }

        public async Task<Artist?> GetArtistByNameAsync(string name)
        {
            string sproc = "up_GetFullArtistByName";
            var parameter = new { Name = name };
            return await _db.GetSingleAsync<Artist>(sproc, parameter);
        }

        public async Task<int> GetArtistIdAsync(string firstName, string lastName)
        {
            var sproc = "up_getArtistIdByName";
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", firstName);
            parameters.Add("@LastName", lastName);
            int id = await _db.GetCountOrIdAsync(sproc, parameters);
            return id;
        }

        public async Task<int> GetArtistIdFromRecordAsync(int recordId)
        {
            var sproc = "up_getArtistIdFromRecordId";
            var parameter = new { RecordId = recordId };
            return await _db.GetCountOrIdAsync(sproc, parameter);
        }

        public async Task<int> GetNoBiographyCountAsync()
        {
            var sproc = "up_NoBiographyCount";
            return await _db.GetCountOrIdAsync(sproc, new { });
        }

        public async Task<IEnumerable<Artist>> GetArtistsWithNoBioAsync()
        {
            var sproc = "up_selectArtistsWithNoBio";
            return await _db.GetDataAsync<Artist>(sproc, new { });
        }

        public async Task<Artist?> GetBiographyAsync(int artistId)
        {
            var sproc = "up_ArtistSelectById";
            var parameters = new { ArtistId = artistId };
            return await _db.GetSingleAsync<Artist>(sproc, parameters);
        }

        public async Task<string> GetBiographyFromRecordIdAsync(int recordId)
        {
            var sproc = "up_GetBiography";
            var parameter = new { RecordId = recordId };
            return await _db.GetTextAsync(sproc, parameter);
        }

        public async Task<string> GetArtistNameByRecordIdAsync(int recordId)
        {
            var sproc = "up_GetArtistNameByRecordId";
            var parameter = new { RecordId = recordId };
            Artist artist = await _db.GetSingleAsync<Artist>(sproc, parameter);

            return artist?.Name ?? string.Empty;
        }

        public async Task<Artist> ShowArtistAsync(int artistId)
        {
            var sproc = "up_ArtistSelectById";
            var parameter = new { ArtistId = artistId };
            return await _db.GetSingleAsync<Artist>(sproc, parameter);
        }

        public async Task<string> GetArtistNameAsync(int artistId)
        {
            var sproc = "up_GetArtistNameByArtistId";
            var parameters = new { ArtistId = artistId };
            var name = await _db.GetTextAsync(sproc, parameters);

            return name ?? string.Empty;
        }

        public async Task<int> UpdateArtistAsync(Artist artist)
        {
            var sproc = "up_UpdateArtist";
            return await _db.SaveDataAsync(sproc, artist, "Result", DbType.Int32);
        }

        public async Task<int> UpdateArtistAsync(int artistId, string firstName, string lastName, string name, string biography, string folder, int recordArtistId)
        {
            var sproc = "up_UpdateArtist";
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
            return await _db.SaveDataAsync(sproc, artist, "Result", DbType.Int32);
        }

        public async Task<bool> DeleteArtistAsync(int artistId)
        {
            var sproc = "up_ArtistDelete";
            var parameter = new { ArtistId = artistId };

            int result = await _db.DeleteDataAsync(sproc, parameter);
            return result > 0;
        }

        public async Task<bool> DeleteArtistAsync(string name)
        {
            var sproc = "up_ArtistDeleteByName";
            var parameter = new { Name = name };
            var rowsAffected = await _db.DeleteDataAsync(sproc, parameter);
            return rowsAffected > 0;
        }
    }
}
