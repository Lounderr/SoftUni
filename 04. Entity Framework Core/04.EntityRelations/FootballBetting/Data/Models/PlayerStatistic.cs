using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02.FootballBetting.Data.Models
{
    [PrimaryKey(nameof(GameId), nameof(PlayerId))]
    public class PlayerStatistic
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
