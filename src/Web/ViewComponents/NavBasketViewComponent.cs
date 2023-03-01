using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.ViewComponents
{
    public class NavBasketViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public NavBasketViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = await _basketViewModelService.GetBasketViewModelAsync();
            return View(vm);
        }
    }
}
