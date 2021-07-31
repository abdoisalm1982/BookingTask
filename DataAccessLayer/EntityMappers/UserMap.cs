using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.UserId)
                   .HasName("pk_user");
            //builder.Property(x => x.UserId)
            //       .ValueGeneratedOnAdd()
            //       .HasColumnName("UserId")
            //       .HasColumnType("INT");

            builder.Property(x => x.Password)
                  .HasColumnName("password")
                  .HasColumnType("NVARCHAR(100)")
                  .IsRequired();
            builder.Property(x => x.Email)
                  .HasColumnName("email")
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
