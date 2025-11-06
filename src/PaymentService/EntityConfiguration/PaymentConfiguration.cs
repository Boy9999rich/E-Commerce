using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentService.Entities;

namespace PaymentService.EntityConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties konfiguratsiyasi
            builder.Property(p => p.OrderId)
                   .IsRequired();

            builder.Property(p => p.UserId)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.PaymentMethod)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasMaxLength(20)
                   .HasDefaultValue("Pending")
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()") // SQL Server uchun
                   .IsRequired();

            // Indexlar (ixtiyoriy)
            builder.HasIndex(p => p.OrderId);
            builder.HasIndex(p => p.UserId);
        }
    }
}
