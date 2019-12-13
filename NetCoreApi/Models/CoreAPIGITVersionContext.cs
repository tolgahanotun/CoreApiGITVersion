using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApiGITVersion.Models
{
    public partial class CoreAPIGITVersionContext : DbContext
    {
        public CoreAPIGITVersionContext()
        {
        }

        public CoreAPIGITVersionContext(DbContextOptions<CoreAPIGITVersionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TArticle> TArticle { get; set; }
        public virtual DbSet<TComments> TComments { get; set; }
        public virtual DbSet<TRole> TRole { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }
        public virtual DbSet<TUserRole> TUserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=CoreAPIGITVersion;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TArticle>(entity =>
            {
                entity.ToTable("tArticle");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("NonClusteredIndex-20191210-102741");

                entity.HasIndex(e => new { e.CreatedDate, e.Deleted })
                    .HasName("NonClusteredIndex-20191210-102641");

                entity.Property(e => e.TArticleId).HasColumnName("tArticleId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Header).HasMaxLength(100);
            });

            modelBuilder.Entity<TComments>(entity =>
            {
                entity.HasKey(e => e.TCommentId)
                    .HasName("PK__tComment__7B43352003317E3D");

                entity.ToTable("tComments");

                entity.HasIndex(e => e.TArticleId)
                    .HasName("NonClusteredIndex-20191210-103115");

                entity.Property(e => e.TCommentId).HasColumnName("tCommentId");

                entity.Property(e => e.CommentText).HasMaxLength(1000);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TArticleId).HasColumnName("tArticleId");

                entity.HasOne(d => d.TArticle)
                    .WithMany(p => p.TComments)
                    .HasForeignKey(d => d.TArticleId)
                    .HasConstraintName("FK_tComments_tArticle");
            });

            modelBuilder.Entity<TRole>(entity =>
            {
                entity.ToTable("tRole");

                entity.Property(e => e.TRoleId).HasColumnName("tRoleId");

                entity.Property(e => e.RoleName).HasMaxLength(150);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.ToTable("tUser");

                entity.HasIndex(e => new { e.UserName, e.Password, e.Enabled })
                    .HasName("NonClusteredIndex-20191210-103430");

                entity.Property(e => e.TUserId).HasColumnName("tUserId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RefreshToken).HasMaxLength(600);

                entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

                entity.Property(e => e.Surname).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(150);
            });

            modelBuilder.Entity<TUserRole>(entity =>
            {
                entity.HasKey(e => new { e.TUserId, e.TRoleId });

                entity.ToTable("tUserRole");

                entity.Property(e => e.TUserId).HasColumnName("tUserId");

                entity.Property(e => e.TRoleId).HasColumnName("tRoleId");

                entity.HasOne(d => d.TRole)
                    .WithMany(p => p.TUserRole)
                    .HasForeignKey(d => d.TRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tUserRole_tRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
