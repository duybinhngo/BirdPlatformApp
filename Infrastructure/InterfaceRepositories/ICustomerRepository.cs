using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Task<Customer> Authenticated(string email, string username, string avatar_url);
    }
}
