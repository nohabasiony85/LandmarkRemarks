﻿using LandmarkRemark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LandmarkRemark.API.Repository
{
    public partial class LandmarkRemarkDataContext : DbContext
    {
        public LandmarkRemarkDataContext(DbContextOptions<LandmarkRemarkDataContext> options)
            : base(options)
        {
        }

        public LandmarkRemarkDataContext()
        {
            throw new System.NotImplementedException();
        }

        public virtual DbSet<RemarkModel> Remarks { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=localhost,1433\\Catalog=LandmarkRemark;Database=LandmarkRemark;User=sa;Password=reallyStrongPwd123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<RemarkModel>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRemarks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Remarks");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}