using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCinema.Models
{
    public class CinemaAPIContext : DbContext
    {
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmStudioSeance> FilmStudioSeances { get; set; }

        public CinemaAPIContext(DbContextOptions<CinemaAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
