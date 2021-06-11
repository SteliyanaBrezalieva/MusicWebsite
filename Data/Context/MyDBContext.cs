using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MyDBContext : DbContext
    {
        //new model 

        public DbSet<Song> Songs { get; set; }
        public DbSet<SongStyle> Styles { get; set; }

        public DbSet<Singer> Singers { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
