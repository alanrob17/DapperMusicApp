using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Dtos
{
    public class ArtistRecordDto
    {
        // Record properties
        public int RecordId { get; set; }
        public int ArtistId { get; set; }
        public string? Name { get; set; }
        public string? SubTitle { get; set; }
        public string? Field { get; set; }
        public int Recorded { get; set; }
        public int Discs { get; set; }
        public string? CoverName { get; set; }
        public string? Review { get; set; }
        public string? Folder { get; set; }
        public string? Length { get; set; }

        // Artist properties
        public string? ArtistName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public override string ToString()
        {
            return $"Artist: {ArtistName} - Record Id: {RecordId}, Title: {Name}, Year: {Recorded}, Field: {Field}, Length: {Length}";
        }
    }
}
