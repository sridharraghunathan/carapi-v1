using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.CarModels
{
    public partial class CarStoresDBContext : DbContext
    {
        public CarStoresDBContext()
        {
        }

        public CarStoresDBContext(DbContextOptions<CarStoresDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarFeature> CarFeature { get; set; }
        public virtual DbSet<CarHomeCarousel> CarHomeCarousel { get; set; }
        public virtual DbSet<CarPhoto> CarPhoto { get; set; }
        public virtual DbSet<CarShop> CarShop { get; set; }
        public virtual DbSet<CompanyExecutiveTeam> CompanyExecutiveTeam { get; set; }
        public virtual DbSet<CompanyServices> CompanyServices { get; set; }
        public virtual DbSet<CompanyWebsiteInfo> CompanyWebsiteInfo { get; set; }
        public virtual DbSet<FuelType> FuelType { get; set; }
        public virtual DbSet<UserGeneralEnquiryMessage> UserGeneralEnquiryMessage { get; set; }
        public virtual DbSet<UserSpecificCarEnquiryMessage> UserSpecificCarEnquiryMessage { get; set; }
        public virtual DbSet<VehicleFeatures> VehicleFeatures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.HasIndex(e => e.CarId)
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SaleType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasIndex(e => e.CarId)
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.BodyStyle)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CarDescription).IsRequired();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Engine)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.InteriorColor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Miles)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Transmission)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.VinNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarFeature>(entity =>
            {

                entity.HasKey(e => new { e.CarId, e.AvailableFeature });

                entity.HasIndex(e => new { e.CarId, e.AvailableFeature })
                    .HasName("IX_CarFeature_CarTS")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.AvailableFeature)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CarHomeCarousel>(entity =>
            {
                entity.HasKey(e => e.CarCaption);

                entity.Property(e => e.CarCaption)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CarImage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<CarPhoto>(entity =>
            {
                entity.HasKey(e => new { e.CarId, e.PhotoId });

                entity.HasIndex(e => new { e.CarId, e.PhotoId })
                    .HasName("IX_CarPhoto_CarTS")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PictureUrl)
                    .IsRequired()
                    .HasColumnName("PictureUrl")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhotoId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CarShop>(entity =>
            {
                entity.HasKey(e => e.ShopEmailAddress);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShopAddress)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ShopEmailAddress)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShopPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyExecutiveTeam>(entity =>
            {
                entity.HasKey(e => new { e.FirstName, e.LastName, e.Designation });

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyServices>(entity =>
            {
                entity.HasKey(e => e.ServiceTagLine);

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceIcon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceSupport)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceTagLine)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyWebsiteInfo>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Timings)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasKey(e => e.FuelType1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FuelType1)
                    .IsRequired()
                    .HasColumnName("FuelType")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserGeneralEnquiryMessage>(entity =>
            {
                entity.HasKey(e => e.EnquiryId);

                entity.HasIndex(e => e.EnquiryId)
                    .HasName("IX_UserGeneralEnquiryMessage_ENQID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSpecificCarEnquiryMessage>(entity =>
            {
                entity.HasKey(e => new { e.CarId, e.EmailAddress });

                entity.HasIndex(e => new { e.CarId, e.EmailAddress })
                    .HasName("IX_UserGeneralEnquiryMessage_ENQID")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EnquiryAbout)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleFeatures>(entity =>
            {
                entity.HasKey(e => e.VehicleFeature);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleFeature)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
