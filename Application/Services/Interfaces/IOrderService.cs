using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
