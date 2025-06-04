using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models
{
    public class Disc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscId { get; set; }

        [Required]
        [ForeignKey(nameof(Record))]
        public int RecordId { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? SubTitle { get; set; }

        [Range(1, 100)]
        public int? DiscNumber { get; set; }

        [MaxLength(50)]
        public string? Length { get; set; }

        public TimeSpan? Duration { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Folder { get; set; }

        // Navigation property
        public virtual Record? Record { get; set; }

        [InverseProperty(nameof(Track.Disc))]
        public virtual ICollection<Track> Tracks { get; set; } = new HashSet<Track>();

        public override string ToString()
        {
            return $"Disc ID: {DiscId}, Name: {Name ?? "Untitled"}, " +
                   $"Disc Number: {DiscNumber?.ToString() ?? "N/A"}, " +
                   $"Duration: {Duration?.ToString(@"hh\:mm\:ss") ?? "N/A"}";
        }
    }
}
