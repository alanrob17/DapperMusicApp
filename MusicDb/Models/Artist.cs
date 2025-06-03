using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(int.MaxValue), Column(TypeName = "text")]
        public string? Biography { get; set; }

        [MaxLength(400)]
        public string Folder { get; set; }

        public int RecordArtistId { get; set; }

        [InverseProperty(nameof(Record.Artist))]
        public virtual ICollection<Record> Records { get; set; }

        public override string ToString()
        {
            var biography = string.IsNullOrEmpty(Biography) ? "No Biography" : (Biography.Length > 30 ? Biography.Substring(0, 30) + "..." : Biography);

            return $"Artist Id: {ArtistId}, Artist: {Name}, Biography: {biography}";
        }
    }
}
