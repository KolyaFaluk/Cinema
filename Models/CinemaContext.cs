using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class CinemaContext:DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
       
    }
}