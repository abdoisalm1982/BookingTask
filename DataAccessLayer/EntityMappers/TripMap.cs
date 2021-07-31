using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMappers
{
    public class TripMap : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trips");
            builder.HasKey(x => x.TripId)
                   .HasName("pk_Trip");
            builder.Property(x => x.TripId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("TripId")
                   .HasColumnType("INT");

            builder.Property(x => x.Name)
                  .HasColumnName("Name")
                  .HasColumnType("NVARCHAR(100)")
                  .IsRequired();
            builder.Property(x => x.CityName)
                  .HasColumnName("CityName")
                  .HasColumnType("NVARCHAR(100)")
                  .IsRequired();
            builder.Property(x => x.ImageUrl)
                 .HasColumnName("ImageUrl")
                 .HasColumnType("NVARCHAR(100)")
                 .IsRequired();

            builder.Property(x => x.CreatedDate)
                 .HasColumnName("CreatedDate")
                 .HasColumnType("DATETIME");
            builder.Property(x => x.ModifiedDate)
                 .HasColumnName("ModifiedDate")
                 .HasColumnType("DATETIME");
         

        }
    }
}
