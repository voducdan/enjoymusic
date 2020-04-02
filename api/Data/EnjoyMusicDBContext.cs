using enjoymusic_project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enjoymusic_project.Data
{
    public class EnjoyMusicDBContext : DbContext
    {
        public EnjoyMusicDBContext(DbContextOptions<EnjoyMusicDBContext> options) : base(options)
        {

        }
        public DbSet<Song> Song { get; set; }
    }
}
