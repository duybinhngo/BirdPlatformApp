using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> AcceptOrderAsync(int id, int state = 2)
        {
            var model = await orderRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            model.Status = state;
            return await orderRepository.UpdateAsync(model);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await orderRepository.CreateAsync(order, true);
        }

        public async Task<List<Order>> GetOrderAsync(string? search)
        {
            return await orderRepository.GetAll()
                .Include("Customer")
                .Include("ScheduleTickets.BirdService.Category")
                .Include("ScheduleTickets.BirdService.Provider")
                .Include("ScheduleTickets.BirdService.Feedbacks")
                .Where(x => x.Customer.Username.Equals(search) 
                            || x.Customer.Email.Contains(search) 
                            || x.ScheduleTickets.FirstOrDefault().BirdService.Provider.Email.Contains(search))
                .OrderByDescending(x => x.OrderDate)
                .ToListAsync();
        }
    }
}
