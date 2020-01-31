using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieApp.Models
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieTable> MovieTable { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieTable>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }*/
    }
}
