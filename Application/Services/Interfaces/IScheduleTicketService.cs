using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IScheduleTicketService
    {
        Task<bool> CreateScheduleTicket(ScheduleTicket scheduleTicket);
    }
}
