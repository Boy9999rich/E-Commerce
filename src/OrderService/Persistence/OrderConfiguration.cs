using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Entities;

namespace OrderService.Persistence
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(p => p.OrderId);

            builder.Property(p => p.OrderDate)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.OrderDate)
                   .HasMaxLength(500);

            builder.Property(p => p.TotalAmount)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired();

            builder.Property(p => p.UserId)
                   .IsRequired();

            builder.HasMany(o => o.OrderItems)       
                   .WithOne(oi => oi.Order)         
                   .HasForeignKey(oi => oi.OrderId) 
                   .OnDelete(DeleteBehavior.Cascade); 
        }

    }
}
