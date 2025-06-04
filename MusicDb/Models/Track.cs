using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }

        [Required]
        [ForeignKey(nameof(Disc))]
        public int DiscId { get; set; }

        [Range(1, 100)]
        public int? DiscNumber { get; set; }

        [MaxLength(250)]
        public string? Name { get; set; }

        [MaxLength(300)]
        public string? Title { get; set; }

        public int? Recorded { get; set; }

        [MaxLength(50)]
        public string? Length { get; set; }

        public TimeSpan? Duration { get; set; }

        public int? Bits { get; set; }

        [Display(Name = "Bit Rate (kbps)")]
        public int? BitRate { get; set; }

        [Display(Name = "Sample Rate (Hz)")]
        public int? AudioSampleRate { get; set; }

        [Range(1, 8)]
        public int? AudioChannels { get; set; }

        [MaxLength(100)]
        public string? Media { get; set; }

        [MaxLength(200)]
        public string? Album { get; set; }

        [MaxLength(600)]
        public string? Artist { get; set; }

        [MaxLength(100)]
        public string? Field { get; set; }

        [Range(1, 999)]
        public int? Number { get; set; }

        [Required]
        [MaxLength(400)]
        public string Folder { get; set; }

        // Navigation properties
        public virtual Disc? Disc { get; set; }

        // Computed properties
        [NotMapped]
        public string FullTitle => $"{Number}. {Title ?? Name ?? "Untitled Track"}";

        [NotMapped]
        public string TechnicalInfo =>
            $"{BitRate}kbps {AudioSampleRate}Hz {(AudioChannels == 2 ? "Stereo" : "Mono")}";

        public override string ToString()
        {
            string number = Number.HasValue ? (Number < 10 ? $"0{Number}" : $"{Number}") : "00"; 

            return $"{number} - {Title ?? Name ?? "Untitled Track"} ({Duration?.ToString(@"mm\:ss") ?? "N/A"})";
        }
    }
}
