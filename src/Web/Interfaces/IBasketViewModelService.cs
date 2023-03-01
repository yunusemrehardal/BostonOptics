using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModelAsync();

        Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity);

        Task EmptyBasketAsync();

        Task DeleteBasketItemAsync(int productId);

        Task UpdateBasketAsync(Dictionary<int, int> quantities);

        Task TransferBasketIfNecessary();

        Task CheckoutAsync(string street, string city, string? state, string country, string zipCode);
    }
}
