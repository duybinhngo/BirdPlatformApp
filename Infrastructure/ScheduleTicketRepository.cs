using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ScheduleTicketRepository : RepositoryBase<ScheduleTicket>,IScheduleTicketRepository
    {
    }
}
