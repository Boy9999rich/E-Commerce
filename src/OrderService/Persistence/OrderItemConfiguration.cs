using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Entities;

namespace OrderService.Persistence
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(p => p.OrderItemId);

            builder.Property(p => p.ProductId)
                   .IsRequired();

            builder.Property(p => p.Quantity)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.UnitPrice)
                   .HasMaxLength(500);

            builder.Property(p => p.OrderId)
                   .IsRequired();
        }
    }
}
