using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await orderRepository.CreateAsync(order, true);
        }
    }
}
