using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    [PrimaryKey(nameof(SongId), nameof(PerformerId))]
    public class SongPerformer
    {
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int PerformerId { get; set; }
        public virtual Performer Performer { get; set; }

    }
}
