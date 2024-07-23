using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entity;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
        }

        public DbSet<Genres> Genres { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Trailers> Trailers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Casts> Casts { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenres>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCasts>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<Reviews>()
                .HasKey(r => new { r.MovieId, r.UserId });

            modelBuilder.Entity<Purchases>()
                .HasKey(p => new { p.MovieId, p.UserId });

            modelBuilder.Entity<Favorites>()
                .HasKey(f => new { f.MovieId, f.UserId });

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
