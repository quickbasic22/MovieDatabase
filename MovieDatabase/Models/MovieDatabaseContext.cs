using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieDatabase.Models
{
    public partial class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext()
        {
        }

        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieDetail> MovieDetails { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Computer1;Initial Catalog=MovieDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorsId)
                    .HasName("PK_dbo.Actors");

                entity.HasIndex(e => e.MovieId, "IX_MovieId");

                entity.Property(e => e.Actor1).HasColumnName("Actor");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_dbo.Actors_dbo.Movies_MovieId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<MovieDetail>(entity =>
            {
                entity.HasKey(e => e.MovieDetailsId)
                    .HasName("PK_dbo.MovieDetails");

                entity.HasIndex(e => e.MovieId, "IX_MovieId");

                entity.Property(e => e.WatchedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieDetails)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_dbo.MovieDetails_dbo.Movies_MovieId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
