using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDb.Models.Dtos
{
    public class ArtistRecordReviewDto
    {
        public int ArtistId { get; set; }
        public int RecordId { get; set; }
        public string ArtistName { get; set; }
        public string RecordName { get; set; }
        public int Recorded { get; set; }
    }
}
