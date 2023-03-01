using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Ardalis.Specification;
using Moq;

namespace UnitTests.ApplicationCore.OrderServiceTests
{
    public class CreateOrder
    {
        private readonly string _demoBuyerId = "This-Is-A-Random-Buyer-Id";

        private readonly Address _demoAddress = new Address()
        {
            City = "London",
            Country = "UK",
            Street = "221B Baker Street",
            ZipCode = "NW1 6XE"
        };

        [Fact]
        public async Task ShouldThrowEmptyBasketExceptionIfBasketIsEmpty()
        {
            var mockBasketRepo = new Mock<IRepository<Basket>>();
            var mockBasketItemRepo = new Mock<IRepository<BasketItem>>();
            var mockProductRepo = new Mock<IRepository<Product>>();
            var mockOrderRepo = new Mock<IRepository<Order>>();

            Basket emptyBasket = new Basket()
            {
                Id = 33, // random integer
                BuyerId = _demoBuyerId,
                Items = new List<BasketItem>()
            };

            mockBasketRepo.Setup(x => x.FirstOrDefaultAsync(It.IsAny<Specification<Basket>>()))
                .ReturnsAsync(emptyBasket);

            var basketRepo = mockBasketRepo.Object;
            var basketItemRepo = mockBasketItemRepo.Object;
            var productRepo = mockProductRepo.Object;
            var orderRepo = mockOrderRepo.Object;

            IBasketService basketService = new BasketService(basketRepo, basketItemRepo, productRepo);
            IOrderService orderService = new OrderService(basketService, orderRepo);

            // I assert that it should throw a "EmptyBasketException" 
            // while creating an order with an empty basket.
            await Assert.ThrowsAsync<EmptyBasketException>(async () =>
                await orderService.CreateOrderAsync(_demoBuyerId, _demoAddress));
        }
    }
}
