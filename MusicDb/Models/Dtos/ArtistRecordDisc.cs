using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models.Dtos
{
    public class ArtistRecordDisc
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ArtistName { get; set; }
        public int RecordId { get; set; }
        public string RecordName { get; set; } = string.Empty;
        public string? Field { get; set; }
        public int Recorded { get; set; }
        public int TotalDiscs { get; set; }
        public string? Media { get; set; }
        public int DiscId { get; set; }
        public string? DiscName { get; set; }
        public int? DiscNumber { get; set; }
        public string? Length { get; set; }
        public TimeSpan? Duration { get; set; }

        public override string ToString()
        {
            string length = Length;

            if (!string.IsNullOrEmpty(Length))
            {
                length = System.Text.RegularExpressions.Regex.Replace( Length,@"^(00:)+", string.Empty);
            }

            return $"Artist: {ArtistName}, Year: {Recorded} - Title: {RecordName}, Field: {Field}, Disc No: {DiscNumber}, Length: {length}";
        }
    }
}
