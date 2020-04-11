using BSKv5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSKv5.Data
{
    public class BSKDbContext:DbContext
    {
        public BSKDbContext(DbContextOptions<BSKDbContext> options)
           : base(options) { }

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<school> Schools { get; set; }
        public DbSet<Officer> Officers { get; set; }
    }
    

}
