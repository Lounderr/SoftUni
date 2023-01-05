using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
        { 
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<SongPerformer> SongPerformers { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Database=MusicHub;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
