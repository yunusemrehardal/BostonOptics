using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? PictureUri { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }


        public Category Category { get; set; } = null!;

        public Brand Brand { get; set; } = null!;
    }
}
