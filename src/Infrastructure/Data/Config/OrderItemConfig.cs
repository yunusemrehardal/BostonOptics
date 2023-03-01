using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ProductName)
                .HasMaxLength(100);

            builder.Property(x => x.UnitPrice)
                .HasPrecision(18, 2);
        }
    }
}
