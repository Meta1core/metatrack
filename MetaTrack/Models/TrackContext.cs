using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MetaTrack.Models
{
    public class TrackContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackInfo> TracksInfo { get; set; }
        public TrackContext(DbContextOptions<TrackContext> options)
        : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
