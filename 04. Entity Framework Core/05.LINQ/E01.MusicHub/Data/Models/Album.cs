using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [NotMapped] // Prop always returns 0, Songs is 0
        public decimal Price => Songs.Select(s => s.Price).Sum(); // calculated property (the sum of all song prices in the album);; Will it exec this code each time it is called or only once?
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
