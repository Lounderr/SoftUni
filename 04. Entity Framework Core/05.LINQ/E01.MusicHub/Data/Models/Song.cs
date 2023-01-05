using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data.Models.Enumerations;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedOn { get; set; }
        public Genre Genre { get; set; }
        public int AlbumId { get; set; } // TODO Could be optional
        public virtual Album Album { get; set; } // TODO Could be optional
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<SongPerformer> SongPerformers { get; set; } // TODO Could be optional
    }
}