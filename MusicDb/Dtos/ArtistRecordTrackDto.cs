using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Dtos
{
    public class ArtistRecordTrackDto
    {
        public int ArtistId { get; set; }
        public string? ArtistName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayArtist { get; set; }
        public int RecordId { get; set; }
        public string? RecordName { get; set; }
        public int Recorded { get; set; }
        public int Discs { get; set; }
        public int DiscId { get; set; }
        public string? DiscName { get; set; }
        public int DiscNumber { get; set; }
        public int TrackId { get; set; }
        public string? Name { get; set; }
        public string Length { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Field { get; set; }
        public int Number { get; set; }
        public string? FullTrackName { get; set; }

        public override string ToString()
        {
            if (!DiscName.IsNullOrEmpty())
            {
                return $"{ArtistName} - {Recorded} {RecordName} ({Field}) - {DiscName} - {FullTrackName} ({Duration?.ToString(@"mm\:ss") ?? "N/A"})";
            }
            else
            {
                return $"{ArtistName} - {Recorded} {RecordName} ({Field}) {FullTrackName} ({Duration?.ToString(@"mm\:ss") ?? "N/A"})";
            }
        }
    }
}
