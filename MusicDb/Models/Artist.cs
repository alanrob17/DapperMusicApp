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

        [Column(TypeName = "text")]
        public string? Biography { get; set; }

        [Required]
        [MaxLength(400)]
        public string Folder { get; set; } = string.Empty;

        public int RecordArtistId { get; set; }

        // Navigation property
        public virtual ICollection<Record> Records { get; set; } = new HashSet<Record>();

        // Computed property for display name
        [NotMapped]
        public string DisplayName => !string.IsNullOrWhiteSpace(Name) ? Name : $"{FirstName} {LastName}".Trim();

        public override string ToString()
        {
            var bioPreview = string.IsNullOrEmpty(Biography)
                ? "No Biography"
                : Biography.Length > 30
                    ? Biography[..30] + "..."
                    : Biography;

            return $"Artist ID: {ArtistId}, Name: {DisplayName}, Bio Preview: {bioPreview}";
        }
    }
}
