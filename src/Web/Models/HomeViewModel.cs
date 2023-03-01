using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new();

        public List<SelectListItem> Categories { get; set; } = new();

        public List<SelectListItem> Brands { get; set; } = new();

        public int? CategoryId { get; set; }

        public int? BrandId { get; set; }

        public PaginationInfoViewModel PaginationInfo { get; set; } = null!;
    }
}
