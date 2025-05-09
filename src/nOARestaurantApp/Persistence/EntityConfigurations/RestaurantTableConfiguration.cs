using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RestaurantTableConfiguration : IEntityTypeConfiguration<RestaurantTable>
{
    public void Configure(EntityTypeBuilder<RestaurantTable> builder)
    {
        builder.ToTable("RestaurantTables").HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.RestaurantId).HasColumnName("RestaurantId");
        builder.Property(rt => rt.TableNumber).HasColumnName("TableNumber");
        builder.Property(rt => rt.Capacity).HasColumnName("Capacity");
        builder.Property(rt => rt.Location).HasColumnName("Location");
        builder.Property(rt => rt.IsAvailable).HasColumnName("IsAvailable");
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rt => !rt.DeletedDate.HasValue);
    }
}