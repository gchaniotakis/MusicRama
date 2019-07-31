using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MusicRama.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base ("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }



    }
}