using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub;
using MusicHub.Data;
using MusicHub.Data.Models;

namespace E02.AllAlbumsProducedByGivenProducer
{
    public class Exercise
    {
        public Exercise(ApplicationDbContext context)
        {
            this.Run(context);
        }

        public void Run(ApplicationDbContext context)
        {

        }
    }
}
