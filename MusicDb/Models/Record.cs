﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        [Required]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(80)]
        public string SubTitle { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Field { get; set; }

        public int Recorded { get; set; }

        [Range(1, 100)]
        public int Discs { get; set; }

        [MaxLength(400)]
        public string? CoverName { get; set; }

        [Column(TypeName = "text")]
        public string? Review { get; set; }

        [Required]
        [MaxLength(400)]
        public string? Folder { get; set; }

        [MaxLength(50)]
        public string? Length { get; set; }

        // Navigation property
        [ForeignKey(nameof(ArtistId))]
        public virtual Artist? Artist { get; set; }

        [InverseProperty(nameof(Disc.Record))]
        public virtual ICollection<Disc> DiscCollection { get; set; } = new HashSet<Disc>();

        [NotMapped]
        public IEnumerable<Track>? AllTracks => DiscCollection?.SelectMany(d => d.Tracks);

        public override string ToString()
        {
            return $"Record ID: {RecordId}, Title: {Name}, Year: {Recorded}, Discs: {Discs}, Length: {Length}";
        }
    }
}
