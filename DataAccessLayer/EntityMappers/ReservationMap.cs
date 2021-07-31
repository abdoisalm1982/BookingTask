using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMappers
{
    public class ReservationMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(x => x.ReservedId)
                   .HasName("pk_Reserved");
            builder.Property(x => x.ReservedId)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("ReservedId")
                   .HasColumnType("INT");

            builder.Property(x => x.ReservedBy)
                  .HasColumnName("ReservedBy")
                  .HasColumnType("NVARCHAR(100)")
                  .IsRequired();
            builder.Property(x => x.CustomerName)
                  .HasColumnName("CustomerName")
                  .HasColumnType("NVARCHAR(100)")
                  .IsRequired();
            builder.Property(x => x.TripId)
                 .HasColumnName("TripId")
                 .HasColumnType("INT")
                 .IsRequired();
            builder.Property(x => x.ReservationDate)
               .HasColumnName("ReservationDate")
               .HasColumnType("DATETIME");
            builder.Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("NVARCHAR(300)")
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
