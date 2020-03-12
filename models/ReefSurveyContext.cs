using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReefSurvey
{
    public partial class ReefSurveyContext : DbContext
    {
        public ReefSurveyContext()
        {
        }

        public ReefSurveyContext(DbContextOptions<ReefSurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batches> Batches { get; set; }
        public virtual DbSet<Families> Families { get; set; }
        public virtual DbSet<Genera> Genera { get; set; }
        public virtual DbSet<Managements> Managements { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Structures> Structures { get; set; }
        public virtual DbSet<StudyAreas> StudyAreas { get; set; }
        public virtual DbSet<SubRegions> SubRegions { get; set; }
        public virtual DbSet<Surveys> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4JBTRU1;Initial Catalog=ReefSurvey;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batches>(entity =>
            {
                entity.HasKey(e => e.BatchId);

                entity.Property(e => e.BatchId)
                    .HasMaxLength(19)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Families>(entity =>
            {
                entity.HasKey(e => e.FamilyId);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Genera>(entity =>
            {
                entity.HasKey(e => e.GenusId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Genera)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Families_Genera");
            });

            modelBuilder.Entity<Managements>(entity =>
            {
                entity.HasKey(e => e.ManagementId);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.CommonName).IsUnicode(false);

                entity.Property(e => e.LatinName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Trophic)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Genus)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.GenusId)
                    .HasConstraintName("FK_Genera_Species");
            });

            modelBuilder.Entity<Structures>(entity =>
            {
                entity.HasKey(e => e.StructureId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudyAreas>(entity =>
            {
                entity.HasKey(e => e.StudyAreaId);

                entity.ToTable("Study Areas");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.SubRegion)
                    .WithMany(p => p.StudyAreas)
                    .HasForeignKey(d => d.SubRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubRegions_StudyAreas");
            });

            modelBuilder.Entity<SubRegions>(entity =>
            {
                entity.HasKey(e => e.SubRegionId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.SubRegions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_SubRegions");
            });

            modelBuilder.Entity<Surveys>(entity =>
            {
                entity.HasKey(e => e.SurveyId);

                entity.Property(e => e.BatchId)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.BatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batches_Surveys");

                entity.HasOne(d => d.Management)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.ManagementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Managements_Surveys");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Species_Surveys");

                entity.HasOne(d => d.Structure)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.StructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Structures_Surveys");

                entity.HasOne(d => d.StudyArea)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.StudyAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudyAreas_Surveys");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
