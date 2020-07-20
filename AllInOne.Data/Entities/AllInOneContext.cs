using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AllInOne.Data.Entities
{
    public partial class AllInOneContext : DbContext
    {
        public AllInOneContext()
        {
        }

        public AllInOneContext(DbContextOptions<AllInOneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserPersonelInfo> UserPersonelInfo { get; set; }
        public virtual DbSet<UserPriceDetail> UserPriceDetail { get; set; }
        public virtual DbSet<WeightDetail> WeightDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=AllInOne;Trusted_Connection=Yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastAccessedTs).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfo_Role");
            });

            modelBuilder.Entity<UserPersonelInfo>(entity =>
            {
                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirthTs).HasColumnType("datetime");

                entity.Property(e => e.LandLine).HasMaxLength(10);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.HasOne(d => d.UserInfo)
                    .WithMany(p => p.UserPersonelInfo)
                    .HasForeignKey(d => d.UserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPersonelInfo_UserInfo");
            });

            modelBuilder.Entity<UserPriceDetail>(entity =>
            {
                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.CreditAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DebitAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPriceDetail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPriceDetail_UserInfo");
            });

            modelBuilder.Entity<WeightDetail>(entity =>
            {
                entity.Property(e => e.CreatedByTs).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ModifiedByTs).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Weight).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.WeightDetail)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeightDetail_Price");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WeightDetail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeightDetail_UserInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
