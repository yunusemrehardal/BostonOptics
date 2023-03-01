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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // IsRequired() yazmasak da zorunlu olurdu (çünkü alan nullable değil)
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            // non-nullable olduğu için IsRequired gereksiz
            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            // nullable olduğu için yazmasanız da aynı olurdu
            builder.Property(x => x.PictureUri)
                .IsRequired(false);

            // aşağıdakiler de olmasa olur, çünkü Product sınıfında
            // ef geleneğine uygun yazarak ilişkileri belirlemiştik.
            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey(x => x.BrandId);
        }
    }
}
