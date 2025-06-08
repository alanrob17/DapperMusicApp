using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models.Dtos
{
    public class ArtistRecordDto
    {
        // Record properties
        public int RecordId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string? Field { get; set; }
        public int Recorded { get; set; }
        public string? Pressing { get; set; }
        public string? Rating { get; set; }
        public int Discs { get; set; }
        public string? Media { get; set; }

        // Artist properties
        public string? ArtistName { get; set; }
        public string? ArtistFirstName { get; set; }
        public string? ArtistLastName { get; set; }

        public override string ToString()
        {
            return $"Artist: {ArtistName} - Record Id: {RecordId}, Title: {Name}, Year: {Recorded}, Field: {Field}";
        }
    }
}
