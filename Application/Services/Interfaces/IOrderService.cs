using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrderAsync(string? search);
        Task<bool> AcceptOrderAsync(int id, int state);
    }
}
