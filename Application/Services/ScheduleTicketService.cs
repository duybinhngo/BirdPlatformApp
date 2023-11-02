using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;

namespace Application.Services
{
    public class ScheduleTicketService : IScheduleTicketService
    {
        private readonly IScheduleTicketRepository scheduleTicketRepository;
        public ScheduleTicketService(IScheduleTicketRepository scheduleTicketRepository)
        {
            this.scheduleTicketRepository = scheduleTicketRepository;
        }
        public async Task<bool> CreateScheduleTicket(ScheduleTicket scheduleTicket)
        {
            return await scheduleTicketRepository.CreateAsync(scheduleTicket);
        }
    }
}
