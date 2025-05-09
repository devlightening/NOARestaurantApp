using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("Restaurants").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Name).HasColumnName("Name");
        builder.Property(r => r.Address).HasColumnName("Address");
        builder.Property(r => r.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(r => r.Email).HasColumnName("Email");
        builder.Property(r => r.OpeningHours).HasColumnName("OpeningHours");
        builder.Property(r => r.ClosingHours).HasColumnName("ClosingHours");
        builder.Property(r => r.Location).HasColumnName("Location");
        builder.Property(r => r.Photo).HasColumnName("Photo");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}