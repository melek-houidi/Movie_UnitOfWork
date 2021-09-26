using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieApp.data.Models
{
    public partial class MovieDBContext : DbContext
    {
        public object Movie;

        public MovieDBContext()
        {
        }

        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DirectorId> DirectorIds { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MovieId> MovieIds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CH4GDL9\\SQLEXPRESS;Initial Catalog=MovieDB; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DirectorId>(entity =>
            {
                entity.HasKey(e => e.DirectorId1);

                entity.ToTable("DirectorID");

                entity.Property(e => e.DirectorId1)
                    .ValueGeneratedNever()
                    .HasColumnName("DirectorID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("GenreID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieId>(entity =>
            {
                entity.HasKey(e => e.MovieId1);

                entity.ToTable("MovieID");

                entity.Property(e => e.MovieId1)
                    .ValueGeneratedNever()
                    .HasColumnName("MovieID");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
