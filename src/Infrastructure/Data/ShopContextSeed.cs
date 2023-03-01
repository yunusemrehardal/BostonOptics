using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class ShopContextSeed
    {
        public static async Task SeedAsync(ShopContext db)
        {
            await db.Database.MigrateAsync();

            if (await db.Categories.AnyAsync() || await db.Brands.AnyAsync() || await db.Products.AnyAsync())
                return;

            var c1 = new Category() { Name = "Men" };
            var c2 = new Category() { Name = "Women" };
            var c3 = new Category() { Name = "Unisex" };

            var b1 = new Brand() { Name = "Ray-Ban" };
            var b2 = new Brand() { Name = "Gucci" };
            var b3 = new Brand() { Name = "Prada" };
            var b4 = new Brand() { Name = "Tom Ford" };

            db.AddRange(
                new Product() { Category = c2, Brand = b1, Price = 130.40m, PictureUri = "01.png", Name = "Ray-Ban Aviator Classic" },
                new Product() { Category = c2, Brand = b1, Price = 158.40m, PictureUri = "02.png", Name = "Ray-Ban Jackie Ohh II" },
                new Product() { Category = c2, Brand = b1, Price = 198.40m, PictureUri = "03.png", Name = "Ray-Ban Bill" },
                new Product() { Category = c2, Brand = b1, Price = 130.40m, PictureUri = "04.png", Name = "Ray-Ban Hexagonal Flat Lenses" },
                new Product() { Category = c1, Brand = b1, Price = 093.40m, PictureUri = "05.png", Name = "Ray-Ban Andrea" },
                new Product() { Category = c1, Brand = b1, Price = 142.40m, PictureUri = "06.png", Name = "Ray-Ban RB3611" },
                new Product() { Category = c3, Brand = b2, Price = 377.50m, PictureUri = "07.png", Name = "Gucci GG0291S" },
                new Product() { Category = c1, Brand = b2, Price = 324.00m, PictureUri = "08.png", Name = "Gucci GG0463S" },
                new Product() { Category = c2, Brand = b2, Price = 452.00m, PictureUri = "09.png", Name = "Gucci GG1111S" },
                new Product() { Category = c2, Brand = b3, Price = 364.00m, PictureUri = "10.png", Name = "Prada PR 19ZS" },
                new Product() { Category = c3, Brand = b3, Price = 346.00m, PictureUri = "11.png", Name = "Prada Hot" },
                new Product() { Category = c1, Brand = b4, Price = 540.00m, PictureUri = "12.png", Name = "Tom Ford FT1003" }
                );
            await db.SaveChangesAsync();
        }
    }
}
